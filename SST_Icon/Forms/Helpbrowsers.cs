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
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace SST_Icon.Forms
{
    public partial class Helpbrowsers : Form
    {
        public Helpbrowsers()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
            circularProgressBar2.Value = 0;
            circularProgressBar3.Value = 0;
            circularProgressBar4.Value = 0;
            timer1.Enabled = true;

            #region GoogleChrome Cache
            // GoogleChrome

            string rootDrive1 = Path.GetPathRoot(Environment.SystemDirectory);
            string userName1 = Environment.UserName;
            string GoogleCookies = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
            try
            {
                if (File.Exists(GoogleCookies))
                {

                }
                else
                {
                    File.Create(GoogleCookies).Dispose();
                }
            }
            catch { }
            string GoogleCookiesjournal = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-journal";
            try
            {
                if (File.Exists(GoogleCookiesjournal))
                {

                }
                else
                {
                    File.Create(GoogleCookiesjournal).Dispose();
                }
            }
            catch { }
            //if (!(Directory.Exists(rootDrive1 + "Users\\" + userName1 + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache")))
            //{
            //    Directory.CreateDirectory(rootDrive1 + "Users\\" + userName1 + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
            //}
            //else
            //{

            //}
            //DirectoryInfo dtInfo = new DirectoryInfo(rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cache");
            //long totalsize = dtInfo.EnumerateFiles().Sum(file => file.Length);
            string google_app_cache = rootDrive1 + "Users\\" + userName1 + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache";
            long SizeGoogleCach = 0;
            DirectoryInfo dir1 = new DirectoryInfo(google_app_cache);
            foreach (FileInfo fi1 in dir1.GetFiles("*.*", SearchOption.AllDirectories))
            {
                SizeGoogleCach += fi1.Length;
            }

            long filesize = new FileInfo(GoogleCookies).Length;
            long filesize1 = new FileInfo(GoogleCookiesjournal).Length;

            int a = Convert.ToInt32(filesize);
            int b = Convert.ToInt32(filesize1);
            int c = Convert.ToInt32(SizeGoogleCach);
            int result = a + b + c;
            //GB
            if (result >= 1073741824)
            {
                long resultBG = result / 1073741824;
                if (resultBG <= 10)
                {
                    long CirVivodGB = resultBG;
                    circularProgressBar1.Maximum = 100;
                    circularProgressBar1.Value = (int)CirVivodGB;
                    if (circularProgressBar1.Value <= (int)CirVivodGB)
                    {
                        timer1.Enabled = false;
                        label1.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                    }
                    else
                    {
                        circularProgressBar1.Value = 100;
                    }
                }
                else
                {
                    long CirVivodGB = resultBG / 10;
                    circularProgressBar1.Maximum = 100;
                    circularProgressBar1.Value = (int)CirVivodGB;
                    if (circularProgressBar1.Value <= (int)CirVivodGB)
                    {
                        timer1.Enabled = false;
                        label1.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                    }
                    else
                    {
                        circularProgressBar1.Value = 100;
                    }
                }

                //MB
            }
            else
            {
                if (result >= 1048576)
                {
                    long resultMB = result / 1048576;
                    if (resultMB <= 10)
                    {
                        long CirVivodMB = resultMB;
                        circularProgressBar1.Maximum = 100;
                        circularProgressBar1.Value = (int)CirVivodMB;
                        if (circularProgressBar1.Value <= (int)CirVivodMB)
                        {
                            timer1.Enabled = false;
                            label1.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar1.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodMB = resultMB / 10;
                        circularProgressBar1.Maximum = 100;
                        circularProgressBar1.Value = (int)CirVivodMB;
                        if (circularProgressBar1.Value <= (int)CirVivodMB)
                        {
                            timer1.Enabled = false;
                            label1.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar1.Value = 100;
                        }
                    }


                }
                else
                {
                    if (result >= 1024)
                    {
                        long resultKB = result / 1024;
                        if (resultKB <= 10)
                        {
                            long CirVivodKB = resultKB;
                            circularProgressBar1.Maximum = 100;
                            circularProgressBar1.Value = (int)CirVivodKB;
                            if (circularProgressBar1.Value <= (int)CirVivodKB)
                            {
                                timer1.Enabled = false;
                                label1.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar1.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodKB = resultKB / 10;
                            circularProgressBar1.Maximum = 100;
                            circularProgressBar1.Value = (int)CirVivodKB;
                            if (circularProgressBar1.Value <= (int)CirVivodKB)
                            {
                                timer1.Enabled = false;
                                label1.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar1.Value = 100;
                            }
                        }

                    }
                    else
                    {
                        circularProgressBar1.Value = 0;
                        label1.Text = "Cache/Cookes: " + "\n" + result.ToString() + " KB";
                    }
                }
            }


            // end GoogleChrome
            #endregion
            #region GoogleChrome History
            string GoogleHistory = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History";
            try
            {
                if (File.Exists(GoogleHistory))
                {

                }
                else
                {
                    File.Create(GoogleHistory).Dispose();
                }
            }
            catch { }
            string GoogleHistoryjournal = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History-journal";
            try
            {
                if (File.Exists(GoogleHistoryjournal))
                {

                }
                else
                {
                    File.Create(GoogleHistoryjournal).Dispose();
                }
            }
            catch { }
            long filesizeHistory = new FileInfo(GoogleHistory).Length;
            long filesize1History = new FileInfo(GoogleHistoryjournal).Length;

            int aHistory = Convert.ToInt32(filesizeHistory);
            int bHistory = Convert.ToInt32(filesizeHistory);

            long resultHistory = aHistory + bHistory;

            if (resultHistory >= 1073741824)
            {
                long resultGBHistory = resultHistory / 1048576;
                if (resultGBHistory <= 10)
                {
                    long CirVivodGBHistory = resultGBHistory;
                    circularProgressBar4.Maximum = 100;
                    circularProgressBar4.Value = (int)CirVivodGBHistory;
                    if (circularProgressBar4.Value <= (int)CirVivodGBHistory)
                    {
                        timer1.Enabled = false;
                        label3.Text = "История: " + "\n" + resultGBHistory.ToString() + " MB";
                    }
                    else
                    {
                        circularProgressBar4.Value = 100;
                    }
                }
                else
                {
                    long CirVivodGBHistory = resultGBHistory / 10;
                    circularProgressBar4.Maximum = 100;
                    circularProgressBar4.Value = (int)CirVivodGBHistory;
                    if (circularProgressBar4.Value <= (int)CirVivodGBHistory)
                    {
                        timer1.Enabled = false;
                        label3.Text = "История: " + "\n" + resultGBHistory.ToString() + " MB";
                    }
                    else
                    {
                        circularProgressBar4.Value = 100;
                    }
                }
            }
            else
            {
                if (resultHistory >= 1048576)
                {
                    long resultMBHistory = resultHistory / 1048576;
                    if (resultMBHistory <= 10)
                    {
                        long CirVivodMBHistory = resultMBHistory;
                        circularProgressBar4.Maximum = 100;
                        circularProgressBar4.Value = (int)CirVivodMBHistory;
                        if (circularProgressBar4.Value <= (int)CirVivodMBHistory)
                        {
                            timer1.Enabled = false;
                            label3.Text = "История: " + "\n" + resultMBHistory.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar4.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodMBHistory = resultMBHistory / 10;
                        circularProgressBar4.Maximum = 100;
                        circularProgressBar4.Value = (int)CirVivodMBHistory;
                        if (circularProgressBar4.Value <= (int)CirVivodMBHistory)
                        {
                            timer1.Enabled = false;
                            label3.Text = "История: " + "\n" + resultMBHistory.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar4.Value = 100;
                        }
                    }
                }
                else
                {
                    if (resultHistory >= 1024)
                    {
                        long resultKBHistory = resultHistory / 1024;
                        if (resultKBHistory <= 10)
                        {
                            long CirVivodKBHistory = resultKBHistory;
                            circularProgressBar4.Maximum = 100;
                            circularProgressBar4.Value = (int)CirVivodKBHistory;
                            if (circularProgressBar4.Value <= (int)CirVivodKBHistory)
                            {
                                timer1.Enabled = false;
                                label3.Text = "История: " + "\n" + resultKBHistory.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar4.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodKBHistory = resultKBHistory / 10;
                            circularProgressBar4.Maximum = 100;
                            circularProgressBar4.Value = (int)CirVivodKBHistory;
                            if (circularProgressBar4.Value <= (int)CirVivodKBHistory)
                            {
                                timer1.Enabled = false;
                                label3.Text = "История: " + "\n" + resultKBHistory.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar4.Value = 100;
                            }
                        }

                    }
                    else
                    {
                        circularProgressBar4.Value = 0;
                        label3.Text = "История: " + "\n" + resultHistory.ToString() + " KB";
                    }
                }
            }






            #endregion
            #region Microsoft Edge Cache
            // Microsoft Edge
            

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string userName = Environment.UserName;
            string EdgeCookies = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies";
            try
            {
                if (File.Exists(EdgeCookies))
                {

                }
                else
                {
                    File.Create(EdgeCookies).Dispose();
                }
            }
            catch { }
            string EdgeCookiesjournal = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies-journal";
            try
            {
                if (File.Exists(EdgeCookiesjournal))
                {

                }
                else
                {
                    File.Create(EdgeCookiesjournal).Dispose();
                }
            }
            catch { }

            if (!(Directory.Exists(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache")))
            {
                Directory.CreateDirectory(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache");
            }
            else
            {

            }
            //DirectoryInfo dtInfo1 = new DirectoryInfo(rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cache");

            //long totalsize1 = dtInfo1.EnumerateFiles().Sum(file => file.Length);
            //string EdgeCache = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache";
            string edge_app_cache = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache";
            long Size_edge_cache = 0;
            DirectoryInfo dir = new DirectoryInfo(edge_app_cache);
            foreach (FileInfo fi1 in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                Size_edge_cache += fi1.Length;
            }


            long filesize2 = new FileInfo(EdgeCookies).Length;
            long filesize11 = new FileInfo(EdgeCookiesjournal).Length;

            int a1 = Convert.ToInt32(filesize2);
            int b1 = Convert.ToInt32(filesize11);
            int c1 = Convert.ToInt32(Size_edge_cache);
            int result1 = a1 + b1 + c1;
            //GB
            if (result1 >= 1073741824)
            {
                long resultBG = result1 / 1073741824;
                if (resultBG <= 10)
                {
                    long CirVivodGB = resultBG;
                    circularProgressBar2.Maximum = 100;
                    circularProgressBar2.Value = (int)CirVivodGB;
                    if (circularProgressBar2.Value <= (int)CirVivodGB)
                    {
                        timer1.Enabled = false;
                        label2.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                    }
                    else
                    {
                        circularProgressBar2.Value = 100;
                    }
                }
                else
                {
                    long CirVivodGB = resultBG / 10;
                    circularProgressBar2.Maximum = 100;
                    circularProgressBar2.Value = (int)CirVivodGB;
                    if (circularProgressBar2.Value <= (int)CirVivodGB)
                    {
                        timer1.Enabled = false;
                        label2.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                    }
                    else
                    {
                        circularProgressBar2.Value = 100;
                    }
                }

                //MB
            }
            else
            {
                if (result1 >= 1048576)
                {
                    long resultMB = result1 / 1048576;
                    if (resultMB <= 10)
                    {
                        long CirVivodMB = resultMB;
                        circularProgressBar2.Maximum = 100;
                        circularProgressBar2.Value = (int)CirVivodMB;
                        if (circularProgressBar2.Value <= (int)CirVivodMB)
                        {
                            timer1.Enabled = false;
                            label2.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar2.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodMB = resultMB / 10;
                        circularProgressBar2.Maximum = 100;
                        circularProgressBar2.Value = (int)CirVivodMB;
                        if (circularProgressBar2.Value <= (int)CirVivodMB)
                        {
                            timer1.Enabled = false;
                            label2.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar2.Value = 100;
                        }
                    }



                }
                else
                {
                    if (result1 >= 1024)
                    {
                        long resultKB = result1 / 1024;
                        if (resultKB <= 10)
                        {
                            long CirVivodKB = resultKB;
                            circularProgressBar2.Maximum = 100;
                            circularProgressBar2.Value = (int)CirVivodKB;
                            if (circularProgressBar2.Value <= (int)CirVivodKB)
                            {
                                timer1.Enabled = false;
                                label2.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar2.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodKB = resultKB / 10;
                            circularProgressBar2.Maximum = 100;
                            circularProgressBar2.Value = (int)CirVivodKB;
                            if (circularProgressBar2.Value <= (int)CirVivodKB)
                            {
                                timer1.Enabled = false;
                                label2.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar2.Value = 100;
                            }
                        }

                    }
                    else
                    {
                        circularProgressBar2.Value = 0;
                        label2.Text = "Cache/Cookes: " + "\n" + result1.ToString() + " KB";
                    }
                }
            }

            //end  Microsoft Edge
            #endregion
            #region Microsoft Edge History
            string EdgeHistory = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\History";
            try
            {
                if (File.Exists(EdgeHistory))
                {

                }
                else
                {
                    File.Create(EdgeHistory).Dispose();
                }

            }
            catch { }
            string EdgeHistoryjournal = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\History-journal";
            try
            {
                if (File.Exists(EdgeHistoryjournal))
                {

                }
                else
                {
                    File.Create(EdgeHistoryjournal).Dispose();
                }
            }
            catch { }
            long filesizeHistoryEdge = new FileInfo(EdgeHistory).Length;
            long filesize1HistoryEdge = new FileInfo(EdgeHistoryjournal).Length;

            int aHistoryEdge = Convert.ToInt32(filesizeHistoryEdge);
            int bHistoryEdge = Convert.ToInt32(filesize1HistoryEdge);

            long resultHistoryEdge = aHistoryEdge + bHistoryEdge;

            if (resultHistoryEdge >= 1073741824)
            {
                long resultGBHistoryEdge = resultHistoryEdge / 1073741824;
                if (resultGBHistoryEdge <= 10)
                {
                    long CirVivodGBHistoryEdge = resultGBHistoryEdge;
                    circularProgressBar3.Maximum = 100;
                    circularProgressBar3.Value = (int)CirVivodGBHistoryEdge;
                    if (circularProgressBar1.Value <= (int)CirVivodGBHistoryEdge)
                    {
                        timer1.Enabled = false;
                        label4.Text = "История: " + "\n" + resultGBHistoryEdge.ToString() + " MB";
                    }
                    else
                    {
                        circularProgressBar3.Value = 100;
                    }
                }
                else
                {
                    long CirVivodGBHistoryEdge = resultGBHistoryEdge / 10;
                    circularProgressBar3.Maximum = 100;
                    circularProgressBar3.Value = (int)CirVivodGBHistoryEdge;
                    if (circularProgressBar1.Value <= (int)CirVivodGBHistoryEdge)
                    {
                        timer1.Enabled = false;
                        label4.Text = "История: " + "\n" + resultGBHistoryEdge.ToString() + " MB";
                    }
                    else
                    {
                        circularProgressBar3.Value = 100;
                    }
                }
            }
            else
            {
                if (resultHistoryEdge >= 1048576)
                {
                    long resultMBHistoryEdge = resultHistoryEdge / 1048576;
                    if (resultMBHistoryEdge <= 10)
                    {
                        long CirVivodMBHistoryEdge = resultMBHistoryEdge;
                        circularProgressBar3.Maximum = 100;
                        circularProgressBar3.Value = (int)CirVivodMBHistoryEdge;
                        if (circularProgressBar1.Value <= (int)CirVivodMBHistoryEdge)
                        {
                            timer1.Enabled = false;
                            label4.Text = "История: " + "\n" + resultMBHistoryEdge.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar3.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodMBHistoryEdge = resultMBHistoryEdge / 10;
                        circularProgressBar3.Maximum = 100;
                        circularProgressBar3.Value = (int)CirVivodMBHistoryEdge;
                        if (circularProgressBar1.Value <= (int)CirVivodMBHistoryEdge)
                        {
                            timer1.Enabled = false;
                            label4.Text = "История: " + "\n" + resultMBHistoryEdge.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar3.Value = 100;
                        }
                    }
                }
                else
                {
                    if (resultHistoryEdge >= 1024)
                    {
                        long resultKBHistoryEdge = resultHistoryEdge / 1024;
                        if (resultKBHistoryEdge <= 10)
                        {
                            long CirVivodKBHistoryEdge = resultKBHistoryEdge;
                            circularProgressBar3.Maximum = 100;
                            circularProgressBar3.Value = (int)CirVivodKBHistoryEdge;
                            if (circularProgressBar1.Value <= (int)CirVivodKBHistoryEdge)
                            {
                                timer1.Enabled = false;
                                label4.Text = "История: " + "\n" + resultKBHistoryEdge.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar3.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodKBHistoryEdge = resultKBHistoryEdge / 10;
                            circularProgressBar3.Maximum = 100;
                            circularProgressBar3.Value = (int)CirVivodKBHistoryEdge;
                            if (circularProgressBar3.Value <= (int)CirVivodKBHistoryEdge)
                            {
                                timer1.Enabled = false;
                                label4.Text = "История: " + "\n" + resultKBHistoryEdge.ToString() + " KB";
                            }
                            else
                            {
                                circularProgressBar3.Value = 100;
                            }
                        }
                    }
                    else
                    {
                        circularProgressBar3.Value = 0;
                        label4.Text = "История: " + "\n" + resultHistoryEdge.ToString() + " KB";
                    }
                }
            }

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Эта функция автоматически закроет программы «Google Chrome» на вашем компьютере. Так же, очистит файлы Cache/Cookies в ранее упомянутом браузере. Если вы хотите продолжить, нажмите кнопку «ОК». Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            #region Закрытие процесса Google Chrome
            {
                string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
                string userName = Environment.UserName;
                try
                {
                    Process[] Path1 = Process.GetProcessesByName("chrome");
                    foreach (Process p in Path1)
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                        p.WaitForExit();
                        p.Dispose();
                    }


                    DirectoryInfo downloadedMessageInfoGoogleChrome = new DirectoryInfo(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");

                    try
                    {
                        foreach (FileInfo file2 in downloadedMessageInfoGoogleChrome.GetFiles())
                        {
                            file2.Delete();
                        }
                    }
                    catch { }

                    try
                    {
                        foreach (DirectoryInfo dir2 in downloadedMessageInfoGoogleChrome.GetDirectories())
                        {
                            dir2.Delete(true);
                        }
                    }
                    catch { }


                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string rootDrive1 = Path.GetPathRoot(Environment.SystemDirectory);
                string userName1 = Environment.UserName;
                string CookiesChrome = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
                string CookiesChromeDel = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies.txt";
                string CookiesChrome1 = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-journal";
                string CookiesChrome1Del = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-journal.txt";
                string ConversionsChrome = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Conversions";
                string ConversionsChromeDel = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Conversions.txt";
                string ConversionsjournalChrome = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Conversions-journal";
                string ConversionsjournalChromeDel = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Conversions-journal.txt";
                string LOGChrome = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\LOG";
                string LOGChromeDel = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\LOG.txt";
                try
                {
                    File.Move(CookiesChrome, Path.ChangeExtension(CookiesChrome, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(CookiesChrome1, Path.ChangeExtension(CookiesChrome1, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(ConversionsChrome, Path.ChangeExtension(ConversionsChrome, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(ConversionsjournalChrome, Path.ChangeExtension(ConversionsjournalChrome, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(LOGChrome, Path.ChangeExtension(LOGChrome, ".txt"));
                }
                catch { }


                try
                {
                    File.Delete(CookiesChromeDel);
                    File.Delete(CookiesChrome1Del);
                    File.Delete(ConversionsChromeDel);
                    File.Delete(ConversionsjournalChromeDel);
                    File.Delete(LOGChromeDel);
                }
                catch { }
                #endregion
            #region GoogleChrome Cache
                // GoogleChrome

                string GoogleCookies = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
                try
                {
                    if (File.Exists(GoogleCookies))
                    {

                    }
                    else
                    {
                        File.Create(GoogleCookies).Dispose();
                    }
                }
                catch { }
                string GoogleCookiesjournal = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-journal";
                try
                {
                    if (File.Exists(GoogleCookiesjournal))
                    {

                    }
                    else
                    {
                        File.Create(GoogleCookiesjournal).Dispose();
                    }
                }
                catch { }
                if (!(Directory.Exists(rootDrive1 + "Users\\" + userName1 + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache")))
                {
                    Directory.CreateDirectory(rootDrive1 + "Users\\" + userName1 + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
                }
                else
                {

                }
                DirectoryInfo dtInfo = new DirectoryInfo(rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\Cache");
                long totalsize = dtInfo.EnumerateFiles().Sum(file => file.Length);

                long filesize = new FileInfo(GoogleCookies).Length;
                long filesize1 = new FileInfo(GoogleCookiesjournal).Length;

                int a = Convert.ToInt32(filesize);
                int b = Convert.ToInt32(filesize1);
                int c = Convert.ToInt32(totalsize);
                int result = a + b + c;
                //GB
                if (result >= 1073741824)
                {
                    long resultBG = result / 1073741824;
                    if (resultBG <= 10)
                    {
                        long CirVivodGB = resultBG;
                        circularProgressBar1.Maximum = 100;
                        circularProgressBar1.Value = (int)CirVivodGB;
                        if (circularProgressBar1.Value <= (int)CirVivodGB)
                        {
                            timer1.Enabled = false;
                            label1.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                        }
                        else
                        {
                            circularProgressBar1.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodGB = resultBG / 10;
                        circularProgressBar1.Maximum = 100;
                        circularProgressBar1.Value = (int)CirVivodGB;
                        if (circularProgressBar1.Value <= (int)CirVivodGB)
                        {
                            timer1.Enabled = false;
                            label1.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                        }
                        else
                        {
                            circularProgressBar1.Value = 100;
                        }
                    }

                    //MB
                }
                else
                {
                    if (result >= 1048576)
                    {
                        long resultMB = result / 1048576;
                        if (resultMB <= 10)
                        {
                            long CirVivodMB = resultMB;
                            circularProgressBar1.Maximum = 100;
                            circularProgressBar1.Value = (int)CirVivodMB;
                            if (circularProgressBar1.Value <= (int)CirVivodMB)
                            {
                                timer1.Enabled = false;
                                label1.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar1.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodMB = resultMB / 10;
                            circularProgressBar1.Maximum = 100;
                            circularProgressBar1.Value = (int)CirVivodMB;
                            if (circularProgressBar1.Value <= (int)CirVivodMB)
                            {
                                timer1.Enabled = false;
                                label1.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar1.Value = 100;
                            }
                        }


                    }
                    else
                    {
                        if (result >= 1024)
                        {
                            long resultKB = result / 1024;
                            if (resultKB <= 10)
                            {
                                long CirVivodKB = resultKB;
                                circularProgressBar1.Maximum = 100;
                                circularProgressBar1.Value = (int)CirVivodKB;
                                if (circularProgressBar1.Value <= (int)CirVivodKB)
                                {
                                    timer1.Enabled = false;
                                    label1.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar1.Value = 100;
                                }
                            }
                            else
                            {
                                long CirVivodKB = resultKB / 10;
                                circularProgressBar1.Maximum = 100;
                                circularProgressBar1.Value = (int)CirVivodKB;
                                if (circularProgressBar1.Value <= (int)CirVivodKB)
                                {
                                    timer1.Enabled = false;
                                    label1.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar1.Value = 100;
                                }
                            }

                        }
                        else
                        {
                            circularProgressBar1.Value = 0;
                            label1.Text = "Cache/Cookes: " + "\n" + result.ToString() + " KB";
                        }
                    }
                }


                // end GoogleChrome
                #endregion

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Эта функция автоматически закроет программы «Google Chrome» на вашем компьютере. Так же, очистит файлы Cache/Cookies в ранее упомянутом браузере. Если вы хотите продолжить, нажмите кнопку «ОК». Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            {
                #region Google Chrome Del History
                try
                {
                    Process[] Path1 = Process.GetProcessesByName("chrome");
                    foreach (Process p in Path1)
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                        p.WaitForExit();
                        p.Dispose();
                    }
                }
                catch { }


                string rootDrive1 = Path.GetPathRoot(Environment.SystemDirectory);
                string userName1 = Environment.UserName;
                string CookiesChrome = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History";
                string CookiesChromeDel = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History.txt";
                string CookiesChrome1 = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History-journal";
                string CookiesChrome1Del = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History-journal.txt";
                try
                {
                    File.Move(CookiesChrome, Path.ChangeExtension(CookiesChrome, ".txt"));
                }
                catch { }
                try
                {
                    File.Move(CookiesChrome1, Path.ChangeExtension(CookiesChrome1, ".txt"));
                }
                catch { }

                try
                {
                    File.Delete(CookiesChromeDel);
                    File.Delete(CookiesChrome1Del);
                }
                catch (IOException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                #endregion
                #region GoogleChrome History
                string GoogleHistory = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History";
                try
                {
                    if (File.Exists(GoogleHistory))
                    {

                    }
                    else
                    {
                        File.Create(GoogleHistory).Dispose();
                    }
                }
                catch { }
                string GoogleHistoryjournal = rootDrive1 + "Users\\" + userName1 + @"\AppData\Local\Google\Chrome\User Data\Default\History-journal";
                try
                {
                    if (File.Exists(GoogleHistoryjournal))
                    {

                    }
                    else
                    {
                        File.Create(GoogleHistoryjournal).Dispose();
                    }
                }
                catch { }
                long filesizeHistory = new FileInfo(GoogleHistory).Length;
                long filesize1History = new FileInfo(GoogleHistoryjournal).Length;

                int aHistory = Convert.ToInt32(filesizeHistory);
                int bHistory = Convert.ToInt32(filesizeHistory);

                long resultHistory = aHistory + bHistory;

                if (resultHistory >= 1073741824)
                {
                    long resultGBHistory = resultHistory / 1048576;
                    if (resultGBHistory <= 10)
                    {
                        long CirVivodGBHistory = resultGBHistory;
                        circularProgressBar4.Maximum = 100;
                        circularProgressBar4.Value = (int)CirVivodGBHistory;
                        if (circularProgressBar4.Value <= (int)CirVivodGBHistory)
                        {
                            timer1.Enabled = false;
                            label3.Text = "История: " + "\n" + resultGBHistory.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar4.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodGBHistory = resultGBHistory / 10;
                        circularProgressBar4.Maximum = 100;
                        circularProgressBar4.Value = (int)CirVivodGBHistory;
                        if (circularProgressBar4.Value <= (int)CirVivodGBHistory)
                        {
                            timer1.Enabled = false;
                            label3.Text = "История: " + "\n" + resultGBHistory.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar4.Value = 100;
                        }
                    }
                }
                else
                {
                    if (resultHistory >= 1048576)
                    {
                        long resultMBHistory = resultHistory / 1048576;
                        if (resultMBHistory <= 10)
                        {
                            long CirVivodMBHistory = resultMBHistory;
                            circularProgressBar4.Maximum = 100;
                            circularProgressBar4.Value = (int)CirVivodMBHistory;
                            if (circularProgressBar4.Value <= (int)CirVivodMBHistory)
                            {
                                timer1.Enabled = false;
                                label3.Text = "История: " + "\n" + resultMBHistory.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar4.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodMBHistory = resultMBHistory / 10;
                            circularProgressBar4.Maximum = 100;
                            circularProgressBar4.Value = (int)CirVivodMBHistory;
                            if (circularProgressBar4.Value <= (int)CirVivodMBHistory)
                            {
                                timer1.Enabled = false;
                                label3.Text = "История: " + "\n" + resultMBHistory.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar4.Value = 100;
                            }
                        }
                    }
                    else
                    {
                        if (resultHistory >= 1024)
                        {
                            long resultKBHistory = resultHistory / 1024;
                            if (resultKBHistory <= 10)
                            {
                                long CirVivodKBHistory = resultKBHistory;
                                circularProgressBar4.Maximum = 100;
                                circularProgressBar4.Value = (int)CirVivodKBHistory;
                                if (circularProgressBar4.Value <= (int)CirVivodKBHistory)
                                {
                                    timer1.Enabled = false;
                                    label3.Text = "История: " + "\n" + resultKBHistory.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar4.Value = 100;
                                }
                            }
                            else
                            {
                                long CirVivodKBHistory = resultKBHistory / 10;
                                circularProgressBar4.Maximum = 100;
                                circularProgressBar4.Value = (int)CirVivodKBHistory;
                                if (circularProgressBar4.Value <= (int)CirVivodKBHistory)
                                {
                                    timer1.Enabled = false;
                                    label3.Text = "История: " + "\n" + resultKBHistory.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar4.Value = 100;
                                }
                            }

                        }
                        else
                        {
                            circularProgressBar4.Value = 0;
                            label3.Text = "История: " + "\n" + resultHistory.ToString() + " KB";
                        }
                    }
                }






                #endregion
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Эта функция автоматически закроет программы «Mircosoft Edge» на вашем компьютере. Так же, очистит файлы Cache/Cookies в ранее упомянутом браузере. Если вы хотите продолжить, нажмите кнопку «ОК». Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            #region Закрытие процесса Microsoft Edge
            {

                try
                {
                    string rootDrive2 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userName2 = Environment.UserName;

                    Process[] MicrosoftEdgeClose = Process.GetProcessesByName("msedge");
                    foreach (Process CloseMSED in MicrosoftEdgeClose)
                    {
                        try
                        {
                            CloseMSED.Kill();
                            CloseMSED.WaitForExit(3000);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    DirectoryInfo MicrosoftEdgeDelete = new DirectoryInfo(rootDrive2 + "Users\\" + userName2 + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache");

                    try
                    {
                        foreach (FileInfo file1 in MicrosoftEdgeDelete.GetFiles())
                        {
                            file1.Delete();
                        }
                    }
                    catch { }

                    try
                    {
                        foreach (DirectoryInfo dir1 in MicrosoftEdgeDelete.GetDirectories())
                        {
                            dir1.Delete(true);
                        }
                    }
                    catch { }
                }
                catch (IOException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }

                string rootDrive3 = Path.GetPathRoot(Environment.SystemDirectory);
                string userName3 = Environment.UserName;
                string CookiesEdge = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies";
                string CookiesEdgeDel = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies.txt";
                string CookiesEdge1 = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies-journal";
                string CookiesEdge1Del = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies-journal.txt";
                string ConversionsEdge = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Conversions";
                string ConversionsEdgeDel = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Conversions.txt";
                string ConversionsjournalEdge = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Conversions-journal";
                string ConversionsjournalEdgeDel = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\Conversions-journal.txt";
                string LOGEdge = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\LOG";
                string LOGEdgeDel = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\LOG.txt";
                try
                {
                    File.Move(CookiesEdge, Path.ChangeExtension(CookiesEdge, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(CookiesEdge1, Path.ChangeExtension(CookiesEdge1, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(ConversionsEdge, Path.ChangeExtension(ConversionsEdge, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(ConversionsjournalEdge, Path.ChangeExtension(ConversionsjournalEdge, ".txt"));
                }
                catch { }

                try
                {
                    File.Move(LOGEdge, Path.ChangeExtension(LOGEdge, ".txt"));
                }
                catch { }


                try
                {
                    File.Delete(CookiesEdgeDel);
                    File.Delete(CookiesEdge1Del);
                    File.Delete(ConversionsEdgeDel);
                    File.Delete(ConversionsjournalEdgeDel);
                    File.Delete(LOGEdgeDel);
                }
                catch { }
                #endregion
            #region Microsoft Edge Cache
                // Microsoft Edge

                string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
                string userName = Environment.UserName;
                string EdgeCookies = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies";
                try
                {
                    if (File.Exists(EdgeCookies))
                    {

                    }
                    else
                    {
                        File.Create(EdgeCookies).Dispose();
                    }
                }
                catch { }
                string EdgeCookiesjournal = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cookies-journal";
                try
                {
                    if (File.Exists(EdgeCookiesjournal))
                    {

                    }
                    else
                    {
                        File.Create(EdgeCookiesjournal).Dispose();
                    }
                }
                catch { }

                if (!(Directory.Exists(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache")))
                {
                    Directory.CreateDirectory(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache");
                }
                else
                {

                }
                DirectoryInfo dtInfo1 = new DirectoryInfo(rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\Cache");

                long totalsize1 = dtInfo1.EnumerateFiles().Sum(file => file.Length);

                long filesize2 = new FileInfo(EdgeCookies).Length;
                long filesize11 = new FileInfo(EdgeCookiesjournal).Length;

                int a1 = Convert.ToInt32(filesize2);
                int b1 = Convert.ToInt32(filesize11);
                int c1 = Convert.ToInt32(totalsize1);
                int result1 = a1 + b1 + c1;
                //GB
                if (result1 >= 1073741824)
                {
                    long resultBG = result1 / 1073741824;
                    if (resultBG <= 10)
                    {
                        long CirVivodGB = resultBG;
                        circularProgressBar2.Maximum = 100;
                        circularProgressBar2.Value = (int)CirVivodGB;
                        if (circularProgressBar2.Value <= (int)CirVivodGB)
                        {
                            timer1.Enabled = false;
                            label2.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                        }
                        else
                        {
                            circularProgressBar2.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodGB = resultBG / 10;
                        circularProgressBar2.Maximum = 100;
                        circularProgressBar2.Value = (int)CirVivodGB;
                        if (circularProgressBar2.Value <= (int)CirVivodGB)
                        {
                            timer1.Enabled = false;
                            label2.Text = "Cache/Cookes: " + "\n" + resultBG.ToString() + " GB";
                        }
                        else
                        {
                            circularProgressBar2.Value = 100;
                        }
                    }

                    //MB
                }
                else
                {
                    if (result1 >= 1048576)
                    {
                        long resultMB = result1 / 1048576;
                        if (resultMB <= 10)
                        {
                            long CirVivodMB = resultMB;
                            circularProgressBar2.Maximum = 100;
                            circularProgressBar2.Value = (int)CirVivodMB;
                            if (circularProgressBar2.Value <= (int)CirVivodMB)
                            {
                                timer1.Enabled = false;
                                label2.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar2.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodMB = resultMB / 10;
                            circularProgressBar2.Maximum = 100;
                            circularProgressBar2.Value = (int)CirVivodMB;
                            if (circularProgressBar2.Value <= (int)CirVivodMB)
                            {
                                timer1.Enabled = false;
                                label2.Text = "Cache/Cookes: " + "\n" + resultMB.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar2.Value = 100;
                            }
                        }



                    }
                    else
                    {
                        if (result1 >= 1024)
                        {
                            long resultKB = result1 / 1024;
                            if (resultKB <= 10)
                            {
                                long CirVivodKB = resultKB;
                                circularProgressBar2.Maximum = 100;
                                circularProgressBar2.Value = (int)CirVivodKB;
                                if (circularProgressBar2.Value <= (int)CirVivodKB)
                                {
                                    timer1.Enabled = false;
                                    label2.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar2.Value = 100;
                                }
                            }
                            else
                            {
                                long CirVivodKB = resultKB / 10;
                                circularProgressBar2.Maximum = 100;
                                circularProgressBar2.Value = (int)CirVivodKB;
                                if (circularProgressBar2.Value <= (int)CirVivodKB)
                                {
                                    timer1.Enabled = false;
                                    label2.Text = "Cache/Cookes: " + "\n" + resultKB.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar2.Value = 100;
                                }
                            }

                        }
                        else
                        {
                            circularProgressBar2.Value = 0;
                            label2.Text = "Cache/Cookes: " + "\n" + result1.ToString() + " KB";
                        }
                    }
                }

                //end  Microsoft Edge
                #endregion

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Эта функция автоматически закроет программы «Mircosoft Edge» на вашем компьютере. Так же, очистит файлы истории в ранее упомянутом браузере. Если вы хотите продолжить, нажмите кнопку «ОК». Если вы хотите сохранить данные и сделать это позже, нажмите кнопку «Cancel». ", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {

            }
            else
            {
                #region Microsoft Edge Del History
                //edge 
                try
                {
                    string rootDrive2 = Path.GetPathRoot(Environment.SystemDirectory);
                    string userName2 = Environment.UserName;

                    Process[] MicrosoftEdgeClose = Process.GetProcessesByName("msedge");
                    foreach (Process CloseMSED in MicrosoftEdgeClose)
                    {
                        try
                        {
                            CloseMSED.Kill();
                            CloseMSED.WaitForExit(3000);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (IOException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }

                string rootDrive3 = Path.GetPathRoot(Environment.SystemDirectory);
                string userName3 = Environment.UserName;
                string HistoryEdge = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\History";
                string HistoryEdgeDel = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\History.txt";
                string HistoryEdge1 = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\History-journal";
                string HistoryEdge1Del = rootDrive3 + "Users\\" + userName3 + @"\AppData\Local\Microsoft\Edge\User Data\Default\History-journal.txt";

                try
                {
                    File.Move(HistoryEdge, Path.ChangeExtension(HistoryEdge, ".txt"));
                }
                catch { }
                try
                {
                    File.Move(HistoryEdge1, Path.ChangeExtension(HistoryEdge1, ".txt"));
                }
                catch { }

                try
                {
                    File.Delete(HistoryEdgeDel);
                    File.Delete(HistoryEdge1Del);
                }
                catch (IOException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }

                #endregion
                #region Microsoft Edge History
                string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
                string userName = Environment.UserName;
                string EdgeHistory = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\History";
                try
                {
                    if (File.Exists(EdgeHistory))
                    {

                    }
                    else
                    {
                        File.Create(EdgeHistory).Dispose();
                    }

                }
                catch { }
                string EdgeHistoryjournal = rootDrive + "Users\\" + userName + @"\AppData\Local\Microsoft\Edge\User Data\Default\History-journal";
                try
                {
                    if (File.Exists(EdgeHistoryjournal))
                    {

                    }
                    else
                    {
                        File.Create(EdgeHistoryjournal).Dispose();
                    }
                }
                catch { }
                long filesizeHistoryEdge = new FileInfo(EdgeHistory).Length;
                long filesize1HistoryEdge = new FileInfo(EdgeHistoryjournal).Length;

                int aHistoryEdge = Convert.ToInt32(filesizeHistoryEdge);
                int bHistoryEdge = Convert.ToInt32(filesize1HistoryEdge);

                long resultHistoryEdge = aHistoryEdge + bHistoryEdge;

                if (resultHistoryEdge >= 1073741824)
                {
                    long resultGBHistoryEdge = resultHistoryEdge / 1073741824;
                    if (resultGBHistoryEdge <= 10)
                    {
                        long CirVivodGBHistoryEdge = resultGBHistoryEdge;
                        circularProgressBar3.Maximum = 100;
                        circularProgressBar3.Value = (int)CirVivodGBHistoryEdge;
                        if (circularProgressBar1.Value <= (int)CirVivodGBHistoryEdge)
                        {
                            timer1.Enabled = false;
                            label4.Text = "История: " + "\n" + resultGBHistoryEdge.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar3.Value = 100;
                        }
                    }
                    else
                    {
                        long CirVivodGBHistoryEdge = resultGBHistoryEdge / 10;
                        circularProgressBar3.Maximum = 100;
                        circularProgressBar3.Value = (int)CirVivodGBHistoryEdge;
                        if (circularProgressBar1.Value <= (int)CirVivodGBHistoryEdge)
                        {
                            timer1.Enabled = false;
                            label4.Text = "История: " + "\n" + resultGBHistoryEdge.ToString() + " MB";
                        }
                        else
                        {
                            circularProgressBar3.Value = 100;
                        }
                    }
                }
                else
                {
                    if (resultHistoryEdge >= 1048576)
                    {
                        long resultMBHistoryEdge = resultHistoryEdge / 1048576;
                        if (resultMBHistoryEdge <= 10)
                        {
                            long CirVivodMBHistoryEdge = resultMBHistoryEdge;
                            circularProgressBar3.Maximum = 100;
                            circularProgressBar3.Value = (int)CirVivodMBHistoryEdge;
                            if (circularProgressBar1.Value <= (int)CirVivodMBHistoryEdge)
                            {
                                timer1.Enabled = false;
                                label4.Text = "История: " + "\n" + resultMBHistoryEdge.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar3.Value = 100;
                            }
                        }
                        else
                        {
                            long CirVivodMBHistoryEdge = resultMBHistoryEdge / 10;
                            circularProgressBar3.Maximum = 100;
                            circularProgressBar3.Value = (int)CirVivodMBHistoryEdge;
                            if (circularProgressBar1.Value <= (int)CirVivodMBHistoryEdge)
                            {
                                timer1.Enabled = false;
                                label4.Text = "История: " + "\n" + resultMBHistoryEdge.ToString() + " MB";
                            }
                            else
                            {
                                circularProgressBar3.Value = 100;
                            }
                        }
                    }
                    else
                    {
                        if (resultHistoryEdge >= 1024)
                        {
                            long resultKBHistoryEdge = resultHistoryEdge / 1024;
                            if (resultKBHistoryEdge <= 10)
                            {
                                long CirVivodKBHistoryEdge = resultKBHistoryEdge;
                                circularProgressBar3.Maximum = 100;
                                circularProgressBar3.Value = (int)CirVivodKBHistoryEdge;
                                if (circularProgressBar1.Value <= (int)CirVivodKBHistoryEdge)
                                {
                                    timer1.Enabled = false;
                                    label4.Text = "История: " + "\n" + resultKBHistoryEdge.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar3.Value = 100;
                                }
                            }
                            else
                            {
                                long CirVivodKBHistoryEdge = resultKBHistoryEdge / 10;
                                circularProgressBar3.Maximum = 100;
                                circularProgressBar3.Value = (int)CirVivodKBHistoryEdge;
                                if (circularProgressBar3.Value <= (int)CirVivodKBHistoryEdge)
                                {
                                    timer1.Enabled = false;
                                    label4.Text = "История: " + "\n" + resultKBHistoryEdge.ToString() + " KB";
                                }
                                else
                                {
                                    circularProgressBar3.Value = 100;
                                }
                            }
                        }
                        else
                        {
                            circularProgressBar3.Value = 0;
                            label4.Text = "История: " + "\n" + resultHistoryEdge.ToString() + " KB";
                        }
                    }
                }

                #endregion
            }
        }
    }
}
