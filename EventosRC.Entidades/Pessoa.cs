using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosRC.Entidades
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Endereco Endereco { get; set; }

        public Pessoa()
        {
            this.Endereco = new Endereco();
        }
    }
}
