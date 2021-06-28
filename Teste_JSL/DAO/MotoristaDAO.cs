using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Teste_JSL.Model;
using Teste_JSL.Utilities;
using System.Data;

namespace Teste_JSL.DAO
{
    public class MotoristaDAO
    {
        //Método que cadastra um motorista
        public bool Cadastrar(Motorista motorista)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "INSERT INTO Motoristas (nome, sobrenome, id_caminhao, id_endereco) VALUES(@nome, @sobrenome, @id_caminhao, @id_endereco)";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@nome", motorista.Nome);
                cmd.Parameters.AddWithValue("@sobrenome", motorista.Sobrenome);
                cmd.Parameters.AddWithValue("@id_caminhao", motorista.Caminhao.Id);
                cmd.Parameters.AddWithValue("@id_endereco", motorista.Endereco.Id);
                //Executa o comando na base de dados
                cmd.ExecuteNonQuery();

                aux = true;
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

            //Retorna situação (true/false)
            return aux;
        }
        public List<Motorista> Listar()
        {
            //Criando uma lista do tipo Motorista

            List<Motorista> lsMotorista = new List<Motorista>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Motoristas";

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
                    Motorista motoristas = new Motorista();
                    motoristas.Id = Convert.ToInt32(reader["id"]);
                    motoristas.Nome = (string)reader["nome"];
                    motoristas.Sobrenome = (string)reader["sobrenome"];
                    motoristas.Caminhao = new Caminhao {
                    Id = Convert.ToInt32(reader["id_caminhao"])
                    };
                    motoristas.Endereco = new Endereco
                    {
                        Id = Convert.ToInt32(reader["id_endereco"])
                    };
                    lsMotorista.Add(motoristas);
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

            return lsMotorista;
        }
    }
}

    
