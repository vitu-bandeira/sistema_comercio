// Arquivo: DALVendas.cs
using sistema_comercio.sistema_comercio;
using System;
using System.Collections.Generic;
using System.Data; // Adicione este using
using System.Data.SQLite;
using System.Text; // Adicione este using

namespace sistema_comercio
{
    public class DALVendas
    {
        // Pega o mesmo caminho de banco de dados das outras classes DAL
        private static string path = DALProdutos.path;

        private static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();
            return connection;
        }

        // 1. MÉTODO PARA CRIAR AS NOVAS TABELAS
        public static void CriarTabelasVendas()
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    // Tabela Principal de Vendas (Recibo)
                    cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Vendas (
                        IdVenda INTEGER PRIMARY KEY AUTOINCREMENT,
                        DataVenda DATETIME NOT NULL,
                        ValorTotal REAL NOT NULL,
                        IdCliente INTEGER,
                        FOREIGN KEY (IdCliente) REFERENCES Clientes_dtb(id)
                    )";
                    cmd.ExecuteNonQuery();

                    // Tabela dos Itens da Venda
                    cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS ItensVenda (
                        IdItemVenda INTEGER PRIMARY KEY AUTOINCREMENT,
                        IdVenda INTEGER NOT NULL,
                        IdProduto INTEGER NOT NULL,
                        NomeProduto TEXT,
                        Quantidade INTEGER NOT NULL,
                        PrecoUnitario REAL NOT NULL,
                        FOREIGN KEY (IdVenda) REFERENCES Vendas(IdVenda),
                        FOREIGN KEY (IdProduto) REFERENCES Produtos_dtb(id)
                    )";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar tabelas de vendas", ex);
            }
        }

        // 2. MÉTODO PARA REGISTRAR A VENDA
        public static void RegistrarVenda(Venda venda, List<ItemVenda> itens)
        {
            using (var conn = CreateConnection())
            using (var transaction = conn.BeginTransaction()) // Inicia uma Transação!
            {
                try
                {
                    // --- PASSO A: INSERE A VENDA PRINCIPAL ---
                    string sqlVenda = @"
                        INSERT INTO Vendas (DataVenda, ValorTotal, IdCliente)
                        VALUES (@DataVenda, @ValorTotal, @IdCliente);
                        SELECT last_insert_rowid();"; // Pega o ID que acabou de ser criado

                    long idVenda;
                    using (var cmdVenda = new SQLiteCommand(sqlVenda, conn))
                    {
                        cmdVenda.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                        cmdVenda.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                        cmdVenda.Parameters.AddWithValue("@IdCliente", (object)venda.IdCliente ?? DBNull.Value);

                        idVenda = (long)cmdVenda.ExecuteScalar();
                    }

                    // --- PASSO B: INSERE OS ITENS DA VENDA ---
                    string sqlItem = @"
                        INSERT INTO ItensVenda (IdVenda, IdProduto, NomeProduto, Quantidade, PrecoUnitario)
                        VALUES (@IdVenda, @IdProduto, @NomeProduto, @Quantidade, @PrecoUnitario)";

                    foreach (var item in itens)
                    {
                        using (var cmdItem = new SQLiteCommand(sqlItem, conn))
                        {
                            cmdItem.Parameters.AddWithValue("@IdVenda", idVenda);
                            cmdItem.Parameters.AddWithValue("@IdProduto", item.ProdutoId);
                            cmdItem.Parameters.AddWithValue("@NomeProduto", item.Nome);
                            cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
                            cmdItem.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao registrar venda: " + ex.Message, ex);
                }
            }
        }

        // 3. MÉTODO PARA BUSCAR VENDAS (Recibos)
        public static DataTable GetVendas(DateTime inicio, DateTime fim, string nomeCliente = "")
        {
            DateTime fimDoDia = fim.Date.AddDays(1).AddSeconds(-1);
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    var sql = new StringBuilder(@"
                        SELECT 
                            v.IdVenda, 
                            v.DataVenda, 
                            COALESCE(c.nome, 'À Vista') as Cliente, 
                            v.ValorTotal
                        FROM Vendas v
                        LEFT JOIN Clientes_dtb c ON v.IdCliente = c.id
                        WHERE v.DataVenda BETWEEN @inicio AND @fim
                    ");

                    if (!string.IsNullOrEmpty(nomeCliente))
                    {
                        sql.Append(" AND c.nome LIKE @nomeCliente");
                        cmd.Parameters.AddWithValue("@nomeCliente", $"%{nomeCliente}%");
                    }

                    sql.Append(" ORDER BY v.DataVenda DESC");

                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@inicio", inicio);
                    cmd.Parameters.AddWithValue("@fim", fimDoDia);

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar histórico de vendas", ex);
            }
        }

        // 4. MÉTODO PARA BUSCAR OS ITENS de uma Venda
        public static DataTable GetItensPorVenda(int idVenda)
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            NomeProduto, 
                            Quantidade, 
                            PrecoUnitario,
                            (Quantidade * PrecoUnitario) as TotalItem
                        FROM ItensVenda
                        WHERE IdVenda = @idVenda";

                    cmd.Parameters.AddWithValue("@idVenda", idVenda);

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar itens da venda", ex);
            }
        }
    }
}