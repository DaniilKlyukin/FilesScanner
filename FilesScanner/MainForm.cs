using FilesScanner;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace FilesScaner
{
    public partial class MainForm : Form
    {
        private FilesSearcher? filesSearcher;
        private ListViewItem? selectedListViewItem;
        private ListViewColumnSorter lvwColumnSorter;

        public MainForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            lvwColumnSorter.AddComparer(1, new DateComparer());
            lvwColumnSorter.AddComparer(2, new SizeComparer());
            listView.ListViewItemSorter = lvwColumnSorter;
        }

        private void buttonSelectRoot_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxRoot.Text = fbd.SelectedPath;
            }
        }

        private async void buttonStartSearch_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxRoot.Text))
                return;

            var minSizeMb = (long)numericUpDownMinFileSize.Value;
            var maxSizeMb = (long)numericUpDownMaxFileSize.Value;
            Regex namePattern;

            try
            {
                namePattern = new Regex(textBoxNamePattern.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }

            toolStripStatusLabel.Text = "Ведётся поиск";
            listView.Items.Clear();

            filesSearcher = new FilesSearcher(minSizeMb, maxSizeMb, namePattern, textBoxRoot.Text);
            filesSearcher.OnFileFound += addFileInfoToListView;

            var files = await filesSearcher.WideSearchAsync();

            toolStripStatusLabel.Text = $"Поиск завершён: {listView.Items.Count} файлов";
        }

        private void addFileInfoToListView(FileInfo fileInfo)
        {
            var item = new ListViewItem();
            item.Tag = fileInfo;
            item.Text = fileInfo.Name;

            item.SubItems.Add(fileInfo.CreationTime.ToShortDateString());

            item.SubItems.Add($"{FilesSearcher.GetSizeMb(fileInfo.Length)} Мб");

            listView.Invoke(() =>
            {
                listView.Items.Add(item);
                toolStripStatusLabel.Text = $"Ведётся поиск: {listView.Items.Count} файлов";
            });
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            listView.Columns[0].Width = listView.Width
                - listView.Columns[1].Width
                - listView.Columns[2].Width
                - 4;
        }

        private void showInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedListViewItem == null)
                return;

            var fileInfo = selectedListViewItem.Tag as FileInfo;

            if (fileInfo == null)
                return;

            if (!File.Exists(fileInfo.FullName))
            {
                return;
            }

            string argument = "/select, \"" + fileInfo.FullName + "\"";

            Process.Start("explorer.exe", argument);
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedListViewItem == null)
                return;

            var fileInfo = selectedListViewItem.Tag as FileInfo;

            if (fileInfo == null)
                return;

            if (MessageBox.Show(
                "Вы уверены, что хотите удалить файл?",
                "Предупреждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(fileInfo.FullName);
                    listView.Items.Remove(selectedListViewItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private ListViewItem? getFileInfoItemOnLocation(Point location)
        {
            var listViewItem = listView.GetItemAt(location.X, location.Y);

            if (listViewItem == null)
                return null;

            return listViewItem;
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedListViewItem = getFileInfoItemOnLocation(e.Location);

                if (selectedListViewItem == null) return;

                contextMenuStrip.Show(listView, e.Location);
            }
        }

        private void labelStop_Click(object sender, EventArgs e)
        {
            filesSearcher?.Stop();
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listView.Sort();
        }

        private void numericUpDownMinFileSize_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMinFileSize.Value > numericUpDownMaxFileSize.Value)
                numericUpDownMaxFileSize.Value = numericUpDownMinFileSize.Value;
        }

        private void numericUpDownMaxFileSize_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMaxFileSize.Value < numericUpDownMinFileSize.Value)
                numericUpDownMinFileSize.Value = numericUpDownMaxFileSize.Value;
        }
    }
}
