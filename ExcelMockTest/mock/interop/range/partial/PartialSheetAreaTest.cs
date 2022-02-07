using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.worksheet.partial;
using ExcelMock.mock.interop.worksheet.partial.builder;
using ExcelMock.mock.interop.worksheet.partial.data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.mock.interop.range.partial
{
    [TestFixture, Category("Unit")]
    public class PartialSheetAreaTest
    {
        [Test]
        public void GIVEN_TODO()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithFormulas(1, 1,
                    new string[,]
                    {
                        { "F_00", "F_01" },
                        { "F_10", "F_11" },
                        { "F_20", "F_21" }
                    })
                .WithValues(1, 1,
                    new string[,]
                    {
                        { "V_00", "V_01" },
                        { "V_10", "V_11" },
                        { "V_20", "V_21" }
                    });
            ISparseArray2D<ICellData> data = builder.Build();
            IPartialSheet sheet = new PartialSheetImpl(data);

            //Act

            //Assert
        }
    }
}
