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
            catch
            {
                throw;
            }
        }

        public static void CriarTabelaClientes()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Clientes_dtb (id INTEGER PRIMARY KEY AUTOINCREMENT,nome varchar(50),telefone varchar(50),endereco varchar(50),saldo decimal(10,2))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetClientes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes_dtb";
                    da = new SQLiteDataAdapter(cmd.CommandText, DBconnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCliente(string nome)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes_dtb where nome like '%" + nome + "%'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DBconnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddCliente(Cliente_dtb cliente)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Clientes_dtb(nome, telefone , endereco, saldo) values (@nome, @telefone , @endereco, @saldo)";
                    cmd.Parameters.AddWithValue("@id", cliente.id);
                    cmd.Parameters.AddWithValue("@nome", cliente.nome);
                    cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@saldo", cliente.saldo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateCliente(Cliente_dtb cliente)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Clientes_dtb SET nome=@nome, telefone=@telefone, endereco=@endereco, saldo=@saldo WHERE id=@id";

                    cmd.Parameters.AddWithValue("@nome", cliente.nome);
                    cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@saldo", cliente.saldo);
                    cmd.Parameters.AddWithValue("@id", cliente.id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;

            }

        }
        public static bool ClienteExiste(string nome)
        {
            using (var cmd = DBconnection().CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM Clientes_dtb WHERE nome = @nome";
                cmd.Parameters.AddWithValue("@nome", nome);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
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
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void AdicionarDebito(string nomeCliente, decimal valorDebito)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    // Soma o novo débito ao saldo existente
                    cmd.CommandText = @"
                UPDATE Clientes_dtb 
                SET saldo = saldo + @valorDebito 
                WHERE nome = @nomeCliente";

                    cmd.Parameters.AddWithValue("@valorDebito", valorDebito);
                    cmd.Parameters.AddWithValue("@nomeCliente", nomeCliente);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar saldo do cliente", ex);
            }
        }
        // Cole este método dentro da classe DALClientes
        public static void AjustarSaldoCliente(int clienteId, decimal valorAjuste)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    // A lógica é: saldo_novo = saldo_antigo + valor_ajuste
                    // Se valorAjuste for -100 (dívida), ele vai somar -100.
                    // Se valorAjuste for 100 (pagamento), ele vai somar 100.
                    cmd.CommandText = "UPDATE Clientes_dtb SET saldo = saldo + @valorAjuste WHERE id = @id";

                    cmd.Parameters.AddWithValue("@valorAjuste", valorAjuste);
                    cmd.Parameters.AddWithValue("@id", clienteId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ajustar saldo do cliente", ex);
            }
        }
    }
}

     
