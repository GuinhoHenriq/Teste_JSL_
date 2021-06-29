using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JSL.DTO.Request
{
    /// <summary>
    /// Classe utilizada para receber o request do cadastro de viagem
    /// </summary>
   public class ViagemRequestDTO
    {
        public int id { get; set; }
        public int id_motorista { get; set; }
        public int id_LocalEntrega { get; set; }
        public int id_LocalSaida { get; set; }
        public float DistanciaEmKM { get; set; }
    }
}
