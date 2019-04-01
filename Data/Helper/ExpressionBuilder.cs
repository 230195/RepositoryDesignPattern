using System;
using System.Linq;
using System.Reflection;

namespace Data.Helper
{
    public static class CustomExpressionBuilder
    {
        private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod("Contains");
        private static readonly MethodInfo StartsWithMethod =
        typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });

        private static readonly MethodInfo EndsWithMethod =
        typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });



        public static T GetValue<T>(string value)
        {
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) ?? t;

            return (value == null || DBNull.Value.Equals(value)) ?
                default(T) : (T)Convert.ChangeType(value, t);
        }

        private static DateTime ConvertDate(string datestring)
        {
            var date = DateTime.Parse(new string(datestring.Take(24).ToArray()));
            return date;
        }

      
    }
}
