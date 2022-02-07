using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.worksheet.partial.data;

namespace ExcelMock.mock.interop.worksheet.partial.builder
{
    /// <summary>
    /// Used to build data for backing mock sheets
    /// </summary>
    public interface IPartialSheetArrayBuilder
    {
        /// <summary>
        /// Build the data
        /// </summary>
        /// <returns>An array of data backing a sheet</returns>
        ISparseArray2D<ICellData> Build();

        /// <summary>
        /// Buffers formulas at the given coordinates
        /// </summary>
        /// <param name="row">Topmost row of formula rectangle</param>
        /// <param name="column">Leftmost column of formula rectangle</param>
        /// <param name="formulas">Array of formulas to add to the sheet data</param>
        /// <returns>Reference to this builder</returns>
        IPartialSheetArrayBuilder WithFormulas(int row, int column, string[,] formulas);

        /// <summary>
        /// Buffers values at the given coordinates
        /// </summary>
        /// <param name="row">Topmost row of value rectangle</param>
        /// <param name="column">Leftmost column of value rectangle</param>
        /// <param name="values">Array of values to add to the sheet data</param>
        /// <returns>Reference to this builder</returns>
        IPartialSheetArrayBuilder WithValues(int row, int column, string[,] values);
    }
}