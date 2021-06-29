using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JSL.DTO
{
    public class CaminhaoDTO
    {
        /// <summary>
        /// Classe para montar o retorno de request
        /// </summary>
        public int id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Eixos { get; set; }
    }
}
