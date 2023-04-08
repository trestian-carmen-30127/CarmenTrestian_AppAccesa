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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EduFuture.DiagramTableAdapters;
using System.Data.SqlClient;
using System.Data.Entity;

namespace EduFuture
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm4()
        {
            InitializeComponent();
            
        }
       // SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\trest\Documents\Test tehnic Accesa\CarmenTrestian_AppAccesa\EduFuture\EduFuture\db.mdf;Integrated Security = True");
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraForm5 frm = new XtraForm5();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
           // UsersTableAdapter.NumberTokens(EduFuturedb.Users);
            //DataTable dt = EduFuturedb.Users;
            //for (int i = 0; i < dt.Rows.Count; i++)
              //  textEdit1.Text += dt.Rows[i]["NrTokens"] + "\n";
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XtraForm4_Load(object sender, EventArgs e)
        {
            
        }
    }
}