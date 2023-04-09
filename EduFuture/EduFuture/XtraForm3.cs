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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.ClipboardSource.SpreadsheetML;
using Microsoft.VisualStudio.Services.Commerce;
//using EduFuture.DiagramTableAdapters;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Native.EntityFramework;
using System.Data.Common;
//using static DevExpress.Data.Utils.AsyncDownloader<TValue>.LifeTime;
//using DevExpress.DataAccess.UI.Sql;


namespace EduFuture
{
    public partial class XtraForm3 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm3()
        {
            InitializeComponent();
        }
     
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");
        private SqlDataAdapter Da = new SqlDataAdapter();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int i;

            using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id_user) AS ID FROM Users", con))
            {
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar()) ;
                con.Close();
                
            }
            i++;
            try
            {
                
                con.Open();
                SqlCommand Insert_Users = con.CreateCommand();
                Insert_Users.CommandText = "INSERT INTO Users (Id_user, Username, Password, Age , Email,Badges,Rank,Tokens) VALUES (@Id_user, @Username, @Password, @Age, @Email,@Badges,@Rank,@Tokens)";
                    Insert_Users.Parameters.AddWithValue("@Id_user", i);
                    Insert_Users.Parameters.AddWithValue("@Username", textEdit1.Text);
                    Insert_Users.Parameters.AddWithValue("@Password", textEdit4.Text);
                    Insert_Users.Parameters.AddWithValue("@Age", textEdit3.Text);
                    Insert_Users.Parameters.AddWithValue("@Email", textEdit2.Text);
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
           
            con.Close() ;

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