using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_JSL.Model;
using Teste_JSL.DAO;
using Teste_JSL.DTO;

namespace Teste_JSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : Controller
    {
        /// <summary>
        /// Cadastra um motorista, juntamente com o endereco e caminhao
        /// </summary>
        /// <param name="motorista"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Cadastrar(Motorista motorista)
        {

            MotoristaDAO motoristaDAO = new MotoristaDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();

            enderecoDAO.Cadastrar(motorista.Endereco);

            caminhaoDAO.Cadastrar(motorista.Caminhao);

            motoristaDAO.Cadastrar(motorista);

            return new JsonResult($"Motorista {motorista.Nome} Cadastrado com Sucesso!");
        }

        /// <summary>
        /// Lista todos os motoristas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Listar()
        {
            //Instanciando as classes 
            MotoristaDAO motoristaDAO = new MotoristaDAO();
            MotoristaDTO motoristaDTO = new MotoristaDTO();
            EnderecoDAO enderecosDAO = new EnderecoDAO();
            CaminhaoDAO caminhoesDAO = new CaminhaoDAO();

            //Gerando uma lista que será utilizada no retorno do request
            List<MotoristaDTO> list = new List<MotoristaDTO>();

            //Alimentando a variavel com o retorno do método
            var motorista = motoristaDAO.Listar();

            //Alimentando a Lista para ser exibida como Json no response da chamadda
            for (int i = 0; i < motorista.Count; i++)
            {
                motoristaDTO.id = motorista[i].Id;
                motoristaDTO.nome = motorista[i].Nome;
                motoristaDTO.sobrenome = motorista[i].Sobrenome;
                motoristaDTO.id_caminhao = motorista[i].Caminhao.Id.ToString();
                motoristaDTO.id_endereco = motorista[i].Endereco.Id.ToString();

                var endereco = enderecosDAO.ListarUnico(motorista[i].Endereco.Id.ToString());

                motoristaDTO.Endereco = new EnderecoDTO
                {

                    Cep = endereco[0].Cep.ToString(),
                    Logradouro = endereco[0].Logradouro.ToString(),
                    Complemento = endereco[0].Complemento.ToString(),
                    Bairro = endereco[0].Bairro.ToString(),
                    Localidade = endereco[0].Localidade.ToString(),
                    UF = endereco[0].UF.ToString(),
                    Numero = endereco[0].Numero.ToString()
                };

                var caminhao = caminhoesDAO.ListarUnico(motorista[i].Caminhao.Id.ToString());

                motoristaDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[0].Marca.ToString(),
                    Modelo = caminhao[0].Modelo.ToString(),
                    Placa = caminhao[0].Placa.ToString(),
                    Eixos = caminhao[0].Eixos.ToString()
                };

                list.Add(motoristaDTO);

            }

            return new JsonResult(list);
        }

        /// <summary>
        /// Listar um motorista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ListarUnico")]
        [HttpGet]
        public JsonResult ListarUnico(int id)
        {
            //Instanciando as classes 
            MotoristaDAO motoristaDAO = new MotoristaDAO();
            MotoristaDTO motoristaDTO = new MotoristaDTO();
            EnderecoDAO enderecosDAO = new EnderecoDAO();
            CaminhaoDAO caminhoesDAO = new CaminhaoDAO();

            //Gerando uma lista que será utilizada no retorno do request
            List<MotoristaDTO> list = new List<MotoristaDTO>();

            //Alimentando a variavel com o retorno do método
            var motorista = motoristaDAO.ListarUnico(id);

            //Alimentando a Lista para ser exibida como Json no response da chamadda
            for (int i = 0; i < motorista.Count; i++)
            {
                motoristaDTO.id = motorista[i].Id;
                motoristaDTO.nome = motorista[i].Nome;
                motoristaDTO.sobrenome = motorista[i].Sobrenome;
                motoristaDTO.id_caminhao = motorista[i].Caminhao.Id.ToString();
                motoristaDTO.id_endereco = motorista[i].Endereco.Id.ToString();

                var endereco = enderecosDAO.ListarUnico(motorista[i].Endereco.Id.ToString());

                motoristaDTO.Endereco = new EnderecoDTO
                {

                    Cep = endereco[0].Cep.ToString(),
                    Logradouro = endereco[0].Logradouro.ToString(),
                    Complemento = endereco[0].Complemento.ToString(),
                    Bairro = endereco[0].Bairro.ToString(),
                    Localidade = endereco[0].Localidade.ToString(),
                    UF = endereco[0].UF.ToString(),
                    Numero = endereco[0].Numero.ToString()
                };

                var caminhao = caminhoesDAO.ListarUnico(motorista[i].Caminhao.Id.ToString());

                motoristaDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[0].Marca.ToString(),
                    Modelo = caminhao[0].Modelo.ToString(),
                    Placa = caminhao[0].Placa.ToString(),
                    Eixos = caminhao[0].Eixos.ToString()
                };

                list.Add(motoristaDTO);

            }

            return new JsonResult(list);
        }

        /// <summary>
        /// Deleta um Motorista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            MotoristaDAO motoristaDAO = new MotoristaDAO();

            motoristaDAO.Deletar(id);

            return new JsonResult($"Motorista deletado com sucesso!");
        }

        /// <summary>
        /// Atualiza um motorista
        /// </summary>
        /// <param name="motorista"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Atualizar(Motorista motorista)
        {

            MotoristaDAO motoristaDAO = new MotoristaDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            MotoristaDTO motoristaDTO = new MotoristaDTO();

            var retMotorista = motoristaDAO.Update(motorista);

            enderecoDAO.Update(motorista.Endereco);

            caminhaoDAO.Update(motorista.Caminhao);

             

            return new JsonResult($"Motorista {retMotorista[0].Nome} atualizado com sucesso!");
        }

    }
}
