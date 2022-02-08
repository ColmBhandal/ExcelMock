using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial.data
{
    internal class ImmutableEmptyCellDataImpl : CellDataBase
    {
        public static ImmutableEmptyCellDataImpl Instance = new ImmutableEmptyCellDataImpl();
        
        private ImmutableEmptyCellDataImpl()
        {

        }
        
        public override string Formula
        {
            get => "";
            set => throw new InvalidOperationException("Cannot set data on immutable cell data");
        }
        public override string Value
        { 
            get => "";
            set => throw new InvalidOperationException("Cannot set data on immutable cell data");
        }

        public override bool IsMutable => false;
    }
}
