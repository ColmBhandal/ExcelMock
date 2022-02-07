using CsharpExtras.Compare;
using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.range.partial;
using ExcelMock.mock.interop.worksheet.partial.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial
{
    internal class PartialSheetImpl : IPartialSheet
    {
        public ISparseArray2D<ICellData> BackingData { get; }

        public PartialSheetImpl(ISparseArray2D<ICellData> data)
        {
            BackingData = data;
        }

        public IComparisonResult CompareUsedData(IPartialSheet other)
        {
            return BackingData.CompareUsedValues(other.BackingData, (c1, c2) => c1.IsEqual(c2));
        }

        public IPartialSheetArea Range(int startRow, int startCol, int endRow, int endCol)
        {
            //TODO: Implement
            return new PartialSheetAreaImpl(1, 1, 1, 1, this);
        }
    }
}
