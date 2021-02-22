using System.Threading.Tasks;
using Aplicacao.Business.Interfaces;
using Aplicacao.Business.Services;
using Aplicacao.Core.Models;
using Aplicacao.Tests.Service;
using Moq;
using NUnit.Framework;

namespace Aplicacao.Tests
{
    public class UserServiceTest
    {
        UserService _userService;
        Mock<IUserRepository> _userRepository;


        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.FindAll()).Returns(UserMock.GetUsers());
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public void FindAllSucess()
        {
            _userRepository.Setup(x => x.FindAll()).Returns(UserMock.GetUsers());

            var result = _userService.FindAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public void EditUserSucess()
        {
            _userRepository.Setup(x => x.EditUser(It.IsAny<User>())).Returns(UserMock.GetUser());

            var result = _userService.EditUser(It.IsAny<User>());
            Assert.IsNotNull(result);
        }

    }
}