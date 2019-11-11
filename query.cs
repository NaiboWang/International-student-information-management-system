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
    public partial class query : Form1
    {
        private Main mm;
        public query(Main m)
        {
            InitializeComponent();
            mm = m;
        }

        private void query_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
            }
            else
            {
                dateTimePicker1.Value = Convert.ToDateTime("1900-01-01 00:00:00");
                dateTimePicker2.Value = Convert.ToDateTime("2100-01-01 00:00:00");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s2="";
            if(checkBox2.Checked == true)
            {
                s2 = "select rid,name,source,rstate,date,consult,school,leve,record from main where stat = 1 and source like '%" + textBox8.Text + "%' and rstate = '" + comboBox1.Text + "' and consult like '%" + textBox1.Text + "%' and pinyin like '%"+ NPinyin.Pinyin.GetPinyin(textBox2.Text).Replace(" ", "").ToLower() + "%' and school like '%" + textBox5.Text + "%' and leve like '%" + textBox6.Text + "%'  and DATEDIFF(day,'" + dateTimePicker1.Value.ToString() + "',date)>=0 and DATEDIFF(day, date,'" + dateTimePicker2.Value.ToString() + "')>=0 ";
            }
            else
            {
                s2 = "select rid,name,source,rstate,date,consult,school,leve,record from main where stat = 1 and source like '%" + textBox8.Text + "%' and pinyin like '%"+ NPinyin.Pinyin.GetPinyin(textBox2.Text).Replace(" ", "").ToLower() + "%' and consult like '%" + textBox1.Text + "%' and school like '%" + textBox5.Text + "%' and leve like '%" + textBox6.Text + "%'  and DATEDIFF(day,'" + dateTimePicker1.Value.ToString() + "',date)>=0 and DATEDIFF(day, date,'" + dateTimePicker2.Value.ToString() + "')>=0 ";
            }
            Clipboard.SetText(s2);
            mm.sql2 = s2;
            mm.refresh();
            Dispose();
        }
    }
}
