using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.build.exception
{
    /// <summary>
    /// Thrown when an exception occurs while trying to configure a mock object.
    /// </summary>
    public class ConfigurationException : Exception
    {
        /// <summary>
        /// Creates a new configuration exception instance.
        /// </summary>
        /// <param name="message">The message to add to the exception.</param>
        public ConfigurationException(string message) : base(message)
        {
        }
    }
}
