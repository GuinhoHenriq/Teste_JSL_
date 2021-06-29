using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JSL.DTO.Request
{
    /// <summary>
    /// Classe para montar o retorno de request
    /// </summary>
    public class ViagemDTO
    {
        public int id_motorista { get; set; }
        public int id_LocalEntrega { get; set; }
        public int id_LocalSaida { get; set; }
        public double DistanciaEmKM { get; set; }
        public MotoristaViagemDTO Motorista { get; set; }
        public EnderecoDTO EnderecoSaida { get; set; }
        public EnderecoDTO EnderecoEntrega { get; set; }
        public CaminhaoDTO Caminhao { get; set; }
        
    }
}
