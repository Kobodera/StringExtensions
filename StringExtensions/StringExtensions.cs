using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an Int32 value. If a default value have been set no exception will be thrown
        /// in case the conversion fails.
        /// </summary>
        /// <param name="value">The string value that is to be parsed</param>
        /// <param name="defaultValue">An optional default value in case the conversion fails</param>
        /// <returns>The Int32 representation of the string</returns>
        public static int ToInt(this string value, int? defaultValue = null)
        {
            int result;

            string temp = value
                .ToLower()
                .Cleanup(
                    " ",        //Regular space 
                    "\u00A0",   //Non breaking space
                    "&nbsp;",   //HTML non breaking space
                    "+"         //Plus signs
                )
                .Trim();

            if (int.TryParse(temp, out result))
            {
                return result;
            }

            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }

            throw new ArgumentException($"The value '{value}' can not be parsed to an integer.");
        }

        
        public static int? ToNullableInt(this string value, int? defaultValue = null)
        {
            string temp = value
                .ToLower()
                .Cleanup(
                    " ",        //Regular space 
                    "\u00A0",   //Non breaking space
                    "&nbsp;",   //HTML non breaking space
                    "+"         //Plus signs
                )
                .Trim();

            if (string.IsNullOrWhiteSpace(temp))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                else
                {
                    return null;
                }
            }

            return temp.ToInt(defaultValue);
        }
        
        /// <summary>
        /// Converts a string to a double value. If a default value have been set no exception will be thrown
        /// in case the conversion fails
        /// </summary>
        /// <param name="value">The string value that is to be parsed</param>
        /// <param name="defaultValue">An optional default value in casae the conversion fails</param>
        /// <returns>The double representation of the string</returns>
        public static double ToDouble(this string value, double? defaultValue = null)
        {
            double result;

            string temp = value
                .ToLower()
                .Replace(",", System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator)
                .Replace(".", System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator)
                .Cleanup(
                    " ",        //Regular space 
                    "\u00A0",   //Non breaking space
                    "&nbsp;",   //HTML non breaking space
                    "+"         //Plus signs
                )
                .Trim();

            if (double.TryParse(temp, out result))
            {
                return result;
            }

            if (defaultValue.HasValue)
            {
                return defaultValue.Value;
            }

            throw new ArgumentException($"The value '{value}' can not be parsed to a double.");
        }

        public static double? ToNullableDouble(this string value, double? defaultValue = null)
        {
            string temp = value
                .ToLower()
                .Cleanup(
                    " ",        //Regular space 
                    "\u00A0",   //Non breaking space
                    "&nbsp;",   //HTML non breaking space
                    "+"         //Plus signs
                )
                .Trim();

            if (string.IsNullOrWhiteSpace(temp))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                else
                {
                    return null;
                }
            }

            return temp.ToDouble(defaultValue);
        }


        /// <summary>
        /// Removes parts of the string. The order of the parts to be removed is important
        /// </summary>
        /// <param name="value">The string that is to be cleaned</param>
        /// <param name="cleanupStrings">The strings that is to be removed from the original string</param>
        /// <returns>A string without the cleanup elements</returns>
        public static string Cleanup(this string value, params string[] cleanupStrings)
        {
            string temp = value;

            foreach (string cleanupString in cleanupStrings)
            {
                temp = temp.Replace(cleanupString, string.Empty, true);
            }

            return temp.Trim();
        }

        /// <summary>
        /// Replaces a part of the string with another value. The user can choose if the replace should be case insensitive
        /// </summary>
        /// <param name="value">The string where the replace is to be done</param>
        /// <param name="replace">The value that is to be replaced</param>
        /// <param name="replaceWith">The value that the old string should be replaced with</param>
        /// <param name="caseSensitive">If the method should look for the replace word without regard to case</param>
        /// <returns>The replaced string</returns>
        public static string Replace(this string value, string replace, string replaceWith, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(replace))
            {
                return value;
            }

            string temp = ignoreCase ? value.ToLower() : value;
            string searchPattern = ignoreCase ? replace.ToLower() : replace;
            string replaceValue = replaceWith ?? string.Empty;

            StringBuilder sb = new StringBuilder();

            int lastIndex = 0;
            int index = temp.IndexOf(searchPattern);

            while (index != -1)
            {
                sb.Append(value.Substring(lastIndex, index - lastIndex));
                sb.Append(replaceValue);

                index += replace.Length;
                lastIndex = index;
                index = temp.IndexOf(searchPattern, index);
            }

            sb.Append(value.Substring(lastIndex));

            return sb.ToString();
        }
    }
}
