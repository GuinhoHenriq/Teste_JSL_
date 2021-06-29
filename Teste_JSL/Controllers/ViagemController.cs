using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_JSL.DAO;
using Teste_JSL.Model;
using Teste_JSL.DTO;
using Teste_JSL.DTO.Request;

namespace Teste_JSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        /// <summary>
        /// Cadastra uma viagem
        /// </summary>
        /// <param name="viagem"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Cadastrar(ViagemRequestDTO viagem)
        {
            ViagemDAO viagemDAO = new ViagemDAO();

            viagemDAO.Cadastrar(viagem);

            return new JsonResult($"Viagem Cadastrado com Sucesso!");
        }

        /// <summary>
        /// Lista todas as viagens
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Listar()
        {
            // Instanciando as classes
            ViagemDAO viagemDAO = new ViagemDAO();
            ViagemDTO viagemDTO = new ViagemDTO();
            MotoristaViagemDTO motoristaDTO = new MotoristaViagemDTO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            MotoristaDAO motoristaDAO = new MotoristaDAO();

            // Gerando uma lista que será utilizada no retorno do request
            List<ViagemDTO> list = new List<ViagemDTO>();

            var viagem = viagemDAO.Listar();

            for (int i = 0; i < viagem.Count; i++)
            {
                viagemDTO.id_motorista = viagem[i].Motorista.Id;
                viagemDTO.id_LocalEntrega = viagem[i].LocalEntrega.Id;
                viagemDTO.id_LocalSaida = viagem[i].LocalSaida.Id;
                viagemDTO.DistanciaEmKM = viagem[i].DistanciaEmKM;

                var motorista = motoristaDAO.ListarUnico(viagem[i].Motorista.Id);

                viagemDTO.Motorista = new MotoristaViagemDTO
                {
                    nome = motorista[0].Nome,
                    sobrenome = motorista[0].Sobrenome,
                    id_caminhao = motorista[0].Caminhao.Id.ToString(),
                    id_endereco = motorista[0].Endereco.Id.ToString()
                    
                };

                var enderecoSaida = enderecoDAO.ListarUnico(viagem[i].LocalEntrega.Id.ToString());

                viagemDTO.EnderecoSaida = new EnderecoDTO
                {
                    Cep = enderecoSaida[0].Cep.ToString(),
                    Logradouro = enderecoSaida[0].Logradouro.ToString(),
                    Complemento = enderecoSaida[0].Complemento.ToString(),
                    Bairro = enderecoSaida[0].Bairro.ToString(),
                    Localidade = enderecoSaida[0].Localidade.ToString(),
                    UF = enderecoSaida[0].UF.ToString(),
                    Numero = enderecoSaida[0].Numero.ToString()
                };

                var EnderecoEntrega = enderecoDAO.ListarUnico(viagem[i].LocalEntrega.Id.ToString());

                viagemDTO.EnderecoEntrega = new EnderecoDTO
                {
                    Cep = enderecoSaida[0].Cep.ToString(),
                    Logradouro = enderecoSaida[0].Logradouro.ToString(),
                    Complemento = enderecoSaida[0].Complemento.ToString(),
                    Bairro = enderecoSaida[0].Bairro.ToString(),
                    Localidade = enderecoSaida[0].Localidade.ToString(),
                    UF = enderecoSaida[0].UF.ToString(),
                    Numero = enderecoSaida[0].Numero.ToString()
                };

                var caminhao = caminhaoDAO.ListarUnico(motorista[0].Caminhao.Id.ToString());

                viagemDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[0].Marca.ToString(),
                    Modelo = caminhao[0].Modelo.ToString(),
                    Placa = caminhao[0].Placa.ToString(),
                    Eixos = caminhao[0].Eixos.ToString()
                };

                list.Add(viagemDTO);
            }

            return new JsonResult(list);
        }

        /// <summary>
        /// Lista uma unica viagem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ListarUnico")]
        [HttpGet]
        public JsonResult ListarUnico(int id)
        {
            // Instanciando as classes
            ViagemDAO viagemDAO = new ViagemDAO();
            ViagemDTO viagemDTO = new ViagemDTO();
            MotoristaViagemDTO motoristaDTO = new MotoristaViagemDTO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            MotoristaDAO motoristaDAO = new MotoristaDAO();

            // Gerando uma lista que será utilizada no retorno do request
            List<ViagemDTO> list = new List<ViagemDTO>();

            var viagem = viagemDAO.ListarUnico(id);

            for (int i = 0; i < viagem.Count; i++)
            {
                viagemDTO.id_motorista = viagem[i].Motorista.Id;
                viagemDTO.id_LocalEntrega = viagem[i].LocalEntrega.Id;
                viagemDTO.id_LocalSaida = viagem[i].LocalSaida.Id;
                viagemDTO.DistanciaEmKM = viagem[i].DistanciaEmKM;

                var motorista = motoristaDAO.ListarUnico(viagem[i].Motorista.Id);

                viagemDTO.Motorista = new MotoristaViagemDTO
                {
                    nome = motorista[0].Nome,
                    sobrenome = motorista[0].Sobrenome,
                    id_caminhao = motorista[0].Caminhao.Id.ToString(),
                    id_endereco = motorista[0].Endereco.Id.ToString()

                };

                var enderecoSaida = enderecoDAO.ListarUnico(viagem[i].LocalEntrega.Id.ToString());

                viagemDTO.EnderecoSaida = new EnderecoDTO
                {
                    Cep = enderecoSaida[0].Cep.ToString(),
                    Logradouro = enderecoSaida[0].Logradouro.ToString(),
                    Complemento = enderecoSaida[0].Complemento.ToString(),
                    Bairro = enderecoSaida[0].Bairro.ToString(),
                    Localidade = enderecoSaida[0].Localidade.ToString(),
                    UF = enderecoSaida[0].UF.ToString(),
                    Numero = enderecoSaida[0].Numero.ToString()
                };

                var EnderecoEntrega = enderecoDAO.ListarUnico(viagem[i].LocalEntrega.Id.ToString());

                viagemDTO.EnderecoEntrega = new EnderecoDTO
                {
                    Cep = enderecoSaida[0].Cep.ToString(),
                    Logradouro = enderecoSaida[0].Logradouro.ToString(),
                    Complemento = enderecoSaida[0].Complemento.ToString(),
                    Bairro = enderecoSaida[0].Bairro.ToString(),
                    Localidade = enderecoSaida[0].Localidade.ToString(),
                    UF = enderecoSaida[0].UF.ToString(),
                    Numero = enderecoSaida[0].Numero.ToString()
                };

                var caminhao = caminhaoDAO.ListarUnico(motorista[0].Caminhao.Id.ToString());

                viagemDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[0].Marca.ToString(),
                    Modelo = caminhao[0].Modelo.ToString(),
                    Placa = caminhao[0].Placa.ToString(),
                    Eixos = caminhao[0].Eixos.ToString()
                };

                list.Add(viagemDTO);
            }

            return new JsonResult(list);
        }
        
        /// <summary>
        /// Deleta uma viagem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            ViagemDAO viagemDAO = new ViagemDAO();

            viagemDAO.Deletar(id);
            return new JsonResult("Viagem deletada com sucesso!");
        }

        /// <summary>
        /// Atualiza uma viagem
        /// </summary>
        /// <param name="viagem"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Atualizar(ViagemRequestDTO viagem)
        {
            ViagemDAO viagemDAO = new ViagemDAO();

            viagemDAO.Update(viagem);

            return new JsonResult("Viagem atualizada com sucesso!");
        }

    }
}
