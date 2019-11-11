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
    public partial class minor : Form1
    {
        private DataTable ds;
        private string sid;
        private int re, i;
        private int ce;
        private bool sa = true;//设置保存位，默认为已保存
        public minor(string s)
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            sid = s;
        }

        private void minor_Load(object sender, EventArgs e)
        {
            
            Resize += Minor_Resize;
            dataGridView1.CellClick += DataGridView1_CellClick;
            Res();
            foreach (var item in Controls)
            {
                if (item is Label)
                {
                    if ((item as Label).Name != "label4")
                    {
                        (item as Label).Font = new Font("宋体", 14);
                        (item as Label).Tag = 9999;
                    }

                }

            }
            if (config.type == "财务")
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                component11.ReadOnly = true;
                button1.Enabled = false;
                button2.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else if (config.type == "超级管理员")
            { }
            else
            {
                dateTimePicker1.Enabled = false;
                component13.ReadOnly = true;
                component14.ReadOnly = true;
                linkLabel1.Enabled = false;
            }
            refresh();
            FormClosing += Minor_FormClosing;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
            {
                ce = e.ColumnIndex;
                re = e.RowIndex;
                System.Drawing.Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                int dgvX = dataGridView1.Location.X;
                int dgvY = dataGridView1.Location.Y;
                int cellX = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                int cellY = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;
                int x = dgvX + cellX;
                int y = dgvY + cellY;
                dateTimePicker2.Width = rect.Width;
                dateTimePicker2.Height = rect.Height;
                Point l = new Point(x, y);
                dateTimePicker2.Location = l;
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                 dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToString("d"));
                else
                 dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                dateTimePicker2.Visible = true;
                dateTimePicker2.BringToFront();
                dateTimePicker2.Select();
            }
        }

        private void Minor_Resize(object sender, EventArgs e)
        {
            Res();
        }

        private void Res()
        {
            this.SuspendLayout();
            button1.Left = Width * 16 / 100;
            button2.Left = Width * 32 / 100;
            button3.Left = Width * 48 / 100;
            button4.Left = Width * 64 / 100;
            linkLabel1.Left = Width * 498 / 1000;
            label17.Left = Width *498/1000;
            label18.Left = Width * 498 / 1000;
            component11.Width = Width * 46 / 100;
            component14.Width = Width * 46 / 100;
            component12.Width = Width * 47 / 100;
            component13.Width = Width * 47 / 100;
            component12.Left = Width * 50 / 100;
            component13.Left = Width * 50 / 100;
            component14.Left = Width * 50 / 100;

            time.Width = Width * 10 / 100;
            account.Width = Width * 10 / 100;
            result.Width = Width * 10 / 100;
            time.Width = dataGridView1.Width - rid.Width-school.Width-course.Width-date.Width-account.Width-result.Width-yzresult.Width-lan.Width-ttime.Width-dqdate.Width-10;
            label4.Left = Width * 45 / 100;
            this.ResumeLayout(false);
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sa = false;
        }

        private void Minor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!sa)//如果没有保存
            {
                DialogResult dt =  MessageBox.Show("您尚未保存，是否保存？", "提示", MessageBoxButtons.YesNoCancel);
                if(dt==DialogResult.Yes)
                {
                    if (textBox8.Text == "")
                    {
                        MessageBox.Show("请填写资源来源", "提示");
                        e.Cancel = true;
                        return;
                    }
                    save();
                }
                else if(dt == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else//选择否
                {
                    config.excuteSql("update minor set state = 1 where state = 0 and rid = '" + sid + "'");//执行取消操作的时候，把数据库中本来删除的行恢复
                }
            }
        }
        private void save()
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("请填写资源来源", "提示");
                return;
            }
            sa = true;//设置保存状态位为已保存
            string esql = "";
            if (config.type == "超级管理员")
            {
                esql = "update main set name = '" + textBox1.Text + "',tel = '" + textBox2.Text + "',qq = '" + textBox3.Text + "',mail = '" + textBox4.Text + "',school = '" + textBox5.Text + "',major ='" + textBox6.Text + "',leve = '" + textBox7.Text + "',source = '" + textBox8.Text + "',record = '" + component11.getTip() + "',backlog = '" + component13.getTip() + "',visa = '" + component14.getTip() + "',rstate = '" + comboBox1.Text + "',consult = '" + comboBox2.Text + "',date = '" + dateTimePicker1.Value.ToString() + "',pinyin='"+ NPinyin.Pinyin.GetPinyin(textBox1.Text).Replace(" ", "").ToLower() + "' where rid = '" + sid + "'";
            }
            else if(config.type == "财务")
            {
                esql = "update main set date = '" + dateTimePicker1.Value.ToString() + "',backlog = '" + component13.getTip() + "',visa = '" + component14.getTip() + "' where rid = '" + sid + "'";
                MessageBox.Show(esql);
            }
            else
            {
                esql = "update main set name = '" + textBox1.Text + "',tel = '" + textBox2.Text + "',qq = '" + textBox3.Text + "',mail = '" + textBox4.Text + "',school = '" + textBox5.Text + "',major ='" + textBox6.Text + "',leve = '" + textBox7.Text + "',source = '" + textBox8.Text + "',record = '" + component11.getTip() + "',rstate = '" + comboBox1.Text + "',consult = '" + comboBox2.Text + "',pinyin='" + NPinyin.Pinyin.GetPinyin(textBox1.Text).Replace(" ", "").ToLower() + "' where rid = '" + sid + "'";
            }
            bool t = config.excuteSql(esql);
            //对datagridview，对数据库中已经存在的进行update,对数据库中不存在的进行insert，对数据库中state为0的进行删除
            string up="";
            if(config.type !="财务")
            {
                try
                {
                    int count = dataGridView1.Rows.Count;
                    for (int i = 0; i < count; i++)//得到总行数并在之内循环    
                    {
                        string tid = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                        if (tid == "-1")
                        {
                            up = "insert into minor(rid,school,course,senddate,account,enterinfor,yasi,ldate,language,getdate,result) values('" + sid + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "')";
                        }
                        else
                        {
                            up = "update minor set school = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "',course='" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "',senddate='" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "',account='" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "',enterinfor='" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "',yasi='" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "',language='" + dataGridView1.Rows[i].Cells[8].Value.ToString() + "',ldate='" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "',getdate='" + dataGridView1.Rows[i].Cells[9].Value.ToString() + "',result='" + dataGridView1.Rows[i].Cells[10].Value.ToString() + "' where ID = " + tid;
                        }
                        config.excuteSql(up);
                    }
                    config.excuteSql("delete from minor where rid = '" + sid + "' and state = 0");//删除要删除的内容
                }
                catch (Exception)
                {
                    MessageBox.Show("更新失败！", "提示");
                }
            }
            
            if (t)
            {
                MessageBox.Show("保存成功", "提示");
            }
        }
        private void refresh()
        {
            dateTimePicker2.LostFocus += DateTimePicker2_LostFocus;
            label2.Text = sid;
            comboBox1.SelectedIndex = 1;
            comboBox2.Items.Clear();
            comboBox2.Items.Insert(0, config.username);
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;//置空
            dateTimePicker1.CustomFormat = "   ";
            component11.setTip("请及时更新最新动态");
            component13.setTip("在此记录服务费的特殊情况说明及DIY押金说明");
            component12.setTip("");
            component14.setTip("第三方费用说明");
            int st = 0;
            DataTable ds2 = config.querySql("select * from main where rid = '" + sid + "'",ref st);
            textBox1.Text = config.getText(ds2.Rows[0]["name"]);
            textBox2.Text = config.getText(ds2.Rows[0]["tel"]);
            textBox3.Text = config.getText(ds2.Rows[0]["qq"]);
            textBox4.Text = config.getText(ds2.Rows[0]["mail"]);
            textBox5.Text = config.getText(ds2.Rows[0]["school"]);
            textBox6.Text = config.getText(ds2.Rows[0]["major"]);
            textBox7.Text = config.getText(ds2.Rows[0]["leve"]);
            textBox8.Text = config.getText(ds2.Rows[0]["source"]);
            if (config.getText(ds2.Rows[0]["record"]) != "")//显示提示文本
                component11.Text = config.getText(ds2.Rows[0]["record"]);
            if (config.getText(ds2.Rows[0]["backlog"]) != "")
                component13.Text = config.getText(ds2.Rows[0]["backlog"]);
            if (config.getText(ds2.Rows[0]["visa"]) != "")
                component14.Text = config.getText(ds2.Rows[0]["visa"]);
            comboBox1.Text = config.getText(ds2.Rows[0]["rstate"]);
            comboBox2.Text = config.getText(ds2.Rows[0]["consult"]);
            if(DateTime.Compare((DateTime)ds2.Rows[0]["date"],Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                dateTimePicker1.Value = (DateTime)ds2.Rows[0]["date"];
            }
            getfwf();


            string sql = "select ID,school,course,senddate,account,enterinfor,yasi,language,ldate,getdate,result from minor where rid = '"+sid+"' order by ID asc";
            ds = config.querySql(sql, ref st);
            ds.Columns.Add("IDS", typeof(string));
            ds.Columns.Add("rd", typeof(string));
            ds.Columns.Add("sd", typeof(string));
            ds.Columns.Add("ld", typeof(string));
            ds.Columns.Add("lad", typeof(string));
            ds.Columns.Add("gd", typeof(string));
            i = 1;
            foreach (DataRow dr in ds.Rows)
            {
                dr["IDS"] = i.ToString();//添加表格
                dr["rd"] = ((DateTime)dr["result"]).ToString("d").Replace("1900/1/1","");//添加表格
                dr["sd"] = ((DateTime)dr["senddate"]).ToString("d").Replace("1900/1/1", "");//添加表格
                dr["ld"] = ((DateTime)dr["ldate"]).ToString("d").Replace("1900/1/1", "");//添加表格
                dr["lad"] = ((DateTime)dr["language"]).ToString("d").Replace("1900/1/1", "");//添加表格
                dr["gd"] = ((DateTime)dr["getdate"]).ToString("d").Replace("1900/1/1", "");//添加表格
                i++;
            }
            dataGridView1.DataSource = ds;
            rid.DataPropertyName = ds.Columns["IDS"].ToString();
            school.DataPropertyName = ds.Columns["school"].ToString();
            course.DataPropertyName = ds.Columns["course"].ToString();
            date.DataPropertyName = ds.Columns["sd"].ToString();
            date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            account.DataPropertyName = ds.Columns["account"].ToString();
            result.DataPropertyName = ds.Columns["enterinfor"].ToString();
            time.DataPropertyName = ds.Columns["yasi"].ToString();
            lan.DataPropertyName = ds.Columns["lad"].ToString();
            ttime.DataPropertyName = ds.Columns["ld"].ToString();
            ttime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dqdate.DataPropertyName = ds.Columns["gd"].ToString();
            dqdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            yzresult.DataPropertyName = ds.Columns["rd"].ToString();
            dataGridView1.Columns[22].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[23].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[24].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[25].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[26].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[27].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[17].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[16].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[19].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[20].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[21].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[18].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[11].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[12].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[13].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[14].Visible = false;   //绑定后将此列设为不可见
            dataGridView1.Columns[15].Visible = false;   //绑定后将此列设为不可见
            dateTimePicker2.Select();
            sa = true;
        }

        private void DateTimePicker2_LostFocus(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
        }

        public void refwf()
        {
            getfwf();
        }
        private void getfwf()
        {
            int s = 0;
            DataTable t = config.querySql("select * from main where rid = '" + sid + "'", ref s);
            string str = "总服务费xxxx0元，yyyymmdd1缴纳定金xxxx1元，yyyymmdd2缴纳录取后费用xxxx2元，yyyymmdd3缴纳签证后费用xxxx3元";
            string total = config.getdText(t.Rows[0]["total"]);
            if (total == "")
                total = "   ";
            string frontfee = config.getdText(t.Rows[0]["frontfee"]);
            if (frontfee == "")
                frontfee = "   ";
            string endfee = config.getdText(t.Rows[0]["endfee"]);
            if (endfee == "")
                endfee = "   ";
            string visafee = config.getdText(t.Rows[0]["visafee"]);
            if (visafee == "")
                visafee = "   ";

            DateTime frontdate = (DateTime)t.Rows[0]["frontdate"];
            DateTime endtime = (DateTime)t.Rows[0]["endtime"];
            DateTime visadate = (DateTime)t.Rows[0]["visadate"];
            str = str.Replace("xxxx0",total);
            str = str.Replace("xxxx1", frontfee);
            str = str.Replace("xxxx2", endfee);
            str = str.Replace("xxxx3", visafee);
            if (DateTime.Compare((DateTime)t.Rows[0]["frontdate"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                str = str.Replace("yyyymmdd1", frontdate.ToString("yyyy-MM-dd"));
            }
            else
            {
                str = str.Replace("yyyymmdd1","   ");
            }
            if (DateTime.Compare((DateTime)t.Rows[0]["endtime"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                str = str.Replace("yyyymmdd2", endtime.ToString("yyyy-MM-dd"));
            }
            else
            {
                str = str.Replace("yyyymmdd2", "   ");
            }
            if (DateTime.Compare((DateTime)t.Rows[0]["visadate"], Convert.ToDateTime("2017-01-01 00:00:00")) != 0)
            {
                str = str.Replace("yyyymmdd3", visadate.ToString("yyyy-MM-dd"));
            }
            else
            {
                str = str.Replace("yyyymmdd3", "   ");
            }
            component12.Text = str;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void component13_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }
        private void component14_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }
        private void component15_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }
        private void component12_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            sa = false;
            dateTimePicker1.CustomFormat = null;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[re].Cells[ce].Value = dateTimePicker2.Value;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fwf f = new fwf(sid,this);
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sa = true;
            config.excuteSql("update minor set state = 1 where state = 0 and rid = '"+sid+"'");//执行取消操作的时候，把数据库中本来删除的行恢复
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id;
            int index;
            try
            {
                id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                index = dataGridView1.CurrentRow.Index;
            }
            catch (Exception)
            {
                id = "-1";
                index = -1;
            }
            if (id != "-1")//这里在数据库中把要删除的行的状态设置为0，若最终保存则删除掉行，不然就恢复
            {
                if (config.excuteSql("update minor set state = 0 where ID = " + id))
                {
                    ds.Rows.RemoveAt(index);
                }
            }
            else
            {
                ds.Rows.RemoveAt(index);
            }
            sa = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void component11_TextChanged(object sender, EventArgs e)
        {
            sa = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = ds.Rows.Count;
            if(index>=config.num)
            {
                MessageBox.Show("超出最大学校限制，禁止添加学校！", "提示");
            }
            else
            {
                ds.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = i;//标记序号
                i++;
                //DataTable t = config.querySql(
                //    "insert into minor(rid) values('"+sid+"');select ident_current('minor') as ID; "
                //    , ref state);
                //if (state == 1)
                //{
                dataGridView1.Rows[index].Cells["ID"].Value = "-1";//这里把新增的行的id设置为-1，保存的时候对这些插入，其他的保存
                                                                   //}
                sa = false;
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
            }
        }
    }
}
