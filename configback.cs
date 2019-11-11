using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class configback
    {
        public static string str_con = "Data Source=120.77.211.218,1567;Initial Catalog=information;Password=1303014@0047.com;User ID=backinfor;";//数据库连接字符串
        public static SqlConnection conn;
        public static SqlCommand comm;
        public static SqlDataAdapter da;
        public static DataTable dss;
        static configback()
        {
            refresh();
        }
        public static DataTable querySql(string query, ref int state)
        {
            try
            {
                conn.Open();//打开数据库
                comm = new SqlCommand(query, conn);
                da = new SqlDataAdapter(comm);
                dss = new DataTable();
                da.Fill(dss);
            }
            catch (Exception)
            {
                MessageBox.Show("查询参数错误！", "提示");
                state = 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            state = 1;//查询状态为成功
            return dss;
        }
        public static bool excuteSql(string excu)//定义执行增删改的sql
        {
            try
            {
                comm = new SqlCommand(excu, conn);
                conn.Open();//打开数据库
                comm.ExecuteNonQuery();//执行sql
            }
            catch (Exception)
            {
                MessageBox.Show("您填写的参数有误，请检查！", "提示");
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return true;//返回成功状态
        }
        public static int refresh()//用来刷新参数列表
        {
            return 1;
        }
}
}
