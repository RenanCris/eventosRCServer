using EventosRC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Contratos
{
    public interface IPessoaService : IBase<Pessoa>
    {
        bool IsPessoaExistsByCpf(string cpf);
        Pessoa Autenticar(string cpf, string senha);
    }
}
