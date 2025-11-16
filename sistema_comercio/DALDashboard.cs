// Arquivo: DALDashboard.cs
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace sistema_comercio.sistema_comercio
{
    public class DALDashboard
    {
        // Pega o mesmo caminho de banco de dados das outras classes DAL
        private static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";

        private static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();
            return connection;
        }

        // --- MÉTODOS PARA OS KPIS (CARTÕES) ---

        public static decimal GetVendasHoje()
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT SUM(ValorTotal) 
                        FROM Vendas 
                        WHERE DATE(DataVenda) = DATE('now', 'localtime')";

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        return Convert.ToDecimal(result);
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        public static decimal GetFaturamentoMesAtual()
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT SUM(ValorTotal) 
                        FROM Vendas 
                        WHERE strftime('%Y-%m', DataVenda) = strftime('%Y-%m', 'now', 'localtime')";

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        return Convert.ToDecimal(result);
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        // --- MÉTODOS PARA OS GRÁFICOS ---

        public static DataTable GetFaturamentoUltimos7Dias()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            strftime('%Y-%m-%d', DataVenda) as Dia,
                            SUM(ValorTotal) as Total
                        FROM Vendas 
                        WHERE DataVenda >= DATE('now', '-6 days', 'localtime')
                        GROUP BY Dia
                        ORDER BY Dia ASC";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception) { return dt; }
        }

        public static DataTable GetFaturamentoVistaPrazoMes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            CASE WHEN IdCliente IS NULL THEN 'À Vista' ELSE 'A Prazo' END as Tipo, 
                            SUM(ValorTotal) as Total
                        FROM Vendas 
                        WHERE strftime('%Y-%m', DataVenda) = strftime('%Y-%m', 'now', 'localtime')
                        GROUP BY Tipo";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception) { return dt; }
        }

        // --- MÉTODOS PARA OS GRIDS (TOP 5) ---

        public static DataTable GetTop5ProdutosVendidosMes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            iv.NomeProduto, 
                            SUM(iv.Quantidade) as QuantidadeVendida
                        FROM ItensVenda iv
                        JOIN Vendas v ON iv.IdVenda = v.IdVenda
                        WHERE strftime('%Y-%m', v.DataVenda) = strftime('%Y-%m', 'now', 'localtime')
                        GROUP BY iv.NomeProduto
                        ORDER BY QuantidadeVendida DESC
                        LIMIT 5";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception) { return dt; }
        }
    }
}