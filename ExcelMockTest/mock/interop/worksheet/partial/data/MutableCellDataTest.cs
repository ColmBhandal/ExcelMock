using ExcelMock.mock.interop.worksheet.partial.data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.mock.interop.worksheet.partial.data
{
    [TestFixture, Category("Unit")]
    public class MutableCellDataTest
    {
        [Test, TestCase("", ""), TestCase("=B1+B3", "Hello 41")]
        public void GIVEN_TwoCellDataWithSameFields_WHEN_IsEqual_THEN_True(string formula, string value)
        {
            //Arrange
            ICellData data1 = new MutableCellDataImpl(formula, value);
            ICellData data2 = new MutableCellDataImpl(formula, value);

            //Act
            bool isEqual = data1.IsEqual(data2);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [Test,
            TestCase("=A2", "", "", ""),
            TestCase("", "Foo", "", ""),
            TestCase("", "", "=B1", ""),
            TestCase("", "", "", "Bar"),
            TestCase("=B1+B3", "Hello 41", "=B1+B3", "Hello 42"),
            TestCase("=B1+B3", "Hello 41", "=B1+C3", "Hello 41"),
            TestCase("=B1+B3", "Hello 41", "=B1+C3", "Different Value"),]
        public void GIVEN_TwoCellDataWithDifferentFields_WHEN_IsEqual_THEN_False
            (string formulaLeft, string valueLeft, string formulaRight, string valueRight)
        {
            //Arrange
            ICellData dataLeft = new MutableCellDataImpl(formulaLeft, valueLeft);
            ICellData dataRight = new MutableCellDataImpl(formulaRight, valueRight);

            //Act
            bool isEqual = dataLeft.IsEqual(dataRight);

            //Assert
            Assert.IsFalse(isEqual);
        }
    }
}
