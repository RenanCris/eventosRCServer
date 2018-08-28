using EventosRC.Infra.Data.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data.Repositorios
{
    public class CartaoRepository
    {
        public IRepository<Cartao> GetRepository { get; private set; }

        public CartaoRepository()
        {
            GetRepository = new MongoRepository<Cartao>();
        }
    }
}
