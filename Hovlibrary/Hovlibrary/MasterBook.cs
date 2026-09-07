using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hovlibrary
{
    public partial class MasterBook : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int id;
        public MasterBook()
        {
            InitializeComponent();
        }

        private void MasterBook_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void LoadDgv()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = db.Books.Select(x => new
            {
                ID = x.id,
                Language = x.Language.long_text,
                Title = x.title,
                ISBN = x.isbn,
                ISBN13 = x.isbn13,
                Author = x.authors,
                Publisher = x.Publisher.name,
                PublicationYear = x.publication_date,
                PageCount = x.number_of_pages,
                Ratings = x.average_rating,
            }).ToList();

            DataGridViewButtonColumn show = new DataGridViewButtonColumn();
            show.Name = "Show";
            show.HeaderText = "Book List";
            show.Text = "Show";
            show.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(show);

            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.Name = "edit";
            edit.HeaderText = "Book List";
            edit.Text = "edit";
            edit.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(edit);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.Name = "delete";
            delete.HeaderText = "Book List";
            delete.Text = "delete";
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
        }

        private void EnableTrue(bool enable)
        {
            txtLanguage.Enabled = enable;
            txtTitle.Enabled = enable;
            txtIsbn.Enabled = enable;
            txtIsbn13.Enabled = enable;
            txtPublisher.Enabled = enable;
            dateTimePicker1.Enabled = enable;
            txtAuthors.Enabled = enable;
            txtPage.Enabled = enable;
            txtRatings.Enabled = enable;
            btnSave.Enabled = enable;
        }

        private void clearField()
        {
            txtLanguage.Text = "";
            txtTitle.Text = "";
            txtIsbn.Text = "";
            txtIsbn13.Text = "";
            txtPublisher.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtAuthors.Text = "";
            txtPage.Text = "";
            txtRatings.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Show")
            {
                clearField();
                EnableTrue(false);
                
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                txtLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtIsbn.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtIsbn13.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAuthors.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPublisher.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                txtPage.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtRatings.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "edit")
            {
                clearField();
                EnableTrue(true);

                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                txtLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtIsbn.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtIsbn13.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAuthors.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPublisher.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                txtPage.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtRatings.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "delete")
                {
                    var query = db.Books.FirstOrDefault(x => x.id == Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
                    db.Books.DeleteOnSubmit(query);
                    db.SubmitChanges();
                    MessageBox.Show("Delete Berhasil!!");
                    LoadDgv();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var query = db.Books.FirstOrDefault(x => x.id == id);
            query.language_id = db.Languages.FirstOrDefault(x => x.long_text.Equals(txtLanguage.Text)).id;
            query.title = txtTitle.Text;
            query.isbn = txtIsbn.Text;
            query.isbn13 = txtIsbn13.Text;
            query.authors = txtAuthors.Text;
            query.publisher_id = db.Publishers.FirstOrDefault(x => x.name.Equals(txtPublisher.Text)).id;
            query.publication_date = dateTimePicker1.Value;
            query.number_of_pages = Convert.ToInt32(txtPage.Text);
            query.average_rating = Convert.ToDouble(txtRatings.Text);

            db.SubmitChanges();
            MessageBox.Show("Update Berhasil!!");

            clearField();  
            EnableTrue(false);
            LoadDgv();
        }
    }
}
