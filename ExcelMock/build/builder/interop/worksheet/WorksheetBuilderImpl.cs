using ExcelMock.build.builder._base;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.build.builder.interop.worksheet
{
    internal class WorksheetBuilderImpl : BuilderBase<Worksheet, IWorksheetBuilder>, IWorksheetBuilder
    {
        public WorksheetBuilderImpl()
        {
        }

        protected override IWorksheetBuilder Self => this;
    }
}
