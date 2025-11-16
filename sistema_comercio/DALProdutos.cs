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

    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.IO;

    namespace sistema_comercio
    {
        public class DALProdutos
        {
            public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";

            private static SQLiteConnection CreateConnection()
            {
                var connection = new SQLiteConnection("Data Source=" + path);
                connection.Open();
                return connection;
            }

            public static void CriarBancoSQLite()
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        SQLiteConnection.CreateFile(path);
                    }
                }
                catch
                {
                    throw;
                }
            }

            public static void CriarTabelaProdutos()
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Produtos_dtb (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            codigoBarras TEXT UNIQUE,
                            nome VARCHAR(50) NOT NULL,
                            preco REAL NOT NULL,
                            estoque INT NOT NULL,
                            validade TEXT  
                        )";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criar tabela de produtos", ex);
                }
            }

            public static DataTable GetProdutos()
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Produtos_dtb";
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
                    throw new Exception("Erro ao obter produtos", ex);
                }
            }

            public static DataTable GetProduto(string nome)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        
                        cmd.CommandText = "SELECT * FROM Produtos_dtb WHERE nome LIKE @nome";
                        cmd.Parameters.AddWithValue("@nome", $"%{nome}%");

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
                    throw new Exception("Erro ao buscar produto", ex);
                }
            }

            public static void AddProduto(Produto_dtb produto)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                INSERT INTO Produtos_dtb(nome, codigoBarras, preco, estoque, validade)
                VALUES (@nome, @codigoBarras, @preco, @estoque, @validade)";

                        cmd.Parameters.AddWithValue("@nome", produto.Nome);
                        cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras ?? (object)DBNull.Value); // Permite nulo
                        cmd.Parameters.AddWithValue("@preco", produto.Preco);
                        cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

                        // Tratamento especial para validade (permite nulo)
                        if (produto.Validade.HasValue)
                            cmd.Parameters.AddWithValue("@validade", produto.Validade.Value.ToString("yyyy-MM-dd"));
                        else
                            cmd.Parameters.AddWithValue("@validade", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao adicionar produto" + ex.Message);
                }
            }

            public static void UpdateProduto(Produto_dtb produto)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        UPDATE Produtos_dtb 
                        SET nome = @nome, 
                            codigoBarras = @codigoBarras,
                            preco = @preco, 
                            estoque = @estoque 
                        WHERE id = @id";

                        cmd.Parameters.AddWithValue("@nome", produto.Nome);
                        cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@preco", produto.Preco);
                        cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                        cmd.Parameters.AddWithValue("@id", produto.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar produto", ex);
                }
            }

            public static bool ProdutoExiste(string nome)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(1) FROM Produtos_dtb WHERE nome = @nome";
                        cmd.Parameters.AddWithValue("@nome", nome);

                        // Correção: Usar ExecuteScalar para obter o resultado
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao verificar produto", ex);
                }
            }

            public static void DeleteProduto(int id)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Produtos_dtb WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir produto", ex);
                }
            }

            public static DataTable GetProdutoParaVenda(string termo)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        
                        cmd.CommandText = @"
                SELECT * FROM Produtos_dtb 
                WHERE codigoBarras = @termo 
                OR nome LIKE @termoLike
                LIMIT 1";

                        cmd.Parameters.AddWithValue("@termo", termo);
                        cmd.Parameters.AddWithValue("@termoLike", $"%{termo}%");

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
                    throw new Exception("Erro ao buscar produto para venda", ex);
                }
            }
            public static void AtualizarEstoque(int produtoId, int quantidadeVendida)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        // Subtrai a quantidade vendida do estoque atual
                        cmd.CommandText = @"
                UPDATE Produtos_dtb 
                SET estoque = estoque - @quantidadeVendida 
                WHERE id = @id";

                        cmd.Parameters.AddWithValue("@quantidadeVendida", quantidadeVendida);
                        cmd.Parameters.AddWithValue("@id", produtoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao dar baixa no estoque", ex);
                }
            }
            // Cole isto dentro da classe DALProdutos
            public static int GetContagemEstoqueBaixo(int limite)
            {
                try
                {
                    using (var conn = CreateConnection())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(id) FROM Produtos_dtb WHERE estoque <= @limite";
                        cmd.Parameters.AddWithValue("@limite", limite);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao contar estoque baixo", ex);
                }
            }
        }

    }
}
