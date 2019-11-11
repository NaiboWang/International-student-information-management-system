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
    public partial class user : Form1
    {
        DataTable ds;
        int u;
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            FormClosing += User_FormClosing;
            string sql1 = "select * from us order by username asc";
            int state = 0;
            ds = config.querySql(sql1, ref state);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[9].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[8].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[10].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[6].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[7].Visible = false;   //绑定后将此列设为不可见
            username.DataPropertyName = ds.Columns["username"].ToString();
            pass.DataPropertyName = ds.Columns["passwd"].ToString();
            utype.DataPropertyName = ds.Columns["tp"].ToString();
            xz.DataPropertyName = ds.Columns["xz"].ToString();
            DataTable st = config.querySql("select count(*) from us", ref state);
            u = (int)st.Rows[0][0];
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.account = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cID = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                if (e.ColumnIndex == 5)//如果点击的是删除
                {
                    DialogResult dt = MessageBox.Show("确认要删除吗？", "提示", MessageBoxButtons.YesNo);
                    if(dt == DialogResult.Yes)
                    {
                        config.excuteSql("delete from us where username = '" + cID + "'");
                        ds.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("删除成功");
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    DialogResult dt = MessageBox.Show("确认要修改吗？", "提示", MessageBoxButtons.YesNo);
                    if (dt == DialogResult.Yes)
                    {
                        string s = "update us set username = '"+cID+"',passwd ='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "',tp='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "',xz = '"+ dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "' where id = '" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                        if(config.excuteSql(s))
                         MessageBox.Show("修改成功");
                        else
                            MessageBox.Show("修改失败，请检查是否有相同用户名");
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("要访问的用户信息不存在！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = ds.Rows.Count;
            int s = 0;
            DataTable t = config.querySql("insert into us(username) values('user" + u.ToString() + "');select ident_current('us') as id; ",ref s);
            if (s == 1)
            {
                ds.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "user"+u.ToString();//标记序号
                dataGridView1.Rows[index].Cells["id"].Value = t.Rows[0][0].ToString();//标记序号
                dataGridView1.Rows[index].Cells[2].Value = "普通用户";
                u++;
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
            }
        }
    }
}
