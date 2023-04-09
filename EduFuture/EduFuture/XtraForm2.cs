using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        public string Usern
        {
            get { return textEdit1.Text; }
        }
        public XtraForm2()
        {
            InitializeComponent();
        }
        private SqlConnection con = new SqlConnection("Data Source=" + "LAPTOP-GPJH9TCQ\\SQLEXPRESS01;Initial Catalog=EduFuturedb;Integrated Security=True");
        private SqlDataAdapter Da = new SqlDataAdapter();
       
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            con.Open();

            string user = textEdit1.Text;
            SqlCommand pass = new SqlCommand("SELECT Password FROM Users WHERE Username=@user", con);
            pass.Parameters.AddWithValue("@user", user);
            string p= (string)pass.ExecuteScalar();


            if ( p!=null && (string.Compare(p.Trim(),textEdit2.Text)==0 ))
            {
                
                XtraForm4 frm = new XtraForm4();
                frm.Usern = user;
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();

                XtraForm5 frm5 = new XtraForm5();
                frm5.Usern = user;
             //   frm5.Location = this.Location;
              //  frm5.StartPosition = FormStartPosition.Manual;
                //frm5.FormClosing += delegate { this.Show(); };
                //frm5.Show();
                //this.Hide();


            }
            else MessageBox.Show("The password or username is invalid.") ;
            con.Close();
           
            
        }

        
    }
}