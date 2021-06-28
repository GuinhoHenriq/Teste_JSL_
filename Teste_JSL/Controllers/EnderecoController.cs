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
    public class EnderecoController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CaminhaoController : Controller
        {

            [HttpPost]
            public JsonResult Cadastrar(Endereco endereco)
            {
                EnderecoDAO enderecoDAO = new EnderecoDAO();

                enderecoDAO.Cadastrar(endereco);

                return new JsonResult($"Endereço cadastrado com sucesso!");
            }

            [HttpGet]
            public JsonResult Listar()
            {
                EnderecoDAO endereco = new EnderecoDAO();

                return new JsonResult("");
            }

            [HttpDelete]
            public JsonResult Excluir(Endereco endereco)
            {
                return new JsonResult("");
            }

            [HttpPut]
            public JsonResult Editar(Endereco endereco)
            {
                return new JsonResult("");
            }
        }
    }
}

