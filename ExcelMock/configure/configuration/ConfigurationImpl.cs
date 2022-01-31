using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configuration
{
    internal class ConfigurationImpl<TObj> : IConfiguration<TObj>
        where TObj : class
    {
        public Mock<TObj> Mock { get; } = new Mock<TObj>();
    }
}
