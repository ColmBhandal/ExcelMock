using ExcelMock.build.builder.interop.worksheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.Factory
{
    internal class BuilderFactoryImpl : IBuilderFactory
    {
        public IWorksheetBuilder NewWorksheetBuilder()
        {
            return new WorksheetBuilderImpl();
        }
    }
}
