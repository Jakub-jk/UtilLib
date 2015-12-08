using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilLibTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void przytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!string.IsNullOrEmpty(toolStripComboBox1.Text) && int.TryParse(toolStripComboBox1.Text, out i))
            {

            }
        }
    }
}
