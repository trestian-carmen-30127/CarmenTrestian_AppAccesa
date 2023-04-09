using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Data.SqlClient;
using System.Data.Entity;
using static EduFuture.XtraForm2;

namespace EduFuture
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm4()
        {
            InitializeComponent();
           // this.Load += new EventHandler(XtraForm4_Load);

        }
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");


        int userId = UserSession.UserId;
        string username = UserSession.Username;

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            con.Open();
          
            SqlCommand rank = new SqlCommand("SELECT Rank FROM Users WHERE Username=@username", con);
            rank.Parameters.AddWithValue("@username", username);
            string r = (string)rank.ExecuteScalar();

            if (r != null && (string.Compare(r.Trim(), "teacher") == 0))
            {
                XtraForm5 frm = new XtraForm5();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("You don't have the teacher rank yet.");

            con.Close();
        }

        private void XtraForm4_Load(object sender, EventArgs e)
        {  
            con.Open();
     

            SqlCommand rank = new SqlCommand("SELECT Rank FROM Users WHERE Username=@username", con);
            rank.Parameters.AddWithValue("@username", username);
            string r = (string)rank.ExecuteScalar();// dupa ce insereaza un quest se pierde variabila users-ului
            textEdit2.Text = r;

            SqlCommand tokens = new SqlCommand("SELECT Tokens FROM Users WHERE Username=@username", con);
            tokens.Parameters.AddWithValue("@username", username);
            int t = Convert.ToInt32(tokens.ExecuteScalar());
            textEdit1.Text = t.ToString();

            SqlCommand badges = new SqlCommand("SELECT Badges FROM Users WHERE Username=@username", con);
            badges.Parameters.AddWithValue("@username", username);
            int b = Convert.ToInt32(badges.ExecuteScalar());
            textEdit4.Text = b.ToString();

            con.Close();
        }

    }
}