namespace MinhasFinancas.Domain.ValueObjects
{
    public class LoginVO
    {
        public LoginVO()
        {

        }

        public LoginVO(string email, string passWord)
        {
            Email = email;
            Password = passWord;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
