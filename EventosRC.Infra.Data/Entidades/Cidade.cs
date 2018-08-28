using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data.Entidades
{
    public class Cidade : Entity
    {
        public string Descricao { get; set; }
    }
}
