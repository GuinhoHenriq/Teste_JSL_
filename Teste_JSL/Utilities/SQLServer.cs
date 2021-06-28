using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Teste_JSL.Utilities
{
    public static class SQLServer
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Falha ao abrir conexão com o Banco de Dados. Erro: {ex.Message}");
                throw;
            }
            return conn;
        }

        public static void CloseConnection(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Falha ao fechar a conexão com o Banco de Dados. Erro: {ex.Message}");
                throw;
            }
        }
    }
}
