using ExcelMock.configure.configuration.interop.worksheet;
using ExcelMock.configure.configurer._base;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer.interop.worksheet
{
    internal class WorksheetConfigurerImpl :
        ConfigurerBase<Worksheet, IWorksheetConfiguration, IWorksheetConfigurer>
        , IWorksheetConfigurer
    {
        public WorksheetConfigurerImpl(IWorksheetConfiguration configuration) : base(configuration)
        {
        }

        protected override IWorksheetConfigurer Self => this;

        protected override Worksheet CreateObject()
        {
            //TODO: Implement properly by creating a MockWorksheetImpl
            return _configurationWrapper.Get(c => c.Mock.Object);
        }
    }
}
