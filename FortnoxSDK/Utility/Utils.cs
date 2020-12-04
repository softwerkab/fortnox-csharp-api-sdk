using System;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Utils
{
    public static class Utils
    {
        internal static string GetStringValue(object value, Type type)
        {
            if (value == null) return null;

            type = Nullable.GetUnderlyingType(type) ?? type; //unwrap nullable type

            if (type == typeof(string))
                return value.ToString();
            if (type.IsEnum)
                return ((Enum)value).GetStringValue();
            if (type == typeof(DateTime))
            {
                if (((DateTime)value).Date == (DateTime)value) //Date without hours/minutes/seconds..
                    return ((DateTime)value).ToString(APIConstants.DateFormat);

                return ((DateTime)value).ToString(APIConstants.DateAndTimeFormat);
            }

            return value.ToString().ToLower();
        }
    }
}
