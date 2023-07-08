using System;
using Xunit;
using ExpectedObjects;
using global::Almoxarifado.Domain.Builders;
using global::Almoxarifado.Domain;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Almoxarifado.Test
{
    public class PessoaTest
    {
        private string _documento;
        private string _nome;
        private DateTime _dataNasc;

        public PessoaTest()
        {
            Faker faker = new Faker();
            faker.Locale = "pt_BR";
            _documento = faker.Person.Cpf(false);
            _nome = faker.Name.FullName();
            _dataNasc = faker.Date.Between(DateTime.MinValue, DateTime.Now.AddYears(-18));
        }

        [Fact]
        public void DeveCriarPessoaComSucesso()
        {
            // Arrange
            var pessoaEsperada = new
            {
                Documento = _documento,
                Nome = _nome,
                DataNasc = _dataNasc
            };

            // Act
            Pessoa pessoaCriada = new Pessoa(
                pessoaEsperada.Documento,
                pessoaEsperada.Nome,
                pessoaEsperada.DataNasc
            );

            // Assert
            pessoaEsperada.ToExpectedObject().ShouldMatch(pessoaCriada);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void PessoaDocumentoInvalido(string documento)
        {
            Assert.Throws<ArgumentException>(() => new PessoaBuilder().SetDocumento(documento).Build());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void PessoaNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(() => new PessoaBuilder().SetNome(nome).Build());
        }

        [Fact]
        public void PessoaDataNascInvalida()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataMenor18Anos = dataAtual.AddYears(-17);

            Assert.Throws<ArgumentException>(() => new PessoaBuilder().SetDataNascimento(dataMenor18Anos).Build());
        }
    }
}

