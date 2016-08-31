using System.Collections.Generic;
using System.Windows.Forms;
using TestApplication.Helpers;

namespace TestApplication
{
    public partial class AddForm : Form
    {
        private CsvReader _csv;
        private DbHelper _database;
        public AddForm(CsvReader csv, DbHelper database)
        {
            InitializeComponent();
            _csv = csv;
            _database = database;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("Key","Key");
            dataGridView1.Columns.Add("Value", "Value");

            List<string> columns = _database.GetTableColumns(_csv.TableName);
            foreach (string key in columns)
            {
                dataGridView1.Rows.Add(key, string.Empty);
            }
        }

        private void SaveRowButton_Click(object sender, System.EventArgs e)
        {
            Dictionary<string,string> result = new Dictionary<string, string>();
            foreach (DataGridViewRow  row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    result.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
            }
            _database.AddTableRows(result, _csv.TableName);
            MessageBox.Show("Row added");
            this.Close();
        }

    }
}
