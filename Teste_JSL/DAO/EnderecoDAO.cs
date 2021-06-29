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
        /// <summary>
        /// Cadastra um endereço
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
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
                cmd.Parameters.AddWithValue("@numero_residencial", endereco.Numero);

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

        /// <summary>
        /// Lista todos os endereços
        /// </summary>
        /// <returns></returns>
        public List<Endereco> Listar()
        {
            //Criando uma lista do tipo Endereco

            List<Endereco> lsEndereco = new List<Endereco>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Enderecos";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Executa o comando na base de dados
                SqlDataReader reader = cmd.ExecuteReader();

                //Alimenta o objeto com o retorno do Select
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
                    endereco.Numero = (string)reader["numero_residencial"];

                    //Adiciona o objeto na lista
                    lsEndereco.Add(endereco);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao listar endereço!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            //Retorna a lista para o Endpoint chamado
            return lsEndereco;
        }

        /// <summary>
        /// Lista um unico endereco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Endereco> ListarUnico(string id)
        {
            //Criando uma lista do tipo Endereco

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

                //Alimenta o objeto com o retorno do Select
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
                    endereco.Numero = (string)reader["numero_residencial"];

                    //Adiciona o objeto na lista
                    lsEndereco.Add(endereco);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao listar endereço!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            //Retorna a lista para o Endpoint chamado
            return lsEndereco;
        }

        /// <summary>
        /// Atualiza um endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public bool Update(Endereco endereco)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "Update Enderecos set cep = @cep, logradouro = @logradouro, complemento = @complemento, bairro = @bairro, localidade = @localidade, uf = @uf, numero_residencial = @numero_residencial where id = @id";

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
                cmd.Parameters.AddWithValue("@numero_residencial", endereco.Numero);
                cmd.Parameters.AddWithValue("@id", endereco.Id);

                //Executa o comando na base de dados
                endereco.Id = Convert.ToInt32(cmd.ExecuteScalar());

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao atualizar endereço!\nMotivo: " + ex.GetBaseException());
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

        /// <summary>
        /// Deleta um endereco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "Delete Enderecos where id = @id";

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
                cmd.ExecuteNonQuery();

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao deletar endereço!\nMotivo: " + ex.GetBaseException());
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
    }
}
