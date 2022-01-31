using ExcelMock.configure.configurer.interop.worksheet;

namespace ExcelMock.Factory
{
    /// <summary>
    /// A configurer factory provides methods to construct configurers
    /// Configurers in turn are used to configure mock objects
    /// </summary>
    public interface IConfigurerFactory
    {
        /// <summary>
        /// Creates a new worksheet configurer
        /// </summary>
        /// <returns>A new worksheet configurer</returns>
        IWorksheetConfigurer NewWorksheetConfigurer();
    }
}