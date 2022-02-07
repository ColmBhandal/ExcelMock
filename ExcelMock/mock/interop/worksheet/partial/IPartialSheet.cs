using CsharpExtras.Compare;
using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.range.partial;
using ExcelMock.mock.interop.worksheet.partial.data;

namespace ExcelMock.mock.interop.worksheet.partial
{
    internal interface IPartialSheet
    {
        ISparseArray2D<ICellData> BackingData { get; }

        IComparisonResult CompareUsedData(IPartialSheet other);
        IPartialSheetArea Range(int startRow, int startCol, int endRow, int endCol);
    }
}