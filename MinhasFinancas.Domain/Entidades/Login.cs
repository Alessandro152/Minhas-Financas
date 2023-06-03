using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Entidades
{
    public class Login : Entidade
    {
        protected Login(){}

        public Login(string email, string password, int usuarioId)
        {
            Email = email;
            Senha = password;
            UsuarioId = usuarioId;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
    }
}
