using ExcelMock.build.builder.interop.worksheet;

namespace ExcelMock.Factory
{
    /// <summary>
    /// A builder factory provides methods to construct builders
    /// Builders in turn are used to configure mock objects
    /// </summary>
    public interface IBuilderFactory
    {
        /// <summary>
        /// Creates a new worksheet builder
        /// </summary>
        /// <returns>A new worksheet builder</returns>
        IWorksheetBuilder NewWorksheetBuilder();
    }
}