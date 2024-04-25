namespace FilesScaner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxRoot = new TextBox();
            label1 = new Label();
            buttonSelectRoot = new Button();
            label2 = new Label();
            numericUpDownMinFileSize = new NumericUpDown();
            buttonStartSearch = new Button();
            listView = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderDate = new ColumnHeader();
            columnHeaderSize = new ColumnHeader();
            statusStrip = new StatusStrip();
            labelStop = new ToolStripStatusLabel();
            toolStripStatusLabel = new ToolStripStatusLabel();
            contextMenuStrip = new ContextMenuStrip(components);
            showInExplorerToolStripMenuItem = new ToolStripMenuItem();
            deleteFileToolStripMenuItem = new ToolStripMenuItem();
            textBoxNamePattern = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numericUpDownMaxFileSize = new NumericUpDown();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinFileSize).BeginInit();
            statusStrip.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxFileSize).BeginInit();
            SuspendLayout();
            // 
            // textBoxRoot
            // 
            textBoxRoot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRoot.Location = new Point(143, 12);
            textBoxRoot.Name = "textBoxRoot";
            textBoxRoot.Size = new Size(398, 23);
            textBoxRoot.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 16);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 1;
            label1.Text = "Корень поиска:";
            // 
            // buttonSelectRoot
            // 
            buttonSelectRoot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelectRoot.Location = new Point(547, 11);
            buttonSelectRoot.Name = "buttonSelectRoot";
            buttonSelectRoot.Size = new Size(112, 24);
            buttonSelectRoot.TabIndex = 2;
            buttonSelectRoot.Text = "Выбрать папку";
            buttonSelectRoot.UseVisualStyleBackColor = true;
            buttonSelectRoot.Click += buttonSelectRoot_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 47);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 3;
            label2.Text = "Размер файла от";
            // 
            // numericUpDownMinFileSize
            // 
            numericUpDownMinFileSize.Location = new Point(143, 45);
            numericUpDownMinFileSize.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownMinFileSize.Name = "numericUpDownMinFileSize";
            numericUpDownMinFileSize.Size = new Size(96, 23);
            numericUpDownMinFileSize.TabIndex = 4;
            numericUpDownMinFileSize.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownMinFileSize.ValueChanged += numericUpDownMinFileSize_ValueChanged;
            // 
            // buttonStartSearch
            // 
            buttonStartSearch.Location = new Point(143, 103);
            buttonStartSearch.Name = "buttonStartSearch";
            buttonStartSearch.Size = new Size(325, 24);
            buttonStartSearch.TabIndex = 5;
            buttonStartSearch.Text = "Начать поиск";
            buttonStartSearch.UseVisualStyleBackColor = true;
            buttonStartSearch.Click += buttonStartSearch_Click;
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderDate, columnHeaderSize });
            listView.Location = new Point(12, 153);
            listView.Name = "listView";
            listView.Size = new Size(647, 304);
            listView.TabIndex = 8;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.ColumnClick += listView_ColumnClick;
            listView.MouseClick += listView_MouseClick;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Имя";
            columnHeaderName.Width = 440;
            // 
            // columnHeaderDate
            // 
            columnHeaderDate.Text = "Дата изменения";
            columnHeaderDate.Width = 100;
            // 
            // columnHeaderSize
            // 
            columnHeaderSize.Text = "Размер";
            columnHeaderSize.Width = 100;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { labelStop, toolStripStatusLabel });
            statusStrip.Location = new Point(0, 458);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(668, 24);
            statusStrip.TabIndex = 9;
            statusStrip.Text = "statusStrip1";
            // 
            // labelStop
            // 
            labelStop.BackColor = Color.Red;
            labelStop.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            labelStop.BorderStyle = Border3DStyle.Raised;
            labelStop.Name = "labelStop";
            labelStop.Size = new Size(38, 19);
            labelStop.Text = "Стоп";
            labelStop.Click += labelStop_Click;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(43, 19);
            toolStripStatusLabel.Text = "Статус";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { showInExplorerToolStripMenuItem, deleteFileToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(203, 48);
            // 
            // showInExplorerToolStripMenuItem
            // 
            showInExplorerToolStripMenuItem.Name = "showInExplorerToolStripMenuItem";
            showInExplorerToolStripMenuItem.Size = new Size(202, 22);
            showInExplorerToolStripMenuItem.Text = "Показать в проводнике";
            showInExplorerToolStripMenuItem.Click += showInExplorerToolStripMenuItem_Click;
            // 
            // deleteFileToolStripMenuItem
            // 
            deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            deleteFileToolStripMenuItem.Size = new Size(202, 22);
            deleteFileToolStripMenuItem.Text = "Удалить";
            deleteFileToolStripMenuItem.Click += deleteFileToolStripMenuItem_Click;
            // 
            // textBoxNamePattern
            // 
            textBoxNamePattern.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNamePattern.Location = new Point(143, 74);
            textBoxNamePattern.Name = "textBoxNamePattern";
            textBoxNamePattern.Size = new Size(325, 23);
            textBoxNamePattern.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 77);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 11;
            label3.Text = "Regex Шаблон имени:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(373, 47);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 12;
            label4.Text = "Мб";
            // 
            // numericUpDownMaxFileSize
            // 
            numericUpDownMaxFileSize.Location = new Point(271, 45);
            numericUpDownMaxFileSize.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownMaxFileSize.Name = "numericUpDownMaxFileSize";
            numericUpDownMaxFileSize.Size = new Size(96, 23);
            numericUpDownMaxFileSize.TabIndex = 14;
            numericUpDownMaxFileSize.Value = new decimal(new int[] { 500000, 0, 0, 0 });
            numericUpDownMaxFileSize.ValueChanged += numericUpDownMaxFileSize_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(245, 47);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 13;
            label6.Text = "до";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 482);
            Controls.Add(numericUpDownMaxFileSize);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxNamePattern);
            Controls.Add(statusStrip);
            Controls.Add(listView);
            Controls.Add(buttonStartSearch);
            Controls.Add(numericUpDownMinFileSize);
            Controls.Add(label2);
            Controls.Add(buttonSelectRoot);
            Controls.Add(label1);
            Controls.Add(textBoxRoot);
            Name = "MainForm";
            Text = "Поисковик файлов";
            SizeChanged += MainForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinFileSize).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxFileSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxRoot;
        private Label label1;
        private Button buttonSelectRoot;
        private Label label2;
        private NumericUpDown numericUpDownMinFileSize;
        private Button buttonStartSearch;
        private ListView listView;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderDate;
        private ColumnHeader columnHeaderSize;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem showInExplorerToolStripMenuItem;
        private ToolStripMenuItem deleteFileToolStripMenuItem;
        private ToolStripStatusLabel labelStop;
        private TextBox textBoxNamePattern;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownMaxFileSize;
        private Label label6;
    }
}
