using EventosRC.Dominio.Contratos;
using EventosRC.Infra.Data;
using EventosRC.Infra.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Implementacao
{
    public class CidadeService : ICidadeService
    {
        CidadeRepository rep;

        public CidadeService()
        {
            rep = new CidadeRepository();
        }

        public void Add(Cidade cidade)
        {
            rep.GetRepository.Add(cidade);
        }

        public void Deletar(Cidade entidade)
        {
            rep.GetRepository.Delete(entidade);
        }

        public Cidade GetById(string id)
        {
            return rep.GetRepository.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Cidade> GetTodos()
        {
            return rep.GetRepository.ToList();
        }
    }
}
