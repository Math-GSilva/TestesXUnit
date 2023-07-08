using ExpectedObjects;
using Almoxarifado.Domain.Builders;
using Almoxarifado.Domain;
using static Almoxarifado.Domain.Movimentacao;
using Bogus;

namespace Almoxarifado.Test
{
    public class MovimentacaoTest
    {
        private EnumTipo _tipo;
        private DateTime _data;
        private Usuario _usuarioCadastro;
        private Pessoa _pessoa;
        private Produto _produto;
        private double _quantidade;

        public MovimentacaoTest()
        {
            Faker faker = new Faker();
            faker.Locale = "pr_BR";
            _tipo = faker.Random.Enum<EnumTipo>();
            _data = faker.Date.Between(DateTime.MinValue, DateTime.Now.AddYears(-18)); ;
            _usuarioCadastro = new UsuarioBuilder().Build();
            _pessoa = new PessoaBuilder().Build();
            _produto = new ProdutoBuilder().Build();
            _quantidade = faker.Random.Double(1, (double)_produto.Estoque);
        }

        [Fact]
        public void DeveCriarMovimentacaoComSucesso()
        {
            // Arrange
            var movimentacaoEsperada = new
            {
                Tipo = _tipo,
                Data = _data,
                UsuarioCadastro = _usuarioCadastro,
                Pessoa = _pessoa,
                Produto = _produto,
                Quantidade = _quantidade
            };

            // Act
            Movimentacao movimentacaoCriada = new Movimentacao(
                movimentacaoEsperada.Tipo,
                movimentacaoEsperada.Data,
                movimentacaoEsperada.UsuarioCadastro,
                movimentacaoEsperada.Pessoa,
                movimentacaoEsperada.Produto,
                movimentacaoEsperada.Quantidade
            );

            // Assert
            movimentacaoEsperada.ToExpectedObject().ShouldMatch(movimentacaoCriada);
        }

        [Theory]
        [InlineData(null)]
        public void MovimentacaoTipoInvalido(EnumTipo? tipo)
        {
            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
                .SetTipo(tipo)
                .Build());
        }

        [Fact]
        public void MovimentacaoDataInvalida()
        {
            DateTime dataInvalida = DateTime.MinValue;

            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
                .SetData(null)
                .Build());
        }

        [Fact]
        public void MovimentacaoUsuarioCadastroInvalido()
        {
            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
            .SetUsuarioCadastro(null)
                .Build());
        }

        [Fact]
        public void MovimentacaoPessoaInvalida()
        {
            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
                .SetPessoa(null)
                .Build());
        }

        [Fact]
        public void MovimentacaoProdutoInvalido()
        {
            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
                .SetProduto(null)
                .Build());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void MovimentacaoQuantidadeInvalida(int quantidadeInvalida)
        {
            Assert.Throws<ArgumentException>(() => new MovimentacaoBuilder()
                .SetQuantidade(quantidadeInvalida)
                .Build());
        }

        [Theory]
        [InlineData(EnumTipo.Entrada, 5)]
        [InlineData(EnumTipo.Saida, 5)]
        public void MovimentacaoDeveAbaixarOEstoqueDoProduto(EnumTipo tipoOperacao, double qtd)
        {
            Produto produto = new ProdutoBuilder().Build();
            double qtdEsperada = tipoOperacao == EnumTipo.Saida 
                ? ((double)produto.Estoque) - qtd 
                : ((double)produto.Estoque) + qtd;

            Movimentacao movimentacao = new MovimentacaoBuilder()
                .SetQuantidade(qtd)
                .SetTipo(tipoOperacao)
                .SetProduto(produto)
                .Build();


            Assert.Equal(qtdEsperada, movimentacao.Produto.Estoque);
        }
    }
}
