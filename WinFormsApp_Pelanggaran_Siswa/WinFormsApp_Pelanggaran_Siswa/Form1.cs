using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormPelanggara : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private System.Windows.Forms.Timer refreshTimer;

        public FormPelanggara()
        {
            InitializeComponent();

            this.Load += FormPelanggara_Load;

            InitializeRefreshTimer();
        }

        private void FormPelanggara_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadTopPelanggar();
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 3000
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LoadTopPelanggar));
            }
            else
            {
                LoadTopPelanggar();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        private void SetupDataGridView()
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.RowTemplate.Height = 35;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
        }

        private void LoadTopPelanggar()
        {
            try
            {
                if (dataGridView2 == null) return;

                using (var conn = Konn.GetConn())
                {
                    conn.Open();

                    string queryTop = @"
                        SELECT TOP 20
                            nis, nama, kelas, total_point
                        FROM siswa
                        ORDER BY total_point DESC;";

                    var dt = new DataTable();
                    using (var da = new SqlDataAdapter(queryTop, conn))
                    {
                        da.Fill(dt);
                    }

                    dataGridView2.DataSource = dt;

                    if (dataGridView2.Columns["nis"] != null) dataGridView2.Columns["nis"].HeaderText = "NIS";
                    if (dataGridView2.Columns["nama"] != null) dataGridView2.Columns["nama"].HeaderText = "Nama";
                    if (dataGridView2.Columns["kelas"] != null) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                    if (dataGridView2.Columns["total_point"] != null) dataGridView2.Columns["total_point"].HeaderText = "Point";

                    UpdateDashboardLabels(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDashboardLabels(SqlConnection conn)
        {
            string sqlCountSiswa = "SELECT COUNT(*) FROM siswa WHERE status = 'aktif'";
            using (var cmd = new SqlCommand(sqlCountSiswa, conn))
            {
                if (label6 != null)
                {
                    object val = cmd.ExecuteScalar();
                    label6.Text = (val == null || val == DBNull.Value) ? "0" : val.ToString();
                }
            }

            string sqlCountToday = "SELECT COUNT(*) FROM pelanggaran WHERE CAST(created_at AS DATE) = CAST(GETDATE() AS DATE)";
            using (var cmd = new SqlCommand(sqlCountToday, conn))
            {
                if (label9 != null)
                {
                    object val = cmd.ExecuteScalar();
                    label9.Text = (val == null || val == DBNull.Value) ? "0" : val.ToString();
                }
            }

            string sqlTopStudent = "SELECT TOP 1 nama FROM siswa ORDER BY total_point DESC";
            using (var cmd = new SqlCommand(sqlTopStudent, conn))
            {
                if (lblpointtertinggi != null)
                {
                    object val = cmd.ExecuteScalar();
                    lblpointtertinggi.Text = (val == null || val == DBNull.Value) ? "" : val.ToString();
                }
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (sender is not DataGridView dgv || dgv.DataSource == null) return;

                if (!dgv.Columns.Contains("total_point")) return;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["total_point"].Value is not null && int.TryParse(row.Cells["total_point"].Value.ToString(), out int point))
                    {
                        row.DefaultCellStyle.BackColor = point switch
                        {
                            > 100 => Color.LightGray,
                            > 50 => Color.LightCoral,
                            > 25 => Color.Yellow,
                            _ => Color.LightGreen
                        };
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                // Mencegah error crash
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormPelanggara_Load_1(object sender, EventArgs e)
        {

        }
    }
}