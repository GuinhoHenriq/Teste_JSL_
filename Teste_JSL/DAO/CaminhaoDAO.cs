using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Teste_JSL.Model;
using Teste_JSL.Utilities;

namespace Teste_JSL.DAO
{
    public class CaminhaoDAO
    {
        //Método que cadastra um Caminhao
        public bool Cadastrar(Caminhao caminhao)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "INSERT INTO Caminhoes (marca, modelo, placa, eixos) VALUES(@marca, @modelo, @placa, @eixos) SELECT SCOPE_IDENTITY();";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@marca", caminhao.Marca);
                cmd.Parameters.AddWithValue("@modelo", caminhao.Modelo);
                cmd.Parameters.AddWithValue("@placa", caminhao.Placa);
                cmd.Parameters.AddWithValue("@eixos", caminhao.Eixos);
                
                //Executa o comando na base de dados
                caminhao.Id = Convert.ToInt32(cmd.ExecuteScalar());

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao cadastrar Caminhao!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            //Retorna situação (true/false)
            return aux;
        }

        public List<Caminhao> Listar()
        {
            //Criando uma lista do tipo Motorista

            List<Caminhao> lsCaminhao = new List<Caminhao>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Caminhoes";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Executa o comando na base de dados
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Caminhao caminhoes = new Caminhao();
                    caminhoes.Id = Convert.ToInt32(reader["id"]);
                    caminhoes.Marca = (string)reader["marca"];
                    caminhoes.Modelo = (string)reader["modelo"];
                    caminhoes.Placa= (string)reader["placa"];
                    caminhoes.Eixos = (string)reader["eixos"];
                    lsCaminhao.Add(caminhoes);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao cadastrar motorista!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            return lsCaminhao;
        }

        public List<Caminhao> ListarUnico(string id)
        {
            //Criando uma lista do tipo Motorista

            List<Caminhao> lsCaminhao = new List<Caminhao>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Caminhoes where id = @id";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando na base de dados
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Caminhao caminhao = new Caminhao();
                    caminhao.Id = Convert.ToInt32(reader["id"]);
                    caminhao.Marca = (string)reader["marca"];
                    caminhao.Modelo = (string)reader["modelo"];
                    caminhao.Placa = (string)reader["placa"];
                    caminhao.Eixos = (string)reader["eixos"];

                    lsCaminhao.Add(caminhao);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao cadastrar motorista!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            return lsCaminhao;
        }
    }
}
