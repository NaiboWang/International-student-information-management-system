using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControl1 : UserControl
    {
        private bool state = false;
        private DateTime __Value;
        public UserControl1()
        {
            InitializeComponent();
            monthCalendar1.BringToFront();//显示在最前面
            pictureBox1.Click += PictureBox1_Click;
            monthCalendar1.LostFocus += MonthCalendar1_LostFocus;
            monthCalendar1.Leave += MonthCalendar1_Leave;
            monthCalendar1.DateSelected += MonthCalendar1_DateSelected;
            Height = label1.Height + 3;
            LostFocus += UserControl1_LostFocus;
        }

        private void UserControl1_LostFocus(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            Height = label1.Height + 3;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            label1.Text = monthCalendar1.SelectionStart.ToString();
            label1.Text = label1.Text.Replace("0:00:00", "");
            Height = label1.Height + 3;
            Value = monthCalendar1.SelectionStart;
        }

        private void MonthCalendar1_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void MonthCalendar1_LostFocus(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            Height = label1.Height + 3;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if(state)
            {
                monthCalendar1.Visible = false;
                Height = label1.Height + 3;
            }
            else
            {
                monthCalendar1.Visible = true;
                Height = label1.Height + monthCalendar1.Height;
            }
            state = !state;

        }


        //set get方法
        public DateTime Value
        {
            get { return __Value; }
            set { __Value = value; }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (state)
            {
                monthCalendar1.Visible = false;
                Height = label1.Height + 3;
            }
            else
            {
                monthCalendar1.Visible = true;
                Height = label1.Height + monthCalendar1.Height;
            }
            state = !state;
        }
    }
}
