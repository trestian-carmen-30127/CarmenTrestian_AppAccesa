﻿using DevExpress.XtraEditors;
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
            int i;
            if (q != null && (string.Compare(q.Trim(), textEdit1.Text) == 0))
            {
                
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

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection=con;
                    cmd.CommandText = @"UPDATE Users SET Users.Tokens = Users.Tokens+ Quest.prize FROM Users JOIN User_q ON Users.Id_user = User_q.Id_userfk JOIN Quest ON User_q.Id_quest = Quest.Id_quest WHERE  Id_user=@userId;";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DA.SelectCommand = cmd;
                    DA.Fill(new DataSet());
                    


                    SqlCommand id = new SqlCommand("SELECT Id_user FROM Users WHERE Id_user=@userId", con);
                    id.Parameters.AddWithValue("@userId", userId);
                    int j = Convert.ToInt32(id.ExecuteScalar());

                    SqlCommand Insert_User_q = con.CreateCommand();
                    Insert_User_q.CommandText = "INSERT INTO User_q (Id_userq, Id_userfk,Id_questfk,Type) VALUES (@Id_userq, @Id_userfk, @Id_questfk,@Type )";
                    Insert_User_q.Parameters.AddWithValue("@Id_userq", i);
                    Insert_User_q.Parameters.AddWithValue("@Id_userfk", j);
                    Insert_User_q.Parameters.AddWithValue("@Id_questfk", i);
                    Insert_User_q.Parameters.AddWithValue("@Type", "answered");
                    Insert_User_q.ExecuteNonQuery();

                    MessageBox.Show("Your answer was correct!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else MessageBox.Show("Your answer is wrong.");
        }
    }
}