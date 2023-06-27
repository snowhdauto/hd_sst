using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Management;

namespace SST_Icon
{
    public partial class MainForm : Form
    {
        PerformanceCounter ZSATunnel = new PerformanceCounter("Process", "Working Set - Private", "ZSATunnel");

        private FormWindowState _lastGoodState;
        public MainForm()
        {
            InitializeComponent();
            #region Hidden forms
            notifyIcon1.Click += notifyIcon1_Click;
            _lastGoodState = this.WindowState;
            try
            {
                #region NamePC
                /// namePC
                string rootDriveRURF = Path.GetPathRoot(Environment.SystemDirectory);
                string userNameRURF = Environment.UserName;
                string RURFCache_SST = rootDriveRURF + "Users\\" + userNameRURF + "\\AppData\\Local\\Temp\\SST\\RURFCache_SST.txt";


                try
                {
                    TextReader tr = new StreamReader(RURFCache_SST);
                    int NumberOfLines = 15;
                    string[] ListLines = new string[NumberOfLines];
                    ListLines[1] = tr.ReadLine();
                    Username.Text = "UserID: " + ListLines[1];

                }
                catch
                {
                    string rootDriveRURF1 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNameRURF1 = Environment.UserName;
                    string namepcRURF = SystemInformation.UserName.ToString();
                    string wayfolder = rootDriveRURF1 + "users\\" + userNameRURF1 + "\\AppData\\Local\\Temp\\SST";
                    string nametxt = "RURFCache_SST.txt";
                    string waytxt = namepcRURF;
                    string text = waytxt;
                    string dir = wayfolder;
                    string file = Path.Combine(dir, nametxt);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.WriteAllText(file, text);
                    Username.Text = "UserID: " + namepcRURF;


                }
                ///namePC end
                #endregion

                #region IP_PC
                IPHostEntry host;
                string LocalIP = "?";
                host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip1 in host.AddressList)
                {
                    if (ip1.AddressFamily.ToString() == "InterNetwork")
                    {
                        LocalIP = ip1.ToString();
                        label10.ForeColor = Color.Red;
                        label10.Text = "Отключен";
                        label2.Text = "Домашний интернет: " + LocalIP;
                    }
                    else
                    {
                        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                        {
                            foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                            {

                                string Cisco = "Cisco AnyConnect Secure Mobility Client Virtual Miniport Adapter for Windows x64";
                                if (Cisco == nic.Description)
                                {
                                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                    {
                                        label10.ForeColor = Color.Green;
                                        label10.Text = ip.Address.ToString();
                                        label2.Text = "Домашний интернет: " + LocalIP;
                                    }

                                }

                            }
                        }
                    }

                }
                /// Zscaler start

                try
                {
                    if (ZSATunnel.NextValue() != 0)
                        label9.ForeColor = Color.Green;
                    label9.Text = "Включен";
                }
                catch
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = "Отключен";
                }
                try
                {
                    if (label10.ForeColor == Color.Green && ZSATunnel.NextValue() != 0)
                    {
                        label9.ForeColor = Color.YellowGreen;
                        label9.Text = "Запущен, но не активен";
                    }
                }
                catch
                {

                }
                

                /// Zscaler end
                #endregion

                #region Panel1Cache
                string rootDrivePanel1 = Path.GetPathRoot(Environment.SystemDirectory);
                string userNamePanel1 = Environment.UserName;
                string filename = "Panel1";
                string recPath = rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\";
                string recPathFromeFile = rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\Panel1.png";

                if (!(Directory.Exists(rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\")))
                {
                    Directory.CreateDirectory(rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\");
                }


                if (File.Exists(recPathFromeFile))
                {
                    panel1.BackgroundImage = Image.FromFile(recPathFromeFile);
                }
                else
                {
                    panel1.BackgroundImage.Save(recPath + @"\" + filename.ToString() + ".png", ImageFormat.Png); // Создает картинку вытаскивая её из panel
                }
                #endregion

                #region Panel2Cache
                string rootDrivePanel2 = Path.GetPathRoot(Environment.SystemDirectory);
                string userNamePanel2 = Environment.UserName;
                string filenamePanel2 = "Panel2";
                string recPathPanel2 = rootDrivePanel2 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\";
                string recPathFromeFilePanel2 = rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\Panel2.png";

                if (!(Directory.Exists(rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\")))
                {
                    Directory.CreateDirectory(rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\");
                }


                if (File.Exists(recPathFromeFilePanel2))
                {
                    panel2.BackgroundImage = Image.FromFile(recPathFromeFilePanel2);
                }
                else
                {
                    panel2.BackgroundImage.Save(recPathPanel2 + @"\" + filenamePanel2.ToString() + ".png", ImageFormat.Png); // Создает картинку вытаскивая её из panel
                }
                #endregion

                #region HosnamePC
                ///Hostname
                string rootDriveHostname = Path.GetPathRoot(Environment.SystemDirectory);
                string userNameHostname = Environment.UserName;
                string HostanameCache_SST = rootDriveHostname + "Users\\" + userNameHostname + "\\AppData\\Local\\Temp\\SST\\HostnameCache_SST.txt";


                try
                {
                    TextReader tr = new StreamReader(HostanameCache_SST);
                    int NumberOfLines = 15;
                    string[] ListLines = new string[NumberOfLines];
                    ListLines[1] = tr.ReadLine();
                    Hostname.Text = "Имя ПК: " + ListLines[1];

                }
                catch
                {
                    string rootDriveHostname1 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNameHostname1 = Environment.UserName;
                    string comname = SystemInformation.ComputerName;
                    string wayfolder = rootDriveHostname1 + "users\\" + userNameHostname1 + "\\AppData\\Local\\Temp\\SST";
                    string nametxt = "HostnameCache_SST.txt";
                    string waytxt = comname;
                    string text = waytxt;
                    string dir = wayfolder;
                    string file = Path.Combine(dir, nametxt);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.WriteAllText(file, text);
                    Hostname.Text = "Имя ПК: " + comname;


                }
                ///Hostname end
                #endregion

                SerialNumber();

                CheckVerionPC();

            }
            catch { }            
            #endregion

        }

        private void SerialNumber()
        {
            ManagementObjectSearcher ComSerial = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in ComSerial.Get())
            {
                try
                {
                    label11.Text = "Серийный номер ПК: " + wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            
        }

        private void CheckVerionPC()
        {
            ManagementObjectSearcher ModelPC1 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            foreach (ManagementObject wmi in ModelPC1.Get())
            {
                try
                {
                    string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
                    string userName = Environment.UserName;
                    string ModelPC = "/c wmic csproduct get version>" + rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\VerisonPC.txt";
                    string ModelPCChack = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\VerisonPC.txt";

                    if (File.Exists(ModelPCChack))
                    {
                        TextReader tr = new StreamReader(ModelPCChack);
                        int NumberOfLines = 15;
                        string[] ListLines = new string[NumberOfLines];

                        for (int i = 1; i < NumberOfLines; i++)
                        {
                            ListLines[i] = tr.ReadLine();
                        }
                        tr.Dispose();

                        label12.Text = "Модель: " + wmi.GetPropertyValue("Manufacturer").ToString() + " " + ListLines[2];
                    }
                    else
                    {
                        ProcessStartInfo ModelPCSerch = new ProcessStartInfo("cmd.exe", ModelPC);
                        ModelPCSerch.RedirectStandardInput = true;
                        ModelPCSerch.RedirectStandardOutput = true;
                        ModelPCSerch.RedirectStandardError = true;
                        ModelPCSerch.UseShellExecute = false;
                        ModelPCSerch.CreateNoWindow = true;
                        ModelPCSerch.WindowStyle = ProcessWindowStyle.Hidden;
                        Process.Start(ModelPCSerch);

                        Thread.Sleep(599);

                        TextReader tr = new StreamReader(ModelPCChack);
                        int NumberOfLines = 15;
                        string[] ListLines = new string[NumberOfLines];

                        for (int i = 1; i < NumberOfLines; i++)
                        {
                            ListLines[i] = tr.ReadLine();
                        }
                        tr.Dispose();

                        label12.Text = "Модель: " + wmi.GetPropertyValue("Manufacturer").ToString() + " " + ListLines[2];
                    }

                }
                catch { }
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Получено сообщение на активацию.
            if (m.Msg == Win32.WM_MAINFORM_ACTIVATE)
            {
                RestoreAndActivate();
            }

            else
                base.WndProc(ref m);
        }

        public void RestoreAndActivate()
        {
            // Если окно свернуто — развернуть его в предыдущее состояние.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = _lastGoodState;
            if (this.Visible == false)
                this.Visible = true;



            // Показать поверх остальных окон и сделать активным.
            Activate();
        }

        protected override void OnResize(EventArgs e)
        {
            // Запомнить состояние окна до того, как оно свернуто.
            if (this.WindowState != FormWindowState.Minimized)
                _lastGoodState = this.WindowState;


            base.OnResize(e);
        }

        #region Filling out the form when clicking on Flag
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
                
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                try
                {
                    #region NamePC
                    /// namePC
                    string rootDriveRURF = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNameRURF = Environment.UserName;
                    string RURFCache_SST = rootDriveRURF + "Users\\" + userNameRURF + "\\AppData\\Local\\Temp\\SST\\RURFCache_SST.txt";


                    try
                    {
                        TextReader tr = new StreamReader(RURFCache_SST);
                        int NumberOfLines = 15;
                        string[] ListLines = new string[NumberOfLines];
                        ListLines[1] = tr.ReadLine();
                        Username.Text = "UserID: " + ListLines[1];

                    }
                    catch
                    {
                        string rootDriveRURF1 = Path.GetPathRoot(Environment.SystemDirectory);
                        string userNameRURF1 = Environment.UserName;
                        string namepcRURF = SystemInformation.UserName.ToString();
                        string wayfolder = rootDriveRURF1 + "users\\" + userNameRURF1 + "\\AppData\\Local\\Temp\\SST";
                        string nametxt = "RURFCache_SST.txt";
                        string waytxt = namepcRURF;
                        string text = waytxt;
                        string dir = wayfolder;
                        string file = Path.Combine(dir, nametxt);

                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        File.WriteAllText(file, text);
                        Username.Text = "UserID: " + namepcRURF;


                    }
                    ///namePC end
                    #endregion

                    #region IP_PC
                    IPHostEntry host;
                    string LocalIP = "?";
                    host = Dns.GetHostEntry(Dns.GetHostName());

                    foreach (IPAddress ip1 in host.AddressList)
                    {
                        if (ip1.AddressFamily.ToString() == "InterNetwork")
                        {
                            LocalIP = ip1.ToString();
                            label10.ForeColor = Color.Red;
                            label10.Text = "Отключен";
                            label2.Text = "Домашний интернет: " + LocalIP;
                        }
                        else
                        {
                            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                            {
                                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                                {

                                    string Cisco = "Cisco AnyConnect Secure Mobility Client Virtual Miniport Adapter for Windows x64";
                                    if (Cisco == nic.Description)
                                    {
                                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                        {
                                            label10.ForeColor = Color.Green;
                                            label10.Text = ip.Address.ToString();
                                            label2.Text = "Домашний интернет: " + LocalIP;
                                        }

                                    }

                                }
                            }
                        }

                    }

                    /// Zscaler start
                    try
                    {
                        if (ZSATunnel.NextValue() != 0)
                            label9.ForeColor = Color.Green;
                        label9.Text = "Включен";
                    }
                    catch
                    {
                        label9.ForeColor = Color.Red;
                        label9.Text = "Отключен";
                    }

                    try
                    {
                        if (label10.ForeColor == Color.Green && ZSATunnel.NextValue() != 0)
                        {
                            label9.ForeColor = Color.YellowGreen;
                            label9.Text = "Запущен, но не активен";
                        }
                    }
                    catch
                    {

                    }

                    /// Zscaler end

                    #endregion

                    #region Panel1Cache
                    string rootDrivePanel1 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNamePanel1 = Environment.UserName;
                    string filename = "Panel1";
                    string recPath = rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\";
                    string recPathFromeFile = rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\Panel1.png";

                    if (!(Directory.Exists(rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\")))
                    {
                        Directory.CreateDirectory(rootDrivePanel1 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\");
                    }


                    if (File.Exists(recPathFromeFile))
                    {
                        panel1.BackgroundImage = Image.FromFile(recPathFromeFile);
                    }
                    else
                    {
                        panel1.BackgroundImage.Save(recPath + @"\" + filename.ToString() + ".png", ImageFormat.Png); // Создает картинку вытаскивая её из panel
                    }
                    #endregion

                    #region Panel2Cache
                    string rootDrivePanel2 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNamePanel2 = Environment.UserName;
                    string filenamePanel2 = "Panel2";
                    string recPathPanel2 = rootDrivePanel2 + "Users\\" + userNamePanel1 + "\\AppData\\Local\\Temp\\SST\\";
                    string recPathFromeFilePanel2 = rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\Panel2.png";

                    if (!(Directory.Exists(rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\")))
                    {
                        Directory.CreateDirectory(rootDrivePanel2 + "Users\\" + userNamePanel2 + "\\AppData\\Local\\Temp\\SST\\");
                    }


                    if (File.Exists(recPathFromeFilePanel2))
                    {
                        panel2.BackgroundImage = Image.FromFile(recPathFromeFilePanel2);
                    }
                    else
                    {
                        panel2.BackgroundImage.Save(recPathPanel2 + @"\" + filenamePanel2.ToString() + ".png", ImageFormat.Png); // Создает картинку вытаскивая её из panel
                    }
                    #endregion

                    #region HosnamePC
                    ///Hostname
                    string rootDriveHostname = Path.GetPathRoot(Environment.SystemDirectory);
                    string userNameHostname = Environment.UserName;
                    string HostanameCache_SST = rootDriveHostname + "Users\\" + userNameHostname + "\\AppData\\Local\\Temp\\SST\\HostnameCache_SST.txt";


                    try
                    {
                        TextReader tr = new StreamReader(HostanameCache_SST);
                        int NumberOfLines = 15;
                        string[] ListLines = new string[NumberOfLines];
                        ListLines[1] = tr.ReadLine();
                        Hostname.Text = "Имя ПК: " + ListLines[1];

                    }
                    catch
                    {
                        string rootDriveHostname1 = Path.GetPathRoot(Environment.SystemDirectory);
                        string userNameHostname1 = Environment.UserName;
                        string comname = SystemInformation.ComputerName;
                        string wayfolder = rootDriveHostname1 + "users\\" + userNameHostname1 + "\\AppData\\Local\\Temp\\SST";
                        string nametxt = "HostnameCache_SST.txt";
                        string waytxt = comname;
                        string text = waytxt;
                        string dir = wayfolder;
                        string file = Path.Combine(dir, nametxt);

                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        File.WriteAllText(file, text);
                        Hostname.Text = "Имя ПК: " + comname;


                    }
                    ///Hostname end
                    #endregion

                    SerialNumber();

                    CheckVerionPC();

                }
                catch { }
            }
        }
#endregion

        #region Move Form
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr nWnd, int wMsg, int wParam, int iwParam);
        #endregion

        #region OpenChildForm
        private Form activeForm = null;
        private void openChildForm(Form chilFrom)
        {
            try
            {
                if (activeForm != null)
                    activeForm.Close();
                activeForm = chilFrom;
                chilFrom.TopLevel = false;
                chilFrom.FormBorderStyle = FormBorderStyle.None;
                chilFrom.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(chilFrom);
                panelChildForm.Tag = chilFrom;
                chilFrom.BringToFront();
                chilFrom.Show();
            }
            catch { MessageBox.Show("Упс, что-то пошло не так"); }
            
        }
        #endregion


        #region Buttons
        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.MenuForms());
        }
        #region Move Panel 1 and 2
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
#endregion

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Helpbrowsers());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenHelpYourPC();

        }
        private void OpenHelpYourPC()
        {
            openChildForm(new Forms.HelpYourPC());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("https://cchprod.service-now.com/sp?id=sc_cat_item&sys_id=4c7ad542db60e490e40845403996193b");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://cchellenic.sharepoint.com/sites/spaces-RU-RUBSSHLP/SitePages/Home.aspx");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://teams.microsoft.com/_#/apps/c1586b70-2bd1-45cb-8af0-e6337ad4fdb8/sections/conversations?slug=28:bb92e66d-fc1d-42f1-8689-b716b8103785");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string pismovHelpDesk = string.Format("mailto:{0}?Subject={1}", "helpdesk.regional@cchellenic.com", "Incident:");
            pismovHelpDesk = Uri.EscapeUriString(pismovHelpDesk);
            Process.Start(pismovHelpDesk);
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Process.Start("https://ois.eur.cchbc.com/workitemdlg.aspx?ACTTEMP=1001321&RURLID=82b7ffd1-8856-4242-befa-b8417088f095");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
