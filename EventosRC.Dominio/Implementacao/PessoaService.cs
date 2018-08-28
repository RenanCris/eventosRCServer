using EventosRC.Dominio.Contratos;
using EventosRC.Entidades;
using EventosRC.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Implementacao
{
    public class PessoaService : IPessoaService
    {
        PessoaRepository rep = null;

        public PessoaService()
        {
            rep = new PessoaRepository();
        }

        public void Add(Pessoa entidade)
        {
            rep.GetRepository.Add(entidade);
        }

        public Pessoa Autenticar(string cpf, string senha)
        {
            return rep.GetRepository
                .Where(x => x.Cpf.Equals(cpf) && x.Senha.Equals(senha))
                .FirstOrDefault();
        }

        public void Deletar(Pessoa entidade)
        {
            rep.GetRepository.Add(entidade);
        }

        public Pessoa GetById(string id)
        {
            return rep.GetRepository.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Pessoa> GetTodos()
        {
            return rep.GetRepository.ToList();
        }

        public bool IsPessoaExistsByCpf(string cpf) {
            return rep.GetRepository.Any(x => x.Cpf.Equals(cpf));
        }

       
    }
}
