using EventosRC.Entidades;
using EventosRC.Infra.Data.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data
{
    public  class PessoaRepository
    {
        public IRepository<Pessoa> GetRepository { get; private set; }

        public PessoaRepository()
        {
            GetRepository = new MongoRepository<Pessoa>();
        }
    }
}
