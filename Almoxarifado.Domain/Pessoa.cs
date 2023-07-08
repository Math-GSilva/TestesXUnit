using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Pessoa
    {
        public string Documento { get; }
        public string Nome { get; }
        public DateTime DataNasc { get; }

        public Pessoa(string? documento, string? nome, DateTime? dataNasc)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("O documento da pessoa não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da pessoa não pode ser nulo ou vazio.");
            }

            if (dataNasc == null || dataNasc > DateTime.Now.AddYears(-18))
            {
                throw new ArgumentException("Informe uma data de nascimento válida!");
            }


            Documento = documento;
            Nome = nome;
            DataNasc = (DateTime)dataNasc;
        }
    }

}
