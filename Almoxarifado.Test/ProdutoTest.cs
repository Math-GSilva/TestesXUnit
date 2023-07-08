using System;
using ExpectedObjects;
using Bogus;
using Xunit;
using Almoxarifado.Domain;
using Almoxarifado.Domain.Builders;

namespace Almoxarifado.Test
{
    public class ProdutoTest
    {

        private string _nome;
        private double _valor;
        private double _estoque;
        private DateTime _dataUltimo;
        private DateTime _dataProximo;
        private Categoria _categoria;


        public ProdutoTest()
        {
            Faker faker = new Faker();
            faker.Locale = "pt_BR";
            _nome = faker.Random.String(10);
            _valor = faker.Random.Double(1);
            _estoque = faker.Random.Double(1);
            _dataUltimo = faker.Date.Past(1);
            _dataProximo = faker.Date.Future(1);
            _categoria = new CategoriaBuilder().Build();
        }

        [Fact]
        public void DeveCriarProdutoComSucesso()
        {
            // Arrange
            var produtoEsperado = new
            {
                Nome = _nome,
                Valor = _valor,
                Estoque = _estoque,
                UltimoAbastecimento = _dataUltimo,
                ProximoAbastecimento = _dataProximo,
                Categoria = _categoria
            };

            // Act
            Produto produtoCriado = new Produto(
                produtoEsperado.Nome,
                produtoEsperado.Estoque,
                produtoEsperado.Estoque,
                produtoEsperado.UltimoAbastecimento,
                produtoEsperado.ProximoAbastecimento,
                produtoEsperado.Categoria
                );

            // Assert
            produtoEsperado.ToExpectedObject().ShouldMatch(produtoCriado);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData(null)]
        public void ProdutoNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(() => new ProdutoBuilder().SetNome(nome).Build());
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(null)]
        public void ProdutoValorInvalido(double? valor)
        {
            Assert.Throws<ArgumentException>(() => new ProdutoBuilder().SetValor(valor).Build());
        }


        [Theory]
        [InlineData(-10.0)]
        [InlineData(null)]
        public void ProdutEstoqueInvalido(double? estoque)
        {
            Assert.Throws<ArgumentException>(() => new ProdutoBuilder().SetEstoque(estoque).Build());
        }

        [Theory]
        [MemberData(nameof(MeuMetodoDeDados))]
        [InlineData(null)]
        public void ProdutoUltAbastecimentoInvalido(DateTime? data)
        {
            Assert.Throws<ArgumentException>(() => new ProdutoBuilder().SetUltimoAbastecimento(data).Build());
        }

        [Theory]
        [InlineData(null)]
        public void ProdutoCategoriaInvalida(Categoria? categoria)
        {
            Assert.Throws<ArgumentException>(() => new ProdutoBuilder().SetCategoria(categoria).Build());
        }



        public static TheoryData<DateTime> MeuMetodoDeDados()
        {
            var dataAtual = DateTime.Now;
            var theoryData = new TheoryData<DateTime>
        {
            dataAtual.AddDays(100)
        };

            return theoryData;
        }
    }

}
