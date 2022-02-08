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
    public class EmptyCellDataTest
    {
        [Test, TestCaseSource(nameof(EmptyCellDataSetFieldInvalidOperationProvider))]
        public void GIVEN_EmptyCellData_WHEN_SetField_THEN_InvalidOperationException
            ((Action<ICellData> setAction, string actionDescription) testData)
        {
            //Assemble
            ICellData cellData = ImmutableEmptyCellDataImpl.Instance;

            //Act / Assert
            Assert.Throws<InvalidOperationException>(() => testData.setAction(cellData),
                $"{testData.actionDescription} on empty data should throw exception");
        }

        private static IEnumerable<(Action<ICellData> setAction, string actionDescription)>
            EmptyCellDataSetFieldInvalidOperationProvider()
        {
            return new List<(Action<ICellData> setAction, string actionDescription)>()
            {
                (data => data.Formula = "=A1", "Set formula"),
                (data => data.Value = "Hello World", "Set value")
            };
        }

        [Test, TestCaseSource(nameof(EmptyCellDataGetStringFieldEmptyProvider))]
        public void GIVEN_EmptyCellData_WHEN_GetStringField_THEN_EmptyValueReturned
            ((Func<ICellData, string> getFunction, string getFunctionDescription) testData)
        {
            //Assemble
            ICellData cellData = ImmutableEmptyCellDataImpl.Instance;

            //Act
            string actual = testData.getFunction(cellData);

            //Assert
            Assert.AreEqual("", actual, $"Expected empty string for {testData.getFunctionDescription}");
        }

        private static IEnumerable<(Func<ICellData, string> getFunction, string getFunctionDescription)>
            EmptyCellDataGetStringFieldEmptyProvider()
        {
            return new List<(Func<ICellData, string> getFunction, string getFunctionDescription)>()
            {
                (data => data.Formula, "Get formula"),
                (data => data.Value, "Get value")
            };
        }


        [Test]
        public void GIVEN_EmptyCellDataClass_WHEN_GetInstanceTwice_THEN_SameInstanceReturned()
        {
            //Assemble / Act
            ICellData cellData1 = ImmutableEmptyCellDataImpl.Instance;
            ICellData cellData2 = ImmutableEmptyCellDataImpl.Instance;

            //Assert
            Assert.AreSame(cellData1, cellData2, "Instance property should always return the same instance");
        }


        [Test]
        public void GIVEN_EmptyCellInstances_WHEN_IsEqual_THEN_True()
        {
            //Assemble
            ICellData cellData = ImmutableEmptyCellDataImpl.Instance;

            //Act
            bool isEqual = cellData.IsEqual(cellData);

            //Assert
            Assert.IsTrue(isEqual, "Empty cell data instance should be equal to itself");
        }
    }
}
