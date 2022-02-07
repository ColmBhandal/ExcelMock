using CsharpExtras.Compare;
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

namespace ExcelMockTest.mock.interop.worksheet.partial
{
    [TestFixture, Category("Unit")]
    public class PartialSheetTest
    {
        [Test, TestCaseSource(nameof(ProviderForDifferingSheetDataConstructionTest))]
        public void GIVEN_DifferingSheetData_WHEN_ConstructPartialSheets_THEN_UsedDataNotEqual(
            Func<IPartialSheetArrayBuilder, IPartialSheetArrayBuilder> differingBuildSteps)
        {
            //Arrange
            IPartialSheetArrayBuilder makeBuilder() => new PartialSheetArrayBuilderImpl()
                .WithFormulas(1, 1,
                    new string[,]
                    {
                        { "F_00", "F_01" },
                        { "F_10", "F_11" }
                    })
                .WithValues(1, 1,
                    new string[,]
                    {
                        { "V_00", "V_01" },
                        { "V_10", "V_11" }
                    });
            ISparseArray2D<ICellData> data1 = makeBuilder().Build();
            ISparseArray2D<ICellData> data2 = differingBuildSteps(makeBuilder()).Build();

            //Act
            IPartialSheet sheet1 = new PartialSheetImpl(data1);
            IPartialSheet sheet2 = new PartialSheetImpl(data2);

            //Assert
            IComparisonResult comparison = sheet1.CompareUsedData(sheet2);
            Assert.IsFalse(comparison.IsEqual, comparison.Message);
        }

        private static IEnumerable<Func<IPartialSheetArrayBuilder, IPartialSheetArrayBuilder>>
            ProviderForDifferingSheetDataConstructionTest()
        {
            return new List<Func<IPartialSheetArrayBuilder, IPartialSheetArrayBuilder>>
            {
                b => b.WithFormulas(1, 1, new string[,]{ {"F_DIFF"} }),
                b => b.WithValues(2, 2, new string[,]{ {"V_DIFF"} }),
                b => b.WithValues(3, 4, new string[,]{ {"V_DIFF"} })
                    .WithFormulas(7, 10, new string[,]{ {"F_DIFF"} }),
            };
        }

        [Test]
        public void GIVEN_DistinctEmptySheetData_WHEN_ConstructPartialSheets_THEN_UsedDataEqual()
        {
            //Arrange
            ISparseArray2D<ICellData> data1 = new PartialSheetArrayBuilderImpl().Build();
            ISparseArray2D<ICellData> data2 = new PartialSheetArrayBuilderImpl().Build();

            //Act
            IPartialSheet sheet1 = new PartialSheetImpl(data1);
            IPartialSheet sheet2 = new PartialSheetImpl(data2);

            //Assert
            IComparisonResult comparison = sheet1.CompareUsedData(sheet2);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }

        [Test]
        public void GIVEN_DistinctButEqualSheetData_WHEN_ConstructPartialSheets_THEN_UsedDataEqual()
        {
            //Arrange
            IPartialSheetArrayBuilder makeBuilder() => new PartialSheetArrayBuilderImpl()
                .WithFormulas(1, 1,
                    new string[,]
                    {
                        { "F_00", "F_01" },
                        { "F_10", "F_11" }
                    })
                .WithValues(1, 1,
                    new string[,]
                    {
                        { "V_00", "V_01" },
                        { "V_10", "V_11" }
                    });
            ISparseArray2D<ICellData> data1 = makeBuilder().Build();
            ISparseArray2D<ICellData> data2 = makeBuilder().Build();

            //Act
            IPartialSheet sheet1 = new PartialSheetImpl(data1);
            IPartialSheet sheet2 = new PartialSheetImpl(data2);

            //Assert
            IComparisonResult comparison = sheet1.CompareUsedData(sheet2);
            Assert.IsTrue(comparison.IsEqual, comparison.Message);
        }
    }
}
