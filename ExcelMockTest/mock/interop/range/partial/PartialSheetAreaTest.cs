using CsharpExtras._Enumerable.OneBased;
using CsharpExtras.Compare;
using CsharpExtras.Map.Sparse.TwoDimensional;
using ExcelMock.mock.interop.range.partial;
using ExcelMock.mock.interop.worksheet.partial;
using ExcelMock.mock.interop.worksheet.partial.builder;
using ExcelMock.mock.interop.worksheet.partial.data;
using ExcelMockTest.mock.interop.test._base;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.mock.interop.range.partial
{
    [TestFixture, Category("Unit")]
    public class PartialSheetAreaTest : TestBase
    {
        [Test]
        public void GIVEN_FilledSheet_WHEN_SetBlankFormulas_THEN_SheetUsedDataEqualsEmpty()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithFormulas(2, 3,
                    new string[,]
                    {
                        { "V_00", "V_01"},
                        { "V_10", "V_11"}
                    });
            ISparseArray2D<ICellData> data = builder.Build();
            IPartialSheet sheet = new PartialSheetImpl(data);
            IPartialSheetArea area = new PartialSheetAreaImpl(2, 3, 3, 4, sheet);

            IOneBasedArray2D<string> formulasToWrite = CsharpExtrasApi.NewOneBasedArray2D(
                new string[,]
                    {
                        { "", ""},
                        { "", ""}
                    });
            ISparseArray2D<ICellData> expectedData = new PartialSheetArrayBuilderImpl().Build();
            IPartialSheet expectedSheet = new PartialSheetImpl(expectedData);

            IComparisonResult comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsFalse(comparison.IsEqual, "GIVEN: Sheet data should not be equal to expected prior to write");

            //Act
            area.Formulas = formulasToWrite;

            //Assert
            comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_FilledSheet_WHEN_SetBlankValues_THEN_SheetUsedDataEqualsEmpty()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl()
                .WithValues(2, 3,
                    new string[,]
                    {
                        { "V_00", "V_01"},
                        { "V_10", "V_11"}
                    });
            ISparseArray2D<ICellData> data = builder.Build();
            IPartialSheet sheet = new PartialSheetImpl(data);
            IPartialSheetArea area = new PartialSheetAreaImpl(2, 3, 3, 4, sheet);

            IOneBasedArray2D<string> valuesToWrite = CsharpExtrasApi.NewOneBasedArray2D(
                new string[,]
                    {
                        { "", ""},
                        { "", ""}
                    });
            ISparseArray2D<ICellData> expectedData = new PartialSheetArrayBuilderImpl().Build();
            IPartialSheet expectedSheet = new PartialSheetImpl(expectedData);

            IComparisonResult comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsFalse(comparison.IsEqual, "GIVEN: Sheet data should not be equal to expected prior to write");

            //Act
            area.Values = valuesToWrite;

            //Assert
            comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_EmptySheet_WHEN_SetPartialSheetAreaFormulas_THEN_SheetUsedDataIsAsExpected()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();
            ISparseArray2D<ICellData> data = builder.Build();
            IPartialSheet sheet = new PartialSheetImpl(data);
            IPartialSheetArea area = new PartialSheetAreaImpl(2, 3, 3, 5, sheet);

            IOneBasedArray2D<string> formulasToWrite = CsharpExtrasApi.NewOneBasedArray2D(
                new string[,]
                    {
                        { "F_00", "F_01", "" },
                        { "F_10", "F_11", "" }
                    });

            IPartialSheetArrayBuilder expectedBuilder = new PartialSheetArrayBuilderImpl()
                .WithFormulas(2, 3,
                    new string[,]
                    {
                        { "F_00", "F_01"},
                        { "F_10", "F_11"}
                    });
            ISparseArray2D<ICellData> expectedData = expectedBuilder.Build();
            IPartialSheet expectedSheet = new PartialSheetImpl(expectedData);

            IComparisonResult comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsFalse(comparison.IsEqual, "GIVEN: Sheet data should not be equal to expected prior to write");

            //Act
            area.Formulas = formulasToWrite;

            //Assert
            comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_EmptySheet_WHEN_SetPartialSheetAreaValues_THEN_SheetUsedDataIsAsExpected()
        {
            //Arrange
            IPartialSheetArrayBuilder builder = new PartialSheetArrayBuilderImpl();
            ISparseArray2D<ICellData> data = builder.Build();
            IPartialSheet sheet = new PartialSheetImpl(data);
            IPartialSheetArea area = new PartialSheetAreaImpl(2, 3, 3, 5, sheet);

            IOneBasedArray2D<string> valuesToWrite = CsharpExtrasApi.NewOneBasedArray2D(
                new string[,]
                    {
                        { "V_00", "V_01", "" },
                        { "V_10", "V_11", "" }
                    });

            IPartialSheetArrayBuilder expectedBuilder = new PartialSheetArrayBuilderImpl()
                .WithValues(2, 3,
                    new string[,]
                    {
                        { "V_00", "V_01", "" },
                        { "V_10", "V_11", "" }
                    });
            ISparseArray2D<ICellData> expectedData = expectedBuilder.Build();
            IPartialSheet expectedSheet = new PartialSheetImpl(expectedData);

            IComparisonResult comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsFalse(comparison.IsEqual, "GIVEN: Sheet data should not be equal to expected prior to write");

            //Act
            area.Values = valuesToWrite;

            //Assert
            comparison = expectedSheet.CompareUsedData(sheet);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_PartialSheetArea_WHEN_GetValues_THEN_EqualExpected()
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

            IPartialSheetArea area = new PartialSheetAreaImpl(1, 1, 2, 3, sheet);

            //Act
            IOneBasedArray2D<string> values = area.Values;

            //Assert
            string[,] expectedValues = new string[,]
                    {
                        { "V_00", "V_01", "" },
                        { "V_10", "V_11", "" }
                    };
            Assert.AreEqual(expectedValues, values.ZeroBasedEquivalent);
        }

        [Test]
        public void GIVEN_PartialSheetArea_WHEN_GetFormulas_THEN_EqualExpected()
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

            IPartialSheetArea area = new PartialSheetAreaImpl(2, 1, 4, 2, sheet);

            //Act
            IOneBasedArray2D<string> formulas = area.Formulas;

            //Assert
            string[,] expectedFormulas = new string[,]
                    {
                        { "F_10", "F_11" },
                        { "F_20", "F_21" },
                        { "", "" }
                    };
            Assert.AreEqual(expectedFormulas, formulas.ZeroBasedEquivalent);
        }
    }
}
