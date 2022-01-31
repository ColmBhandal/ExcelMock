using ExcelMock.Factory;

namespace ExcelMock
{
    public interface IExcelMockApi
    {
        IConfigurerFactory ConfigurerFactory { get; }
    }
}