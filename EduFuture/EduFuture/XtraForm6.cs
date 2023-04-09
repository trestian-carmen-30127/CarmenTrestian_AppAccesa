using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EduFuture.XtraForm2;
using static EduFuture.XtraForm4;
namespace EduFuture
{
    public partial class XtraForm6 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm6()
        {
            InitializeComponent();
        }
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");


        int userId = UserSession.UserId;
        string username = UserSession.Username;
        string questiontxt = QuestSession.Questiontxt;
        private void XtraForm6_Load(object sender, EventArgs e)
        {
            labelControl1.Text = questiontxt;
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraForm4 frm = new XtraForm4();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand answer = new SqlCommand("SELECT Answer FROM Quest WHERE Question=@questiontxt", con);
            answer.Parameters.AddWithValue("@question", questiontxt);
            string q = (string)answer.ExecuteScalar();
            if (q != null && (string.Compare(q.Trim(), textEdit1.Text) == 0))
            {

            }
            else MessageBox.Show("Your answer is wrong.");
        }
    }
}