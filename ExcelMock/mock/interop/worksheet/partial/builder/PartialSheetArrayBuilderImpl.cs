using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock._base;
using ExcelMock.mock.interop.worksheet.partial.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.mock.interop.worksheet.partial.builder
{
    internal class PartialSheetArrayBuilderImpl : BaseClass, IPartialSheetArrayBuilder
    {
        public ISparseArray2D<ICellData> Build()
        {
            //TODO
            return CsharpExtrasApi.NewSparseArray2DBuilder<ICellData>(
                new MutableCellDataImpl("TODO: Implement", "TODO: Implement"))
                .Build();
        }

        public IPartialSheetArrayBuilder WithValues(int row, int column, string[,] values)
        {
            //TODO
            return this;
        }

        public IPartialSheetArrayBuilder WithFormulas(int row, int column, string[,] formulas)
        {
            //TODO
            return this;
        }
    }
}
