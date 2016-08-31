using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label1.Text = 
                          "Hey, im glad to see you in my application." + Environment.NewLine +
                          "Before you start please make sure that both Products.csv and Fitments.csv files are in the folder 'Resources'." + Environment.NewLine +
                          "Managing your data is very simple, just use controls." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "After you run application database and tables has been created (if needed)" + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Praparing for work" + Environment.NewLine +
                          "First, select 'Database' from menu strip, than press 'Set default values'" + Environment.NewLine +
                          "This operation will restore default data from files to the database" + Environment.NewLine +
                          "After this you will be able to manipulate with rows by selecting them from 'Select' state over the result data field" + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Data search" + Environment.NewLine +
                          "Write any search word in the search field, choose table and column you need, then press 'Select'" + Environment.NewLine +
                          "Now you can see first 10 rows that mathes your query." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Edit row" + Environment.NewLine +
                          "If you want to edit cell, just select cell you need and write some value into it." + Environment.NewLine +
                          "After you end edit cell this value will be saved." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Delete row" + Environment.NewLine +
                          "If you want to delete row, select whole row and press 'Delete' on the keyboard." + Environment.NewLine +
                          "This record will be deleted from the table emmidiately." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Adding row" + Environment.NewLine +
                          "For adding any row you have to press 'Add Row' button and fill all fields thet you want to insert" + Environment.NewLine +
                          "Than press 'Save'. Record now added to the table." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Import" + Environment.NewLine +
                          "Importing data is available by pressing 'Import Table'. Dont forget to select path to the import file." + Environment.NewLine +
                          "" + Environment.NewLine +
                          "Delete tables" + Environment.NewLine +
                          "You may clear all data with tables by pressing 'Database' in menu strip, then press 'Delete tables'.";

        }
    }
}
