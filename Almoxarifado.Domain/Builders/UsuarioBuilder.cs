using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Builders
{
    public class UsuarioBuilder : PessoaBuilder
    {
        private bool? adm = true;

        public UsuarioBuilder SetAdministrador(bool? adm)
        {
            this.adm = adm;
            return this;
        }

        public new Usuario Build()
        {
            return new Usuario(documento, nome, dataNasc, adm);
        }
    }

}
