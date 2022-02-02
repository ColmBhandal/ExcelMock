using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial.data
{
    internal abstract class CellDataBase : ICellData
    {
        public abstract string Formula { get; set; }
        public abstract string Value { get; set; }

        public bool IsEqual(ICellData other)
        {
            return (Formula == other.Formula
                && Value == other.Value);
        }

        public override string? ToString()
        {
            return $"(v: {Value}, f: {Formula})";
        }
    }
}
