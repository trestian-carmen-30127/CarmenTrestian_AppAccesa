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
using System.Data.Entity;
using static EduFuture.XtraForm2;

namespace EduFuture
{
    public partial class XtraForm5 : DevExpress.XtraEditors.XtraForm
    {
        
        public XtraForm5()
        {
            InitializeComponent();
            

        }
        private SqlConnection con = new SqlConnection("Data Source=" +"LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");
        

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
            int userId = UserSession.UserId;
            string username = UserSession.Username;
            int i;
            
           using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id_quest) FROM Quest", con))
            {
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            i++;
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
              
                SqlCommand id = new SqlCommand("SELECT Id_user FROM Users WHERE Id_user=@userId", con);//nu se transmite aici userul din form2
                id.Parameters.AddWithValue("@userId", userId);
                int j = Convert.ToInt32(id.ExecuteScalar());

                SqlCommand Insert_User_q = con.CreateCommand();
                Insert_User_q.CommandText = "INSERT INTO User_q (Id_userq, Id_userfk,Id_questfk,Type) VALUES (@Id_userq, @Id_userfk, @Id_questfk,@Type )";
                Insert_User_q.Parameters.AddWithValue("@Id_userq", i);
                Insert_User_q.Parameters.AddWithValue("@Id_userfk", j);
                Insert_User_q.Parameters.AddWithValue("@Id_questfk", i);
                Insert_User_q.Parameters.AddWithValue("@Type", "created");
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