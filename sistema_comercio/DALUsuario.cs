using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace sistema_comercio
{
    public class DALUsuario
    {
        private static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";

        private static SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();
            return connection;
        }

        public static void CriarTabelaUsuario()
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuarios (id INTEGER PRIMARY KEY AUTOINCREMENT, login VARCHAR(50) UNIQUE, senha VARCHAR(50))";
                    cmd.ExecuteNonQuery();
                }

                // Cria o admin padrão se não existir ninguém
                CriarAdminPadrao();
            }
            catch (Exception ex) { throw ex; }
        }

        private static void CriarAdminPadrao()
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    // Verifica se tem alguém
                    using (var cmdCheck = conn.CreateCommand())
                    {
                        cmdCheck.CommandText = "SELECT COUNT(*) FROM Usuarios";
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count > 0) return; // Já tem usuário, não faz nada
                    }

                    // Cria o admin / 123
                    using (var cmdInsert = conn.CreateCommand())
                    {
                        cmdInsert.CommandText = "INSERT INTO Usuarios (login, senha) VALUES ('admin', '123')";
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public static bool ValidarLogin(string login, string senha)
        {
            try
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    // Verifica se existe esse par login/senha
                    // Nota: Em produção, usaríamos Hash e Salt aqui.
                    cmd.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE login = @login AND senha = @senha";
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch { return false; }
        }
    }
}