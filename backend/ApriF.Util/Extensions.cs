using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Util
{
    public static class Extensions
    {
        public static T GetValue<T>(this IDataReader dr, string columnName)
        {
            T value = default(T);

            object fieldValue = dr[columnName];

            try
            {
                value = DBNull.Value.Equals(fieldValue) ? default(T) : (T)fieldValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return value;
        }
    }
}
