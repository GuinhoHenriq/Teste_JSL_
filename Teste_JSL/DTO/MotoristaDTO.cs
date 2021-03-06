using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JSL.DTO
{
    /// <summary>
    /// Classe para montar o retorno de request
    /// </summary>
    public class MotoristaDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string id_caminhao { get; set; }
        public string id_endereco { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public CaminhaoDTO Caminhao { get; set; }

    }
}
