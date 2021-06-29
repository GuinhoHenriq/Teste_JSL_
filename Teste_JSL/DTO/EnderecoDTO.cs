using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JSL.DTO
{
    /// <summary>
    /// Classe para montar o retorno de request
    /// </summary>
    public class EnderecoDTO
    {
        public int id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
    }
}
