using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TestApplication.Helpers;

namespace TestApplication
{
    public partial class MainForm : Form
    {
        private List<CsvReader> _defaultEntities;
        private DbHelper _database;

        private string CellInitial;

        public delegate void ProgressStatus(int status);
        public event ProgressStatus progressStatus;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _defaultEntities = new List<CsvReader>();
                foreach (string table in Constants.DefaultTables)
                {
                    _defaultEntities.Add(new CsvReader(table)); 
                }
                DbInitialize();
                RefreshTableComboboxes();
            }
            catch (FileNotFoundException)
            {
                ShowMessage("Resource files not fount. Please, check resource folder;");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        private void BindDataGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _database.TableDataSet.Tables[0];
        }

        private void RefreshTableComboboxes(bool clear = false)
        {
            if (!clear)
            {
                AddRowCombobox.Items.Clear();
                SearchTableCombobox.Items.Clear();

                List<string> tables = GetTableList();

                foreach (string table in tables)
                {
                    AddRowCombobox.Items.Add(table);
                    SearchTableCombobox.Items.Add(table);

                    AddRowCombobox.SelectedItem = table;
                    SearchTableCombobox.SelectedItem = table;
                }
            }
            else
            {
                AddRowCombobox.Items.Clear();
                AddRowCombobox.Text = string.Empty;
                SearchTableCombobox.Items.Clear();
                SearchTableCombobox.Text = string.Empty;
            }
        }

        private List<string> GetTableList()
        {
            List<string> tables = new List<string>();

            foreach (CsvReader csv in _defaultEntities)
            {
                tables.Add(csv.TableName);
            }
            return tables;
        }

        private void DbInitialize()
        {
            _database = new DbHelper(_defaultEntities);


            
        }

        
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void setDefaultValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTables();
            Thread thread = new Thread(FillTables);
            thread.Start(_defaultEntities);
        }

        public void FillTables(object csv)
        {
            try
            {
                List<CsvReader> f = (List<CsvReader>) csv;
                SetUpProgressBar(f);
                _database.progressStatus += UpdateProgressBar;
                _database.FillTables(f);
                InvokeUpdateTableComboboxes();
                ShowMessage("Tables imported");

            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        private int GetMaxProgressBarSize(List<CsvReader> csv)
        {
            int result = 0;
            foreach (CsvReader csvReader in csv)
            {
                result += csvReader.Rows.Count;
            }
            return result;
        }

        public void UpdateProgressBar(int parameter)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(
                    delegate
                    {
                        UpdateProgressBar(parameter);
                    }
                    ));
            ProductsImportProgressBar.Value = parameter;
        }
        public void InvokeUpdateTableComboboxes( bool clear = false)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(
                    delegate
                    {
                        RefreshTableComboboxes( clear);
                    }
                    ));

        }

        public void SetUpProgressBar(List<CsvReader> csv)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(
                    () => SetUpProgressBar(csv)
                    ));
            ProductsImportProgressBar.Minimum = 0;
            ProductsImportProgressBar.Maximum = GetMaxProgressBarSize(csv);
        }

        private void clearTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTables();
        }

        private void DeleteTables()
        {
            try
            {
                foreach (CsvReader csvReader in _defaultEntities)
                {
                    csvReader.ClearOffset();
                }
                string msg = "Are you sure you want to delete used tables?";
                foreach (string table in GetTableList())
                {
                    msg += "\n" + table;
                }
                if (MessageBox.Show(msg, "Delete tables", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _database.ClearTables(GetTableList());
                    RefreshTableComboboxes(true);
                    MessageBox.Show("Your tables were deleted from database.", "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        private void dbSelectButton_Click(object sender, EventArgs e)
        {
            SearchFromTable();
        }

        private void SearchRowCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchTableCombobox.SelectedItem != null)
            {
                List<string> columns = _database.GetTableColumns(SearchTableCombobox.SelectedItem.ToString());
                SearchColumnCombobox.Items.AddRange(columns.ToArray());
                SearchColumnCombobox.SelectedIndex = 0;
            }
        }


        private void SearchFromTable()
        {
            if (AddRowCombobox.Text!=string.Empty)
            {
                try
                {
                    dataGridView1.Columns.Clear();
                    _database.SearchInDatabase(SearchTableCombobox.Text, SearchColumnCombobox.Text, SearchTextBox.Text);

                    BindDataGrid();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.ToString());
                }
                
            }
        }

        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            if (AddRowCombobox.SelectedItem!=null)
            {
                CsvReader csv = _defaultEntities.Find(x => x.TableName == AddRowCombobox.SelectedItem.ToString());
                AddForm addForm = new AddForm(csv, _database);
                addForm.Show();
                
            }
        }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (CellInitial != null && CellInitial != value)
            {
                var key = dataGridView1[0, e.RowIndex].Value.ToString();
                var column = dataGridView1.Columns[e.ColumnIndex].Name;
                var idcol = dataGridView1.Columns[0].Name;
                _database.UpdateTableRows(SearchTableCombobox.SelectedItem.ToString(), key, column, value, idcol);

            } /**/
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            CellInitial = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var key = e.Row.Cells[0].Value.ToString();
            var idcol = dataGridView1.Columns[0].Name;
            _database.DeleteTableRow(SearchTableCombobox.SelectedItem.ToString(), key, idcol);
        }

        private void ProductsBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = BrowseImportDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImportTextBox.Text = BrowseImportDialog.FileName;
            }
        }

        private void ProductImportButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (ImportTextBox.Text != string.Empty)
                {
                    CsvReader newData = new CsvReader(ImportTextBox.Text);
                    List<CsvReader> csv = new List<CsvReader>();
                    csv.Add(newData);

                    Thread thread = new Thread(FillTables);
                    thread.Start(csv);

                }
                else
                {
                    ShowMessage("Please, fill path value");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

    }

}
