using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Fornecedor : Pessoa
    {
        public string? NomeFantasia { get; }

        public Fornecedor(string? documento, string? nome, DateTime? dataNasc, string? nomeFantasia)
            : base(documento, nome, dataNasc)
        {

            if (string.IsNullOrWhiteSpace(nomeFantasia))
            {
                throw new ArgumentException("O nome fantasia do fornecedor não pode ser nulo ou vazio.");
            }

            NomeFantasia = nomeFantasia;
        }
    }

}
