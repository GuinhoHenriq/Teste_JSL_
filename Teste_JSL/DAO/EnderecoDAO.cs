using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_JSL.Model;
using System.Data.SqlClient;
using System.Data;
using Teste_JSL.Utilities;

namespace Teste_JSL.DAO
{
    public class EnderecoDAO
    {
        //Método que cadastra um endereço
        public bool Cadastrar(Endereco endereco)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "INSERT INTO Enderecos (cep, logradouro, complemento, bairro, localidade, uf, numero_residencial) VALUES(@cep, @logradouro, @complemento, @bairro, @localidade, @uf, @numero_residencial) SELECT SCOPE_IDENTITY();";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@cep", endereco.Cep);
                cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                cmd.Parameters.AddWithValue("@localidade", endereco.Localidade);
                cmd.Parameters.AddWithValue("@uf", endereco.UF);
                cmd.Parameters.AddWithValue("@numero_residencial", endereco.NumeroResidencial);

                //Executa o comando na base de dados
                endereco.Id = Convert.ToInt32(cmd.ExecuteScalar());

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao cadastrar endereço!\nMotivo: " + ex.GetBaseException());                
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

        public List<Endereco> ListarUnico(string id)
        {
            //Criando uma lista do tipo Motorista

            List<Endereco> lsEndereco = new List<Endereco>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Enderecos where id = @id";

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
                    Endereco endereco = new Endereco();
                    endereco.Id = Convert.ToInt32(reader["id"]);
                    endereco.Cep = (string)reader["cep"];
                    endereco.Logradouro = (string)reader["logradouro"];
                    endereco.Complemento = (string)reader["complemento"];
                    endereco.Bairro = (string)reader["bairro"];
                    endereco.Localidade = (string)reader["localidade"];
                    endereco.UF = (string)reader["uf"];
                    endereco.NumeroResidencial = (string)reader["numero_residencial"];

                    lsEndereco.Add(endereco);
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

            return lsEndereco;
        }
    }
}
