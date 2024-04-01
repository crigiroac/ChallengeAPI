using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.BusinessObjects.IServices;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Cases.PermissionCases;
using ChallengeAPI.UseCases.Common;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeAPI.Tests.Cases.PermissionCases
{
    public class CreatePermissionInteractorTests
    {
        private MockRepository mockRepository;

        private Mock<IPermissionRepository> mockPermissionRepository;
        private Mock<IOutputPort<CreatePermissionResponse>> mockOutputPort;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<IPermissionTypeRepository> mockPermissionTypeRepository;
        private Mock<IElasticsearchService> mockElasticsearchService;
        private Mock<IKafkaService> mockKafkaService;
        private Mock<IConfiguration> mockConfiguration;

        public CreatePermissionInteractorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPermissionRepository = this.mockRepository.Create<IPermissionRepository>();
            this.mockOutputPort = this.mockRepository.Create<IOutputPort<CreatePermissionResponse>>();
            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>();
            this.mockPermissionTypeRepository = this.mockRepository.Create<IPermissionTypeRepository>();
            this.mockElasticsearchService = this.mockRepository.Create<IElasticsearchService>();
            this.mockKafkaService = this.mockRepository.Create<IKafkaService>();
            this.mockConfiguration = this.mockRepository.Create<IConfiguration>();
        }

        private CreatePermissionInteractor CreateCreatePermissionInteractor()
        {
            return new CreatePermissionInteractor(
                this.mockPermissionRepository.Object,
                this.mockOutputPort.Object,
                this.mockUnitOfWork.Object,
                this.mockEmployeeRepository.Object,
                this.mockPermissionTypeRepository.Object,
                this.mockElasticsearchService.Object,
                this.mockKafkaService.Object,
                this.mockConfiguration.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var createPermissionInteractor = this.CreateCreatePermissionInteractor();
            CreatePermissionRequest request = null;

            // Act
            await createPermissionInteractor.Handle(
                request);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
