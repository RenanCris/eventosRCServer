using EventosRC.Infra.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Contratos
{
    public interface ICompraService : IBase<Compra>
    {
        ICollection<Compra> GetSuasCompras(string cpf);
    }
}
