using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_comercio
{
    public class DALClientes
    {
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";
        private static SQLiteConnection sqliteConnection;

        private static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();
            return connection;
        }

        private static SQLiteConnection DBconnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=" + path);
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    SQLiteConnection.CreateFile(path);
                }
            }
            catch { throw; }
        }

        // --- CORREÇÃO 1: Adicionar colunas novas na criação da tabela (para bancos novos) ---
        public static void CriarTabelaClientes()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Clientes_dtb (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        nome varchar(50),
                                        cpf varchar(50),
                                        telefone varchar(50),
                                        endereco varchar(50),
                                        saldo decimal(10,2),
                                        bloqueado INTEGER DEFAULT 0,
                                        limite decimal(10,2) DEFAULT 0)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // --- NOVO MÉTODO ESSENCIAL: Atualiza bancos antigos ---
        // Chame isso no Load do seu Form1 ou FormCliente para garantir que as colunas existam
        public static void AtualizarEstruturaTabela()
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    // Tenta criar a coluna 'bloqueado'. Se já existir, o try/catch ignora o erro.
                    try
                    {
                        cmd.CommandText = "ALTER TABLE Clientes_dtb ADD COLUMN bloqueado INTEGER DEFAULT 0";
                        cmd.ExecuteNonQuery();
                    }
                    catch { }

                    // Tenta criar a coluna 'limite'.
                    try
                    {
                        cmd.CommandText = "ALTER TABLE Clientes_dtb ADD COLUMN limite DECIMAL(10,2) DEFAULT 0";
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
            catch { }
        }

        public static void CriarTabelaHistorico()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Historico_dtb (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            id_cliente INTEGER,
                                            data DATETIME,
                                            valor DECIMAL(10,2),
                                            descricao VARCHAR(100),
                                            FOREIGN KEY(id_cliente) REFERENCES Clientes_dtb(id))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // --- BUSCAS E LEITURAS ---

        public static DataTable GetClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes_dtb";
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // --- CORREÇÃO 2: Busca Inteligente (Ignora maiúsculas e espaços) ---
        public static int? GetClienteIdPorNome(string nome)
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    // COLLATE NOCASE = Ignora se é maiúscula ou minúscula
                    // TRIM = Ignora espaços antes ou depois
                    cmd.CommandText = "SELECT id FROM Clientes_dtb WHERE TRIM(nome) = @nome COLLATE NOCASE";
                    cmd.Parameters.AddWithValue("@nome", nome.Trim());

                    object result = cmd.ExecuteScalar();
                    if (result != null) return Convert.ToInt32(result);
                }
                return null;
            }
            catch { return null; }
        }

        public static DataTable GetCliente(string nome)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes_dtb where nome like @nome";
                    cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static Cliente_dtb GetClientePorId(int id)
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes_dtb WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cliente_dtb cliente = new Cliente_dtb();
                            cliente.id = Convert.ToInt32(reader["id"]);
                            cliente.nome = reader["nome"].ToString();
                            cliente.cpf = reader["cpf"].ToString();
                            cliente.endereco = reader["endereco"].ToString();
                            cliente.telefone = reader["telefone"].ToString();
                            cliente.saldo = Convert.ToDecimal(reader["saldo"]);

                            // Lê Limite e Bloqueio com segurança (caso coluna não exista, usa padrão)
                            try { cliente.limite = Convert.ToDecimal(reader["limite"]); } catch { cliente.limite = 0; }
                            try { cliente.bloqueado = Convert.ToInt32(reader["bloqueado"]) == 1; } catch { cliente.bloqueado = false; }

                            return cliente;
                        }
                    }
                }
                return null;
            }
            catch { return null; }
        }

        public static bool ClienteExiste(string nome)
        {
            using (var cmd = DBconnection().CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM Clientes_dtb WHERE nome = @nome COLLATE NOCASE";
                cmd.Parameters.AddWithValue("@nome", nome.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // --- GRAVAÇÃO E ATUALIZAÇÃO ---

        public static void AddCliente(Cliente_dtb cliente)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Clientes_dtb(nome, cpf, telefone , endereco, saldo, bloqueado, limite) 
                                        VALUES (@nome, @cpf, @telefone , @endereco, @saldo, @bloqueado, @limite)";

                    cmd.Parameters.AddWithValue("@nome", cliente.nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.cpf ?? "");
                    cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@saldo", cliente.saldo);
                    cmd.Parameters.AddWithValue("@bloqueado", cliente.bloqueado ? 1 : 0);
                    cmd.Parameters.AddWithValue("@limite", cliente.limite);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // --- CORREÇÃO 3: SQL de Update corrigido (Faltava SET bloqueado e limite) ---
        public static void UpdateCliente(Cliente_dtb cliente)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    // Agora sim estamos salvando o bloqueio e o limite!
                    cmd.CommandText = @"UPDATE Clientes_dtb 
                                        SET nome=@nome, cpf=@cpf, telefone=@telefone, endereco=@endereco, 
                                            saldo=@saldo, bloqueado=@bloqueado, limite=@limite 
                                        WHERE id=@id";

                    cmd.Parameters.AddWithValue("@nome", cliente.nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.cpf ?? "");
                    cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@saldo", cliente.saldo);
                    cmd.Parameters.AddWithValue("@bloqueado", cliente.bloqueado ? 1 : 0);
                    cmd.Parameters.AddWithValue("@limite", cliente.limite);
                    cmd.Parameters.AddWithValue("@id", cliente.id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void DeleteCliente(int id)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Clientes_dtb WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // --- SALDOS E EXTRATOS ---

        public static void AdicionarDebito(string nomeCliente, decimal valorDebito)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    // Atualiza saldo pelo nome (ignorando maiúsculas)
                    cmd.CommandText = "UPDATE Clientes_dtb SET saldo = saldo - @valorDebito WHERE nome = @nomeCliente COLLATE NOCASE";
                    cmd.Parameters.AddWithValue("@valorDebito", valorDebito);
                    cmd.Parameters.AddWithValue("@nomeCliente", nomeCliente.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new Exception("Erro ao atualizar saldo", ex); }
        }

        public static void AjustarSaldoCliente(int clienteId, decimal valorAjuste)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Clientes_dtb SET saldo = saldo + @valorAjuste WHERE id = @id";
                    cmd.Parameters.AddWithValue("@valorAjuste", valorAjuste);
                    cmd.Parameters.AddWithValue("@id", clienteId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new Exception("Erro ao ajustar saldo", ex); }
        }

        public static void RegistrarMovimentacao(int idCliente, decimal valor, string descricao)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Historico_dtb (id_cliente, data, valor, descricao) VALUES (@id_cliente, @data, @valor, @descricao)";
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static DataTable GetHistoricoPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT data, descricao, valor FROM Historico_dtb WHERE id_cliente = @id_cliente ORDER BY data DESC";
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static decimal GetTotalSaldosDevedores()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(saldo) FROM Clientes_dtb WHERE saldo < 0";
                    var result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                }
            }
            catch { return 0; }
        }

        public static int GetTotalClientesDevedores()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(id) FROM Clientes_dtb WHERE saldo < 0";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { return 0; }
        }

        public static int GetTotalClientesCadastrados()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(id) FROM Clientes_dtb";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { return 0; }
        }
        public static DataTable GetTop5Devedores()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    // Ordena do menor saldo (mais negativo) para o maior, pegando os 5 primeiros
                    cmd.CommandText = "SELECT nome, saldo FROM Clientes_dtb WHERE saldo < 0 ORDER BY saldo ASC LIMIT 5";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}