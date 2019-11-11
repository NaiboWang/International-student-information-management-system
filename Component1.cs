using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class Component1 : System.Windows.Forms.TextBox
    {
        private string str;
        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void setTip(string s)
        {
            str = s;
            Text = s;
        }
        public string getTip()
        {
            if (Text == str)
                return "";
            else
                return Text;
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (str.Equals(Text))
            {
                Text = "";
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if ("".Equals(Text))
            {
                Text = str;
            }
        }
    }
}
