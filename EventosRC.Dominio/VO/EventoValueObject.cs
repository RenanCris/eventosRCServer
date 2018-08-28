using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Dominio.VO
{
    public class EventoValueObject
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Endereco { get; set; }
        public decimal Valor { get; set; }
        public string TipoEvento { get; set; }
        public string Cidade { get; set; }
    }
}
