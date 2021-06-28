using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Teste_JSL.Model
{
    public class Motorista : Pessoa
    {
        public Caminhao Caminhao { get; set; }

    }
}
