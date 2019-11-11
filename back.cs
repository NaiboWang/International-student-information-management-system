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
    public partial class back : Form1
    {
        private DataTable ds;
        public back()
        {
            InitializeComponent();
        }

        private void back_Load(object sender, EventArgs e)
        {
            FormClosing += Back_FormClosing;
            string sql = "select * from back order by backname";
            int state = 0;
            ds = configback.querySql(sql, ref state);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[3].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[4].Visible = false;   //绑定后将此列设为不可见
            id.DataPropertyName = ds.Columns["tim"].ToString();

        }

        private void Back_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.back = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DialogResult d = MessageBox.Show("确认要备份当前数据库吗？", "提示", MessageBoxButtons.YesNo);
            if(d == DialogResult.Yes)
            {
                int state = 0;
                DataTable s = configback.querySql("EXEC getnewback", ref state);
                if(state == 1)
                {
                    MessageBox.Show("备份成功，备份时间："+s.Rows[0][0].ToString(), "提示");
                    int index = ds.Rows.Count;
                    ds.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = s.Rows[0][0].ToString();//标记时间
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cID = dataGridView1.Rows[e.RowIndex].Cells["backname"].Value.ToString();
                if (e.ColumnIndex ==1)
                {
                    DialogResult d = MessageBox.Show("还原数据库前请确保没有人在使用本系统，确认要还原吗？", "提示", MessageBoxButtons.YesNo);
                    if(d == DialogResult.Yes)
                    {
                        string sql = "EXEC recover '" + cID + "'";
                        configback.excuteSql(sql);
                        MessageBox.Show("还原成功！", "提示");
                    }
                }
                else if(e.ColumnIndex == 2)
                {
                    DialogResult d = MessageBox.Show("确认要删除此备份吗？", "提示", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        string sql = "EXEC deleteback '" + cID +"'";
                        configback.excuteSql(sql);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("删除成功！", "提示");
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception)
            {
                MessageBox.Show("要访问的备份信息不存在！", "提示");
            }
        }
    }
}
