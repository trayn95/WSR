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

namespace WSR
{
    public partial class admin : Form
    {
        public admin(SqlConnection conn)
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }
    }
}
