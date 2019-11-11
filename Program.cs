using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://captcha.three-thinking.com/1.txt");
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream);
            if (sr.ReadToEnd() == "0")
            {
                MessageBox.Show("试用已结束，程序无法运行。", "提示");
                Application.Exit();
            }
            else
            {
                if (!File.Exists("infor.ini"))
                {
                    FileStream fs = new FileStream("infor.ini", FileMode.Create);
                    fs.Close();
                    MessageBox.Show("初次使用，请设置服务器信息。", "提示");
                    Application.Run(new setip());
                }
                else
                {
                    Application.Run(new Form2());
                }
            }
        }
    }
}
