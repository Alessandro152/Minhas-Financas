using System;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class CadastroViewModel
    {
        public Guid UsuarioId { get; internal set; }

        public string UsuarioNome { get; set; }

        public string LogradouroTipo { get; set; }

        public string LogradouroNome { get; set; }

        public string LogradouroNumero { get; set; }

        public string LogradouroBairro { get; set; }

        public string LogradouroCep { get; set; }

        public string LogradouroCidade { get; set; }

        public string LogradouroEstado { get; set; }

        public string UsuarioEmail { get; set; }

        public string UsuarioSenha { get; set; }
    }
}
