using Bogus;
using MinhasFinancas.Application.AppServices;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MinhasFinancas.UnitTest.Application
{
    public class UsuarioAppServiceHandlerTest
    {
        private readonly Mock<IBusHandler> _bus;
        private readonly Mock<IUsuarioQueryRepository> _queryHandler;
        private readonly Mock<IApplicationAdapter> _applicationAdapter;
        private Mock<IDomainNotification> _notification;
        private readonly UsuarioAppServiceHandler _usuarioAppService;

        public UsuarioAppServiceHandlerTest()
        {
            _bus = new Mock<IBusHandler>();
            _queryHandler = new Mock<IUsuarioQueryRepository>();
            _applicationAdapter = new Mock<IApplicationAdapter>();
            _notification = new Mock<IDomainNotification>();

            _usuarioAppService = new UsuarioAppServiceHandler(_bus.Object, _queryHandler.Object, _applicationAdapter.Object, _notification.Object);
        }

        public static IEnumerable<object[]> CreateUser()
        {
            var faker = new Faker();

            yield return new[]
            {
                new NewCadastroViewModel { Nome = faker.Random.Words(), Email = faker.Random.Words(), Senha = faker.Random.Words() }
            };
        }

        [Theory]
        [MemberData(nameof(CreateUser))]
        public void ShouldSignInUserWithSuccess(NewCadastroViewModel usuario)
        {
            _bus.Setup(s => s.SendCommand<dynamic, NewUsuarioCommand>(It.IsAny<NewUsuarioCommand>()));
            _applicationAdapter.Setup(s => s.RetornarDomainResult(It.IsAny<object>())).Returns(new ResultViewModel { });

            var result = _usuarioAppService.CadastrarUsuario(usuario);

            _bus.Verify(v => v.SendCommand<dynamic, NewUsuarioCommand>(It.IsAny<NewUsuarioCommand>()), Times.Once());
            _applicationAdapter.Verify(v => v.RetornarDomainResult(It.IsAny<NewUsuarioCommand>()), Times.Once());
        }
    }
}
