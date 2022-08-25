namespace MinhasFinancas.Domain.Commands.Usuarios.Validations
{
    public class UpdateUsuarioValidation : UsuarioValidation<UpdateUsuarioCommand>
    {
        public UpdateUsuarioValidation()
        {
            ValidarId();
            ValidarEmail();
        }
    }
}
