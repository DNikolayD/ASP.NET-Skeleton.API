using System.Reflection;
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
        private Mock<ILogger<BaseService<TestFactory, TestDto>>> _logger = null!;
        private Mock<TestFactory> _factory = null!;
        private readonly TestValidator _validator = new();

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IBaseRepository>();
            _logger = new Mock<ILogger<BaseService<TestFactory, TestDto>>>();
            _factory = new Mock<TestFactory>();
            _factory.Setup(x => x.Validator).Returns(_validator);
            _service = new ServiceForTests(_repository.Object,
                _factory.Object,
                _logger.Object
                );
        }

        [Test]
        public void Get_ReturnsSuccess()
        {
            //Arrange
            var name = _fixture.Create<string>();
            var payload = _fixture.Build<TestDto>().With(x => x.Name, name).Create();
            var request = _fixture.Build<BaseRequest>().With(x => x.Payload, payload).Create();
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

        public class ServiceForTests : BaseService<TestFactory, TestDto>
        {
            public ServiceForTests(IBaseRepository repository, TestFactory factory, ILogger<BaseService<TestFactory, TestDto>> logger) : base(repository, factory, logger)
            {
            }
        }

        public class TestValidator : BaseValidator
        {
            public override void Validate(object obj)
            {
                var validators = Assembly.GetAssembly(typeof(TestValidator))!
                    .GetTypes()
                    .Where(myType => myType is {IsClass: true} && myType.IsSubclassOf(typeof(BaseValidator)))
                    .Select(type => (BaseValidator) Activator.CreateInstance(type)!)
                    .Select(dummy => dummy)
                    .ToList(); 
                validators.Sort();
                foreach (var type in validators.Select(validator => validator.GetType()))
                {
                    var parameters = new List<object> {obj}.ToArray();
                    var methods = type.GetMethods().Where(x => x.Name.Contains("SetRule")).ToList();
                    var methodName = methods.FirstOrDefault()!.Name;
                    foreach (var method in methods)
                    {
                        method.Invoke(this, parameters);
                    }
                }
                HasErrors = Errors.Any();
            }

            public void SetRule(object obj)
            {
                if (string.IsNullOrWhiteSpace(obj.MapTo<TestDto>().Name))
                {
                    Errors.Add("error"); //replace with ErrorConstructor
                }
            }
        }

        public class TestDto : BaseDto<string>
        {
            public string Name { get; set; } = string.Empty;
        }

        public class TestFactory : BaseFactory<TestDto>
        {
            public override BaseValidator Validator { get; set; } = new TestValidator();
        }
    }
}