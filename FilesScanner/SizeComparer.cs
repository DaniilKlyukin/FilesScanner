using System.Collections;

namespace FilesScanner
{
    public class SizeComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var size1 = int.Parse(((string)x).Split(' ')[0]);
            var size2 = int.Parse(((string)y).Split(' ')[0]);

            return size1.CompareTo(size2);
        }
    }
}
