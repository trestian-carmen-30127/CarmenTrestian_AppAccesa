﻿using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace EduFuture
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm4()
        {
            InitializeComponent();

        }
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");


        int userId = UserSession.UserId;
        string username = UserSession.Username;

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
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
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void XtraForm4_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            try
            {
                if (con.State != ConnectionState.Open)
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

                }
            }
            finally
            {
                con.Close();
            }
           
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand number = new SqlCommand("SELECT COUNT(Id_userq) FROM User_q WHERE Type='created'", con);
            int n = Convert.ToInt32(number.ExecuteScalar());
            for (int i=1;i<=n;i++)
            {
                SqlCommand questions = new SqlCommand("SELECT t1.Question FROM Quest t1 INNER JOIN User_q t2 ON t1.Id_quest=t2.Id_questfk WHERE Type='created' AND t1.Domain='Computer Science'", con);
                questions.Parameters.AddWithValue("@username", username);
                string q = (string)questions.ExecuteScalar();//eroare
                        if (listBox1.FindStringExact(q) == ListBox.NoMatches)
                        {
                            listBox1.Items.Add(q);
                        }
            }
                }
            }
            finally
            {
                con.Close();
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    XtraForm6 frm = new XtraForm6();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand number = new SqlCommand("SELECT COUNT(Id_userq) FROM User_q WHERE Type='created'", con);
                    int n = Convert.ToInt32(number.ExecuteScalar());
                    for (int i = 1; i <= n; i++)
                    {
                        SqlCommand questions = new SqlCommand("SELECT t1.Question FROM Quest t1 INNER JOIN User_q t2 ON t1.Id_quest=t2.Id_questfk WHERE Type='created' AND t1.Domain='History'", con);
                        questions.Parameters.AddWithValue("@username", username);
                        string q = (string)questions.ExecuteScalar();//eroare
                        if (listBox2.FindStringExact(q) == ListBox.NoMatches)
                        {
                            listBox2.Items.Add(q);
                        }
                    }
                }
            }
            finally
            {
                con.Close();
            }
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (listBox2.GetSelected(i))
                {
                    XtraForm6 frm = new XtraForm6();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}