using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form1
    {
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
                textBox3.Text = line.ToString();
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
            sw.Write(textBox1.Text+"\r\n");
            sw.Write(textBox2.Text + "\r\n");
            sw.Write(textBox3.Text + "\r\n");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Read("infor.ini");
            skinEngine1.SkinFile = "Calmness.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                Write("infor.ini");
            }
            config.str_con = "Data Source=TA,TB;Initial Catalog=information;Password=1303014@0047.com;User ID=gsoft;Connection Timeout=5";
            configback.str_con = "Data Source=TA,TB;Initial Catalog=backinfor;Password=1303014@0047.com;User ID=gsoft;Connection Timeout=5";
            config.str_con = config.str_con.Replace("TA", textBox1.Text);
            config.str_con = config.str_con.Replace("TB", textBox2.Text);
            configback.str_con = configback.str_con.Replace("TA", textBox1.Text);
            configback.str_con = configback.str_con.Replace("TB", textBox2.Text);
            configback.conn = new SqlConnection(configback.str_con);
            config.conn= new SqlConnection(config.str_con);
            try
            {
                config.conn.Open();
            }
            catch (Exception)
            {
                if (config.conn.State != ConnectionState.Open)
                    MessageBox.Show("连接数据库失败，请检查设置的地址和端口是否正确！", "提示");
                return;
            }
            config.conn.Close();
            int state = 0;
            DataTable s = config.querySql("EXEC checkuser '" + textBox3.Text + "','" + textBox4.Text + "'", ref state);
            if (s.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("用户名或密码错误！", "提示");
            }
            else
            {
                config.type = (string)s.Rows[0][0];//记录用户类型
                config.username = textBox3.Text;
                DataTable t = config.querySql("select num from config", ref state);
                config.num = (int)t.Rows[0][0];//记录可添加数量限制
                Main m = new Main();
                m.Show();
                Hide();
            }
        }
    }
}
