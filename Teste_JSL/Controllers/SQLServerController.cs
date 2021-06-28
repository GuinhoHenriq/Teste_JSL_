using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_JSL.Utilities;

namespace Teste_JSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQLServerController : ControllerBase
    {
        [HttpGet]
        public JsonResult TesteConexao()
        {
            return new JsonResult(SQLServer.GetConnection().State);
        }
    }
}
