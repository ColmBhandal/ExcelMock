using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using ExcelMock.configure.configurer.simple;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.configure.configurer.simple
{
    [TestFixture, Category("Unit")]
    public class SimpleConfigurerTest
    {
        [Test]
        public void GIVEN_SimpleConfigurer_WHEN_MockSetupFooCallback_THEN_FooInvocationTriggersCallback()
        {
            //Arrange
            IConfiguration<ITestObj> configuration = new ConfigurationImpl<ITestObj>();
            IConfigurer<ITestObj> configurer = new SimpleConfigurerImpl<ITestObj>(configuration);
            Mock<IHandler> mockHandler = new Mock<IHandler>();
            mockHandler.Setup(h => h.Handle()).Verifiable();
            void Setup(Mock<ITestObj> mock)
            {
                mock.Setup(o => o.Foo()).Callback(() => mockHandler.Object.Handle());
            }

            //Act
            configurer.WithMockSetup(Setup);

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
}
