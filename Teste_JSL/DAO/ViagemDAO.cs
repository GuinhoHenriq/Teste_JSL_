using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Teste_JSL.Model;
using Teste_JSL.Utilities;

namespace Teste_JSL.DAO
{
    public class ViagemDAO
    {
        //Método que cadastra uma Viagem
        public bool Cadastrar(Viagem viagem)
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
                cmd.Parameters.AddWithValue("@id_motorista", viagem.Motorista.Id);
                cmd.Parameters.AddWithValue("@local_entrega", viagem.LocalEntrega.Id);
                cmd.Parameters.AddWithValue("@local_saida", viagem.LocalSaida.Id);
                cmd.Parameters.AddWithValue("@distancia_em_km", viagem.DistanciaEmKM);

                //Executa o comando na base de dados
                viagem.Id = Convert.ToInt32(cmd.ExecuteScalar());

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
            //Criando uma lista do tipo Motorista

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

                while (reader.Read())
                {
                    Viagem viagens = new Viagem();
                    viagens.Id = Convert.ToInt32(reader["id"]);
                    //viagens.LocalEntrega = (string)reader["nome"];
                    //viagens.Sobrenome = (string)reader["sobrenome"];
                    //viagens.Caminhao.Id = (int)reader["id_caminhao"];
                    //viagens.Endereco.Id = Convert.ToInt32(reader["id_endereco"]);
                    lsViagem.Add(viagens);
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

            return lsViagem;
        }


    }
}
