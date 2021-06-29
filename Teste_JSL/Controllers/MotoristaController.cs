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

                    Cep = endereco[1].Cep.ToString(),
                    Logradouro = endereco[1].Logradouro.ToString(),
                    Complemento = endereco[1].Complemento.ToString(),
                    Bairro = endereco[1].Bairro.ToString(),
                    Localidade = endereco[1].Localidade.ToString(),
                    UF = endereco[1].UF.ToString(),
                    NumeroResidencial = endereco[1].NumeroResidencial.ToString()
                };

                var caminhao = caminhoesDAO.ListarUnico(motorista[i].Caminhao.Id.ToString());

                motoristaDTO.Caminhao = new CaminhaoDTO
                {
                    Marca = caminhao[1].Marca.ToString(),
                    Modelo = caminhao[1].Modelo.ToString(),
                    Placa = caminhao[1].Placa.ToString(),
                    Eixos = caminhao[1].Eixos.ToString()
                };

                list.Add(motoristaDTO);

            }

            return new JsonResult(list);
        }

        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            MotoristaDAO motoristaDAO = new MotoristaDAO();

            motoristaDAO.Deletar(id);

            return new JsonResult($"Motorista deletado com sucesso!");
        }

        [HttpPut]
        public JsonResult Editar(Motorista motorista)
        {

            MotoristaDAO motoristaDAO = new MotoristaDAO();
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();
            EnderecoDAO enderecoDAO = new EnderecoDAO();
            MotoristaDTO motoristaDTO = new MotoristaDTO();

            var retMotorista = motoristaDAO.Update(motorista);

            enderecoDAO.Update(retMotorista[0].Endereco);

            caminhaoDAO.Update(retMotorista[0].Caminhao);

             

            return new JsonResult($"Motorista {retMotorista[0].Nome} atualizado com sucesso!");
        }

    }
}
