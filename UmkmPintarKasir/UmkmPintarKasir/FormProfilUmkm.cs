using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using UmkmPintarKasir.Data;

namespace UmkmPintarKasir
{
    public partial class FormProfilUmkm : Form
    {
        private int? _idProfil = null;

        public FormProfilUmkm()
        {
            InitializeComponent();

            this.Load += FormProfilUmkm_Load;
            btnSimpan.Click += BtnSimpan_Click;
            btnTutup.Click += (s, e) => this.Close();
        }

        private void FormProfilUmkm_Load(object sender, EventArgs e)
        {
            LoadProfil();
        }

        private void LoadProfil()
        {
            string sql = "SELECT * FROM umkm_profil LIMIT 1";
            DataTable dt = DbConnectionHelper.ExecuteQuery(sql);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                _idProfil = Convert.ToInt32(row["id_profil"]);
                txtNamaToko.Text = row["nama_toko"].ToString();
                txtAlamat.Text = row["alamat_toko"].ToString();
                txtNpwp.Text = row["npwp"].ToString();
                txtKontak.Text = row["kontak"].ToString();
                txtTarif.Text = row["tarif_pph"].ToString();
            }
            else
            {
                _idProfil = null;
                txtTarif.Text = "0.005";  // default 0.5%
            }
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaToko.Text))
            {
                MessageBox.Show("Nama Toko wajib diisi.");
                return;
            }

            decimal tarif;
            if (!decimal.TryParse(txtTarif.Text, out tarif))
            {
                MessageBox.Show("Tarif PPh tidak valid.");
                return;
            }

            string sql;
            NpgsqlParameter[] p = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@nama", txtNamaToko.Text.Trim()),
                new NpgsqlParameter("@alamat", txtAlamat.Text.Trim()),
                new NpgsqlParameter("@npwp", txtNpwp.Text.Trim()),
                new NpgsqlParameter("@kontak", txtKontak.Text.Trim()),
                new NpgsqlParameter("@tarif", tarif)
            };

            if (_idProfil == null)
            {
                sql = @"
                    INSERT INTO umkm_profil
                        (nama_toko, alamat_toko, npwp, kontak, tarif_pph)
                    VALUES
                        (@nama, @alamat, @npwp, @kontak, @tarif)";
            }
            else
            {
                sql = @"
                    UPDATE umkm_profil SET
                        nama_toko = @nama,
                        alamat_toko = @alamat,
                        npwp = @npwp,
                        kontak = @kontak,
                        tarif_pph = @tarif
                    WHERE id_profil = @id";

                Array.Resize(ref p, 6);
                p[5] = new NpgsqlParameter("@id", _idProfil.Value);
            }

            int affected = DbConnectionHelper.ExecuteNonQuery(sql, p);

            if (affected > 0)
            {
                MessageBox.Show("Profil UMKM tersimpan.");
                this.Close();
            }
        }
    }
}
