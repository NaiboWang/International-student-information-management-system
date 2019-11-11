using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Main : Form1
    {
        private DataTable ds;
        public string sql2,sql3;
        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Resize += Main_Resize;
            sql2 = "select rid,name,source,rstate,date,consult,school,leve,record from main where stat = 1 ";
            if(config.type == "财务")
            {
                button2.Enabled = false;
                sql3 = "";
            }
            else if(config.type == "管理员")
            {
                sql3 = "";
                button2.Visible = true;
            }
            else if(config.type == "普通用户")
            {
                sql3 = "and consult like '"+config.username+"'";
            }
            else if(config.type == "高级用户")
            {
                sql3 = "and consult in (select username from us where xz = (select xz from us where username = '" + config.username + "'))";
            }
            else if(config.type == "超级管理员")
            {
                button2.Visible = true;
                sql3 = "";
                excel操作ToolStripMenuItem.Enabled = true;
                回收站ToolStripMenuItem1.Enabled = true;
                用户名密码管理ToolStripMenuItem.Enabled = true;
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
            }
            Res();
            refresh();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Res();
        }
        private void Res()
        {
            label2.Left = Width / 2 - label2.Width;
            //41235
            button4.Left = Width * 16 / 100;
            button1.Left = Width * 28 / 100;
            
            if(config.type !="超级管理员")
            {
                foreach (var item in Controls)
                {
                    if (item is Label)
                        (item as Label).Tag = 9999;
                }
            }
            if (config.type == "超级管理员")
            {
                button2.Left = Width * 40 / 100;
                button5.Left = Width * 52 / 100;
            }
            else if(config.type == "管理员")
            {
                button2.Left = Width * 40 / 100;
                button5.Left = Width * 52 / 100;
            }
            else
            {
                button5.Left = Width * 40 / 100;
            }
            button4.Width = Width / 9;
            button1.Width = Width / 9;
            button2.Width = Width / 9;
            button5.Width = Width / 9;
            button4.Height = Height / 18;
            button1.Height = Height / 18;
            button2.Height = Height / 18;
            button5.Height = Height / 18;
            button4.Font = new Font("宋体", Width / 113);
            button1.Font = new Font("宋体", Width / 113);
            button2.Font = new Font("宋体", Width / 113); 
            button5.Font = new Font("宋体", Width / 113);
            src.Width = Width / 9;
            record.Width = dataGridView1.Width - rid.Width - name.Width - src.Width - rstate.Width - date.Width - level.Width - school.Width - consult.Width - 10;
        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
        }
        private Size beforeResizeSize = Size.Empty;

       
        public void refresh()
        {
            string sql4 = " order by rstate asc,rid asc";
            int state = 0;
            string sql = sql2 + sql3+sql4;
            ds = config.querySql(sql, ref state);
            if (state == 0)//如果查询状态为失败
            {
                MessageBox.Show("数据库连接/查询失败，程序无法运行！");
                Application.Exit();
                return;
            }
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[17].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[16].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[9].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[10].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[11].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[12].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[13].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[14].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[15].Visible = false;   //绑定后将此列设为不可见
            rid.DataPropertyName = ds.Columns["rid"].ToString();
            name.DataPropertyName = ds.Columns["name"].ToString();
            src.DataPropertyName = ds.Columns["source"].ToString();
            rstate.DataPropertyName = ds.Columns["rstate"].ToString();
            date.DataPropertyName = ds.Columns["date"].ToString();
            consult.DataPropertyName = ds.Columns["consult"].ToString();
            school.DataPropertyName = ds.Columns["school"].ToString();
            level.DataPropertyName = ds.Columns["leve"].ToString();
            record.DataPropertyName = ds.Columns["record"].ToString();
            //设置dataGridView1控件第二列的列宽
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1|| e.ColumnIndex == 0)
                {
                    string cID = dataGridView1.Rows[e.RowIndex].Cells["rid"].Value.ToString();
                    minor f = new minor(cID);
                    f.Show();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch(Exception)
            {
                MessageBox.Show("要访问的用户信息不存在！","提示");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int state = 0;
            DataTable t = config.querySql("EXEC getnewid", ref state);
            if (state == 1)
            {
                string cID = t.Rows[0][0].ToString();
                int index = ds.Rows.Count;
                ds.Rows.Add();//把新生成的用户ID添加到datagridview中
                dataGridView1.Rows[index].Cells["rid"].Value = cID;
                dataGridView1.Rows[index].Cells["name"].Value = "暂未设置";
                dataGridView1.Rows[index].Cells["consult"].Value = config.username;
                config.excuteSql("update main set consult = '" + config.username + "' where rid = '" + cID + "'");
                minor f3 = new minor(cID);//打开用户信息页面
                f3.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id;
            int index;
            try//尝试得到要选中项的索引，所没有选中项返回-1
            {
                id = dataGridView1.CurrentRow.Cells["rid"].Value.ToString();
                index = dataGridView1.CurrentRow.Index;
            }
            catch (Exception)
            {
                id = "-1";
                index = -1;
            }
            if (index != -1)
            {
                if (config.excuteSql("update main set stat = 0 where rid = '" + id+"'"))
                {
                    ds.Rows.RemoveAt(index);//在指定索引删除项
                }
            }
        }

        private void 将Excel模板内容导入系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "";
            openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int dt = 0;
                int tss = 0;
                SqlConnection con = new SqlConnection(config.str_con);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();//先实例SqlTransaction类，使用这个事务使用的是con 这个连接，使用BeginTransaction这个方法来开始执行这个事
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = tran;
                try
                {
                    DataTable ts = null;
                    DataTable s = ExcelUtility.ExcelToDataTable(openFileDialog.FileName, ref ts, true);
                    int count = s.Rows.Count;
                    for (int i = 0; i < count; i++)//得到总行数并在之内循环    
                    {
                        dt = i;
                        string rid = s.Rows[i]["资源号"].ToString();
                        string name = s.Rows[i]["姓名"].ToString();
                        string qq = s.Rows[i]["QQ/微信"].ToString();
                        string tel = s.Rows[i]["电话"].ToString();
                        string mail = s.Rows[i]["邮箱"].ToString();
                        string school = s.Rows[i]["在读学校"].ToString();
                        string major = s.Rows[i]["在读专业"].ToString();
                        string leve = s.Rows[i]["级别"].ToString();
                        string rstate = s.Rows[i]["资源状态"].ToString();
                        string consult = s.Rows[i]["顾问"].ToString();
                        string source = s.Rows[i]["资源来源"].ToString();
                        string date = s.Rows[i]["签约日期"].ToString();
                        string record = s.Rows[i]["回访记录"].ToString();
                        string backlog = s.Rows[i]["服务费其他说明"].ToString();
                        string visa = s.Rows[i]["签证费缴纳情况"].ToString();
                        string tuition = s.Rows[i]["学费押金缴纳情况"].ToString();
                        string total = s.Rows[i]["总服务费用"].ToString();
                        string frontfee = s.Rows[i]["服务费定金"].ToString();
                        string frontdate = s.Rows[i]["定金缴费日期"].ToString();
                        string endfee = s.Rows[i]["录取后费用"].ToString();
                        string visafee = s.Rows[i]["录取后缴费日期"].ToString();
                        string visadate = s.Rows[i]["签证后费用"].ToString();
                        string endtime = s.Rows[i]["签证后缴费日期"].ToString();
                        cmd.CommandText = "insert into main(rid,name,qq,tel,mail,school,major,leve,rstate,consult,source,date,record,backlog,visa,tuition,total,frontfee,frontdate,endfee,visafee,visadate,endtime) values('" + rid + "','" + name + "','" + qq + "','" + tel + "','" + mail + "','" + school + "','" + major + "','" + leve + "','" + rstate + "','" + consult + "','" + source + "','" + date + "','" + record + "','" + backlog + "','" + visa + "','" + tuition + "','" + total + "','" + frontfee + "','" + frontdate + "','" + endfee + "','" + visafee + "','" + visadate + "','" + endtime + "')";
                        cmd.ExecuteNonQuery();
                    }
                    tss = 1;
                    count = ts.Rows.Count;
                    for (int i = 0; i < count; i++)//得到总行数并在之内循环    
                    {
                        dt = i;
                        string rid = ts.Rows[i]["资源号"].ToString();
                        string school = ts.Rows[i]["申请学校"].ToString();
                        string course = ts.Rows[i]["申请课程"].ToString();
                        string senddate = ts.Rows[i]["递交日期"].ToString();
                        string account = ts.Rows[i]["网申账号/密码"].ToString();
                        string enterinfor = ts.Rows[i]["录取条件/结果"].ToString();
                        string yasi = ts.Rows[i]["雅思考试时间或不出国备注"].ToString();
                        string language = ts.Rows[i]["配语言学校"].ToString();
                        string ldate = ts.Rows[i]["配语言日期"].ToString();
                        string getdate = ts.Rows[i]["递签日期"].ToString();
                        string result = ts.Rows[i]["签证结果"].ToString();
                        cmd.CommandText = "insert into minor(rid,school,course,senddate,account,enterinfor,yasi,language,ldate,getdate,result) values('" + rid + "','" + school + "','" + course + "','" + senddate + "','" + account + "','" + enterinfor + "','" + yasi + "','" + language + "','" + ldate + "','" + getdate + "','" + result + "')";
                        cmd.ExecuteNonQuery();
                    }


                    tran.Commit();//如果两个sql命令都执行成功，则执行commit这个方法，执行这些操作
                    MessageBox.Show("导入成功", "提示");
                    refresh();
                }
                catch
                {
                    if (tss == 1)
                        MessageBox.Show("导入失败，请检查附表第" + (dt + 2).ToString() + "行数据格式且被导入文件不能处于打开状态！", "提示");
                    else
                        MessageBox.Show("导入失败，请检查主表第" + (dt + 2).ToString() + "行数据格式且被导入文件不能处于打开状态！", "提示");
                    tran.Rollback();//如何执行不成功，发生异常，则执行rollback方法，回滚到事务操作开始之前；
                }
            }
        }

        private void 将系统数据导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xls文件|*.xls";
            DialogResult result = saveFileDialog.ShowDialog();
            string localFilePath = "";
            if (result == DialogResult.OK)
            {
                //获得文件路径
                localFilePath = saveFileDialog.FileName.ToString();
                int state = 0;
                DataTable dt = config.querySql("select rid,name,tel,qq,mail,school,major,leve,rstate,consult,source,date,record,backlog,visa,tuition,total,frontfee,frontdate,endfee,visafee,visadate,endtime from main", ref state);
                dt.Columns["rid"].ColumnName = "资源号";
                dt.Columns["name"].ColumnName = "姓名";
                dt.Columns["qq"].ColumnName = "QQ/微信";
                dt.Columns["tel"].ColumnName = "电话";
                dt.Columns["mail"].ColumnName = "邮箱";
                dt.Columns["school"].ColumnName = "在读学校";
                dt.Columns["major"].ColumnName = "在读专业";
                dt.Columns["leve"].ColumnName = "级别";
                dt.Columns["rstate"].ColumnName = "资源状态";
                dt.Columns["consult"].ColumnName = "顾问";
                dt.Columns["source"].ColumnName = "资源来源";
                dt.Columns["date"].ColumnName = "签约日期";
                dt.Columns["record"].ColumnName = "回访记录";
                dt.Columns["backlog"].ColumnName = "服务费其他说明";
                dt.Columns["visa"].ColumnName = "签证费缴纳情况";
                dt.Columns["tuition"].ColumnName = "学费押金缴纳情况";
                dt.Columns["total"].ColumnName = "总服务费用";
                dt.Columns["frontfee"].ColumnName = "服务费定金";
                dt.Columns["frontdate"].ColumnName = "定金缴费日期";
                dt.Columns["endfee"].ColumnName = "录取后费用";
                dt.Columns["visafee"].ColumnName = "录取后缴费日期";
                dt.Columns["visadate"].ColumnName = "签证后费用";
                dt.Columns["endtime"].ColumnName = "签证后缴费日期";
                //rid id  school course  senddate account enterinfor yasi    language ldate   getdate result

                DataTable dt2 = config.querySql("select rid,school,course,senddate,account,enterinfor,yasi,language,ldate,getdate,result from minor", ref state);
                dt2.Columns["rid"].ColumnName = "资源号";
                dt2.Columns["school"].ColumnName = "申请学校";
                dt2.Columns["course"].ColumnName = "申请课程";
                dt2.Columns["senddate"].ColumnName = "递交日期";
                dt2.Columns["account"].ColumnName = "网申账号/密码";
                dt2.Columns["enterinfor"].ColumnName = "录取条件/结果";
                dt2.Columns["yasi"].ColumnName = "雅思考试时间或不出国备注";
                dt2.Columns["language"].ColumnName = "配语言学校";
                dt2.Columns["ldate"].ColumnName = "配语言日期";
                dt2.Columns["getdate"].ColumnName = "递签日期";
                dt2.Columns["result"].ColumnName = "签证结果";
                ExcelUtility.DataTableToExcel(dt, dt2, localFilePath);
                MessageBox.Show("导出成功！","提示");
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 用户名密码管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!config.account)
            {
                user u = new user();
                u.Show();
                config.account = true;
            }
        }

        private void 回收站ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(!config.re)
            {
                recycle r = new recycle();
                r.Show();
                config.re = true;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 设置学校最大数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!config.setnum)
            {
                设置添加限制 s = new 设置添加限制();
                s.Show();
                config.setnum = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sql2 = "select rid,name,source,rstate,date,consult,school,leve,record from main where stat = 1";
            if (config.type == "财务")
            {
                button2.Enabled = false;
                sql3 = "";
            }
            else if (config.type == "管理员" || config.type == "超级管理员")
            {
                sql3 = "";
            }
            else if (config.type == "普通用户")
            {
                sql3 = "and consult like '" + config.username + "'";
            }
            else if (config.type == "高级用户")
            {
                sql3 = "and consult in (select username from us where xz = (select xz from us where username = '" + config.username + "'))";
            }
            refresh();
        }

        private void 数据备份与还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!config.back)
            {
                back b = new back();
                b.Show();
                config.back = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            query q = new query(this);
            q.Show();
        }
    }
}
