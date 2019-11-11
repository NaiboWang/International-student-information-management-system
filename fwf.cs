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
    public partial class fwf : Form1
    {
        private string sid;
        private minor m;
        public fwf(string s,minor f)
        {
            InitializeComponent();
            sid = s;
            m = f;
        }

        private void fwf_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;//置空
            dateTimePicker1.CustomFormat = "   ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;//置空
            dateTimePicker2.CustomFormat = "   ";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;//置空
            dateTimePicker3.CustomFormat = "   ";
            int st = 0;
            DataTable ds = config.querySql("select * from main where rid = '" + sid + "'", ref st);
            if (DateTime.Compare((DateTime)ds.Rows[0]["frontdate"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                dateTimePicker1.Value = (DateTime)ds.Rows[0]["frontdate"];
            }
            if (DateTime.Compare((DateTime)ds.Rows[0]["endtime"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                dateTimePicker2.Value = (DateTime)ds.Rows[0]["endtime"];
            }
            if (DateTime.Compare((DateTime)ds.Rows[0]["visadate"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                dateTimePicker3.Value = (DateTime)ds.Rows[0]["visadate"];
            }
            textBox3.Text = config.getdText(ds.Rows[0]["total"]);
            textBox1.Text = config.getdText(ds.Rows[0]["frontfee"]);
            textBox5.Text = config.getdText(ds.Rows[0]["endfee"]);
            textBox2.Text = config.getdText(ds.Rows[0]["visafee"]);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = null;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = null;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                textBox3.Text = "0";
            if (textBox1.Text == "")
                textBox1.Text = "0";
            if (textBox2.Text == "")
                textBox2.Text = "0";
            if (textBox5.Text == "")
                textBox5.Text = "0";
            string sql = "update main set total = "+textBox3.Text+",frontfee = "+textBox1.Text+",endfee = "+textBox5.Text+",visafee = "+textBox2.Text+",frontdate = '"+dateTimePicker1.Value+"',endtime = '"+dateTimePicker2.Value+"',visadate = '"+dateTimePicker3.Value+"' where rid = '"+sid+"'";
            if (config.excuteSql(sql))
            {
                try
                {
                    m.refwf();
                }
                catch (Exception)
                {
                } 
                Dispose();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
