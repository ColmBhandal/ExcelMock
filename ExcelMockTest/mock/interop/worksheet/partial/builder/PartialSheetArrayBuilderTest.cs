using CsharpExtras.Compare;
using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.worksheet.partial.builder;
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
        [Test, TestCaseSource(nameof(ProviderFor2DArrayFormulasValuesResultExpected))]
        public void GIVEN_2DArraySOfFormulasAndValues_WHEN_Build_THEN_ResultIsAsExpected
            ((int valueRow, int valueColumn, int formulaRow, int formulaColumn, 
            string[,] values, string[,] formulas, ISparseArray2D<ICellData> expectedData) testData)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithValues(testData.valueRow, testData.valueColumn, testData.values)
                .WithFormulas(testData.formulaRow, testData.formulaColumn, testData.formulas);

            //Act
            ISparseArray2D<ICellData> array = builder.Build();

            //Assert
            IComparisonResult comparison = testData.expectedData
                .CompareUsedValues(array, (d1, d2) => d1.IsEqual(d2));
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        private static IEnumerable<(int valueRow, int valueColumn, int formulaRow, int formulaColumn,
            string[,] values, string[,] formulas, ISparseArray2D<ICellData> expectedData)>
            ProviderFor2DArrayFormulasValuesResultExpected()
        {
            return new List<(int valueRow, int valueColumn, int formulaRow, int formulaColumn,
            string[,] values, string[,] formulas, ISparseArray2D<ICellData> expectedData)>()
            {

            };
        }
    }
}
