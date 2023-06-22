using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Entidades.Usuarios
{
    public class Usuario : Entidade
    {
        protected Usuario(){}

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }

        public virtual UsuarioLogin Login { get; private set; }

        public void AddLogin(string email, string senha)
            => Login = new UsuarioLogin(email, senha, Id);

        public void Editar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
