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

namespace VetClinic_Gui
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataSet dt;
        SqlCommandBuilder cmdbl;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=laptop-qvltqojg;Initial Catalog=Veterinary_Clinic;Integrated Security=True"); // making connection   
                sda = new SqlDataAdapter("SELECT * FROM login", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                dt = new System.Data.DataSet(); //this is creating a virtual table  
                sda.Fill(dt, "Login_Details");
                LoginView.DataSource = dt.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(sda);
                sda.Update(dt, "Login_Details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
