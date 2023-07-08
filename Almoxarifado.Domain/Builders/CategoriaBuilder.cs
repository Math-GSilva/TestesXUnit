namespace Almoxarifado.Domain.Builders
{
    public class CategoriaBuilder
    {
        private string? nome = "blablabla";
        private string? descricao = "blablabla";

        public CategoriaBuilder SetNome(string? nome)
        {
            this.nome = nome;
            return this;
        }

        public CategoriaBuilder SetDescricao(string? descricao)
        {
            this.descricao = descricao;
            return this;
        }

        public Categoria Build()
        {
            return new Categoria(nome, descricao);
        }
    }

}
