using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Movimentacao
    {
        public EnumTipo? Tipo { get; }
        public DateTime? Data { get; }
        public Usuario? UsuarioCadastro { get; }
        public Pessoa? Pessoa { get; }
        public Produto? Produto { get; }
        public double? Quantidade { get; }

        public Movimentacao(EnumTipo? tipo, DateTime? data, Usuario? usuarioCadastro, Pessoa? pessoa, Produto? produto, double? quantidade)
        {
            if (tipo == null)
            {
                throw new ArgumentException("O tipo de movimentação é inválido.");
            }

            if (data == null)
            {
                throw new ArgumentException("A data da movimentação é obrigatória.");
            }

            if (usuarioCadastro == null)
            {
                throw new ArgumentException("O usuário de cadastro é obrigatório.");
            }

            if (pessoa == null)
            {
                throw new ArgumentException("A pessoa é obrigatória.");
            }

            if (produto == null)
            {
                throw new ArgumentException("O produto é obrigatório.");
            }

            if (quantidade == null || quantidade <= 0 || (tipo == EnumTipo.Saida && quantidade > produto.Estoque))
            {
                throw new ArgumentException("Informe uma quantidade válida.");
            }

            if(tipo == EnumTipo.Saida)
            {
                produto.Estoque -= quantidade;
            } 
            else if(tipo == EnumTipo.Entrada) 
            {
                produto.Estoque += quantidade;
            }

            Tipo = tipo;
            Data = data;
            UsuarioCadastro = usuarioCadastro;
            Pessoa = pessoa;
            Produto = produto;
            Quantidade = quantidade;
        }

        public enum EnumTipo
        {
            Saida,
            Entrada
        }
    }
}
