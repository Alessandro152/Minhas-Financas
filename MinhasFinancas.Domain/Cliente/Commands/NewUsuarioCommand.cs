using FluentValidation.Results;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Cliente.Commands
{
    public class NewUsuarioCommand : Command
    {
        public NewUsuarioCommand(string nome, string cidade, string Uf, string email, string senha)
        {
            Nome = nome;
            Cidade = cidade;
            UF = Uf;
            Email = email;
            PassWord = senha;
        }

        public string Nome { get; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Email { get; }

        public string PassWord { get; }

        public ValidationResult IsValid()
        {
            return new UsuarioValidation().Validate(this);
        }
    }
}
