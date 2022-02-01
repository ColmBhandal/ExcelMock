using ExcelMock.mock.interop.range.partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial
{
    internal class PartialSheetImpl : IPartialSheet
    {
        public IPartialSheetArea Range(int startRow, int startCol, int endRow, int endCol)
        {
            //TODO: Implement
            return new PartialSheetAreaImpl(1, 1, 1, 1, this);
        }
    }
}
