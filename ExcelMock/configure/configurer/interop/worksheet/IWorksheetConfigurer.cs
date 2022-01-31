using ExcelMock.configure.configuration.interop.worksheet;
using ExcelMock.configure.configurer._base;
using Microsoft.Office.Interop.Excel;

namespace ExcelMock.configure.configurer.interop.worksheet
{
    public interface IWorksheetConfigurer
        : IConfigurer<Worksheet, IWorksheetConfiguration, IWorksheetConfigurer>
    {
    }
}