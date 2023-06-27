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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Net;
using System.Net.NetworkInformation;

namespace SST_Icon.Forms
{
    public partial class HelpYourPC : Form
    {

        private bool isCollapsedSSTNavigationDropBox;

        public HelpYourPC()
        {
            InitializeComponent();
            Parallel.Invoke(() => OpenPreloader());



        }

        private void OpenPreloader()
        {
            timer3.Enabled = true;
            timer3.Start();
            timer3.Interval = 1000;
            progressBar1.Maximum = 10;
        }

        private void OpenHelpYourPC()
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            circularProgressBar1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;
            #region Floating text
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.button3, "Данная функция работает при двойном нажатии ЛКМ");
            toolTip1.SetToolTip(this.button4, "Данная функция работает при двойном нажатии ЛКМ");

            #endregion

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string userName = Environment.UserName;

            Task.Run(() => CheckAccesskisk());
            Task.Run(() => CheckAccessPrint());
            


            #region AccessDisk
            Thread.Sleep(1000);
            try
            {
                string PutFileNameusenetKol = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\usenetfilekoll.txt";
                //Thread.Sleep(1500);
                TextReader trKoll = new StreamReader(PutFileNameusenetKol);
                int NumberOfLinesKoll = 15;
                string[] ListLinesKoll = new string[NumberOfLinesKoll];
                for (int i = 1; i < NumberOfLinesKoll; i++)
                {
                    ListLinesKoll[i] = trKoll.ReadLine();
                }

                if (ListLinesKoll[3] == "There are no entries in the list.")
                {
                    label1.Text = "Мы не обнаружили подключенные сетевые диски";
                }
                else
                {
                    if (ListLinesKoll[8] == "The command completed successfully.")
                    {
                        label1.Text = "На вашем ПК подключен 1 сетевой диск";
                    }
                    else
                    {
                        if (ListLinesKoll[9] == "The command completed successfully.")
                        {
                            label1.Text = "На вашем ПК подключено 2 сетевых диска";
                        }
                        else
                        {
                            if (ListLinesKoll[10] == "The command completed successfully.")
                            {

                                label1.Text = "На вашем ПК подключено 3 сетевых диска";

                            }
                            else
                            {
                                if (ListLinesKoll[11] == "The command completed successfully.")
                                {
                                    label1.Text = "На вашем ПК подключено 4 сетевых диска";
                                }
                                else
                                {
                                    if (ListLinesKoll[12] == "The command completed successfully.")
                                    {
                                        label1.Text = "На вашем ПК подключено 5 сетевых дисков";
                                    }
                                    else
                                    {
                                        if (ListLinesKoll[13] == "The command completed successfully.")
                                        {
                                            label1.Text = "На вашем ПК подключено 6 сетевых дисков";
                                        }
                                        else
                                        {
                                            if (ListLinesKoll[14] == "The command completed successfully.")
                                            {
                                                label1.Text = "На вашем ПК подключено 7 сетевых дисков";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                trKoll.Close();
                Thread.Sleep(1000);



                Thread.Sleep(1000);

                string CleannetusefileKoll = PutFileNameusenetKol;

                if (File.Exists(CleannetusefileKoll))
                {
                    File.Delete(CleannetusefileKoll);
                }
            }
            catch { }

            Thread.Sleep(1000);
            try
            {
                string PutFileNameusenet = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\usenetfile.txt";
                //Thread.Sleep(1500);
                TextReader tr = new StreamReader(PutFileNameusenet);
                int NumberOfLines = 15;
                string[] ListLines = new string[NumberOfLines];
                for (int i = 1; i < NumberOfLines; i++)
                {
                    ListLines[i] = tr.ReadLine();
                }

                if (ListLines[2] == "\0")
                {
                    richTextBox1.Text = "Мы не обнаружили подключенные сетевые диски";
                }
                else
                {
                    richTextBox1.Text = "Подключены сетевые диски:" + "\n" + ListLines[2] + "\n" + ListLines[3] + "\n" + ListLines[4] + "\n" + ListLines[5] + "\n" + ListLines[6] + "\n" + ListLines[7] + "\n" + ListLines[8] + "\n" + ListLines[9] + "\n" + ListLines[10];
                }


                tr.Close();
                Thread.Sleep(1000);

                //Thread.Sleep(1000);

                string Cleannetusefile = PutFileNameusenet;

                if (File.Exists(Cleannetusefile))
                {
                    File.Delete(Cleannetusefile);
                }
            }
            catch { }

            #endregion
            #region AccessPrint
            Thread.Sleep(1000);
            try
            {


                var textKoll = "EndTextPrint";
                using (var writerKoll = new StreamWriter(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFileSmotKoll.txt", true))
                {
                    writerKoll.WriteLine(textKoll);
                }

                Thread.Sleep(1000);
                try
                {
                    string PutFileNamePrintChten1Koll = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFileSmotKoll.txt";
                    TextReader tr1PrintKoll = new StreamReader(PutFileNamePrintChten1Koll);
                    int NumberOfLines1Koll = 50;
                    string[] ListLines1koll = new string[NumberOfLines1Koll];
                    for (int i = 1; i < NumberOfLines1Koll; i++)
                    {
                        ListLines1koll[i] = tr1PrintKoll.ReadLine();
                    }

                    string proverka = "湅呤硥側楲瑮਍";
                    string proverka2 = "Microsoft Shared Fax Driver          Fax                            ";


                    /// Если подключенно 3 принтеров локально на ПК
                    if (ListLines1koll[3] == proverka2)
                        if (ListLines1koll[9] == proverka)
                        {
                            label2.Text = "На вашем ПК подключено 5 сетевых принтеров";
                        }
                        else
                        {
                            if (ListLines1koll[3] == proverka2)
                                if (ListLines1koll[8] == proverka)
                                {
                                    label2.Text = "На вашем ПК подключено 4 сетевых принтера";
                                }
                                else
                                {
                                    if (ListLines1koll[3] == proverka2)
                                        if (ListLines1koll[7] == proverka)
                                        {
                                            label2.Text = "На вашем ПК подключено 3 сетевых принтера";
                                        }
                                        else
                                        {
                                            if (ListLines1koll[3] == proverka2)
                                                if (ListLines1koll[6] == proverka)
                                                {
                                                    label2.Text = "На вашем ПК подключено 2 сетевых принтера";
                                                }
                                                else
                                                {
                                                    if (ListLines1koll[3] == proverka2)
                                                        if (ListLines1koll[5] == proverka)
                                                        {
                                                            label2.Text = "На вашем ПК подключен 1 сетевой принтер";
                                                        }
                                                        else
                                                        {
                                                            if (ListLines1koll[3] == proverka2)
                                                                if (ListLines1koll[4] == proverka)
                                                                {
                                                                    label2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }

                    /// Если подключенно 4 принтеров локально на ПК
                    if (ListLines1koll[4] == proverka2)
                        if (ListLines1koll[10] == proverka)
                        {
                            label2.Text = "На вашем ПК подключено 5 сетевых принтеров";
                        }
                        else
                        {
                            if (ListLines1koll[4] == proverka2)
                                if (ListLines1koll[9] == proverka)
                                {
                                    label2.Text = "На вашем ПК подключено 4 сетевых принтера";
                                }
                                else
                                {
                                    if (ListLines1koll[4] == proverka2)
                                        if (ListLines1koll[8] == proverka)
                                        {
                                            label2.Text = "На вашем ПК подключено 3 сетевых принтера";
                                        }
                                        else
                                        {
                                            if (ListLines1koll[4] == proverka2)
                                                if (ListLines1koll[7] == proverka)
                                                {
                                                    label2.Text = "На вашем ПК подключено 2 сетевых принтера";
                                                }
                                                else
                                                {
                                                    if (ListLines1koll[4] == proverka2)
                                                        if (ListLines1koll[6] == proverka)
                                                        {
                                                            label2.Text = "На вашем ПК подключен 1 сетевой принтер";
                                                        }
                                                        else
                                                        {
                                                            if (ListLines1koll[4] == proverka2)
                                                                if (ListLines1koll[5] == proverka)
                                                                {
                                                                    label2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }

                    /// Если подключенно 5 принтеров локально на ПК

                    if (ListLines1koll[5] == proverka2)
                        if (ListLines1koll[11] == proverka)
                        {
                            label2.Text = "На вашем ПК подключено 5 сетевых принтеров";
                        }
                        else
                        {
                            if (ListLines1koll[5] == proverka2)
                                if (ListLines1koll[10] == proverka)
                                {
                                    label2.Text = "На вашем ПК подключено 4 сетевых принтера";
                                }
                                else
                                {
                                    if (ListLines1koll[5] == proverka2)
                                        if (ListLines1koll[9] == proverka)
                                        {
                                            label2.Text = "На вашем ПК подключено 3 сетевых принтера";
                                        }
                                        else
                                        {
                                            if (ListLines1koll[5] == proverka2)
                                                if (ListLines1koll[8] == proverka)
                                                {
                                                    label2.Text = "На вашем ПК подключено 2 сетевых принтера";
                                                }
                                                else
                                                {
                                                    if (ListLines1koll[5] == proverka2)
                                                        if (ListLines1koll[7] == proverka)
                                                        {
                                                            label2.Text = "На вашем ПК подключен 1 сетевой принтер";
                                                        }
                                                        else
                                                        {
                                                            if (ListLines1koll[5] == proverka2)
                                                                if (ListLines1koll[6] == proverka)
                                                                {
                                                                    label2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }


                    /// Если подключенно 6 принтеров локально на ПК

                    if (ListLines1koll[6] == proverka2)
                        if (ListLines1koll[12] == proverka)
                        {
                            label2.Text = "На вашем ПК подключено 5 сетевых принтеров";
                        }
                        else
                        {
                            if (ListLines1koll[6] == proverka2)
                                if (ListLines1koll[11] == proverka)
                                {
                                    label2.Text = "На вашем ПК подключено 4 сетевых принтера";
                                }
                                else
                                {
                                    if (ListLines1koll[6] == proverka2)
                                        if (ListLines1koll[10] == proverka)
                                        {
                                            label2.Text = "На вашем ПК подключено 3 сетевых принтера";
                                        }
                                        else
                                        {
                                            if (ListLines1koll[6] == proverka2)
                                                if (ListLines1koll[9] == proverka)
                                                {
                                                    label2.Text = "На вашем ПК подключено 2 сетевых принтера";
                                                }
                                                else
                                                {
                                                    if (ListLines1koll[6] == proverka2)
                                                        if (ListLines1koll[8] == proverka)
                                                        {
                                                            label2.Text = "На вашем ПК подключен 1 сетевой принтер";
                                                        }
                                                        else
                                                        {
                                                            if (ListLines1koll[6] == proverka2)
                                                                if (ListLines1koll[7] == proverka)
                                                                {
                                                                    label2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }

                    Thread.Sleep(1000);
                    tr1PrintKoll.Close();


                    string CleannetusefileKollPrint = PutFileNamePrintChten1Koll;

                    if (File.Exists(CleannetusefileKollPrint))
                    {
                        File.Delete(CleannetusefileKollPrint);
                    }
                }
                catch { }

            }
            catch { }

            Thread.Sleep(1000);
            var textPrint = "EndTextPrint";
            using (var writerPrint = new StreamWriter(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFile.txt", true))
            {
                writerPrint.WriteLine(textPrint);
            }


            Thread.Sleep(1000);
            try
            {
                string PutFileNamePrintChten1 = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFile.txt";
                TextReader tr1 = new StreamReader(PutFileNamePrintChten1);
                int NumberOfLines1 = 50;
                string[] ListLines1 = new string[NumberOfLines1];
                for (int i = 1; i < NumberOfLines1; i++)
                {
                    ListLines1[i] = tr1.ReadLine();
                }

                string proverkaPrint = "湅呤硥側楲瑮਍";
                string proverka2Print = "Microsoft Shared Fax Driver          Fax                            ";

                if (ListLines1[3] == proverka2Print)
                    if (ListLines1[9] == proverkaPrint)
                    {
                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[4] + "\n" + ListLines1[5] + "\n" + ListLines1[6] + "\n" + ListLines1[7] + "\n" + ListLines1[8];
                    }
                    else
                    {
                        if (ListLines1[3] == proverka2Print)
                            if (ListLines1[8] == proverkaPrint)
                            {
                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[4] + "\n" + ListLines1[5] + "\n" + ListLines1[6] + "\n" + ListLines1[7];
                            }
                            else
                            {
                                if (ListLines1[3] == proverka2Print)
                                    if (ListLines1[7] == proverkaPrint)
                                    {
                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[4] + "\n" + ListLines1[5] + "\n" + ListLines1[6];
                                    }
                                    else
                                    {
                                        if (ListLines1[3] == proverka2Print)
                                            if (ListLines1[6] == proverkaPrint)
                                            {
                                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[4] + "\n" + ListLines1[5];
                                            }
                                            else
                                            {
                                                if (ListLines1[3] == proverka2Print)
                                                    if (ListLines1[5] == proverkaPrint)
                                                    {
                                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[4];
                                                    }
                                                    else
                                                    {
                                                        if (ListLines1[3] == proverka2Print)
                                                            if (ListLines1[4] == proverkaPrint)
                                                            {
                                                                richTextBox2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }

                /// Если подключенно 4 принтеров локально на ПК
                if (ListLines1[4] == proverka2Print)
                    if (ListLines1[10] == proverkaPrint)
                    {
                        label1.Text = "На вашем ПК подключено 5 сетевых принтеров";
                    }
                    else
                    {
                        if (ListLines1[4] == proverka2Print)
                            if (ListLines1[9] == proverkaPrint)
                            {
                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[5] + "\n" + ListLines1[6] + "\n" + ListLines1[7] + "\n" + ListLines1[8];
                            }
                            else
                            {
                                if (ListLines1[4] == proverka2Print)
                                    if (ListLines1[8] == proverkaPrint)
                                    {
                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[5] + "\n" + ListLines1[6] + "\n" + ListLines1[7];
                                    }
                                    else
                                    {
                                        if (ListLines1[4] == proverka2Print)
                                            if (ListLines1[7] == proverkaPrint)
                                            {
                                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[5] + "\n" + ListLines1[6];
                                            }
                                            else
                                            {
                                                if (ListLines1[4] == proverka2Print)
                                                    if (ListLines1[6] == proverkaPrint)
                                                    {
                                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[5];
                                                    }
                                                    else
                                                    {
                                                        if (ListLines1[4] == proverka2Print)
                                                            if (ListLines1[5] == proverkaPrint)
                                                            {
                                                                richTextBox2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }

                /// Если подключенно 5 принтеров локально на ПК

                if (ListLines1[5] == proverka2Print)
                    if (ListLines1[11] == proverkaPrint)
                    {
                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[6] + "\n" + ListLines1[7] + "\n" + ListLines1[8] + "\n" + ListLines1[9] + "\n" + ListLines1[10];
                    }
                    else
                    {
                        if (ListLines1[5] == proverka2Print)
                            if (ListLines1[10] == proverkaPrint)
                            {
                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[6] + "\n" + ListLines1[7] + "\n" + ListLines1[8] + "\n" + ListLines1[9];
                            }
                            else
                            {
                                if (ListLines1[5] == proverka2Print)
                                    if (ListLines1[9] == proverkaPrint)
                                    {
                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[6] + "\n" + ListLines1[7] + "\n" + ListLines1[8];
                                    }
                                    else
                                    {
                                        if (ListLines1[5] == proverka2Print)
                                            if (ListLines1[8] == proverkaPrint)
                                            {
                                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[6] + "\n" + ListLines1[7];
                                            }
                                            else
                                            {
                                                if (ListLines1[5] == proverka2Print)
                                                    if (ListLines1[7] == proverkaPrint)
                                                    {
                                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[6];
                                                    }
                                                    else
                                                    {
                                                        if (ListLines1[5] == proverka2Print)
                                                            if (ListLines1[6] == proverkaPrint)
                                                            {
                                                                richTextBox2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }


                /// Если подключенно 6 принтеров локально на ПК

                if (ListLines1[6] == proverka2Print)
                    if (ListLines1[12] == proverkaPrint)
                    {
                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[7] + "\n" + ListLines1[8] + "\n" + ListLines1[9] + "\n" + ListLines1[10] + "\n" + ListLines1[11];
                    }
                    else
                    {
                        if (ListLines1[6] == proverka2Print)
                            if (ListLines1[11] == proverkaPrint)
                            {
                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[7] + "\n" + ListLines1[8] + "\n" + ListLines1[9] + "\n" + ListLines1[10];
                            }
                            else
                            {
                                if (ListLines1[6] == proverka2Print)
                                    if (ListLines1[10] == proverkaPrint)
                                    {
                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[7] + "\n" + ListLines1[8] + "\n" + ListLines1[9];
                                    }
                                    else
                                    {
                                        if (ListLines1[6] == proverka2Print)
                                            if (ListLines1[9] == proverkaPrint)
                                            {
                                                richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[7] + "\n" + ListLines1[8];
                                            }
                                            else
                                            {
                                                if (ListLines1[6] == proverka2Print)
                                                    if (ListLines1[8] == proverkaPrint)
                                                    {
                                                        richTextBox2.Text = "Подключенные сетевые принетры:" + "\n" + ListLines1[7];
                                                    }
                                                    else
                                                    {
                                                        if (ListLines1[6] == proverka2Print)
                                                            if (ListLines1[7] == proverkaPrint)
                                                            {
                                                                richTextBox2.Text = "Мы не обнаружили подключенные сетевые принтеры";
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }

                tr1.Close();
                Thread.Sleep(1000);
            }
            catch { }


            string PutFileNamePrintChten = rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFile.txt";
            string CleanPrintSetFile = PutFileNamePrintChten;

            if (File.Exists(CleanPrintSetFile))
            {
                File.Delete(CleanPrintSetFile);
            }

            #endregion
            #region Disk C FreeSpcae and %temp%

            try
            {


                timer3.Enabled = true;
                string rootDirDiskC = Directory.GetDirectoryRoot(Environment.SystemDirectory);
                DriveInfo driveInfoDiskC = new DriveInfo(rootDirDiskC);
                long FreeSpace = driveInfoDiskC.TotalFreeSpace;

                if (FreeSpace >= 1099511627776)
                {
                    long FreeSpaceTB = driveInfoDiskC.TotalFreeSpace / 1099511627776;
                    long AllSpcaeTB = driveInfoDiskC.TotalSize / 1099511627776;
                    label3.Text = "Диск C:" + "\n" + "Свободно:" + " " + FreeSpaceTB.ToString() + " " + "GB" + " " + "\n" + "Всего:" + " " + AllSpcaeTB.ToString() + " " + "GB";
                    circularProgressBar1.Maximum = (int)AllSpcaeTB;
                    circularProgressBar1.Value = (int)FreeSpaceTB;
                    if (circularProgressBar1.Value == (int)FreeSpaceTB)
                    {
                        timer3.Enabled = false;
                    }
                }
                else
                {
                    if (FreeSpace >= 1073741824)
                    {
                        long FreeSpaceGB = driveInfoDiskC.TotalFreeSpace / 1073741824;
                        long AllSpcaeGB = driveInfoDiskC.TotalSize / 1073741824;
                        label3.Text = "Диск C:" + "\n" + "Свободно:" + " " + FreeSpaceGB.ToString() + " " + "GB" + " " + "\n" + "Всего:" + " " + AllSpcaeGB.ToString() + " " + "GB";
                        circularProgressBar1.Maximum = (int)AllSpcaeGB;
                        circularProgressBar1.Value = (int)FreeSpaceGB;
                        if (circularProgressBar1.Value == (int)AllSpcaeGB)
                        {
                            timer3.Enabled = false;
                        }

                    }
                    else
                    {
                        if (FreeSpace >= 1048576)
                        {
                            long FreeSpaceMB = driveInfoDiskC.TotalFreeSpace / 1048576;
                            label3.Text = FreeSpaceMB.ToString() + " " + "MB";
                        }
                        else
                        {
                            if (FreeSpace >= 1024)
                            {
                                long FreeSpaceKB = driveInfoDiskC.TotalFreeSpace / 1024;
                                label3.Text = FreeSpaceKB.ToString() + " " + "KB";
                            }
                        }
                    }
                }
            }
            catch { }



            try
            {


                // Сколько всего занято на ПК Пользователя
                string rootDirDiskCProv = Directory.GetDirectoryRoot(Environment.SystemDirectory);
                DriveInfo driveInfoDiskCProv = new DriveInfo(rootDirDiskCProv);
                long FreeSpaceProv = driveInfoDiskCProv.TotalFreeSpace;
                long BusySpace = driveInfoDiskCProv.TotalSize;

                long TotalOccupied = (BusySpace - FreeSpaceProv) / 1073741824 + 1;
                //Thread.Sleep(100);
                // end Сколько всего занято на ПК Пользователя
                //

                string rootDrive1ProvTemp = Path.GetPathRoot(Environment.SystemDirectory);
                string userName1ProvTemp = Environment.UserName;


                // Занято в папке Temp

                string dirPathTemp = rootDrive1ProvTemp + "Users\\" + userName1ProvTemp + "\\AppData\\Local\\Temp";

                if (Directory.Exists(dirPathTemp) == false)
                {

                }

                DirectoryInfo dirInfoTemp = new DirectoryInfo(dirPathTemp);
                //Thread.Sleep(100);
                long sizeTemp = 0;
                IEnumerable<FileInfo> fisTemp = dirInfoTemp.EnumerateFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo fiTemp in fisTemp)
                {
                    sizeTemp += fiTemp.Length;
                }


                // TB
                if (sizeTemp >= 1099511627776)
                {
                    double x = sizeTemp;
                    double z = x / 1099511627776;
                    timer3.Enabled = false;
                    label4.Text = "Занято временными файлами: " + z.ToString("#.#") + " TB" + "\n" + "Занято всего на ПК: " + TotalOccupied.ToString() + " GB";

                }
                else
                {
                    //GB
                    if (sizeTemp >= 1073741824)
                    {
                        double x = sizeTemp;
                        double z = x / 1073741824;
                        timer3.Enabled = false;
                        label4.Text = "Занято временными файлами: " + z.ToString("#.#") + " GB" + "\n" + "Занято всего на ПК: " + TotalOccupied.ToString() + " GB";

                    }
                    else
                    {
                        //MB
                        if (sizeTemp >= 1048576)
                        {
                            double x = sizeTemp;
                            double z = x / 1048576;
                            timer3.Enabled = false;
                            label4.Text = "Занято временными файлами: " + z.ToString("#.#") + " MB" + "\n" + "Занято всего на ПК: " + TotalOccupied.ToString() + " GB";


                        }
                        else
                        {
                            //KB
                            if (sizeTemp >= 1024)
                            {
                                double x = sizeTemp;
                                double z = x / 1024;
                                timer3.Enabled = false;
                                label4.Text = "Занято временными файлами: " + z.ToString("#.#") + " KB" + "\n" + "Занято всего на ПК: " + TotalOccupied.ToString() + " GB";

                            }

                        }
                    }
                }
            }
            catch { }

        }

        #region Create request CheckDisk
        private void CheckAccesskisk()
        {
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string userName = Environment.UserName;
            string namefileusenetfileKoll = "/c net use>" + rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\usenetfilekoll.txt";
            ProcessStartInfo cmd1Koll = new ProcessStartInfo("cmd.exe", namefileusenetfileKoll);
            cmd1Koll.RedirectStandardInput = true;
            cmd1Koll.RedirectStandardOutput = true;
            cmd1Koll.RedirectStandardError = true;
            cmd1Koll.UseShellExecute = false;
            cmd1Koll.CreateNoWindow = true;
            cmd1Koll.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(cmd1Koll);
            Thread.Sleep(1000);


            string namefileusenetfile = "/c wmic netuse get LocalName, RemoteName>" + rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\usenetfile.txt";
            ProcessStartInfo cmd1 = new ProcessStartInfo("cmd.exe", namefileusenetfile);
            cmd1.RedirectStandardInput = true;
            cmd1.RedirectStandardOutput = true;
            cmd1.RedirectStandardError = true;
            cmd1.UseShellExecute = false;
            cmd1.CreateNoWindow = true;
            cmd1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(cmd1);
            Thread.Sleep(1000);
        }

        #endregion

        #region Create request CheckPrint
        private void CheckAccessPrint()
        {
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string userName = Environment.UserName;
            string namefileKoll = "/c wmic printer get DriverName, Name>" + rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFileSmotKoll.txt";
            ProcessStartInfo PrintcmdprocessKoll = new ProcessStartInfo("cmd.exe", namefileKoll);
            PrintcmdprocessKoll.RedirectStandardInput = true;
            PrintcmdprocessKoll.RedirectStandardOutput = true;
            PrintcmdprocessKoll.RedirectStandardError = true;
            PrintcmdprocessKoll.UseShellExecute = false;
            PrintcmdprocessKoll.CreateNoWindow = true;
            PrintcmdprocessKoll.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(PrintcmdprocessKoll);
            Thread.Sleep(1000);

            string namefile = "/c wmic printer get DriverName, Name>" + rootDrive + "Users\\" + userName + "\\AppData\\Local\\Temp\\SST\\PrintSetFile.txt";
            ProcessStartInfo Printcmdprocess = new ProcessStartInfo("cmd.exe", namefile);
            Printcmdprocess.RedirectStandardInput = true;
            Printcmdprocess.RedirectStandardOutput = true;
            Printcmdprocess.RedirectStandardError = true;
            Printcmdprocess.UseShellExecute = false;
            Printcmdprocess.CreateNoWindow = true;
            Printcmdprocess.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(Printcmdprocess);
            Thread.Sleep(1000);

        }
        #endregion

            #endregion


            
        

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsedSSTNavigationDropBox)
            {
                richTextBox1.Height += 10;
                if (richTextBox1.Size == richTextBox1.MaximumSize)
                {
                    timer1.Enabled = false;
                    isCollapsedSSTNavigationDropBox = false;
                }
            }
            else
            {
                richTextBox1.Height -= 10;
                if (richTextBox1.Size == richTextBox1.MinimumSize)
                {
                    timer1.Enabled = false;
                    isCollapsedSSTNavigationDropBox = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsedSSTNavigationDropBox)
            {
                richTextBox2.Height += 10;
                if (richTextBox2.Size == richTextBox2.MaximumSize)
                {
                    timer2.Enabled = false;
                    isCollapsedSSTNavigationDropBox = false;
                }
            }
            else
            {
                richTextBox2.Height -= 10;
                if (richTextBox2.Size == richTextBox2.MinimumSize)
                {
                    timer2.Enabled = false;
                    isCollapsedSSTNavigationDropBox = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 10)
            {
                progressBar1.Value++;
                if (progressBar1.Value == 10)
                {
                    Parallel.Invoke(() => OpenHelpYourPC());
                }
            }

            if (progressBar1.Value == 1)
            {
                label6.Text = "Проверка данных на ПК";
            }
            if (progressBar1.Value == 2)
            {
                label6.Text = "Проверка свободной памяти";
            }
            if (progressBar1.Value == 4)
            {
                label6.Text = "Поиск подключенных сетевых принтеров";
            }
            if (progressBar1.Value == 7)
            {
                label6.Text = "Поиск подключенных сетевых дисков";
            }
            if (progressBar1.Value == 9)
            {
                label6.Text = "Почти все готово";
            }
            if (button1.Visible == true)
            {
                label6.Visible = false;
                progressBar1.Visible = false;
                timer3.Stop();
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
