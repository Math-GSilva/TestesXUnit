using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Builders
{
    public class PessoaBuilder
    {
        protected string? nome = "Matheus G";
        protected string? documento = "11111111111";
        protected DateTime? dataNasc = DateTime.Now.AddYears(-19);

        public PessoaBuilder SetDocumento(string? documento)
        {
            this.documento = documento;
            return this;
        }

        public PessoaBuilder SetNome(string? nome)
        {
            this.nome = nome;
            return this;
        }

        public PessoaBuilder SetDataNascimento(DateTime? dataNasc)
        {
            this.dataNasc = dataNasc;
            return this;
        }

        public Pessoa Build()
        {
            return new Pessoa(documento, nome, dataNasc);
        }
    }
}

