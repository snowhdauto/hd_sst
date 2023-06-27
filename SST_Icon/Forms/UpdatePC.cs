using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Text;

namespace SST_Icon.Forms
{
    public partial class UpdatePC : Form
    {
        private const string waytxtgpupdate = "gpupdate /force";
        private const string wayfolder = "C:\\temp";
        private const string namebatfilegpupdate = "gpupdate121.bat";
        private const string waybatfilegpupdate = @"C:\temp\gpupdate121.bat";

        public UpdatePC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Просьба ознакомиться с описанием данной функции." + "\n" + "Если вы хотите продолжить, нажмите кнопку «ОК»." + "\n" + "Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            {
                string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
                string userName = Environment.UserName;
                string waytxtgpupdate = "gpupdate /force";
                string wayfolder = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST";
                string namebatfilegpupdate = "gpupdate121.bat";
                string waybatfilegpupdate = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\gpupdate121.bat";
                string text2 = waytxtgpupdate;
                string dir2 = wayfolder;
                string file2 = Path.Combine(dir2, namebatfilegpupdate);

                if (!Directory.Exists(dir2))
                    Directory.CreateDirectory(dir2);

                File.WriteAllText(file2, text2);

                Process proc3 = new Process();
                proc3.StartInfo.FileName = waybatfilegpupdate;
                proc3.StartInfo.WorkingDirectory = wayfolder;
                proc3.Start();


                Thread.Sleep(1000);

                string CleangpupdateFile = waybatfilegpupdate;

                if (File.Exists(CleangpupdateFile))
                {
                    File.Delete(CleangpupdateFile);
                }
            }

            
        }
    }
}
