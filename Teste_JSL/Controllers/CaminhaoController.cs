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
    public class CaminhaoController : Controller
    {

        [HttpPost]
        public JsonResult Cadastrar(Caminhao caminhao)
        {
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();

            caminhaoDAO.Cadastrar(caminhao);

            return new JsonResult($"Caminhao cadastrado com sucesso!");
        }

        [HttpGet]
        public JsonResult Listar()
        {
            CaminhaoDAO caminhao = new CaminhaoDAO();

            return new JsonResult(caminhao.Listar());
        }

        [HttpDelete]
        public JsonResult Excluir(Caminhao motorista)
        {
            return new JsonResult("");
        }

        [HttpPut]
        public JsonResult Editar(Caminhao motorista)
        {
            return new JsonResult("");
        }
    }
}
