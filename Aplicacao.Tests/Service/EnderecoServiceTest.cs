using Aplicacao.Business.Interfaces;
using Aplicacao.Business.Services;
using Aplicacao.Tests.Service;
using Moq;
using NUnit.Framework;

namespace Aplicacao.Tests
{
    public class EnderecoServiceTest
    {
        EnderecoService _enderecoService;
        Mock<IEnderecoRepository> _enderecoRepository;


        [SetUp]
        public void Setup()
        {
            _enderecoRepository = new Mock<IEnderecoRepository>();
            _enderecoRepository.Setup(x => x.FindAll()).Returns(EnderecoMock.GetEnderecos());
            _enderecoService = new EnderecoService(_enderecoRepository.Object);
        }

        [Test]
        public void FindAllSucess()
        {
            _enderecoRepository.Setup(x => x.FindAll()).Returns(EnderecoMock.GetEnderecos());

            var result = _enderecoService.FindAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetEnderecoByCepSucess()
        {
            var endereco = EnderecoMock.GetEndereco();
            _enderecoRepository.Setup(x => x.FindByCEP(It.IsAny<string>())).Returns(endereco);

            var result = _enderecoService.GetEnderecoByCep(It.IsAny<string>());
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateSucess()
        {
            var endereco = EnderecoMock.GetEndereco();
            _enderecoRepository.Setup(x => x.Create(It.IsAny<string>())).Returns(endereco);

            var result = _enderecoService.Create(It.IsAny<string>());
            Assert.IsNotNull(result);
        }
    }
}