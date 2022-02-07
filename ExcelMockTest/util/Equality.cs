using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.util
{
    public static class Equality
    {
        public static bool JsonEquals(this object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            string objJson = JsonConvert.SerializeObject(obj);
            string anotherJson = JsonConvert.SerializeObject(another);

            return objJson == anotherJson;
        }
    }
}
