
using ExcelMock.configure.configuration;
using Moq;

namespace ExcelMock.configure.configurer._base
{
    public interface IConfigurer<TObj, TConfig, TSelf>
        where TSelf: IConfigurer<TObj, TConfig, TSelf>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        TObj Object { get; }

        TSelf WithMockSetup(Action<Mock<TObj>> setup);
        TSelf WithConfigSetup(Action<TConfig> setup);
    }
}