using System.Collections;

namespace FilesScanner
{
    public class DateComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var date1 = DateTime.Parse((string)x);
            var date2 = DateTime.Parse((string)y);

            return date1.CompareTo(date2);
        }
    }
}
