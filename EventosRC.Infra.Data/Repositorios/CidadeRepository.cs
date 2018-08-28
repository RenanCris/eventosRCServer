using EventosRC.Infra.Data.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data
{
    public  class CidadeRepository
    {
        public IRepository<Cidade> GetRepository { get; private set; }

        public CidadeRepository()
        {
            GetRepository = new MongoRepository<Cidade>();
        }
    }
}
