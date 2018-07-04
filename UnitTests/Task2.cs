using System;

namespace UnitTests
{
    internal class Task2
    {
        public static string ReverseText(string text)
        {
                var charArray = text.ToCharArray();

                Array.Reverse(charArray);

                return new string(charArray);
        }
    }
}
