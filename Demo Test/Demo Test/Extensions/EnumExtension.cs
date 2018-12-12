using System;
using System.Linq;
using System.Reflection;

namespace DemoTest.Extensions
{
    public static class EnumExtension
    {
        private static string GetAttribute(string s, Enum enumeration)
        {
            MemberInfo[] memInfo = enumeration.GetType().GetMember(s);
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(StringValueAttribute), false);
            if (attributes.Length > 0)
            {
                return ((StringValueAttribute)attributes[0]).Value;
            }
            return String.Empty;
        }

        public static string GetStringValue(this Enum enumeration)
        {
            var t = enumeration.GetType();

            if (t.CustomAttributes.Any(x => x.AttributeType == typeof(FlagsAttribute)))
            {
                var enumValues = enumeration.ToString().Split(',');
                var resultString = string.Empty;

                foreach (var enumValue in enumValues)
                {
                    var value = enumValue.Trim();
                    var result = GetAttribute(value, enumeration);
                    if (!string.IsNullOrEmpty(result))
                    {
                        resultString = resultString + (string.IsNullOrEmpty(resultString) ? string.Empty : " | ") + result;
                    }
                }

                return resultString;
            }

            return GetAttribute(enumeration.ToString(), enumeration);
        }
    }
}
