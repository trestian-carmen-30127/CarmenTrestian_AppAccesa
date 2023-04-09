﻿using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EduFuture
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
       
        public XtraForm2()
        {
            InitializeComponent();
        }
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");


        public static class UserSession
        {
            public static int UserId { get; set; }
            public static string Username { get; set; }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            con.Open();

            string user = textEdit1.Text;
            SqlCommand pass = new SqlCommand("SELECT Password FROM Users WHERE Username=@user", con);
            pass.Parameters.AddWithValue("@user", user);
            string p= (string)pass.ExecuteScalar();


            if ( p!=null && (string.Compare(p.Trim(),textEdit2.Text)==0 ))
            {
                SqlCommand id = new SqlCommand("SELECT Tokens FROM Users WHERE Username=@user", con);
                id.Parameters.AddWithValue("@user", user);
                int i = Convert.ToInt32(id.ExecuteScalar());
                UserSession.UserId = i;
                UserSession.Username = user;
                XtraForm4 frm = new XtraForm4();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();

            }
            else MessageBox.Show("The password or username is invalid.") ;

          

            con.Close();
         


        }

        
    }
}