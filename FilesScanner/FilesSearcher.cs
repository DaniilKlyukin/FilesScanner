using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FilesScanner
{
    public class FilesSearcher
    {
        public static long GetSizeMb(long sizeBytes) => sizeBytes >> 20;

        public delegate void FileFound(FileInfo fileInfo);

        public event FileFound? OnFileFound;
        public long MinSizeMb { get; }
        public Regex NamePattern { get; }
        public string Root { get; }

        private bool stopPending;

        public FilesSearcher(long minSizeMb, Regex namePattern, string root)
        {
            MinSizeMb = minSizeMb;
            NamePattern = namePattern;
            Root = root;
        }

        public async Task<ICollection<FileInfo>> WideSearchAsync()
        {
            stopPending = false;
            return await Task.Run(() => wideSearch(Root).ToArray());
        }

        public void Stop()
        {
            stopPending = true;
        }

        private IEnumerable<FileInfo> wideSearch(string path)
        {
            var files = tryGetFilesPathsFromDirectory(path) ?? new List<string>();

            foreach (var file in files
                .Select(p => new FileInfo(p))
                .Where(f => GetSizeMb(f.Length) >= MinSizeMb && NamePattern.IsMatch(f.Name)))
            {
                OnFileFound?.Invoke(file);
                yield return file;
            }

            if (stopPending)
                yield break;

            var folders = tryGetDirectoriesPathsFromDirectory(path) ?? new List<string>();

            foreach (var folder in folders)
            {
                foreach (var file in wideSearch(folder))
                {
                    yield return file;
                }
            }
        }

        private ICollection<string>? tryGetFilesPathsFromDirectory(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private ICollection<string>? tryGetDirectoriesPathsFromDirectory(string path)
        {
            try
            {
                return Directory.GetDirectories(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
