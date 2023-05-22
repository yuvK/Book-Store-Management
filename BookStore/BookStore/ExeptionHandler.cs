using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace BookStore
{
    internal static class ExeptionHandler
    {
        public static string ValidString(string text, string propName)
        {
            if (string.IsNullOrEmpty(text))
                throw new InvalidInputExeption(propName, " is invalid");
            return text;
        }
        public static int ValidInt(string text, string propName)
        {
            if (!int.TryParse(text, out int num))
            {
                throw new InvalidInputExeption(propName, " needs a number input");
            }
            if (num < 0)
            {
                throw new InvalidInputExeption(propName," is inValid");
            }
            return num;
        }
        public static long ValidLong(string text, string propName)
        {
            long num;
            if (!long.TryParse(text, out num))
            {
                throw new InvalidInputExeption(propName, " needs a number input");
            }
            if (num < 0)
            {
                throw new InvalidInputExeption(propName, " is inValid");
            }
            return num;
        }
        public static double ValidDouble(string text, string propName)
        {
            double num;
            if (!double.TryParse(text, out num))
            {
                throw new InvalidInputExeption(propName, " needs a number input");
            }
            if (num < 0)
            {
                throw new InvalidInputExeption(propName, " is inValid");
            }
            return num;
        }
        public static DateTime ValidDate(DateTime date, string propName)
        {
            if (String.IsNullOrEmpty(date.ToString()))
            {
                throw new InvalidInputExeption("Please Pick a: ", propName);
            }
            else
                return date;
        }
    }
}
