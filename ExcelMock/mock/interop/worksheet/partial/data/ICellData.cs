namespace ExcelMock.mock.interop.worksheet.partial.data
{
    /// <summary>
    /// Backing type for data inside the cells of a mock worksheet.
    /// </summary>
    public interface ICellData
    {
        /// <summary>
        /// The formula inside a cell
        /// </summary>
        string Formula { get; set; }

        /// <summary>
        /// The value inside a cell
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Compare this cell for equality against another one
        /// </summary>
        /// <param name="other">The other cell against which to compare</param>
        /// <returns>True iff all the data in this cell matches the other one</returns>
        bool IsEqual(ICellData other);
    }
}