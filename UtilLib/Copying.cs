using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilLib
{
    public partial class Copying : Form
    {
        private string charArrayToString(char[] array)
        {
            string s = "";
            foreach (char c in array)
                s += c;
            return s;
        }

        public Copying()
        {
            InitializeComponent();
        }
    }
}
