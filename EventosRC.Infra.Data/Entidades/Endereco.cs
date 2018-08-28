using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Entidades
{
    public class Endereco
    {
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
    }
}
