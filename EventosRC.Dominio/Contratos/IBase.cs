using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Contratos
{
    public interface IBase<T> where T: class
    {
        void Add(T entidade);
        T GetById(string id);
        void Deletar(T entidade);
        List<T> GetTodos();
    }
}
