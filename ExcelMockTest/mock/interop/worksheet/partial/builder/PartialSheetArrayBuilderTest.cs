using CsharpExtras.Api;
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
            ICsharpExtrasApi csharpExtrasApi = new CsharpExtrasApi();
            return new List<(int valueRow, int valueColumn, int formulaRow, int formulaColumn,
            string[,] values, string[,] formulas, ISparseArray2D<ICellData> expectedData)>()
            {
                (
                    1, 1, 3, 3, 
                    new string[,]
                    {
                        { "V_00", "V_01" },
                        { "V_01", "V_11" }
                    },
                    new string[,]
                    {
                        { "F_00", "F_01" },
                        { "F_01", "F_11" }
                    },
                    csharpExtrasApi.NewSparseArray2DBuilder<ICellData>(EmptyCellDataImpl.Instance)
                        .WithValue(new MutableCellDataImpl("V_00", ""), 1, 1)
                        .WithValue(new MutableCellDataImpl("V_01", ""), 1, 2)
                        .WithValue(new MutableCellDataImpl("V_10", ""), 2, 1)
                        .WithValue(new MutableCellDataImpl("V_11", ""), 2, 2)
                        .WithValue(new MutableCellDataImpl("", "F_00"), 3, 3)
                        .WithValue(new MutableCellDataImpl("", "F_01"), 3, 4)
                        .WithValue(new MutableCellDataImpl("", "F_10"), 4, 3)
                        .WithValue(new MutableCellDataImpl("", "F_11"), 4, 4)
                        .Build()
                )
            };
        }
    }
}
