using System;
using Xunit;
using ExpectedObjects;
using Almoxarifado.Domain.Builders;
using Almoxarifado.Domain;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Almoxarifado.Test
{
    public class UsuarioTest
    {
        private string _documento;
        private string _nome;
        private DateTime _dataNasc;
        private bool _adm;

        public UsuarioTest()
        {
            Faker faker = new Faker();  
            faker.Locale = "pt_BR";
            _documento = faker.Person.Cpf(false);
            _nome = faker.Person.FullName;
            _dataNasc = faker.Date.Between(DateTime.MinValue, DateTime.Now.AddYears(-18));
            _adm = faker.Random.Bool();
        }

        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            // Arrange
            var usuarioEsperado = new
            {
                Documento = _documento,
                Nome = _nome,
                DataNasc = _dataNasc,
                Adm = _adm
            };

            // Act
            Usuario usuarioCriado = new Usuario(
                usuarioEsperado.Documento,
                usuarioEsperado.Nome,
                usuarioEsperado.DataNasc,
                usuarioEsperado.Adm
            );

            // Assert
            usuarioEsperado.ToExpectedObject().ShouldMatch(usuarioCriado);
        }

        [Fact]
        public void UsuarioAdmInvalido()
        {
            Assert.Throws<ArgumentException>(() => new UsuarioBuilder().SetAdministrador(null).Build());
        }
    }
}
