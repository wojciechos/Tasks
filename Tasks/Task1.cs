namespace Tasks
{
    public class Task1
    {
        public static bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
    }
}
