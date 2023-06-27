using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SST_Icon.Forms
{
    public partial class MenuForms : Form
    {
        private bool isCollapsedSSTNavigationDropBox;
        public MenuForms()
        {
            InitializeComponent();
        }


        private Form activeForm = null;
        private void openChildForm(Form chilFrom)
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

        private void Uvedomleniya()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Вернуться на главную страницу");
            toolTip1.SetToolTip(this.button2, "Открыть/Закрыть меню");
            toolTip1.SetToolTip(this.button3, "Чистка временных файлов");
            toolTip1.SetToolTip(this.button4, "Обновить групповые политики");
            toolTip1.SetToolTip(this.button5, "Проблемы с доступом в интернет");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsedSSTNavigationDropBox)
            {
                panel1.Width += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Enabled = false;
                    isCollapsedSSTNavigationDropBox = false;
                }
            }
            else
            {
                panel1.Width -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Enabled = false;
                    isCollapsedSSTNavigationDropBox = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                if (panel1.Size == panel1.MaximumSize)
                {
                    Uvedomleniya();
                    label1.Text = "В данном меню вы можете:" + "\n" + "1) Самостоятельно произвести очистку ПК от временных файлов. — Это поможет вам решить проблемы с " + "\n" + "переполненностью системного раздела," + "\n" + "которые были сгенерированы на вашем ПК ранее используемыми программами." + "\n" + "\n" + "2) Обновить групповые политики — Данная функция может пригодиться в ситуациях" + "\n" + "когда, необходимо передать вашему ПК новые данные с сервера по вашей учетной записи" + "\n" + "\n" + "3) Быстро снять логи / трассировки при массовых проблемах с интернет соединением." + "\n" + "Этот функционал необходим для быстрого сбора данных и передачи их в отдел HelpDesk" + "\n" + "в момент массового отключения интернета в офисе";
                }
                else
                {
                    label1.Text = "В данном меню, вы можете:" + "\n" + "1) Самостоятельно  произвести очистку ПК" + "\n" + "от временных файлов." + "\n" + "\n" + "2) Обновить групповые политики" + "\n" + "\n" + "3) Быстро снять логи / трассировки при" + "\n" + "массовых проблемах с интернет соединением.";
  
                }

                timer1.Enabled = true;
            }
            else
            {
                if (panel1.Size == panel1.MaximumSize)
                {

                    label1.Text = "В данном меню вы можете:" + "\n" + "1) Самостоятельно произвести очистку ПК от временных файлов. — Это поможет вам решить проблемы с " + "\n" + "переполненностью системного раздела," + "\n" + "которые были сгенерированы на вашем ПК ранее используемыми программами." + "\n" + "\n" + "2) Обновить групповые политики — Данная функция может пригодиться в ситуациях" + "\n" + "когда, необходимо передать вашему ПК новые данные с сервера по вашей учетной записи" + "\n" + "\n" + "3) Быстро снять логи / трассировки при массовых проблемах с интернет соединением." + "\n" + "Этот функционал необходим для быстрого сбора данных и передачи их в отдел HelpDesk" + "\n" + "в момент массового отключения интернета в офисе";
                }
                else
                {
                    label1.Text = "В данном меню, вы можете:" + "\n" + "1) Самостоятельно  произвести очистку ПК" + "\n" + "от временных файлов." + "\n" + "\n" + "2) Обновить групповые политики" + "\n" + "\n" + "3) Быстро снять логи / трассировки при" + "\n" + "массовых проблемах с интернет соединением.";
                }

                activeForm.Close();
                timer1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Size == panel1.MaximumSize)
            {
                Uvedomleniya();
                label2.Text = "Yes";
                openChildForm(new Forms.tempcookies());
            }
            else
            {
                label2.Text = "No";
                openChildForm(new Forms.tempcookies());

            }
            if (label2.Text == "Yes")
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Size == panel1.MaximumSize)
            {
                Uvedomleniya();
                label2.Text = "Yes";
                openChildForm(new Forms.UpdatePC());
            }
            else
            {
                label2.Text = "No";
                openChildForm(new Forms.UpdatePC());

            }
            if (label2.Text == "Yes")
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel1.Size == panel1.MaximumSize)
            {
                Uvedomleniya();
                label2.Text = "Yes";
                openChildForm(new Forms.Internetaccess());
            }
            else
            {
                label2.Text = "No";
                openChildForm(new Forms.Internetaccess());

            }
            if (label2.Text == "Yes")
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
