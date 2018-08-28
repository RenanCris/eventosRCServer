using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Entidades
{
    public class Evento
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Endereco { get; set; }
        public int Qtd { get; set; }
        public decimal Valor { get; set; }
    }
}
