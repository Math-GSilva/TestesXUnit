using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Builders
{
    public class FornecedorBuilder : PessoaBuilder
    {
        private string? nomeFantasia = "aaaaaaaaaaa";

        public FornecedorBuilder SetNomeFantasia(string nomeFantasia)
        {
            this.nomeFantasia = nomeFantasia;
            return this;
        }

        public new Fornecedor Build()
        {
            return new Fornecedor(this.documento, this.nome, this.dataNasc, this.nomeFantasia);
        }
    }


}
