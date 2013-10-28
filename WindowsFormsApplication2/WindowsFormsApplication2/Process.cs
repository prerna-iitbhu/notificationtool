using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication2.Properties;

namespace WindowsFormsApplication2
{
    class Process: IDisposable
    {
        NotifyIcon n1;
        public Form1 f1;
        

        public Process()
        {
           
            n1 = new NotifyIcon();
            f1 = new Form1();
        }

        public void Display()
        {

            n1.MouseDoubleClick += new MouseEventHandler(n1_MouseDoubleClick);
            n1.Icon = Resources.Icon1;
            n1.Text = "Bugs notification tool";
            n1.Visible = true;
            n1.ContextMenuStrip = new ContextMenus().Create();
           
        }


        void n1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
           // f1.Show();
        }

        public void Dispose()
        {
            n1.Dispose();

        }
    }
}
