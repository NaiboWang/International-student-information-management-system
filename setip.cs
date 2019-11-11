using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class setip : Form1
    {
        private string user = null;
        public setip()
        {
            InitializeComponent();
        }
        public void Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            try
            {
                line = sr.ReadLine();
                textBox1.Text = line.ToString();
                line = sr.ReadLine();
                textBox2.Text = line.ToString();
                line = sr.ReadLine();
                user = line.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
                sr.Close();
            }
        }
        public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(textBox1.Text + "\r\n");
            sw.Write(textBox2.Text + "\r\n");
            sw.Write(user + "\r\n");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
        private void setip_Load(object sender, EventArgs e)
        {
            Read("infor.ini");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("请填写完整信息", "提示");
            }
            else
            {
                DialogResult s = MessageBox.Show("确认要设置吗？", "提示", MessageBoxButtons.YesNo);
                if (s == DialogResult.Yes)
                {
                    Write("infor.ini");
                    MessageBox.Show("设置成功，请重新打开本程序！", "提示");
                    Dispose();
                }
            }
        }
    }
}
