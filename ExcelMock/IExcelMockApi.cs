using ExcelMock.Factory;

namespace ExcelMock
{
    /// <summary>
    /// Entry point for all types within the ExcelMock library.
    /// </summary>
    public interface IExcelMockApi
    {
        /// <summary>
        /// The configurer factory allows for the creation of new configurers.
        /// See <see cref="IConfigurerFactory"/>
        /// </summary>
        IConfigurerFactory ConfigurerFactory { get; }
    }
}