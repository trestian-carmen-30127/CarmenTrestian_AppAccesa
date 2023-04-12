using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
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
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

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
            con.Open();
            SqlCommand answer = new SqlCommand("SELECT Answer FROM Quest WHERE Question=@questiontxt", con);
            answer.Parameters.AddWithValue("@questiontxt", questiontxt);
            string q = (string)answer.ExecuteScalar();
            con.Close();
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
                    //Adauga celui care a raspuns corect numarul de tokens
                    SqlCommand prize = new SqlCommand("SELECT Prize FROM Quest Where Question=@questiontxt", con);
                    prize.Parameters.AddWithValue("@questiontxt", questiontxt);
                    int p = Convert.ToInt32(prize.ExecuteScalar());

                    SqlCommand tokens = new SqlCommand("SELECT Tokens FROM Users WHERE Id_user=@userId", con);
                    tokens.Parameters.AddWithValue("@userId", userId);
                    int t = Convert.ToInt32(tokens.ExecuteScalar());

                    int sum = t + p;
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Tokens = @sum WHERE Id_user = @userId",con);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@sum", sum);
                    cmd.ExecuteNonQuery();

                    //Ia de la cel care a creat questul prize-ul 


                    SqlCommand tokens2 = new SqlCommand("SELECT t1.Tokens FROM Users t1 JOIN User_q t2 ON t1.Id_user=t2.Id_userfk JOIN Quest t3 ON t2.Id_questfk=t3.Id_quest WHERE t3.Question=@questiontxt", con);
                    tokens2.Parameters.AddWithValue("@questiontxt", questiontxt);
                    int t2 = Convert.ToInt32(tokens2.ExecuteScalar());

                    int dif=t2 - p;

                    SqlCommand cmd2 = new SqlCommand("UPDATE Users SET Users.Tokens=@dif FROM Users JOIN User_q ON Users.Id_user=User_q.Id_userfk JOIN Quest ON User_q.Id_questfk=Quest.Id_quest WHERE Quest.Question=@questiontxt",con);
                    cmd2.Parameters.AddWithValue("@questiontxt", questiontxt);
                    cmd2.Parameters.AddWithValue("@dif", dif);                   
                    cmd2.ExecuteNonQuery();

                    // Insereaza in tablea User_q questul ca fiind raspuns


                    SqlCommand idq = new SqlCommand("SELECT Id_quest FROM Quest WHERE Question=@questiontxt", con);
                    idq.Parameters.AddWithValue("@questiontxt", questiontxt);
                    int j=Convert.ToInt32(idq.ExecuteScalar());


                    SqlCommand Insert_User_q = con.CreateCommand();
                    Insert_User_q.CommandText = "INSERT INTO User_q (Id_userq, Id_userfk,Id_questfk,Type) VALUES (@Id_userq, @Id_userfk, @Id_questfk,@Type )";
                    Insert_User_q.Parameters.AddWithValue("@Id_userq", i);
                    Insert_User_q.Parameters.AddWithValue("@Id_userfk", userId);
                    Insert_User_q.Parameters.AddWithValue("@Id_questfk", j);
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

                SqlCommand qa = new SqlCommand("SELECT COUNT(t1.Id_quest) FROM Quest t1 INNER JOIN User_q t2 ON t1.Id_quest=t2.Id_questfk WHERE Type='answered' AND t2.Id_userfk=@userId", con);
                qa.Parameters.AddWithValue("@userId", userId);
                int qi = Convert.ToInt32(qa.ExecuteScalar());

                if (qi>5)
                {
                    SqlCommand lvl2 = new SqlCommand("UPDATE Users  SET Users.Rank='Junior' FROM Users WHERE Id_user=@userId",con);
                    lvl2.Parameters.AddWithValue("@userId", userId);
                    lvl2.ExecuteNonQuery();
                }
                if (qi > 10)
                {
                    SqlCommand lvl3 = new SqlCommand("UPDATE Users  SET Users.Rank='Avrage' FROM Users WHERE Id_user=@userId", con);
                    lvl3.Parameters.AddWithValue("@userId", userId);
                    lvl3.ExecuteNonQuery();
                }
                if (qi > 15)
                {
                    SqlCommand lvl4 = new SqlCommand("UPDATE Users  SET Users.Rank='Smart' FROM Users WHERE Id_user=@userId", con);
                    lvl4.Parameters.AddWithValue("@userId", userId);
                    lvl4.ExecuteNonQuery();
                }
                if (qi > 30)
                {
                    SqlCommand lvl5 = new SqlCommand("UPDATE Users  SET Users.Rank='teacher' FROM Users WHERE Id_user=@userId", con);
                    lvl5.Parameters.AddWithValue("@userId", userId);
                    lvl5.ExecuteNonQuery();
                }

                SqlCommand qacs = new SqlCommand("SELECT COUNT(t1.Id_quest) FROM Quest t1 INNER JOIN User_q t2 ON t1.Id_quest=t2.Id_questfk WHERE Type='answered' AND t2.Id_userfk=@userId AND t1.Domain='Computer Science'", con);
                qacs.Parameters.AddWithValue("@userId", userId);
                int qcs = Convert.ToInt32(qacs.ExecuteScalar());
                if (qcs>5) 
                {
                    SqlCommand bd1 = new SqlCommand("UPDATE Users  SET Users.Badges=Badges+1 FROM Users WHERE Id_user=@userId", con);
                    bd1.Parameters.AddWithValue("@userId", userId);
                    bd1.ExecuteNonQuery();
                }
                if (qcs > 10)
                {
                    SqlCommand bd2 = new SqlCommand("UPDATE Users  SET Users.Badges=Badges+1 FROM Users WHERE Id_user=@userId", con);
                    bd2.Parameters.AddWithValue("@userId", userId);
                    bd2.ExecuteNonQuery();
                }


                SqlCommand qah= new SqlCommand("SELECT COUNT(t1.Id_quest) FROM Quest t1 INNER JOIN User_q t2 ON t1.Id_quest=t2.Id_questfk WHERE Type='answered' AND t2.Id_userfk=@userId AND t1.Domain='History'", con);
                qacs.Parameters.AddWithValue("@userId", userId);
                int qh = Convert.ToInt32(qah.ExecuteScalar());
                if (qh > 5)
                {
                    SqlCommand bh1 = new SqlCommand("UPDATE Users  SET Users.Badges=Badges+1 FROM Users WHERE Id_user=@userId", con);
                    bh1.Parameters.AddWithValue("@userId", userId);
                    bh1.ExecuteNonQuery();
                }
                if (qcs > 10)
                {
                    SqlCommand bh2 = new SqlCommand("UPDATE Users  SET Users.Badges=Badges+1 FROM Users WHERE Id_user=@userId", con);
                    bh2.Parameters.AddWithValue("@userId", userId);
                    bh2.ExecuteNonQuery();
                }

            }
            else MessageBox.Show("Your answer is wrong.");
        }
    }
}