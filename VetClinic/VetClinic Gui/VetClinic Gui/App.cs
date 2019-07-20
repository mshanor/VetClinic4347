using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetClinic_Gui
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void Manage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new InsertDeleteModify().Show();
        }
    }
}
