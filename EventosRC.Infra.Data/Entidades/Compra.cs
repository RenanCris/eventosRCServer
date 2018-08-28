using EventosRC.Entidades;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Infra.Data.Entidades
{
    public class Compra : Entity
    {
        public ICollection<Evento> Eventos { get; set; }
        public decimal ValorTotal { get; set; }
        public string  Cpf { get; set; }
        public DateTime DataCompra { get; set; }
        public Cartao Cartao { get; set; }

        public Compra()
        {
            this.DataCompra = DateTime.Now;
        }
    }
}
