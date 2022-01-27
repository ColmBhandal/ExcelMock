
using ExcelMock.configure.configuration;
using Moq;

namespace ExcelMock.configure.configurer._base
{
    internal interface IConfigurer<TObj, TConfig>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        TObj Object { get; }

        void WithMockSetup(Action<Mock<TObj>> setup);
        void WithConfigSetup(Action<TConfig> setup);
    }
}