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
        /// <summary>
        /// Cadastra um caminhao
        /// </summary>
        /// <param name="caminhao"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Cadastrar(Caminhao caminhao)
        {
            CaminhaoDAO caminhaoDAO = new CaminhaoDAO();

            caminhaoDAO.Cadastrar(caminhao);

            return new JsonResult($"Caminhao cadastrado com sucesso!");
        }
        /// <summary>
        /// Efetua a listagem de todos os caminhoes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Listar()
        {
            CaminhaoDAO caminhao = new CaminhaoDAO();

            return new JsonResult(caminhao.Listar());
        }

        /// <summary>
        /// Lista um unico Caminhao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ListarUnico")]
        [HttpGet]
        public JsonResult ListarUnico(string id)
        {
            CaminhaoDAO caminhao = new CaminhaoDAO();

            return new JsonResult(caminhao.ListarUnico(id));
        }

        /// <summary>
        /// Deleta um caminhao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Excluir(int id)
        {
            CaminhaoDAO caminhao = new CaminhaoDAO();

            caminhao.Deletar(id);

            return new JsonResult("Caminhao deletado com sucesso!");
        }

        /// <summary>
        /// Atualiza um caminhao
        /// </summary>
        /// <param name="caminhao"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Atualizar(Caminhao caminhao)
        {
            CaminhaoDAO caminhoes = new CaminhaoDAO();

            caminhoes.Update(caminhao);

            return new JsonResult("Caminhao atualizado com sucesso!");
        }
    }
}
