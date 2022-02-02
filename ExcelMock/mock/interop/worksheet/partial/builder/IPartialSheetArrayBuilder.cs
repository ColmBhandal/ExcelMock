using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.worksheet.partial.data;

namespace ExcelMock.mock.interop.worksheet.partial.builder
{
    internal interface IPartialSheetArrayBuilder
    {
        ISparseArray2D<ICellData> Build();
        IPartialSheetArrayBuilder WithFormulas(int row, int column, string[,] formulas);
        IPartialSheetArrayBuilder WithValues(int valueRow, int valueColumn, string[,] values);
    }
}