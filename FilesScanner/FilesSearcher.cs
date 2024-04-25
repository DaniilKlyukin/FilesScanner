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
        public long MaxSizeMb { get; }
        public Regex NamePattern { get; }
        public string Root { get; }

        private bool stopPending;

        public FilesSearcher(long minSizeMb, long maxSizeMb, Regex namePattern, string root)
        {
            MinSizeMb = minSizeMb;
            MaxSizeMb = maxSizeMb;
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
            var pathsQueue = new Queue<string>();
            pathsQueue.Enqueue(path);

            while (pathsQueue.Any())
            {
                var currentPath = pathsQueue.Dequeue();

                var files = tryGetFilesPathsFromDirectory(currentPath) ?? new List<string>();

                foreach (var file in files
                                        .Select(p => new FileInfo(p))
                                        .Where(f =>
                                        {
                                            var size = GetSizeMb(f.Length);

                                            return size >= MinSizeMb
                                                && size <= MaxSizeMb
                                                && NamePattern.IsMatch(f.Name);
                                        }))
                {
                    if (stopPending)
                        yield break;

                    OnFileFound?.Invoke(file);
                    yield return file;
                }

                var folders = tryGetDirectoriesPathsFromDirectory(currentPath) ?? new List<string>();

                foreach (var folder in folders)
                {
                    pathsQueue.Enqueue(folder);
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
