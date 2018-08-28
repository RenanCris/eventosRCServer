using EventosRC.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data.Repositorios
{
    public class EventoRepository
    {
        public IRepository<Evento> GetRepository { get; private set; }
        public EventoRepository()
        {
            GetRepository = new MongoRepository<Evento>();
        }
    }
}
