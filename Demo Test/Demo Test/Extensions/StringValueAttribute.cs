using System;

namespace DemoTest.Extensions
{
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Constructor, just takes the string value.
        /// </summary>
        /// <example>
        /// <code>
        /// [StringValue("value")]
        /// EnumValue
        /// </code>
        /// </example>
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// String value that is paired with your enum value
        /// </summary>
        public string Value
        {
            get;
            private set;
        }
    }
}
