using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MsiReader;

namespace MsiPropertiesReader
{
    public partial class FrmMain : Form
    {
        private MsiFile msiFile;

        public FrmMain(string[] args)
        {
            InitializeComponent();
            if (args != null && args.Length == 1 && !String.IsNullOrEmpty(args[0]))
            {
                try
                {
                    var file = new System.IO.FileInfo(args[0]);
                    if (file.Exists)
                    {
                        OpenMsiFile(args[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OpenMsiFile(string filename)
        {
            try
            {
                msiFile = new MsiFile(filename);

                dtGrvProperties.Rows.Clear();
                dtGrvProperties.Columns.Clear();
                cmbBxPropertyNames.Items.Clear();

                SortedDictionary<string, Table> tables = msiFile.GetAllTables();
                int propertyIndex = -1;

                foreach (KeyValuePair<string, Table> pair in tables)
                {
                    if (pair.Value.IsOrdered)
                    {
                        int index = cmbBxPropertyNames.Items.Add(pair.Value);
                        if (String.Compare(pair.Value.Name, "Property", true) == 0)
                        { propertyIndex = index; }
                    }
                }
                if (propertyIndex != -1)
                {
                    cmbBxPropertyNames.SelectedIndex = propertyIndex;
                    dtGrvProperties.Sort(dtGrvProperties.Columns[0], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLoadMsiFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenMsiFile(openFileDialog1.FileName);
            }
        }

        private void CmbBxPropertyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtGrvProperties.Rows.Clear();
            dtGrvProperties.Columns.Clear();

            try
            {
                if (cmbBxPropertyNames.SelectedIndex != -1 && cmbBxPropertyNames.SelectedItem != null)
                {
                    Table table = (Table)cmbBxPropertyNames.SelectedItem;

                    table = msiFile.GetAllValuesFromTable(table);

                    SortedDictionary<int, Column> columns = new SortedDictionary<int, Column>();

                    foreach (Column column in table.Columns)
                    {
                        columns.Add(column.Order, column);
                    }

                    foreach (KeyValuePair<int, Column> pair in columns)
                    {
                        dtGrvProperties.Columns.Add(pair.Value.Name, pair.Value.Name);
                    }

                    DataGridViewRow productCodeRow = null;

                    for (int i = 0; i < columns[1].Values.Count; i++)
                    {
                        int index = dtGrvProperties.Rows.Add();
                        DataGridViewRow row = dtGrvProperties.Rows[index];

                        foreach (KeyValuePair<int, Column> pair in columns)
                        {
                            if (pair.Value.Values.Count != 0)
                                row.Cells[pair.Value.Name].Value = pair.Value.Values[i];
                        }
                        if (String.Compare(row.Cells[0].Value.ToString(), "ProductCode", true) == 0)
                        {
                            productCodeRow = row;
                        }
                    }
                    dtGrvProperties.Sort(dtGrvProperties.Columns[0], ListSortDirection.Ascending);
                    if (productCodeRow != null)
                    {
                        dtGrvProperties.ClearSelection();
                        productCodeRow.Selected = true;
                        dtGrvProperties.FirstDisplayedScrollingRowIndex = productCodeRow.Index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
