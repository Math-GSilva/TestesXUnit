using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Produto
    {
        public string? Nome { get; }
        public double? Valor { get; }
        public double? Estoque { get; set; }
        public DateTime? UltimoAbastecimento { get; }
        public DateTime? ProximoAbastecimento { get; }
        public Categoria? Categoria { get; }

        public Produto(string? nome, double? valor, double? estoque, DateTime? ultimoAbastecimento, DateTime? proximoAbastecimento, Categoria? categoria)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
            {
                throw new ArgumentException("O nome do produto deve ter mais de um caractere.");
            }
            if (valor == null || valor <= 0)
            {
                throw new ArgumentException("O valor do produto deve ser maior que zero.");
            }
            if (estoque == null || estoque < 0)
            {
                throw new ArgumentException("O estoque do produto não pode ser negativo.");
            }
            if (ultimoAbastecimento == null || ultimoAbastecimento > DateTime.Now)
            {
                throw new ArgumentException("A data de último abastecimento não pode ser maior que a data atual.");
            }
            if(categoria == null)
            {
                throw new ArgumentException("Por favor, informe uma categoria");
            }

            Nome = nome;
            Valor = valor;
            Estoque = estoque;
            UltimoAbastecimento = ultimoAbastecimento;
            ProximoAbastecimento = proximoAbastecimento;
            Categoria = categoria;
        }
    }
}
