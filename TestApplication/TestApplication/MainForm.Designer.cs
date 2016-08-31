namespace TestApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbSelectButton = new System.Windows.Forms.Button();
            this.SearchTableCombobox = new System.Windows.Forms.ComboBox();
            this.ProductAddButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductImportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddRowCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProductsBrowseButton = new System.Windows.Forms.Button();
            this.ImportTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductsImportProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SearchColumnCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BrowseImportDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(12, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 321);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter_1);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // dbSelectButton
            // 
            this.dbSelectButton.Location = new System.Drawing.Point(551, 116);
            this.dbSelectButton.Name = "dbSelectButton";
            this.dbSelectButton.Size = new System.Drawing.Size(75, 23);
            this.dbSelectButton.TabIndex = 1;
            this.dbSelectButton.Text = "Select";
            this.dbSelectButton.UseVisualStyleBackColor = true;
            this.dbSelectButton.Click += new System.EventHandler(this.dbSelectButton_Click);
            // 
            // SearchTableCombobox
            // 
            this.SearchTableCombobox.FormattingEnabled = true;
            this.SearchTableCombobox.Location = new System.Drawing.Point(267, 116);
            this.SearchTableCombobox.Name = "SearchTableCombobox";
            this.SearchTableCombobox.Size = new System.Drawing.Size(89, 21);
            this.SearchTableCombobox.TabIndex = 2;
            this.SearchTableCombobox.Text = "Table";
            this.SearchTableCombobox.SelectedIndexChanged += new System.EventHandler(this.SearchRowCombobox_SelectedIndexChanged);
            // 
            // ProductAddButton
            // 
            this.ProductAddButton.Location = new System.Drawing.Point(22, 19);
            this.ProductAddButton.Name = "ProductAddButton";
            this.ProductAddButton.Size = new System.Drawing.Size(75, 23);
            this.ProductAddButton.TabIndex = 3;
            this.ProductAddButton.Text = "Add Row";
            this.ProductAddButton.UseVisualStyleBackColor = true;
            this.ProductAddButton.Click += new System.EventHandler(this.ProductAddButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(81, 116);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(136, 20);
            this.SearchTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search:";
            // 
            // ProductImportButton
            // 
            this.ProductImportButton.Location = new System.Drawing.Point(6, 19);
            this.ProductImportButton.Name = "ProductImportButton";
            this.ProductImportButton.Size = new System.Drawing.Size(107, 23);
            this.ProductImportButton.TabIndex = 7;
            this.ProductImportButton.Text = "Import Table";
            this.ProductImportButton.UseVisualStyleBackColor = true;
            this.ProductImportButton.Click += new System.EventHandler(this.ProductImportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddRowCombobox);
            this.groupBox1.Controls.Add(this.ProductAddButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 83);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding";
            // 
            // AddRowCombobox
            // 
            this.AddRowCombobox.FormattingEnabled = true;
            this.AddRowCombobox.Location = new System.Drawing.Point(22, 48);
            this.AddRowCombobox.Name = "AddRowCombobox";
            this.AddRowCombobox.Size = new System.Drawing.Size(75, 21);
            this.AddRowCombobox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProductsBrowseButton);
            this.groupBox2.Controls.Add(this.ImportTextBox);
            this.groupBox2.Controls.Add(this.ProductImportButton);
            this.groupBox2.Location = new System.Drawing.Point(139, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 83);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Importing";
            // 
            // ProductsBrowseButton
            // 
            this.ProductsBrowseButton.Location = new System.Drawing.Point(316, 17);
            this.ProductsBrowseButton.Name = "ProductsBrowseButton";
            this.ProductsBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ProductsBrowseButton.TabIndex = 11;
            this.ProductsBrowseButton.Text = "Browse";
            this.ProductsBrowseButton.UseVisualStyleBackColor = true;
            this.ProductsBrowseButton.Click += new System.EventHandler(this.ProductsBrowseButton_Click);
            // 
            // ImportTextBox
            // 
            this.ImportTextBox.Location = new System.Drawing.Point(119, 19);
            this.ImportTextBox.Name = "ImportTextBox";
            this.ImportTextBox.Size = new System.Drawing.Size(191, 20);
            this.ImportTextBox.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDefaultValuesToolStripMenuItem,
            this.clearTablesToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // setDefaultValuesToolStripMenuItem
            // 
            this.setDefaultValuesToolStripMenuItem.Name = "setDefaultValuesToolStripMenuItem";
            this.setDefaultValuesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setDefaultValuesToolStripMenuItem.Text = "Set default values";
            this.setDefaultValuesToolStripMenuItem.Click += new System.EventHandler(this.setDefaultValuesToolStripMenuItem_Click);
            // 
            // clearTablesToolStripMenuItem
            // 
            this.clearTablesToolStripMenuItem.Name = "clearTablesToolStripMenuItem";
            this.clearTablesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.clearTablesToolStripMenuItem.Text = "Delete tables";
            this.clearTablesToolStripMenuItem.Click += new System.EventHandler(this.clearTablesToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // ProductsImportProgressBar
            // 
            this.ProductsImportProgressBar.Location = new System.Drawing.Point(6, 16);
            this.ProductsImportProgressBar.Name = "ProductsImportProgressBar";
            this.ProductsImportProgressBar.Size = new System.Drawing.Size(292, 23);
            this.ProductsImportProgressBar.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProductsImportProgressBar);
            this.groupBox3.Location = new System.Drawing.Point(551, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 83);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progress";
            // 
            // SearchColumnCombobox
            // 
            this.SearchColumnCombobox.FormattingEnabled = true;
            this.SearchColumnCombobox.Location = new System.Drawing.Point(386, 116);
            this.SearchColumnCombobox.Name = "SearchColumnCombobox";
            this.SearchColumnCombobox.Size = new System.Drawing.Size(159, 21);
            this.SearchColumnCombobox.TabIndex = 15;
            this.SearchColumnCombobox.Text = "Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "FROM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "IN";
            // 
            // BrowseImportDialog
            // 
            this.BrowseImportDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchColumnCombobox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SearchTableCombobox);
            this.Controls.Add(this.dbSelectButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dbSelectButton;
        private System.Windows.Forms.ComboBox SearchTableCombobox;
        private System.Windows.Forms.Button ProductAddButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ProductImportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ProductsBrowseButton;
        private System.Windows.Forms.TextBox ImportTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDefaultValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ProgressBar ProductsImportProgressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox AddRowCombobox;
        private System.Windows.Forms.ComboBox SearchColumnCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog BrowseImportDialog;
    }
}

