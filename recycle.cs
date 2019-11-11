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
    public partial class recycle : Form1
    {
        private DataTable ds;
        public recycle()
        {
            InitializeComponent();
        }

        private void recycle_Load(object sender, EventArgs e)
        {
            string sql1 = "select name,rid from main where stat = 0";
            int state = 0;
            ds = config.querySql(sql1, ref state);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[4].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[5].Visible = false;   //绑定后将此列设为不可见
            rid.DataPropertyName = ds.Columns["rid"].ToString();
            name.DataPropertyName = ds.Columns["name"].ToString();
            FormClosing += Recycle_FormClosing;
        }

        private void Recycle_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.re = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cID = dataGridView1.Rows[e.RowIndex].Cells["rid"].Value.ToString();
                if (e.ColumnIndex == 2)//如果点击的是还原
                {   
                    config.excuteSql("update main set stat = 1 where rid = '"+cID+"'");
                }
                else if(e.ColumnIndex == 3)
                {
                    config.excuteSql("delete from minor where rid = '" + cID + "'");
                    config.excuteSql("delete from main where rid = '" + cID +"'");
                }
                ds.Rows.RemoveAt(e.RowIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("要访问的用户信息不存在！");
            }
        }
    }
}
