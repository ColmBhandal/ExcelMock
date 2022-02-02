using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial.data
{
    internal class MutableCellDataImpl : CellDataBase
    {
        public override string Formula { get; set; }

        public override string Value { get; set; }

        public MutableCellDataImpl(string formula, string value)
        {
            Formula = formula ?? throw new ArgumentNullException(nameof(formula));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
