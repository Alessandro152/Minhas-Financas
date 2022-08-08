using System;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class CadastroViewModel
    {
        public Guid Id { get; internal set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
