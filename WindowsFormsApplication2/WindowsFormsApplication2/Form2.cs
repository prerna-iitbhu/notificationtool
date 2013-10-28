using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        Microsoft.Win32.RegistryKey k;
        Microsoft.Win32.RegistryKey reg;
        string RunRegValueName = "OneBugNotifier";
        String RefreshTimeRegKey = "RefreshTime";
        String RefreshTimeVaue = "Minutes";
        String Cmpntreg = "Components";
        String test = "Name";
        String PersonalQueryReg = "PersonalQuery";        
        Boolean PersonalQuery = false;
        public Form2()
        {
            // projecg names are loaded here

            string[] projectnames = { "All", "Jasper", "Bruin", "Merlin", "Other" };
            
            InitializeComponent();
            Projects.DataSource = projectnames;
            reg = Microsoft.Win32.Registry.CurrentUser;
            k = reg.OpenSubKey("OneBugNotifier");
            Microsoft.Win32.RegistryKey test = k.OpenSubKey("Project");
            if (test == null)
            {
                ProjectNotSet.Visible = true;
            }
            else
            {
                ProjectNotSet.Visible = false;
            }
            
            
           
            //startup check box is loaded here
            Microsoft.Win32.RegistryKey StartUpRegLoc = reg.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            object RunValue = StartUpRegLoc.GetValue(RunRegValueName);
            if (RunValue == null)
                RunOnStartup.Checked = false;
            else
                RunOnStartup.Checked = true;

            //refresh time is loaded here
            string refresh = "OneBugNotifier"+"\\"+ RefreshTimeRegKey;
            Microsoft.Win32.RegistryKey RefeshRegLoc = reg.OpenSubKey(refresh, true);
            if (RefeshRegLoc == null)
            {
                RefreshTimeTextBox.Text = "1";
            }
            else
            {                
                RefreshTimeTextBox.Text = RefeshRegLoc.GetValue(RefreshTimeVaue).ToString();
            }

           
            //components loaded here
            string cmpnt = "OneBugNotifier" + "\\" + "Components";
            Microsoft.Win32.RegistryKey ComponentLoc = reg.OpenSubKey(cmpnt); ;
            if (ComponentLoc == null)
            { }
            else 
            {
                string ListComponent = ComponentLoc.GetValue("Name").ToString();
                string[] words = ListComponent.Split(',');
                foreach (string s in words)
                {
                    listBox2.Items.Add(s);
                
                }
            }
          
        }



        private void Projects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectNotSet.Visible = true;
            //Run at start up
            if (RunOnStartup.Checked == true)
            {
                // write the regisrty 
                // MessageBox.Show("box is checked");
                string CurrentDirectory =  System.IO.Directory.GetCurrentDirectory();
                //string AppPath = CurrentDirectory + "\\WindowsFormsApplication2.exe";
                string AppPath = CurrentDirectory + "\\OneBugNotifier.exe";
                Microsoft.Win32.RegistryKey StartUpRegLoc = reg.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
               // StartUpRegLoc.SetValue("OneBugNotifier", @"C:\Users\kirankumar\Documents\WindowsFormsApplication2\WindowsFormsApplication2\bin\Debug\WindowsFormsApplication2.exe");
                StartUpRegLoc.SetValue("OneBugNotifier", AppPath);
            }
            else
            {
                Microsoft.Win32.RegistryKey StartUpRegLoc = reg.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                try
                {
                    StartUpRegLoc = reg.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    StartUpRegLoc.DeleteValue("OneBugNotifier");
                }
                catch (Exception e1)
                {
                }
               
            }
                      
            
            // Project file and personal query setting on registry
            if (ProjectNotSet.Visible == true)
            {
                k = reg.CreateSubKey("OneBugNotifier");
                Microsoft.Win32.RegistryKey UserProj = k.CreateSubKey("Project");
                string ProjectSelected = "";
                if (Projects.Text.Contains("other"))
                {
                    ProjectSelected = textBox1.Text;
                }
                else
                {
                    ProjectSelected = Projects.Text;
                }

                if(ProjectSelected.Contains("All"))
                    ProjectSelected = "";
                UserProj.SetValue("Name", ProjectSelected, Microsoft.Win32.RegistryValueKind.String);
                UserProj.SetValue(PersonalQueryReg, "True");
            }
            
            //refresh time setting 

            if (ProjectNotSet.Visible == true)
            {
                k = reg.CreateSubKey("OneBugNotifier");
                Microsoft.Win32.RegistryKey UserProj = k.CreateSubKey(RefreshTimeRegKey);
                UserProj.SetValue(RefreshTimeVaue, RefreshTimeTextBox.Text, Microsoft.Win32.RegistryValueKind.String);
                DateTime now = DateTime.Now.ToUniversalTime();
                string nowStr = now.ToString("yyyy-MM-dd HH:mm:ss");
                reg = Microsoft.Win32.Registry.CurrentUser;
                k = reg.OpenSubKey("OneBugNotifier");
                UserProj = k.OpenSubKey("RefreshTime", true);
                Object lastQt = UserProj.GetValue("LastQueryTime");
                if (lastQt == null)
                    UserProj.SetValue("LastQueryTime", nowStr, Microsoft.Win32.RegistryValueKind.String);

            }
            

            //component setting

            if (ProjectNotSet.Visible == true)
            {
                try
                {
                    
                    // cmpnt = k.OpenSubKey("Components", true);
                    string s = "";
                    foreach (string st in listBox2.Items)
                    {
                        s = s + st + ",";
                    }
                    if(s.Length >=1)
                    s = s.Remove(s.Length - 1);
                    reg = Microsoft.Win32.Registry.CurrentUser;
                    k = reg.CreateSubKey("OneBugNotifier");
                    Microsoft.Win32.RegistryKey cmpnt = k.CreateSubKey(Cmpntreg);                    
                    cmpnt.SetValue(test, s, Microsoft.Win32.RegistryValueKind.String);

                }
                catch (Exception ec)
                {
                   // MessageBox.Show("Exception");
                
                }
            }
           


            this.Close();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void Projects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
            if (Projects.Text.Contains("other"))
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string inpt = box.Text;
            SqlConnection myconnection;
            myconnection = new SqlConnection();
            myconnection.ConnectionString = "Server=ftlpobugsqlcl01.citrite.net; Database= OneBugDatamart; Trusted_Connection= True";
            string qry = "select * from USR_COMPONENTS where (TS_TITLE like '%' + @input + '%')";
            myconnection.Open();

            SqlCommand cmnd = new SqlCommand(qry, myconnection);
            cmnd.CommandTimeout = 0;
            cmnd.Parameters.AddWithValue("@input", inpt);
            SqlDataReader rdr = cmnd.ExecuteReader();
            listBox1.Items.Clear();

            while (rdr.Read())
            {
                string value2 = (rdr.GetString(2));
                
                listBox1.Items.Add(value2);
            }


            //SqlDataAdapter da = new SqlDataAdapter(qry, myconnection);

            //DataTable ds = new DataTable();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string crntitem = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(crntitem);
                listBox2.Items.Add(crntitem);

            }
            catch (Exception Button4e)
            {

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                string crntitem = listBox2.SelectedItem.ToString();
                listBox2.Items.Remove(crntitem);
                listBox1.Items.Add(crntitem);
            }
            catch (Exception Button5e)
            {

            }
        }

        private void ProjectNotSet_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
          
                PersonalQuery = true;
            
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    string inpt = componentbox.Text;
        //    if (string.IsNullOrEmpty(inpt) == true)
        //    {
        //        //Microsoft.Win32.RegistryKey k;
        //        //Microsoft.Win32.RegistryKey reg;
        //        //reg = Microsoft.Win32.Registry.CurrentUser;
        //        //k = reg.OpenSubKey("OneBugNotifier");
        //        //Microsoft.Win32.RegistryKey cmpnt = k.OpenSubKey("Component");
        //        //if (cmpnt == null)
        //        //{ }
        //        //else
        //        //{
        //        //    k.DeleteSubKey("Component");
 
                
        //        //}

        //    }
        //    else
        //    {
              
        //        SqlConnection myconnection;
        //        myconnection = new SqlConnection();
        //        myconnection.ConnectionString = "Server=ftlpobugsqlcl01.citrite.net; Database= OneBugDatamart; Trusted_Connection= True";
        //        string qry = "select TS_TITLE as title from USR_COMPONENTS where (TS_TITLE like @input + '%')";
        //        myconnection.Open();
        //        SqlCommand cmnd = new SqlCommand(qry,myconnection);
        //        cmnd.CommandTimeout = 0;
        //        cmnd.Parameters.AddWithValue("@input", inpt);

        //        SqlDataReader rdr = cmnd.ExecuteReader();
        //        //SqlDataAdapter da = new SqlDataAdapter(qry, myconnection);
        //        //DataTable ds = new DataTable();
        //        //da.Fill(ds);
        //        //dataGridView1.DataSource = ds;
        //    }
        //}

      

       
    }
}
