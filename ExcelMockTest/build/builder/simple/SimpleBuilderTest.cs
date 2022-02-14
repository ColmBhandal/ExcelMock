using ExcelMock.build.builder._base;
using ExcelMock.build.builder.simple;
using ExcelMock.build.exception;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.build.builder.simple
{
    [TestFixture, Category("Unit")]
    public class SimpleBuilderTest
    {
        [Test]
        public void GIVEN_SimpleBuilder_WHEN_WithMockSetupFooCallback_THEN_FooInvocationTriggersCallback()
        {
            //Arrange
            ISimpleBuilder<ITestObj> builder = new SimpleBuilderImpl<ITestObj>();
            Mock<IHandler> mockHandler = new();
            mockHandler.Setup(h => h.Handle()).Verifiable();
            void Setup(Mock<ITestObj> mock)
            {
                mock.Setup(o => o.Foo()).Callback(() => mockHandler.Object.Handle());
            }

            //Act
            builder.WithMockSetup(Setup);

            //Assert
            mockHandler.Verify(h => h.Handle(), Times.Never(), "Handler should not have been called yet");
            ITestObj obj = builder.Build();
            obj.Foo();
            mockHandler.Verify(h => h.Handle(), Times.Once());
        }

        [Test]
        public void GIVEN_SimpleBuilder_WHEN_BuildTwice_THEN_NotSameObjects()
        {
            //Arrange
            ISimpleBuilder<ITestObj> builder = new SimpleBuilderImpl<ITestObj>();

            //Act
            ITestObj object1 = builder.Build();
            ITestObj object2 = builder.Build();

            //Assert
            Assert.AreNotSame(object1, object2, "Successive calls to builder should build distinct objects");
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
