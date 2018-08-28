using EventosRC.Dominio.Contratos;
using EventosRC.Infra.Data.Entidades;
using EventosRC.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Implementacao
{
    public class CartaoService : ICartaoService
    {
        CartaoRepository rep;

        public CartaoService()
        {
            rep = new CartaoRepository();
        }

        public void Add(Cartao entidade)
        {
            rep.GetRepository.Add(entidade);
        }

        public void Deletar(Cartao entidade)
        {
            throw new NotImplementedException();
        }

        public Cartao GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Cartao> GetTodos()
        {
            throw new NotImplementedException();
        }
    }
}
