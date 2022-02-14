using ExcelMock.Factory;

namespace ExcelMock
{
    /// <summary>
    /// Entry point for all types within the ExcelMock library.
    /// </summary>
    public interface IExcelMockApi
    {
        /// <summary>
        /// The builder factory allows for the creation of new builders.
        /// See <see cref="IBuilderFactory"/>
        /// </summary>
        IBuilderFactory BuilderFactory { get; }
    }
}