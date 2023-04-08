using DevExpress.XtraEditors;
//using EduFuture.DiagramTableAdapters;
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

namespace EduFuture
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm4()
        {
            InitializeComponent();
        }

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
          /*  UsersTableAdapter.NumberTokens(Usersdb.Users);
            DataTable dt=Usersdb.Users;
            for (int i = 0; i < dt.Rows.Count; i++)
                textEdit1.Text += dt.Rows[i]["NrTokens"] + "\n";*/
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XtraForm4_Load(object sender, EventArgs e)
        {

        }
    }
}