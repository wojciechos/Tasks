﻿using System.Linq;

namespace UnitTests
{
    internal class Task3
    {
        public static string ReplicateText(string text, int replicateNumber)
        {
            return string.Concat(Enumerable.Repeat(text, replicateNumber));
        }
    }
}
