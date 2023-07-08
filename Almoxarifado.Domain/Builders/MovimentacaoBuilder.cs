using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Almoxarifado.Domain.Movimentacao;

namespace Almoxarifado.Domain.Builders
{
    public class MovimentacaoBuilder
    {
        private EnumTipo? tipo = EnumTipo.Entrada;
        private DateTime? data = DateTime.Now.AddDays(-42).AddYears(-18);
        private Usuario? usuarioCadastro = new UsuarioBuilder().Build();
        private Pessoa? pessoa = new PessoaBuilder().Build();
        private Produto? produto = new ProdutoBuilder().Build();
        private double? quantidade = 1;

        public MovimentacaoBuilder SetTipo(EnumTipo? tipo)
        {
            this.tipo = tipo;
            return this;
        }

        public MovimentacaoBuilder SetData(DateTime? data)
        {
            this.data = data;
            return this;
        }

        public MovimentacaoBuilder SetUsuarioCadastro(Usuario? usuarioCadastro)
        {
            this.usuarioCadastro = usuarioCadastro;
            return this;
        }

        public MovimentacaoBuilder SetPessoa(Pessoa? pessoa)
        {
            this.pessoa = pessoa;
            return this;
        }

        public MovimentacaoBuilder SetProduto(Produto? produto)
        {
            this.produto = produto;
            return this;
        }

        public MovimentacaoBuilder SetQuantidade(double? quantidade)
        {
            this.quantidade = quantidade;
            return this;
        }

        public Movimentacao Build()
        {
            return new Movimentacao(tipo, data, usuarioCadastro, pessoa, produto, quantidade);
        }
    }

}
