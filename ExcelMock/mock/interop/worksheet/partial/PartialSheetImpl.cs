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
        private ISparseArray2D<ICellData> _backingData;

        public PartialSheetImpl(ISparseArray2D<ICellData> data)
        {
            _backingData = data;
        }

        public IPartialSheetArea Range(int startRow, int startCol, int endRow, int endCol)
        {
            //TODO: Implement
            return new PartialSheetAreaImpl(1, 1, 1, 1, this);
        }
    }
}
