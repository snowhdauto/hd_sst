using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SST_Icon.Forms
{
    public partial class tempcookies : Form
    {
        public tempcookies()
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
                string waytxt = "del %Temp% /S /F /Q";
                string wayfolder = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST";
                string nametxt = "CleanTemp.bat";
                string CleanTempCreate = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\CleanTemp.bat";

                string text = waytxt;
                string dir = wayfolder;
                string file = Path.Combine(dir, nametxt);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(file, text);

                Process proc1 = new Process();
                proc1.StartInfo.FileName = CleanTempCreate;
                proc1.StartInfo.WorkingDirectory = wayfolder;
                proc1.Start();

                Thread.Sleep(1000);

                string CleanTempDel = CleanTempCreate;

                if (File.Exists(CleanTempDel))
                {
                    File.Delete(CleanTempDel);
                }
            }


        }
    }
}
