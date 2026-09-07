using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petertemuan1LKS
{
    public partial class Form2 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-M-yyyy H:m:s");
            loaddgv();
        }
        private void loaddgv()
        {
            var query = db.Users.Where(x => x.Role == '2').Select(x => new
            {
                User = x.FullName,
                x.Gender,
                x.BirthDate,
                x.IsActive
            }).ToList();
            dataGridView1.DataSource = query;

            var query2 = db.Participants.Where(x => x.User.Role == '2').Select(x => new
            {
                User = x.User.FullName,
                x.Subject.Name,
                x.Date,
                x.TimeTaken,
                Answered = db.ParticipantAnswers.Where(pa => pa.ParticipantID == x.ID).Count(),
                Unanswered = db.Questions.Where(pa => pa.SubjectID == x.SubjectID).Count() - db.ParticipantAnswers.Where(pa => pa.ParticipantID == x.ID).Count()
            }).ToList();
            dataGridView2.DataSource = query2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
        