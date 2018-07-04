using System;

namespace UnitTests
{
    internal class Task4
    {
        public void PrintOddNumbersFrom0To100()
        {
            for (var i = 1; i < 100; i += 2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
