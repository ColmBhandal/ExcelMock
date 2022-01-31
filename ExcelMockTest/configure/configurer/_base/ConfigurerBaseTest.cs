using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.configure.configurer._base
{
    [TestFixture, Category("Unit")]
    public class ConfigurerBaseTest
    {
        [Test]
        public void GIVEN_OtherConfigurer_WHEN_WithConfigSetupOtherFooCallback_THEN_FooInvocationTriggersCallback()
        {
            //Arrange
            OtherConfiguration configuration = new();
            OtherConfigurer configurer = new OtherConfigurer(configuration);
            Mock<IHandler> mockHandler = new();
            mockHandler.Setup(h => h.Handle()).Verifiable();
            void Setup(OtherConfiguration configuration)
            {
                configuration.Other.Setup(o => o.Foo()).Callback(() => mockHandler.Object.Handle());
            }

            //Act
            configurer.WithConfigSetup(Setup);

            //Assert
            mockHandler.Verify(h => h.Handle(), Times.Never(), "Handler should not have been called yet");
            ITestObj obj = configurer.Object;
            obj.Foo();
            mockHandler.Verify(h => h.Handle(), Times.Once());
        }
    }

    interface ITestObj
    {
        void Foo();
    }

    interface IHandler
    {
        void Handle();
    }

    class OtherConfigurer : ConfigurerBase<ITestObj, OtherConfiguration, OtherConfigurer>
    {
        public OtherConfigurer(OtherConfiguration configuration) : base(configuration)
        {
        }

        protected override OtherConfigurer Self => this;

        protected override ITestObj CreateObject() =>
            _configuration.Other.Object;
    }

    class OtherConfiguration : IConfiguration<ITestObj>
    {
        public Mock<ITestObj> Mock => throw new NotImplementedException(
            "Other configuration is meant for testing acess to data other than the standard mock," +
            " so the standard mock is intentionally not implemented");
        public Mock<ITestObj> Other { get; } = new Mock<ITestObj>();
    }
}
