using ExcelMock.build.builder._base;
using Microsoft.Office.Interop.Excel;

namespace ExcelMock.build.builder.interop.worksheet
{
    /// <summary>
    /// A class for building mock worksheets.
    /// </summary>
    public interface IWorksheetBuilder: IBuilder<Worksheet, IWorksheetBuilder>
    {
    }
}