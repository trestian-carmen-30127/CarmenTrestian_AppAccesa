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
using System.Data.SqlClient;
//using EduFuture.DiagramTableAdapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.ClipboardSource.SpreadsheetML;
using Microsoft.VisualStudio.Services.Commerce;


namespace EduFuture
{
    public partial class XtraForm3 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm3()
        {
            InitializeComponent();
        }
      //  SqlConnection con= new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\trest\Documents\Test tehnic Accesa\CarmenTrestian_AppAccesa\EduFuture\EduFuture\Usersdb.mdf;Integrated Security = True");
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           /* //int i = int.Parse(AccountsTableAdapter.Last_Idaccount().ToString());
            try
            {
                int i = 1;
                con.Open();
                SqlCommand Insert_Accounts = con.CreateCommand();
                Insert_Accounts.CommandText = "INSERT INTO Accounts (Id_account, Id_user, Username, Password, Age , Email) VALUES (@Id_account,@Id_user, @Username, @Password, @Age, @Email)";
                Insert_Accounts.Parameters.AddWithValue("@Id_account", i);
                Insert_Accounts.Parameters.AddWithValue("@Id_user", i);
                Insert_Accounts.Parameters.AddWithValue("@Username", textEdit1.Text);
                Insert_Accounts.Parameters.AddWithValue("@Password", textEdit4.Text);
                Insert_Accounts.Parameters.AddWithValue("@Age", textEdit3.Text);
                Insert_Accounts.Parameters.AddWithValue("@Email", textEdit2.Text);
                Insert_Accounts.ExecuteNonQuery();
                SqlCommand Insert_Users = con.CreateCommand();
                Insert_Users.CommandText = "INSERT INTO Users (Id_user,Username,Badges,Rank,Tokens) VALUES (@Id_user,@Username,@Badges,@Rank,@Tokens)";
                Insert_Users.Parameters.AddWithValue("@Id_user", i);
                Insert_Users.Parameters.AddWithValue("@username", textEdit1.Text);
                Insert_Users.Parameters.AddWithValue("@Badges", 0);
                if (checkBox1.Checked) Insert_Users.Parameters.AddWithValue("@Rank", "teacher");
                else Insert_Users.Parameters.AddWithValue("@Rank", "begginer");
                Insert_Users.Parameters.AddWithValue("@Tokens", 0);
                Insert_Users.ExecuteNonQuery();
                MessageBox.Show("Your account was created!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();

            */

            XtraForm4 frm = new XtraForm4();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void XtraForm3_Load(object sender, EventArgs e)
        {

        }
    }
}