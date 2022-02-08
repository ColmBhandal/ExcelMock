using CsharpExtras._Enumerable.OneBased;

namespace ExcelMock.mock.interop.range.partial
{
    internal interface IPartialSheetArea
    {
        IOneBasedArray2D<string> Formulas { get; set; }
        IOneBasedArray2D<string> Values { get; set; }
    }
}