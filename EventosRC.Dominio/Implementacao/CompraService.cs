using EventoRc.Shared;
using EventosRC.Dominio.Contratos;
using EventosRC.Infra.Data;
using EventosRC.Infra.Data.Entidades;
using EventosRC.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.Implementacao
{
    public class CompraService : ICompraService
    {
        CompraRepository rep;
        PessoaRepository pessoa;

        public CompraService()
        {
            rep = new CompraRepository();
            pessoa = new PessoaRepository();
        }

        public void Add(Compra entidade)
        {
            try
            {
                entidade.Cartao.Numero = CriptUtilMd5.GerarHashMd5(entidade.Cartao.Numero);
                entidade.Cartao.Cvv = CriptUtilMd5.GerarHashMd5(entidade.Cartao.Cvv);

                rep.GetRepository.Add(entidade);

                var _pessoa = pessoa.GetRepository.Where(x => x.Cpf.Equals(entidade.Cpf)).FirstOrDefault();

                if (_pessoa != null)
                    EmailHelper.EnviarEmail(string.Format("Seu Valor em compras : {0}", entidade.ValorTotal.ToString()), _pessoa.Email);
            }
            catch(Exception e) {
                throw e;
            }
            
        }

        public void Deletar(Compra entidade)
        {
            throw new NotImplementedException();
        }

        public Compra GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Compra> GetSuasCompras(string cpf)
        {
            return rep.GetRepository.Where(x => x.Cpf.Equals(cpf)).ToList();
        }

        public List<Compra> GetTodos()
        {
            return rep.GetRepository.ToList();
        }
    }
}
