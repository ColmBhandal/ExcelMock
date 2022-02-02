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
        [Test]
        public void GIVEN_BuilderWithSubsequentWithFormulasOverlaps_WHEN_Build_THEN_LastFormulaWins()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithFormulas(1, 1, new string[,]
                    {
                        { "F0_00", "F0_01" },
                        { "F0_01", "F0_11" }
                    })
                .WithFormulas(2, 2, new string[,]
                    {
                        { "F1_00", "F1_01" },
                        { "F1_01", "F1_11" }
                    });

            //Act
            ISparseArray2D<ICellData> data = builder.Build();

            //Assert
            string valueAtOverlap = data[2, 2].Formula;
            Assert.AreEqual("F1_00", valueAtOverlap);
        }

        [Test]
        public void GIVEN_BuilderWithSubsequentWithValuesOverlaps_WHEN_Build_THEN_LastValueWins()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithValues(1, 1, new string[,]
                    {
                        { "V0_00", "V0_01" },
                        { "V0_01", "V0_11" }
                    })
                .WithValues(2, 2, new string[,]
                    {
                        { "V1_00", "V1_01" },
                        { "V1_01", "V1_11" }
                    });

            //Act
            ISparseArray2D<ICellData> data = builder.Build();

            //Assert
            string valueAtOverlap = data[2, 2].Value;
            Assert.AreEqual("V1_00", valueAtOverlap);
        }

        [Test, TestCase(0, 2), TestCase(3, 0), TestCase(0, 0),
            TestCase(-7, 2), TestCase(12, -1), TestCase(-4, -6)]
        public void GIVEN_NonPositiveCoordinate_WHEN_AccessBuiltObject_THEN_IndexOutOfRangeException
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();
            ISparseArray2D<ICellData> data = builder.Build();

            //Act / Assert
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = data[row, col]; });
        }

        [Test, TestCase(0, 2), TestCase(3, -1)]
        public void GIVEN_InvalidCoordinates_WHEN_WithValuesForEmptyArea_THEN_UsedCountIsZero
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();

            //Act
            builder.WithValues(row, col, new string[,] { });

            //Assert
            ISparseArray2D<ICellData> array = builder.Build();
            Assert.AreEqual(0, (int)array.BackingArray.UsedValuesCount);
        }

        [Test, TestCase(-2, 2), TestCase(2, 0)]
        public void GIVEN_InvalidCoordinates_WHEN_WithFormulasForEmptyArea_THEN_UsedCountIsZero
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();

            //Act
            builder.WithFormulas(row, col, new string[,] { });

            //Assert
            ISparseArray2D<ICellData> array = builder.Build();
            Assert.AreEqual(0, (int) array.BackingArray.UsedValuesCount);
        }

        [Test, TestCase(0, 2), TestCase(3, -1)]
        public void GIVEN_InvalidCoordinates_WHEN_WithValuesForNonEmptyArea_THEN_ArgumentException
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();

            //Act / Assert
            Assert.Throws<ArgumentException>(() =>
                builder.WithValues(row, col, new string[,] { { "" } }));
        }

        [Test, TestCase(-2, 2), TestCase(2, 0)]
        public void GIVEN_InvalidCoordinates_WHEN_WithFormulasForNonEmptyArea_THEN_ArgumentException
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();

            //Act / Assert
            Assert.Throws<ArgumentException>(() =>
                builder.WithFormulas(row, col, new string[,] { { "" } }));
        }

        [Test]
        public void GIVEN_BuilderWithNoValuesOrFormulas_WHEN_Build_THEN_UsedValuesEqualsEmptySparseArray()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();
            ISparseArray2D<ICellData> expected = CsharpExtrasApi.NewSparseArray2DBuilder<ICellData>
                (EmptyCellDataImpl.Instance).Build();

            //Act
            ISparseArray2D<ICellData> actual = builder.Build();

            //Assert
            IComparisonResult comparison = expected.CompareUsedValues(actual, AreCellDatasEqual);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test, TestCase(1, 1), TestCase(1, 27), TestCase(13, 1), TestCase(12, 9)]
        public void GIVEN_BuilderWithNoValuesOrFormulas_WHEN_Build_THEN_EmptyCellDataAtValidCoordinates
            (int row, int col)
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();

            //Act
            ISparseArray2D<ICellData> array = builder.Build();

            //Assert
            ICellData data = array[row, col];;
            Assert.IsTrue(EmptyCellDataImpl.Instance.IsEqual(data), "Expected cell data to equal empty cell data");
        }

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
                .CompareUsedValues(array, AreCellDatasEqual);
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
                ),
                (
                    1, 1, 2, 2,
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
                        .WithValue(new MutableCellDataImpl("V_11", "F_00"), 2, 2)
                        .WithValue(new MutableCellDataImpl("", "F_01"), 2, 3)
                        .WithValue(new MutableCellDataImpl("", "F_10"), 3, 2)
                        .WithValue(new MutableCellDataImpl("", "F_11"), 3, 3)
                        .Build()
                ),
            };
        }

        private static bool AreCellDatasEqual(ICellData d1, ICellData d2)
        {
            return d1.IsEqual(d2);
        }
    }
}
