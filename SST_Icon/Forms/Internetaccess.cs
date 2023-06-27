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
    public partial class Internetaccess : Form
    {
        public Internetaccess()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Просьба ознакомиться с описанием данной функции." + "\n" + "Если вы хотите продолжить, нажмите кнопку «ОК»." + "\n" + "Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            {

                if (!(Directory.Exists(@"C:\Temp")))
                {
                    Directory.CreateDirectory(@"C:\Temp");

                    Thread.Sleep(599);
                    ProcessStartInfo cmd = new ProcessStartInfo("cmd.exe", "/c ipconfig /all >c:\\temp\\ipconfig_all.txt");
                    cmd.RedirectStandardInput = true;
                    cmd.RedirectStandardOutput = true;
                    cmd.RedirectStandardError = true;
                    cmd.UseShellExecute = false;
                    cmd.CreateNoWindow = true;
                    cmd.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd);

                    //tracert -d 8.8.8.8

                    ProcessStartInfo cmd1 = new ProcessStartInfo("cmd.exe", "/c tracert -d 8.8.8.8 >c:\\temp\\tracert_d_8_8_8_8.txt");
                    cmd1.RedirectStandardInput = true;
                    cmd1.RedirectStandardOutput = true;
                    cmd1.RedirectStandardError = true;
                    cmd1.UseShellExecute = false;
                    cmd1.CreateNoWindow = true;
                    cmd1.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd1);

                    //ping 8.8.8.8 -n 100

                    ProcessStartInfo cmd2 = new ProcessStartInfo("cmd.exe", "/c ping 8.8.8.8 -n 100 >c:\\temp\\ping_8_8_8_8_n_100.txt");
                    cmd2.RedirectStandardInput = true;
                    cmd2.RedirectStandardOutput = true;
                    cmd2.RedirectStandardError = true;
                    cmd2.UseShellExecute = false;
                    cmd2.CreateNoWindow = true;
                    cmd2.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd2);

                    //tracert -d cuvl3501

                    ProcessStartInfo cmd3 = new ProcessStartInfo("cmd.exe", "/c tracert -d cuvl0301 >c:\\temp\\tracert_d_cuvl3501.txt");
                    cmd3.RedirectStandardInput = true;
                    cmd3.RedirectStandardOutput = true;
                    cmd3.RedirectStandardError = true;
                    cmd3.UseShellExecute = false;
                    cmd3.CreateNoWindow = true;
                    cmd3.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd3);

                    //ping cuvl3501 -n 100

                    ProcessStartInfo cmd4 = new ProcessStartInfo("cmd.exe", "/c ping cuvl0301 -n 100 >c:\\temp\\ping_cuvl3501_n_100.txt");
                    cmd4.RedirectStandardInput = true;
                    cmd4.RedirectStandardOutput = true;
                    cmd4.RedirectStandardError = true;
                    cmd4.UseShellExecute = false;
                    cmd4.CreateNoWindow = true;
                    cmd4.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd4);

                    //set log

                    ProcessStartInfo cmd5 = new ProcessStartInfo("cmd.exe", "/c set log >c:\\temp\\set_log.txt");
                    cmd5.RedirectStandardInput = true;
                    cmd5.RedirectStandardOutput = true;
                    cmd5.RedirectStandardError = true;
                    cmd5.UseShellExecute = false;
                    cmd5.CreateNoWindow = true;
                    cmd5.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd5);

                    //gpresult /r

                    ProcessStartInfo cmd6 = new ProcessStartInfo("cmd.exe", "/c ping cuvl3501 -n 100 >c:\\temp\\gpresult_r.txt");
                    cmd6.RedirectStandardInput = true;
                    cmd6.RedirectStandardOutput = true;
                    cmd6.RedirectStandardError = true;
                    cmd6.UseShellExecute = false;
                    cmd6.CreateNoWindow = true;
                    cmd6.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd6);

                    //echo %logonserver%

                    ProcessStartInfo cmd7 = new ProcessStartInfo("cmd.exe", "/c echo %logonserver% >c:\\temp\\echo_logonserver.txt");
                    cmd7.RedirectStandardInput = true;
                    cmd7.RedirectStandardOutput = true;
                    cmd7.RedirectStandardError = true;
                    cmd7.UseShellExecute = false;
                    cmd7.CreateNoWindow = true;
                    cmd7.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd7);


                    MessageBox.Show("Выполнено");

                }
                else
                {
                    ProcessStartInfo cmd = new ProcessStartInfo("cmd.exe", "/c ipconfig /all >c:\\temp\\ipconfig_all.txt");
                    cmd.RedirectStandardInput = true;
                    cmd.RedirectStandardOutput = true;
                    cmd.RedirectStandardError = true;
                    cmd.UseShellExecute = false;
                    cmd.CreateNoWindow = true;
                    cmd.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd);

                    //tracert -d 8.8.8.8

                    ProcessStartInfo cmd1 = new ProcessStartInfo("cmd.exe", "/c tracert -d 8.8.8.8 >c:\\temp\\tracert_d_8_8_8_8.txt");
                    cmd1.RedirectStandardInput = true;
                    cmd1.RedirectStandardOutput = true;
                    cmd1.RedirectStandardError = true;
                    cmd1.UseShellExecute = false;
                    cmd1.CreateNoWindow = true;
                    cmd1.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd1);

                    //ping 8.8.8.8 -n 100

                    ProcessStartInfo cmd2 = new ProcessStartInfo("cmd.exe", "/c ping 8.8.8.8 -n 100 >c:\\temp\\ping_8_8_8_8_n_100.txt");
                    cmd2.RedirectStandardInput = true;
                    cmd2.RedirectStandardOutput = true;
                    cmd2.RedirectStandardError = true;
                    cmd2.UseShellExecute = false;
                    cmd2.CreateNoWindow = true;
                    cmd2.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd2);

                    //tracert -d cuvl3501

                    ProcessStartInfo cmd3 = new ProcessStartInfo("cmd.exe", "/c tracert -d cuvl0301 >c:\\temp\\tracert_d_cuvl3501.txt");
                    cmd3.RedirectStandardInput = true;
                    cmd3.RedirectStandardOutput = true;
                    cmd3.RedirectStandardError = true;
                    cmd3.UseShellExecute = false;
                    cmd3.CreateNoWindow = true;
                    cmd3.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd3);

                    //ping cuvl3501 -n 100

                    ProcessStartInfo cmd4 = new ProcessStartInfo("cmd.exe", "/c ping cuvl3501 -n 100 >c:\\temp\\ping_cuvl3501_n_100.txt");
                    cmd4.RedirectStandardInput = true;
                    cmd4.RedirectStandardOutput = true;
                    cmd4.RedirectStandardError = true;
                    cmd4.UseShellExecute = false;
                    cmd4.CreateNoWindow = true;
                    cmd4.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd4);

                    //set log

                    ProcessStartInfo cmd5 = new ProcessStartInfo("cmd.exe", "/c set log >c:\\temp\\set_log.txt");
                    cmd5.RedirectStandardInput = true;
                    cmd5.RedirectStandardOutput = true;
                    cmd5.RedirectStandardError = true;
                    cmd5.UseShellExecute = false;
                    cmd5.CreateNoWindow = true;
                    cmd5.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd5);

                    //gpresult /r

                    ProcessStartInfo cmd6 = new ProcessStartInfo("cmd.exe", "/c ping cuvl3501 -n 100 >c:\\temp\\gpresult_r.txt");
                    cmd6.RedirectStandardInput = true;
                    cmd6.RedirectStandardOutput = true;
                    cmd6.RedirectStandardError = true;
                    cmd6.UseShellExecute = false;
                    cmd6.CreateNoWindow = true;
                    cmd6.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd6);

                    //echo %logonserver%

                    ProcessStartInfo cmd7 = new ProcessStartInfo("cmd.exe", "/c echo %logonserver% >c:\\temp\\echo_logonserver.txt");
                    cmd7.RedirectStandardInput = true;
                    cmd7.RedirectStandardOutput = true;
                    cmd7.RedirectStandardError = true;
                    cmd7.UseShellExecute = false;
                    cmd7.CreateNoWindow = true;
                    cmd7.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(cmd7);


                    MessageBox.Show("Выполнено");

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
