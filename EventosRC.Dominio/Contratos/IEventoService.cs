using EventosRC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Contratos
{
    public interface IEventoService : IBase<Evento>
    {
        long GetTotalEventos();
    }
}
