
using Moq;

namespace ExcelMock.configure.configurer._base
{
    internal interface IConfigurer<TObj>
        where TObj : class
    {
        TObj Object { get; }

        void WithMockSetup(Action<Mock<TObj>> setup);
    }
}