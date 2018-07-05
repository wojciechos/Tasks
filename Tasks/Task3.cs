using System.Linq;

namespace Tasks
{
    internal class Task3
    {
        public static string ReplicateText(string text, int replicateNumber)
        {
            return replicateNumber < 0 ? null : string.Concat(Enumerable.Repeat(text, replicateNumber));
        }
    }
}
