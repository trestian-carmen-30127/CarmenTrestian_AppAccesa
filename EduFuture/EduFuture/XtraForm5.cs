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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace EduFuture
{
    public partial class XtraForm5 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm5()
        {
            InitializeComponent();
            this.Load += new EventHandler(XtraForm5_Load);

        }
        private string user;
        public string Usern
        {
            set { user = value; }
        }
        private SqlConnection con = new SqlConnection("Data Source=" +"LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");
    //    private SqlDataAdapter Da = new SqlDataAdapter();
        private void back_Click(object sender, EventArgs e)
        {
            XtraForm4 frm = new XtraForm4();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
       

        private void createq_Click(object sender, EventArgs e)
        {
           
            int i=1;
           /*using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id_user) FROM Users", con))
            {
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            i++;*/
            try
            {

                con.Open();
                SqlCommand Insert_Users = con.CreateCommand();
                Insert_Users.CommandText = "INSERT INTO Quest (Id_quest,Domain,Question,Answer,Prize) VALUES (@Id_quest,@Domain,@Question,@Answer,@Prize)";
                Insert_Users.Parameters.AddWithValue("@Id_Quest", i);
                Insert_Users.Parameters.AddWithValue("@Domain", comboBoxEdit1.SelectedItem.ToString());
                Insert_Users.Parameters.AddWithValue("@Question", textEdit2.Text);
                Insert_Users.Parameters.AddWithValue("@Answer", textEdit3.Text);
                Insert_Users.Parameters.AddWithValue("@Prize", textEdit1.Text);
                Insert_Users.ExecuteNonQuery();
                MessageBox.Show(user);
                // ia id ul userului pentru a il seta in tabela
                SqlCommand id = new SqlCommand("SELECT Id_user FROM Users WHERE Username=@user", con);
                id.Parameters.AddWithValue("@user", user);
                int j = Convert.ToInt32(id.ExecuteScalar())+1;

                SqlCommand Insert_User_q = con.CreateCommand();
                Insert_User_q.CommandText = "INSERT INTO User_q (Id_userq, Id_quest,Id_user) VALUES (@Id_userq, @Id_quest , @Id_user )";
                Insert_User_q.Parameters.AddWithValue("@Id_userq", i);
                Insert_User_q.Parameters.AddWithValue("@Id_quest", i);
                Insert_User_q.Parameters.AddWithValue("@Id_user", j);
                Insert_User_q.ExecuteNonQuery();

                MessageBox.Show("Your quest was created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            XtraForm4 frm = new XtraForm4();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

       
    }
}