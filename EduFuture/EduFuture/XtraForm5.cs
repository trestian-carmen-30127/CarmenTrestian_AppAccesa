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
        }
        private SqlConnection con = new SqlConnection("Data Source=" +"LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");
        private SqlDataAdapter Da = new SqlDataAdapter();
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
            int i = 1;
           
          
            

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
                MessageBox.Show("Your account was created!");
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