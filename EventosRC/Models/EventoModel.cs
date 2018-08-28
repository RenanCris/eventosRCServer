using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventosRC.Models
{
    public class EventoModel
    {
        [Required(ErrorMessage = "Informe a Descrição!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a Data!")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Informe o Endereço!")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Informe a quantidade!")]
        [Range(1,10000,ErrorMessage ="Quantidade Peritida {1} até {2}")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Informe o Tipo do Evento")]
        public string TipoEvento { get; set; }
        [Required(ErrorMessage = "Informe a Cidade!")]
        public string Cidade { get; set; }
    }
}