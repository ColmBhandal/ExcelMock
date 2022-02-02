using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.worksheet.partial.data;
using ExcelMockTest.mock.interop.test._base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.mock.interop.worksheet.partial.builder
{
    [TestFixture, Category("Unit")]
    public class PartialSheetArrayBuilderTest : TestBase
    {
        [Test]
        public void GIVEN_((int formulaRow, int formulaColumn, int valueRow, int valueColumn,
            string[,] values, string[,] formulas, ISparseArray2D<ICellData> expectedData) testData)
        {
            //Arrange



        }
    }
}
