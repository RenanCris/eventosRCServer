using EventosRC.Dominio.Contratos;
using EventosRC.Entidades;
using EventosRC.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Implementacao
{
    public class EventoService : IEventoService
    {
        EventoRepository rep;

        public EventoService()
        {
            rep = new EventoRepository();
        }

        public void Add(Evento entidade)
        {
            rep.GetRepository.Add(entidade);
        }

        public void Deletar(Evento entidade)
        {
            rep.GetRepository.Delete(entidade);
        }

        public Evento GetById(string id)
        {
            return rep.GetRepository.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Evento> GetTodos()
        {
            return rep.GetRepository.ToList();
        }

        public long GetTotalEventos()
        {
            return rep.GetRepository.Count();
        }
    }
}
