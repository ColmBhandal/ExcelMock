using ExcelMock.mock.interop.worksheet.partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.range.partial
{
    internal class PartialSheetAreaImpl : IPartialSheetArea
    {
        public string AddressLocal => "TODO: Implement";
        private readonly int _startRow;
        private readonly int _startCol;
        private readonly int _endRow;
        private readonly int _endCol;

        private readonly IPartialSheet _parent;

        public PartialSheetAreaImpl(int startRow, int startCol,
            int endRow, int endCol, IPartialSheet parent)
        {
            _startRow = startRow;
            _startCol = startCol;
            _endRow = endRow;
            _endCol = endCol;
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }
    }
}
