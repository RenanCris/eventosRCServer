using EventosRC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventosRC.Models
{
    public class PessoaModel
    {
        [Required(ErrorMessage ="Informe o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Data de Nascimento!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o Sexo!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Informe o Endereço!")]
        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Senha { get; set; }
    }
}