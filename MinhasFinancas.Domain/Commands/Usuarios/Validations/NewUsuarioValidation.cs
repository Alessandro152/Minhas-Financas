namespace MinhasFinancas.Domain.Commands.Usuarios.Validations
{
    public class NewUsuarioValidation : UsuarioValidation<NewUsuarioCommand>
    {
        public NewUsuarioValidation()
        {
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
        }
    }
}
