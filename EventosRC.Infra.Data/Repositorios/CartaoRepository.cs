using EventosRC.Infra.Data.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data.Repositorios
{
    public class CompraRepository
    {
        public IRepository<Compra> GetRepository { get; private set; }

        public CompraRepository()
        {
            GetRepository = new MongoRepository<Compra>();
        }
    }
}
