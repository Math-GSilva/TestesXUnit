using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain
{
    public class Usuario : Pessoa
    {
        public bool? Adm { get; }

        public Usuario(string? documento, string? nome, DateTime? dataNasc, bool? adm)
            : base(documento, nome, dataNasc)
        {
            if (adm == null) throw new ArgumentException("Informe se o usuário é um adm!");
            Adm = adm;
        }
    }

}
