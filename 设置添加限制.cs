using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class 设置添加限制 : Form1
    {
        public 设置添加限制()
        {
            InitializeComponent();
        }

        private void 设置添加限制_Load(object sender, EventArgs e)
        {
            textBox1.Text = config.num.ToString();
            FormClosing += 设置添加限制_FormClosing;
        }

        private void 设置添加限制_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.setnum = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int t = int.Parse(textBox1.Text);
                config.num = t;
                config.excuteSql("update config set num = " + t.ToString());
                Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("参数填写错误", "提示");
            }
        }
    }
}
