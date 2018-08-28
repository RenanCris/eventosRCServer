using EventosRC.Dominio.VO;
using EventosRC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventosRC.Models
{
    public class CompraCartaoModel
    {
        [Required(ErrorMessage = "Informe o Número do Cartão!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o CVV!")]
        public string Cvv { get; set; }

        [Required(ErrorMessage = "Informe o Evento!")]
        public EventoValueObject[] Eventos { get; set; }

        [Required(ErrorMessage = "Informe o Valor!")]
        public decimal ValorTotal { get; set; }
    }
}