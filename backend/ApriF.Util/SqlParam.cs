using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Util
{
    public class SqlParam
    {
        public static object Value(object value)
        {
            object sqlValue = value ?? DBNull.Value;

            return sqlValue;
        }
    }
}
