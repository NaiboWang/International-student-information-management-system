using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TextBoxP : UserControl
    {
        private string str;
        public TextBoxP()
        {
            InitializeComponent();
        }
        public TextBoxP(string s)
        {
            InitializeComponent();
            str = s;
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("sdf2");
            throw new NotImplementedException();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("sdf");
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
