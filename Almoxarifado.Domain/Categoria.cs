using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Categoria
    {
        private string? nome;
        private string? descricao;

        public string? Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string? Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public Categoria(string? nome, string? descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da categoria não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição da categoria não pode ser nula ou vazia.");
            }

            Nome = nome;
            Descricao = descricao;
        }
    }

}
