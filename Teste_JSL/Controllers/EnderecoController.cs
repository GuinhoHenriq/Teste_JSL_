using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_JSL.DAO;
using Teste_JSL.Model;


namespace Teste_JSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : Controller
    {
        /// <summary>
        /// Cadastra um endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Cadastrar(Endereco endereco)
        {
            EnderecoDAO enderecoDAO = new EnderecoDAO();

            enderecoDAO.Cadastrar(endereco);

            return new JsonResult($"Endereço cadastrado com sucesso!");
        }

        /// <summary>
        /// Lista todos os enderecos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Listar()
        {
            EnderecoDAO endereco = new EnderecoDAO();

            return new JsonResult(endereco.Listar());
        }
        
        /// <summary>
        /// Lista todos os enderecos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ListarUnico")]
        [HttpGet]
        public JsonResult ListarUnico(string id)
        {
            EnderecoDAO endereco = new EnderecoDAO();

            return new JsonResult(endereco.ListarUnico(id));
        }

        /// <summary>
        /// Deleta um endereco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            EnderecoDAO endereco = new EnderecoDAO();

            endereco.Delete(id);

            return new JsonResult("Endereço deletado com sucesso!");
        }

        /// <summary>
        /// Atualiza um endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Atualizar(Endereco endereco)
        {
            EnderecoDAO enderecos = new EnderecoDAO();

            enderecos.Update(endereco);

            return new JsonResult("Endereço atualizado com sucesso!");
        }
    }
}

