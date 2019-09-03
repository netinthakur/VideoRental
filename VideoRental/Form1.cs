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

namespace VideoRental
{
    public partial class Form1 : Form
    {
        Biz bl = new Biz();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Login Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", txtLoginID.Text);

            sp[1] = new SqlParameter("@pwd", txtPassword.Text);
            dt = bl.getExecutSP_DataTableWithParamter("userLogin", sp);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {

                    this.Hide();
                    VideoRent _VideoRent = new VideoRent();
                    _VideoRent.ShowDialog();

                }

            }
            else
            {
                txtLoginID.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Login ID and Password is invalid.");
            }
        }
    }
}
