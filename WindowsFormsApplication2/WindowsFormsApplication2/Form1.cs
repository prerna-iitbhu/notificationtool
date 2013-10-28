using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using MyWpfWindow;
using System.Data.SqlClient;
using System.Threading;
using System.Timers;

namespace WindowsFormsApplication2
{
 
    public partial class Form1 : Form
    {
       
        public static  System.Timers.Timer timer1;
        public static Thread PreviousThread;
        public static bool NetworkProblem;

        public Form1()
        {
            try
            {
                Microsoft.Win32.RegistryKey k;
                Microsoft.Win32.RegistryKey reg;
                InitializeComponent();  
                timer1 = new System.Timers.Timer();
                timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                //set the timer
                reg = Microsoft.Win32.Registry.CurrentUser;
                k = reg.CreateSubKey("OneBugNotifier");
                Microsoft.Win32.RegistryKey UserProj = k.OpenSubKey("RefreshTime");
                int RefreshMinutes = Convert.ToInt32(UserProj.GetValue("Minutes"));
                timer1.Interval = RefreshMinutes * 10;// 60 * 1000;                
                timer1.Enabled = true;
                PreviousThread = null;
                NetworkProblem = false;
            }
            catch(Exception E)
            {
                //String ExpStr = "HI!!! Looks like this Tool is not configure... Press ok to Open the Configuration Window";
               //MessageBox.Show(ExpStr);
                new Form2().Show();
                timer1.Interval = 10 * 1000;// 60 * 1000;                
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void RunThreadFunction()
        {
            try
            {
                SqlConnection myconnection;

                List<Notification> l = new List<Notification> { };
                bool ThereIsNotification = false;
                myconnection = new SqlConnection();
                myconnection.ConnectionString = "Server=ftlpobugsqlcl01.citrite.net; Database= OneBugDatamart; Trusted_Connection= True";
                myconnection.Open();
               
                string project = null;

                Microsoft.Win32.RegistryKey k;
                Microsoft.Win32.RegistryKey reg;
                reg = Microsoft.Win32.Registry.CurrentUser;
               
                    k = reg.OpenSubKey("OneBugNotifier");
                    Microsoft.Win32.RegistryKey ProjReg = k.OpenSubKey("Project", true);
                    Microsoft.Win32.RegistryKey UserProj = k.OpenSubKey("RefreshTime", true);
                    Microsoft.Win32.RegistryKey cmpnt = k.OpenSubKey("Components");
                    String listcmpnt = null ;
                    try
                    {
                         listcmpnt = cmpnt.GetValue("Name").ToString();
                         project = ProjReg.GetValue("Name").ToString();
                    }
                    catch (Exception ComponentRegKeyNotAvailable)
                    {

                    }

                    String LastQueryTime = UserProj.GetValue("LastQueryTime").ToString();
                    
               // if (Convert.ToBoolean(ProjReg.GetValue("PersonalQuery").ToString()))
                    
                // personal query is always done. Without any input
                if(true) 
                    {
                        string name = System.Environment.UserName;    
                        string query = "select  BUGID as [CPR#], title as [title], LastModifierNm as [LastModifier] from OB_BUGS where (TargetReleaseSingular LIKE @project or Project LIKE @project )and (SubmitterId = @name or OwnerId= @name) and (LastModifiedDate >= @queryTime) order by LastModifiedDate desc";
                        
                           if (String.IsNullOrEmpty(project))
                            {
                                query = "select  BUGID as [CPR#], title as [title], LastModifierNm as [LastModifier] from OB_BUGS where (SubmitterId = @name or OwnerId= @name) and (LastModifiedDate >= @queryTime) order by LastModifiedDate desc";
                            }                       
                        
                        NetworkProblem = false;
                        DateTime now = DateTime.Now.ToUniversalTime();
                        string nowStr = now.ToString("yyyy-MM-dd HH:mm:ss");
                        reg = Microsoft.Win32.Registry.CurrentUser;
                        k = reg.OpenSubKey("OneBugNotifier");
                        UserProj = k.OpenSubKey("RefreshTime", true);
                       // UserProj.SetValue("LastQueryTime", nowStr, Microsoft.Win32.RegistryValueKind.String);

                        SqlCommand querycommand = new SqlCommand(query, myconnection);
                        querycommand.CommandTimeout = 0;
                        querycommand.Parameters.AddWithValue("@name", name);
                        querycommand.Parameters.AddWithValue("@project", project);
                        querycommand.Parameters.AddWithValue("@queryTime", LastQueryTime);
                        SqlDataReader rdr = querycommand.ExecuteReader();

                        while (rdr.Read())
                        {
                            ThereIsNotification = true;
                            string value2 = (rdr.GetInt32(0)).ToString();
                            string value3 = rdr.GetString(1);
                            string value4 = rdr.GetString(2);
                          //  l.Add(new Notification { Bugid = value2, Bugtitle = value3, Modifier = value4 });
                            bool contains1 = false;
                            foreach (Notification n in l)
                            {
                                if (n.Bugid == value2)
                                {
                                    contains1 = true;
                                }
                            }

                            if (contains1 == false)
                            {
                                l.Add(new Notification { Bugid = value2, Bugtitle = value3, Modifier = value4 });
                            }
                            

                        }
                        querycommand.Dispose();
                        rdr.Dispose();
                      
                    }
                       
                if(listcmpnt != null)
                {
                   
                      //  listcmpnt = listcmpnt.Remove(listcmpnt.Length - 1);
                    String[] words = listcmpnt.Split(',');
                    string query = "select  BUGID as [CPR#], title as [title], LastModifierNm as [LastModifier] ,Component as [Component]from OB_BUGS where (TargetReleaseSingular LIKE '@project' or Project LIKE '@project' ) and ";

                    if ((String.IsNullOrEmpty(project)))
                    {
                        query = "select  BUGID as [CPR#], title as [title], LastModifierNm as [LastModifier] ,Component as [Component]from OB_BUGS where";
                    }
                        //foreach (string d in words)
                        //{
                        //    query= query + "Component LIKE" + "'"+ d + "'" + " or ";
                        
                        //}
                        //query = query.Remove(query.Length - 3, 3);
                        //query = query + ")";
                        query = query + " (LastModifiedDate >= @queryTime)  order by LastModifiedDate desc";
                        DateTime now = DateTime.Now.ToUniversalTime();
                        string nowStr = now.ToString("yyyy-MM-dd HH:mm:ss");
                        reg = Microsoft.Win32.Registry.CurrentUser;
                        k = reg.OpenSubKey("OneBugNotifier");
                        UserProj = k.OpenSubKey("RefreshTime", true);
                        UserProj.SetValue("LastQueryTime", nowStr, Microsoft.Win32.RegistryValueKind.String);

                    //    query = "select  BUGID as [CPR#], title as [title], LastModifierNm as [LastModifier],Component as [Component] from OB_BUGS where (TargetReleaseSingular LIKE '" + project+"' or Project LIKE '" + project+"' ) and  (LastModifiedDate >= '"+LastQueryTime+"')  order by LastModifiedDate desc";
                        SqlCommand querycommand = new SqlCommand(query, myconnection);
                        querycommand.CommandTimeout = 0;
                        querycommand.Parameters.AddWithValue("@project", project);
                        querycommand.Parameters.AddWithValue("@queryTime", LastQueryTime);

                        SqlDataReader rdr = querycommand.ExecuteReader();
                    string str11;
                    int i = 0;
                        while (rdr.Read())
                        {
                            i++;
                            str11 =  rdr.GetValue(3).ToString();
                            if (listcmpnt.Contains(str11) == false || String.IsNullOrEmpty(str11) ==true)
                            {
                                continue;
                            }
                            ThereIsNotification = true;
                            string value2 = (rdr.GetInt32(0)).ToString();
                            string value3 = rdr.GetString(1);
                            string value4 = rdr.GetString(2);
                           
                           
                            //implemting list.contains. Since the contains fuction has O(n). It should not affect the performance here.
                            
                            bool contains = false;
                            foreach (Notification n in l)
                            {
                                if (n.Bugid == value2)
                                {
                                    contains = true;
                                }
                            }

                            if (contains == false)
                            {
                                l.Add(new Notification { Bugid = value2, Bugtitle = value3, Modifier = value4 });
                            }
                            

                        }

                        querycommand.Dispose();
                        rdr.Dispose();

                    }

                myconnection.Close();
                myconnection.Dispose();
               
                if (ThereIsNotification == true)
                {
                    
                    var wpfwindow = new MyWpfWindow.MyWpfWindow1(l);                    
                    wpfwindow.Visibility = System.Windows.Visibility.Visible;
                    System.Windows.Threading.Dispatcher.Run();
                    
                }

                
             
                
            }
            catch (Exception E)
            {


                try
                {
                    Microsoft.Win32.RegistryKey k;
                    Microsoft.Win32.RegistryKey reg;                  
                    reg = Microsoft.Win32.Registry.CurrentUser;
                    k = reg.OpenSubKey("OneBugNotifier");
                    Microsoft.Win32.RegistryKey UserProj = k.OpenSubKey("RefreshTime");
                    int RefreshMinutes = Convert.ToInt32(UserProj.GetValue("Minutes"));

                    if (NetworkProblem == false)
                    {
                        String ExpStr = "Looks like some problem in connecting to the OneBUG Server.Please check if you have a permission to query One Bug SQL Server";
                       // MessageBox.Show(ExpStr);
                        NetworkProblem = true;
                    }

                   
                }
                catch (Exception E11)
                {
                   
                }
                
              
            }
        }


        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            timer1.Enabled = false;            
            System.Threading.Thread SqlQueryThread;
            SqlQueryThread = new Thread(new ThreadStart(RunThreadFunction));
            SqlQueryThread.SetApartmentState(ApartmentState.STA);
            SqlQueryThread.Start();
            
            if (PreviousThread != null)
            {
                try
                {
                   // PreviousThread.Abort();
                }
                catch (Exception e11)
                {
                }
            }

            PreviousThread = SqlQueryThread;
            Microsoft.Win32.RegistryKey k;
            Microsoft.Win32.RegistryKey reg;      
            reg = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                k = reg.OpenSubKey("OneBugNotifier");
                Microsoft.Win32.RegistryKey UserProj = k.OpenSubKey("RefreshTime");
                int RefreshMinutes = Convert.ToInt32(UserProj.GetValue("Minutes"));
                timer1.Interval = RefreshMinutes * 60 * 1000;
            }
            catch (Exception ex11)
            {
                timer1.Enabled = true; 
            }
            timer1.Enabled = true;          
        }

        
    }

    
    
}
