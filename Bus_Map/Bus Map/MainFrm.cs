using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bus_Map
{
    public partial class MainFrm : Form
    {
        BusMapFrm Map;

        public int ActiveUsers;

        public string NameUser;

        //підпункт файла "Довідка"
        ToolStripMenuItem tsmInfo = new ToolStripMenuItem("Довідка");
        //підпункт файла "Вихід"
        ToolStripMenuItem tsmExit = new ToolStripMenuItem("Вихід");
        //пункт меню "Особистий кабінет"
        ToolStripMenuItem tsmiMyFile = new ToolStripMenuItem("Особистий кабінет");
        //підпункт файла "Авторизація"
        ToolStripMenuItem tsmiAuthorizationUsers = new ToolStripMenuItem("Авторизація");
        //підпункт файла "Реєстрація"
        ToolStripMenuItem tsmRegistratioUsers = new ToolStripMenuItem("Реєстрація");
        //підпункт файла "Поточний аккаунт"
        ToolStripMenuItem tsmiAccount = new ToolStripMenuItem("Поточний акаунт");
        //підпункт файла "Вихід з аккаунту"
        ToolStripMenuItem tsmiExitAccount = new ToolStripMenuItem("Вихід з акаунту");
        //підпункт файла "Карта"
        ToolStripMenuItem tsmMap = new ToolStripMenuItem("Карта");     

        public MainFrm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //перевірка на активність користувача
            ActiveUser.SomeEvent += Active;
        }

        public void Active(object sender, EventArgs e)
        {
            ActiveUsers = ActiveUser.sValue;
            //якщо коритсувач активний, то відкриваєм особистий кабінет
            if (ActiveUsers == 1)
            {
                //Властивості форми
                ClientSize = new Size(690, 400);
                this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Bus.ico");
                this.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\FonUserActive.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Text = "Особистий Кабінет";
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                //Скриваємо підпук=нкти Реєстрація і Авторизація
                tsmiAuthorizationUsers.Visible = false;
                tsmRegistratioUsers.Visible = false;

                //Добавляєм підпунт "Карта" до пункту "Файл"
                tsmiMyFile.DropDownItems.Add(tsmMap);
                //Добавляєм підпункт "Поточний аккаунт" до пункту "Файл"
                tsmiMyFile.DropDownItems.Add(tsmiAccount);
                //Добавляєм підпунт "Вихід з аккаунту" до пункту "Файл"
                tsmiMyFile.DropDownItems.Add(tsmiExitAccount);                                     

                // задаємо колір підпунктам
                tsmiAccount.BackColor = Color.FromArgb(85, 157, 255);
                tsmiExitAccount.BackColor = Color.FromArgb(85, 157, 255);
                tsmInfo.BackColor = Color.FromArgb(85, 157, 255);
                tsmMap.BackColor = Color.FromArgb(85, 157, 255);
                tsmExit.BackColor = Color.FromArgb(85, 157, 255);

                // Добавляємо пункти на Menu
                Menu.Items.Add(tsmiMyFile);
                Menu.Items.Add(tsmInfo);
                Menu.Items.Add(tsmExit);

                // Задаємо їм функції
                tsmMap.Click += new EventHandler(this.Map_Click);
                tsmiExitAccount.Click += new EventHandler(this.ExitUser_Click);
                tsmiAccount.Click += new EventHandler(this.Account_Click);
                tsmInfo.Click += new EventHandler(this.Info_Click);
                tsmExit.Click += new EventHandler(this.Exit_Click);
      
            }
            //якщо не активний то головне меню
            else
            {
                //Властивості форми
                ClientSize = new Size(690, 400);
                this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Bus.ico");
                this.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\FonMainFrm.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Text = "Меню";

                // Добавляєм підпункт "Авторизація" до пункту "Файл"
                tsmiMyFile.DropDownItems.Add(tsmiAuthorizationUsers);
                //Добавляєм підпунт "Реєстрація" до пункту "Файл"
                tsmiMyFile.DropDownItems.Add(tsmRegistratioUsers);                                  

                //Задаємо колір підпунктам
                tsmiAuthorizationUsers.BackColor = Color.FromArgb(85, 157, 255);
                tsmRegistratioUsers.BackColor = Color.FromArgb(85, 157, 255);
                tsmInfo.BackColor = Color.FromArgb(85, 157, 255);
                tsmExit.BackColor = Color.FromArgb(85, 157, 255);

                // Добавляємо пункти на Menu
                Menu.Items.Add(tsmiMyFile);
                Menu.Items.Add(tsmInfo);
                Menu.Items.Add(tsmExit);
               
                // Задаємо їм функції
                tsmiAuthorizationUsers.Click += new EventHandler(this.Log_Click);
                tsmRegistratioUsers.Click += new EventHandler(this.Reg_Click);
                tsmInfo.Click += new EventHandler(this.Info_Click);
                tsmExit.Click += new EventHandler(this.Exit_Click);
            }
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            //якщо файлу не існує то ми запускаємо головне меню
            if (File.Exists(@"Зовнішні файли\Text\UserActive.txt"))
            {
                //користувач активний
                ActiveUser.sValue = 1;

                //зчитування імені користувача
                using (StreamReader InfoProgram = new StreamReader(@"Зовнішні файли\Text\UserActive.txt", Encoding.Default))
                {
                    NameUser = InfoProgram.ReadToEnd();
                }
            }
            //якщо файла існує і користувач не зберігався
            else
            {
                ActiveUser.sValue = 0;
            }
            //Присвоєння імені коритсувачові в формі Bus Map
            if (ActiveUser.Name == null)
            {
                Map = new BusMapFrm(NameUser);
            }
            else
            {
                Map = new BusMapFrm(ActiveUser.Name);
            }
        }


        public void Account_Click(object sender, EventArgs e)
        {
            // зчитування імені коритсувача
            if (ActiveUser.Name == null)
            {
                //Вибиття імені коитсувача
                MessageBox.Show(
                  "Ваш поточний аккаунт: " + NameUser,
                  "Поточний аккаунт",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
                  );
                
            }
            else
            {
                //Вибиття імені коитсувача
                MessageBox.Show(
                   "Ваш поточний аккаунт: " + ActiveUser.Name,
                   "Поточний аккаунт",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
                   );
            }
        }

        //Відкривання форми Bus Map
        public void Map_Click(object sender, EventArgs e)
        {
            Map.Show();
            Hide();
        }

        //Відкривання форми Аторизації
        public void Log_Click(object sender, EventArgs e)
        {
            LoginFrm Log = new LoginFrm();
            Log.Show();
            Hide();
        }

        //Відкривання форми Реєстрації
        public void Reg_Click(object sender, EventArgs e)
        {
            RegistrationFrm Reg = new RegistrationFrm();
            Reg.Show();
            Hide();
        }

        //Відкривання форми Довідки
        public void Info_Click(object sender, EventArgs e)
        {
            InformationFrm Info = new InformationFrm();
            Info.Show();
            Hide();
        }

        //Закриття проекту по кнопці Виход
        public void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void ExitUser_Click(object sender, EventArgs e)
        {
            // користувач не активний
            ActiveUser.sValue = 0;
            // видалення файлу з іменем
            File.Delete(@"Зовнішні файли\Text\UserActive.txt");
            // відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        //Закриття проекту 
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //Закриття форми на клавішу Escape
            if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
