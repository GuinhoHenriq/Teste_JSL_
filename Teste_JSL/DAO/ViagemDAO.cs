using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Teste_JSL.Model;
using Teste_JSL.Utilities;
using Teste_JSL.DTO.Request;

namespace Teste_JSL.DAO
{
    public class ViagemDAO
    {
        //Método que cadastra uma Viagem
        public bool Cadastrar(ViagemRequestDTO viagem)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "INSERT INTO Viagens (id_motorista, local_entrega, local_saida, distancia_em_km) VALUES(@id_motorista, @local_entrega, @local_saida, @distancia_em_km) SELECT SCOPE_IDENTITY();";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@id_motorista", viagem.id_motorista);
                cmd.Parameters.AddWithValue("@local_entrega", viagem.id_LocalEntrega);
                cmd.Parameters.AddWithValue("@local_saida", viagem.id_LocalSaida);
                cmd.Parameters.AddWithValue("@distancia_em_km", viagem.DistanciaEmKM);

                //Executa o comando na base de dados
                viagem.id = Convert.ToInt32(cmd.ExecuteScalar());

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao cadastrar a Viagem!\nMotivo: " + ex.GetBaseException());
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

        public List<Viagem> Listar()
        {
            //Criando uma lista do tipo Viagem

            List<Viagem> lsViagem = new List<Viagem>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Viagens";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Executa o comando na base de dados
                SqlDataReader reader = cmd.ExecuteReader();

                // Alimenta o objeto com o retorno do Select
                while (reader.Read())
                {
                    Viagem viagens = new Viagem();
                    viagens.Id = Convert.ToInt32(reader["id"]);

                    viagens.Motorista = new Motorista
                    {
                        Id = Convert.ToInt32(reader["id_motorista"])
                    };

                    
                    viagens.LocalEntrega = new Endereco
                    {
                        Id = Convert.ToInt32(reader["local_entrega"])
                    };


                    viagens.LocalSaida = new Endereco
                    {
                        Id = Convert.ToInt32(reader["local_saida"])
                    };

                    viagens.DistanciaEmKM = Convert.ToDouble(reader["distancia_em_km"]);

                    // Acrescenta o objeto na lista
                    lsViagem.Add(viagens);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao listar viagem!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }
            //Retorna a lista para o Endpoint chamado
            return lsViagem;
        }

        public List<Viagem> ListarUnico(int id)
        {
            //Criando uma lista do tipo Viagem

            List<Viagem> lsViagem = new List<Viagem>();

            SqlConnection conexao = null;

            //Comando sql
            string sql = "SELECT * FROM Viagens where id = @id";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando na base de dados
                SqlDataReader reader = cmd.ExecuteReader();

                //Alimenta o objeto com o retorno do Select
                while (reader.Read())
                {
                    Viagem viagens = new Viagem();
                    viagens.Id = Convert.ToInt32(reader["id"]);

                    viagens.Motorista = new Motorista
                    {
                        Id = Convert.ToInt32(reader["id_motorista"])
                    };


                    viagens.LocalEntrega = new Endereco
                    {
                        Id = Convert.ToInt32(reader["local_entrega"])
                    };


                    viagens.LocalSaida = new Endereco
                    {
                        Id = Convert.ToInt32(reader["local_saida"])
                    };

                    viagens.DistanciaEmKM = Convert.ToDouble(reader["distancia_em_km"]);

                    //Adiciona o objeto na lista
                    lsViagem.Add(viagens);
                }
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao listar viagem!\nMotivo: " + ex.GetBaseException());
                //Trata a exceção
                throw;
            }
            finally
            {
                //Fecha a conexão
                SQLServer.CloseConnection(conexao);
            }

            //Retorna a lista para o endpoint chamado
            return lsViagem;
        }

        public bool Deletar(int id)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "Delete Viagens where id = @id";

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
                Console.WriteLine("Erro ao deletar viagem!\nMotivo: " + ex.GetBaseException());
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

        public bool Update(ViagemRequestDTO viagem)
        {
            //Inicializa as variáveis necessárias
            //Variável Auxiliar
            bool aux = false;
            //Objeto de conexão
            SqlConnection conexao = null;

            //Comando sql
            string sql = "Update Viagens set id_motorista = @id_motorista, local_entrega = @local_entrega, local_saida = @local_saida, distancia_em_km = @distancia_em_km where id = @id";

            //Início do bloco com risco de exceções                        
            try
            {
                //Obtém conexão
                conexao = SQLServer.GetConnection();

                //Cria um comando especificando qual script e em qual conexão
                using SqlCommand cmd = new SqlCommand(sql, conexao);

                //Adiciona os parâmetros para evitar Injeção SQL
                cmd.Parameters.AddWithValue("@id_motorista", viagem.id_motorista);
                cmd.Parameters.AddWithValue("@local_entrega", viagem.id_LocalEntrega);
                cmd.Parameters.AddWithValue("@local_saida", viagem.id_LocalSaida);
                cmd.Parameters.AddWithValue("@distancia_em_km", viagem.DistanciaEmKM);
                cmd.Parameters.AddWithValue("@id", viagem.id);


                //Executa o comando na base de dados
                cmd.ExecuteNonQuery();

                aux = true;
            }
            //Caso aconteça alguma falha
            catch (SqlException ex)
            {
                //Aprensenta o erro no console
                Console.WriteLine("Erro ao atualizar a viagem!\nMotivo: " + ex.GetBaseException());
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
