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
    public partial class VideoRent : Form
    {
        Biz bl = new Biz();
        public VideoRent()
        {
            InitializeComponent();
            GetCustomerList();
            GetMovieList();
            GetRentalList();
        }
        /// <summary>
        /// Get Customer List
        /// </summary>
        private void GetCustomerList()
        {
            DataTable dt = new DataTable();
            dt = bl.getExecutSP_DataTableWithoutParamter("sp_GetCustomerList");
            dataGridViewCustomers.DataSource = dt;

        }
        /// <summary>
        /// Get Movies List
        /// </summary>
        private void GetMovieList()
        {
            DataTable dt = new DataTable();
            dt = bl.getExecutSP_DataTableWithoutParamter("sp_GetMovieList");
            dataGridViewMovies.DataSource = dt;

        }
        /// <summary>
        /// Get Rental Movies List
        /// </summary>
        private void GetRentalList()
        {
            DataTable dt = new DataTable();
            dt = bl.getExecutSP_DataTableWithoutParamter("sp_GetRentalList");
            dataGridViewRental.DataSource = dt;

        }
       /// <summary>
       /// Add Customer Details
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@FirstName", txtCustFirstName.Text);
            sp[1] = new SqlParameter("@LastName", txtCustLastName.Text);
            sp[2] = new SqlParameter("@Address", txtAddress.Text);
            sp[3] = new SqlParameter("@Phone", txtPhone.Text);
            dt = bl.getExecutSP_DataTableWithParamter("sp_InsertUpdateCustomer", sp);
            GetCustomerList();
            MessageBox.Show("Customer updated successfully");
        }
        /// <summary>
        /// Update Customer Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@FirstName", txtCustFirstName.Text);
            sp[1] = new SqlParameter("@LastName", txtCustLastName.Text);
            sp[2] = new SqlParameter("@Address", txtAddress.Text);
            sp[3] = new SqlParameter("@Phone", txtPhone.Text);
            sp[4] = new SqlParameter("@CustID", txtCustID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_InsertUpdateCustomer", sp);
            txtCustFirstName.Text = "";
            txtCustLastName.Text = "";
            txtAddress.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            GetCustomerList();
            MessageBox.Show("Customer updated successfully");
        }
        /// <summary>
        /// Delete Customer Record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@customerID", txtCustID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_DeleteCustomers", sp);
            GetCustomerList();
            MessageBox.Show("Customer deleted successfully");
        }
        /// <summary>
        /// Movies All Rented List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbAllRented_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@rentalType", "A");
            dt = bl.getExecutSP_DataTableWithParamter("GetMoviesRentalList", sp);
            dataGridViewRental.DataSource = dt;
        }
        /// <summary>
        /// Add Movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@Title", txtTitle.Text);
            sp[1] = new SqlParameter("@Rental_Cost", txtRentalCost.Text);
            sp[2] = new SqlParameter("@Genre", txtGenre.Text);
            sp[3] = new SqlParameter("@Plot", txtPlot.Text);
            bl.getExecutSP_DataTableWithParamter("sp_InsertUpdateMovies", sp);
            GetMovieList();
            MessageBox.Show("Movie saved successfully");

        }
        /// <summary>
        /// Delete Movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@movieID", txtMovieID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_DeleteMovies", sp);
            GetMovieList();
            MessageBox.Show("Movie deleted successfully");
        }
        /// <summary>
        /// Update Movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@Title", txtTitle.Text);
            sp[1] = new SqlParameter("@Rental_Cost", txtRentalCost.Text);
            sp[2] = new SqlParameter("@Genre", txtGenre.Text);
            sp[3] = new SqlParameter("@Plot", txtPlot.Text);
            sp[4] = new SqlParameter("@MovieID", txtMovieID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_InsertUpdateMovies", sp);
            GetMovieList();
            MessageBox.Show("Movie updated successfully");

        }
        /// <summary>
        /// Populate Customer Data in Textboxes of Customers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridViewCustomers.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtCustID.Text = row.Cells[0].Value.ToString();
                txtCustFirstName.Text = row.Cells[1].Value.ToString();
                txtCustLastName.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
            }
        }
        /// <summary>
        /// Populate Movies Date in Textbox of Movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridViewMovies.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtMovieID.Text = row.Cells[0].Value.ToString();
                txtTitle.Text = row.Cells[1].Value.ToString();
                txtGenre.Text = row.Cells[2].Value.ToString();
                txtRentalCost.Text = row.Cells[3].Value.ToString();
                txtPlot.Text = row.Cells[4].Value.ToString();
            }
        }
        /// <summary>
        /// Populate Data according to Return Movie, Issue Movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridViewRental.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtRentalID.Text = row.Cells[0].Value.ToString();
                txtCustFirstName.Text = row.Cells[1].Value.ToString();
                txtCustLastName.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
                txtRentalCost.Text = row.Cells[5].Value.ToString();
            }
        }
        /// <summary>
        /// Returm Movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnMovie_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@rentalID", txtRentalID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_UpdateRentalReturnMovie", sp);
            GetRentalList();
            MessageBox.Show("Movie returned by the customer");
        }
        /// <summary>
        /// Issue Movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIssueMovie_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@customerID", txtCustID.Text);
            sp[1] = new SqlParameter("@movieID", txtMovieID.Text);
            bl.getExecutSP_DataTableWithParamter("sp_InsertRentalIssueMovie", sp);
            GetRentalList();    
            MessageBox.Show("Movie rented to the customer");
        }
        /// <summary>
        /// Rent Out Movies List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbOutRented_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@rentalType", "O");
            dt = bl.getExecutSP_DataTableWithParamter("GetMoviesRentalList", sp);
            dataGridViewRental.DataSource = dt;

        }
    }
}
