using ExcelMock.build.builder._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.build.builder.simple
{
    internal class SimpleBuilderImpl<TObj>
        : BuilderBase<TObj, ISimpleBuilder<TObj>>, ISimpleBuilder<TObj>
        where TObj : class
    {
        protected override ISimpleBuilder<TObj> Self => this;
    }
}
