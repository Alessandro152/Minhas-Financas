using MediatR;
using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Cliente.Commands
{
    public class NewUsuarioCommand : Command
    {
        public NewUsuarioCommand(string nome, string email, string passWord)
        {
            Nome = nome;
            Email = email;
            PassWord = passWord;
        }

        public string Nome { get; }

        public string Email { get; }

        public string PassWord { get; }
    }
}
