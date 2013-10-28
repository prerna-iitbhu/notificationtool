using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class ContextMenus
    {
        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            item = new ToolStripMenuItem();
            item.Text = "Reconfigure";
            item.Click += new EventHandler(Reconfigure_Click);
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new EventHandler(Exit_Click);
            menu.Items.Add(item);

            return menu;

        }


        void Reconfigure_Click(object sender, EventArgs e)
        {
            
            Form2 F = new Form2();
            F.Visible = true;

        }

        void Exit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            //Application.Exit();

        }
    }
}
