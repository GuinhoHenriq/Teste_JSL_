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
    public class MotoristaController : ControllerBase
    {
        [HttpPost]
        public JsonResult Cadastrar (Motorista motorista)
        {

            MotoristaDAO motoristaDAO = new MotoristaDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();

            enderecoDAO.Cadastrar(motorista.Endereco);

            caminhaoDAO.Cadastrar(motorista.Caminhao);

            motoristaDAO.Cadastrar(motorista);

            return new JsonResult($"Motorista {motorista.Nome} Cadastrado com Sucesso!");
        }

        [HttpGet]
        public JsonResult Listar()
        {
            //Instanciando as classes 
            MotoristaDAO motoristaDAO = new MotoristaDAO();
            MotoristaDTO motoristaDTO = new MotoristaDTO();
            EnderecoDAO enderecosDAO = new EnderecoDAO();
            CaminhaoDAO caminhoesDAO = new CaminhaoDAO();

            //Gerando uma lista que será usada no retorno do request
            List<MotoristaDTO> list = new List<MotoristaDTO>();

            //Alimentando a variavel com o retorno do método
            var motorista = motoristaDAO.Listar();

            //Alimentando a Lista
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

                    Cep = endereco[i].Cep.ToString(),
                    Logradouro = endereco[i].Logradouro.ToString(),
                    Complemento = endereco[i].Complemento.ToString(),
                    Bairro = endereco[i].Bairro.ToString(),
                    Localidade = endereco[i].Localidade.ToString(),
                    UF = endereco[i].UF.ToString(),
                    NumeroResidencial = endereco[i].NumeroResidencial.ToString()
                };

                var caminhao = caminhoesDAO.ListarUnico(motorista[i].Caminhao.Id.ToString());

                motoristaDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[i].Marca,
                    Modelo = caminhao[i].Modelo,
                    Placa = caminhao[i].Placa,
                    Eixos = caminhao[i].Eixos
                };

                list.Add(motoristaDTO);

            }
            
            return new JsonResult(list);
        }

        [HttpDelete]
        public JsonResult Excluir(Motorista motorista)
        {
            return new JsonResult("");
        }

        [HttpPut]
        public JsonResult Editar(Motorista motorista)
        {
            return new JsonResult("");
        }

    }
}
