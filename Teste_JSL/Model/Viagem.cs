using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Teste_JSL.Model
{
    public class Viagem
    {
        public int Id { get; set; }
        public Motorista Motorista { get; set; }
        public Endereco LocalEntrega { get; set; }
        public Endereco LocalSaida { get; set; }
        public double DistanciaEmKM { get; set; }
    }
}
