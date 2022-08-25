using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Domain.Commands.Usuarios.Validations;

namespace MinhasFinancas.Domain.Cliente.Validations
{
    public class NewUsuarioValidation : UsuarioValidation<NewUsuarioCommand>
    {
        public NewUsuarioValidation()
        {
            ValidarNome();
            ValidarEmail();
        }
    }
}
