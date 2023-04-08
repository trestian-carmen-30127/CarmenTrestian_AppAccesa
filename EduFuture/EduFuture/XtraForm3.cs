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
using EduFuture.DiagramTableAdapters;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Native.EntityFramework;
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
         SqlConnection con = new SqlConnection(@"Data Source=LocalDB\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\trest\\Documents\\Test tehnic Accesa\\CarmenTrestian_AppAccesa\\EduFuture\\EduFuture\\EduFuturedb.mdf;Integrated Security = True; Connect Timeout = 30");
        //private SqlConnection con = new SqlConnection("Data Source=" +
        //   "LAPTOP-GPJH9TCQ;Initial Catalog=EduFuturedb;Integrated Security=True");
      

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          

            int i = 1;
             try
            {
                
                con.Open();
                SqlCommand Insert_Users = con.CreateCommand();
                    Insert_Users.CommandText = "INSERT INTO Accounts (Id_user, Username, Password, Age , Email,Badges,Rank,Tokens) VALUES (@Id_user, @Username, @Password, @Age, @Email,@Badges,@Rank,@Tokens)";
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