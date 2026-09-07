using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Motor_Maleke_
{
    public partial class Transaction : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public Transaction()
        {
            InitializeComponent();
        }

        void generateId() 
        {
            var query = db.TransactionServices.OrderByDescending(x => x.TransactionNumber ).AsEnumerable().Where(x =>x.TransactionDate.Value.Month == DateTime.Now.Month && x.TransactionDate.Value.Year == DateTime.Now.Year).ToList();
            var totalTransaksi = query.Count() + 1;
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var currentDay = DateTime.Now.Day;
            var lastId = "T" + totalTransaksi.ToString("000") + currentMonth + currentYear;

            txtTransaction.Text = lastId;
            txtDamage.Text = currentDay.ToString("00") +" "+ DateTime.Now.ToString("MMM")+" "+ currentYear;
        }

        void loadservice()
        {
            dataGridView1.DataSource = services;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }
        private void Transaction_Load(object sender, EventArgs e)
        {
            generateId();
            loadservice();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void loopDgvService()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == dataGridView1.Rows.Count)
                {
                    continue;
                }
                MessageBox.Show(row.Index.ToString());
                if (string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                {
                    continue; 
                }

                TotalCostService += int .Parse(row.Cells[2].Value.ToString());
                txtTotalServicecost.Text = TotalCostService.ToString();
            }
        }

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                int col = dataGridView1.CurrentCell.ColumnIndex;

                MessageBox.Show(row.ToString());
            }
        }
        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex - 1];
                var code = row.Cells[0].Value.ToString();
                var query = db.MotorcycleServices.FirstOrDefault(x => x.ServiceCode == code);

                if (query != null)
                {
                    return;
                }

                row.Cells[1].Value = query.ServiceName; 
                row.Cells[2].Value = query.Cost;



            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clicked = true;
            MessageBox.Show("Test");
        }
    }
}
