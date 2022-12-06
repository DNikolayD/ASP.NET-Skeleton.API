using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Data.Repositories;
using ASP.NET_Skeleton.Service;
using ASP.NET_Skeleton.Service.DTOs;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Skeleton.Tests
{
    public class Tests : BaseTest
    {
        private IBaseService _service = null!;

        private Mock<IBaseRepository> _repository = null!;
        private Mock<ILogger<BaseService<BaseFactory<BaseDto<string>>, BaseDto<string>>>> _logger = null!;
        private Mock<BaseFactory<BaseDto<string>>> _factory = null!;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IBaseRepository>();
            _logger = new Mock<ILogger<BaseService<BaseFactory<BaseDto<string>>, BaseDto<string>>>>();
            _factory = new Mock<BaseFactory<BaseDto<string>>>();
            _service = new ServiceForTests(_repository.Object,
                _factory.Object,
                _logger.Object
                );
        }

        [Test]
        public void Get_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.GetById(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.Get(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public async Task AddAsync_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.InsertAsync(It.IsAny<BaseRequest>())).ReturnsAsync(response);
            //Act
            var result = await _service.AddAsync(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public void Remove_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.Delete(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.Remove(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public void Update_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.Update(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.Update(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public void GetMany_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.GetMany(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.GetMany(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public void GetSorted_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.Sort(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.GetSorted(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        [Test]
        public void GetFiltered_ReturnsSuccess()
        {
            //Arrange
            var request = _fixture.Create<BaseRequest>();
            var response = _fixture.Create<BaseResponse>();
            _repository.Setup(x => x.Filter(It.IsAny<BaseRequest>())).Returns(response);
            //Act
            var result = _service.GetFiltered(request);
            //Assert
            Assert.That(result.IsSuccessful);
        }

        private class ServiceForTests : BaseService<BaseFactory<BaseDto<string>>, BaseDto<string>>
        {
            public ServiceForTests(IBaseRepository repository, BaseFactory<BaseDto<string>> factory, ILogger<BaseService<BaseFactory<BaseDto<string>>, BaseDto<string>>> logger) : base(repository, factory, logger)
            {
            }
        }
    }
}