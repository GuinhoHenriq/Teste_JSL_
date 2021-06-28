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
    public class ViagemController : ControllerBase
    {
        [HttpPost]
        public JsonResult Cadastrar(Viagem viagem)
        {
            ViagemDAO viagemDAO = new ViagemDAO();

            viagemDAO.Cadastrar(viagem);

            return new JsonResult($"Viagem Cadastrado com Sucesso!");
        }

        [HttpGet]
        public JsonResult Listar()
        {
            ViagemDAO viagemDAO = new ViagemDAO();

            return new JsonResult(viagemDAO.Listar());
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
