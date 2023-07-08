using Almoxarifado.Domain.Builders;
using System;

namespace Almoxarifado.Domain
{
    public class ProdutoBuilder
    {
        private string? _nome = "blablalba";
        private double? _valor = 10;
        private double? _estoque = 10;
        private DateTime? _ultimoAbastecimento = DateTime.Now.AddDays(-50);
        private DateTime? _proximoAbastecimento = DateTime.Now.AddDays(50);
        private Categoria? _categoria = new CategoriaBuilder().Build();

        public ProdutoBuilder SetNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ProdutoBuilder SetValor(double? valor)
        {
            _valor = valor;
            return this;
        }

        public ProdutoBuilder SetEstoque(double? estoque)
        {
            _estoque = estoque;
            return this;
        }

        public ProdutoBuilder SetUltimoAbastecimento(DateTime? ultimoAbastecimento)
        {
            _ultimoAbastecimento = ultimoAbastecimento;
            return this;
        }

        public ProdutoBuilder SetProximoAbastecimento(DateTime? proximoAbastecimento)
        {
            _proximoAbastecimento = proximoAbastecimento;
            return this;
        }
        public ProdutoBuilder SetCategoria(Categoria? categoria)
        {
            _categoria = categoria;
            return this;
        }

        public Produto Build()
        {
            return new Produto(_nome, _valor, _estoque, _ultimoAbastecimento, _proximoAbastecimento, _categoria);
        }
    }
}
