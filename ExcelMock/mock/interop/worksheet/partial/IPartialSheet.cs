using ExcelMock.mock.interop.range.partial;

namespace ExcelMock.mock.interop.worksheet.partial
{
    internal interface IPartialSheet
    {
        IPartialSheetArea Range(int startRow, int startCol, int endRow, int endCol);
    }
}