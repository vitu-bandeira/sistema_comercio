using SistemaComercio.Dominio;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaComercio.Infrastructure
{
    public class ProdutoRepository : IProdutosRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Adicionar(Produto produto)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Produtos_dtb(nome, codigoBarras, preco, estoque, validade) 
                               VALUES (@nome, @codigoBarras, @preco, @estoque, @validade)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    cmd.Parameters.AddWithValue("@validade", produto.Validade.HasValue ? produto.Validade.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Produto produto)
        {
           using(var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Produtos_dtb 
                               SET nome = @nome, 
                                   codigoBarras = @codigoBarras,
                                   preco = @preco, 
                                   estoque = @estoque 
                               WHERE id = @id";
                using(var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    cmd.Parameters.AddWithValue("@id", produto.Id);
                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        public void AtualizarEstoque(int produtoId, int quantidadeVendida)
        {   
            using(var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("UPDATE Produtos_dtb   " +
                    "SET estoque = estoque - @quantidadeVendida WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@quantidadeVendida", quantidadeVendida);
                    cmd.Parameters.AddWithValue("@id", produtoId);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using(var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Produtos_dtb WHERE id = @id";

                using(var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        public int ObterContagemEstoqueBaixo(int limite)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(id) FROM Produtos_dtb WHERE estoque <= @limite", conn))
                {
                    cmd.Parameters.AddWithValue("@limite", limite);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public Produto ObterParaVenda(string termo)
        {
            Produto produto = null;
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SQLiteCommand("SELECT * FROM Produtos_dtb WHERE codigoBarras = @termo OR nome LIKE @termolike  LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@termo", termo);
                    cmd.Parameters.AddWithValue("@termolike","%" + termo +"%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                CodigoBarras = reader["codigoBarras"] != DBNull.Value ? reader["codigoBarras"].ToString() : null,
                                Preco = Convert.ToDecimal(reader["preco"]),
                                Estoque = Convert.ToInt32(reader["estoque"]),
                                Validade = reader["validade"] != DBNull.Value ? Convert.ToDateTime(reader["validade"]) : (DateTime?)null

                            };
                        }
                    }
                }
            }
            return produto;
        }

        public Produto ObterPorID(int id)
        {
            Produto produto = null;
            using(var conn =  new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM  Produtos_dtb WHERE id = @id";
                using(var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                CodigoBarras = reader["codigoBarras"] != DBNull.Value ? reader["codigoBarras"].ToString() : null,
                                Preco = Convert.ToDecimal(reader["preco"]),
                                Estoque = Convert.ToInt32(reader["estoque"]),
                                Validade = reader["validade"] != DBNull.Value ? Convert.ToDateTime(reader["validade"]) : (DateTime?)null
                            };
                        }
                    }
                }
            }
            return produto;
        }

        public IEnumerable<Produto> ObterPorNome(string nome)
        {
            var produtos = new List<Produto>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM produtos_dtb WHERE nome LIKE @nome", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtos.Add(new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                CodigoBarras = reader["codigoBarras"] != DBNull.Value ? reader["codigoBarras"].ToString() : null,
                                Preco = Convert.ToDecimal(reader["preco"]),
                                Estoque = Convert.ToInt32(reader["estoque"]),
                                Validade = reader["validade"] != DBNull.Value ? Convert.ToDateTime(reader["validade"]) : (DateTime?)null
                                
                            });
                        }
                    }
                }
            }
            return produtos;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var produtos = new List<Produto>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SQLiteCommand("SELECT * FROM produtos_dtb", conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtos.Add(new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                CodigoBarras = reader["codigoBarras"] != DBNull.Value ? reader["codigoBarras"].ToString() : null,
                                Preco = Convert.ToDecimal(reader["preco"]),
                                Estoque = Convert.ToInt32(reader["estoque"]),
                                Validade = reader["validade"] != DBNull.Value ? Convert.ToDateTime(reader["validade"]) : (DateTime?)null
                            });
                        }
                    }
                }
            }
            return produtos;
        }

        public int ObterTotalProdutosCadastrados()
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(id) FROM Produtos_dtb", conn))
                {
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public decimal ObterValorTotalEstoque()
        {
            using(var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT SUM(preco * estoque) FROM Produtos_dtb", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public bool ProdutoExiste(string nome)
        {
            using(var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT 1 FROM produtos_dtb WHERE nome = @nome LiMIT 1";
                using(var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    var result = cmd.ExecuteScalar();
                    return result != null;

                }
            }
        }
    }
}
