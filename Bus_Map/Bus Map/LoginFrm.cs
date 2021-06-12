using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Робота з текстом
using System.Text.RegularExpressions;
//Кодування тексту
using System.Security.Cryptography;
using System.IO;

namespace Bus_Map
{
    public partial class LoginFrm : Form
    {
        BusMapFrm BusMap;
        //Словарь(ключ-значення) для збереження даних про користувача
        Dictionary<string, string> UsersData = new Dictionary<string, string>();
        //Регулярний вираз
        Regex Pattern = new Regex(@"\w{1,8}");
        //зміна для перевірки чи зберігати користувача
        public bool SaveUser = false;


        public LoginFrm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            //Властивості форми
            ClientSize = new Size(800, 450);
            this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Login.ico");
            this.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\FonFrm.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "Авторизація";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Створення нової кнопки Головного меню, надання їй властивість
            Button Menu = new Button();
            Menu.Name = "Menu";
            Menu.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\House.png");
            Menu.FlatStyle = FlatStyle.Flat;
            Menu.BackgroundImageLayout = ImageLayout.Stretch;
            Menu.BackColor = Color.Transparent;
            Menu.FlatAppearance.BorderSize = 1;
            Menu.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Menu.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Menu.Size = new Size(60, 60);
            Menu.Location = new Point(20, 20);
            Menu.Click += new EventHandler(this.Menu_Click);
            this.Controls.Add(Menu);

            // Створення нової кнопки Зареєструватися, надання їй властивість
            Button Log = new Button();
            Log.FlatStyle = FlatStyle.Flat;
            Log.Name = "Registration";
            Log.Text = "Авторизуватися";
            Log.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Log.Size = new Size(270, 60);
            Log.FlatAppearance.BorderSize = 3;
            Log.BackColor = Color.FromArgb(74, 153, 255);
            Log.Location = new Point(245, 360);
            Log.Click += new System.EventHandler(this.Log_Click);
            this.Controls.Add(Log);

            //Сторення мітки уведення Авторизації, надання їй властивостей
            Label LogLbl = new Label();
            LogLbl.Name = "Login";
            LogLbl.Text = "Авторизація";
            LogLbl.Font = new Font("Segoe Print", 30, FontStyle.Italic, GraphicsUnit.Point);
            LogLbl.Size = new Size(330, 110);
            LogLbl.BackColor = Color.Transparent;
            LogLbl.Location = new Point(200, 50);
            this.Controls.Add(LogLbl);

            //Сторення мітки уведення логіна, надання їй властивостей
            Label Login = new Label();
            Login.Name = "Login";
            Login.Text = "Логін";
            Login.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Login.Size = new Size(100, 40);
            Login.BackColor = Color.Transparent;
            Login.Location = new Point(210, 180);
            Login.Anchor = AnchorStyles.Top;
            this.Controls.Add(Login);

            //Сторення мітки уведення паролю, надання їй властивостей
            Label Password = new Label();
            Password.Name = "Password";
            Password.Text = "Пароль";
            Password.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Password.Size = new Size(150, 40);
            Password.BackColor = Color.Transparent;
            Password.Location = new Point(190, 245);
            Password.Anchor = AnchorStyles.Top;
            this.Controls.Add(Password);
        }

        //Функція для хешування даних
        public string GetHashMD5(string input)
        {
            var mD5 = MD5.Create();
            //хешування даних в формат MD5
            var HashMD5 = mD5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(HashMD5);
        }

        public void Log_Click(object sender, EventArgs e)
        {
            try
            {
                //Перевірка на правильність вводу даних(Пустота)
                if (string.IsNullOrWhiteSpace((txtBoxLog.Text)) || string.IsNullOrWhiteSpace((txtBoxPass.Text)))
                {
                    //Перевірка на правильність вводу Логіна
                    if (string.IsNullOrWhiteSpace((txtBoxLog.Text)))
                    {
                        MessageBox.Show("Логін не може бути пустим/складаючимся тільки з роздільних символів!",
                           "Помилка авторизації",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    }
                    //Перевірка на пустоту Паролю
                    if (string.IsNullOrWhiteSpace((txtBoxPass.Text)))
                    {
                        MessageBox.Show("Пароль не може бути пустим/складаючимся тільки з роздільних символів!",
                           "Помилка авторизації",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    }
                    return;
                }
                //Перевірка на правильність вводу даних(Формат)
                if (!Pattern.IsMatch((txtBoxLog.Text)) || !Pattern.IsMatch((txtBoxPass.Text)))
                {
                    //Перевірка на правильність вводу Логіна
                    if (!Pattern.IsMatch((txtBoxLog.Text)))
                    {
                        MessageBox.Show("Невірний формат!", "" +
                        "Помилка авторизації",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    //Перевірка на правильність вводу Пароля
                    if (!Pattern.IsMatch((txtBoxPass.Text)))
                    {
                        MessageBox.Show("Невірний формат!",
                           "Помилка авторизації",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    }
                    return;
                }

                //зчитування файлу з даними
                using (StreamReader Read = new StreamReader(@"Зовнішні файли\Text\User.txt", Encoding.Default))
                {
                    string ReadLine;
                    //масив для записування даних
                    string[] couple = new string[2];
                    //Цикл записування в словарь значення
                    while ((ReadLine = Read.ReadLine()) != null)
                    {

                        if (ReadLine.Split(' ').Length == 2) couple = ReadLine.Split(' ');
                        //Додання в словарь
                        try { UsersData.Add(couple[0], couple[1]); } catch { }
                    }
                }

                //Присвоєння даних зміній User із текст боксів
                (string, string) User = (GetHashMD5(txtBoxLog.Text), GetHashMD5(txtBoxPass.Text));
                //Перевірка даних Логіна
                if (!UsersData.ContainsKey(User.Item1))
                {
                    MessageBox.Show("Користувач з таким іменем немає!",
                            "Помилка авторизації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }
                //Перевірка даних Пароля
                if (User.Item2 != UsersData[User.Item1])
                {
                    MessageBox.Show("Невірний пароль",
                             "Помилка авторизації",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    return;
                }

                //Зміна для логіна користувача
                string log = txtBoxLog.Text;
                //Сповіщення про вхід
                MessageBox.Show("Вітаю, ви успішно авторизувалися",
                    "Вхід",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //перехід на іншу сторінку
                BusMap = new BusMapFrm(log);
                BusMap.Show();
                Hide();

                //зберігання імя коритсувача
                ActiveUser.Name = log;

                //якщо вибраний CheckBox
                if (SaveUser)
                {
                    //збереження користувача
                    using (StreamWriter sw = new StreamWriter(@"Зовнішні файли\Text\UserActive.txt", false, Encoding.Default))
                    {
                        sw.WriteLine(log);
                    }
                }

                //очищення полів вводу
                txtBoxLog.Text = "";
                txtBoxPass.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show(@"Перевірте файл за шляхом: Зовнішні файли\Text\User.txt",
                    "Помилка даних",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

      
        public void Menu_Click(object sender, EventArgs e)
        {
            //очищення полів вводу
            txtBoxLog.Text = "";
            txtBoxPass.Text = "";
            //Відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //очищення полів вводу
            txtBoxLog.Text = "";
            txtBoxPass.Text = "";
            //Відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        private void LoginFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //Закриття форми на клавішу Escape
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void сheckBoxSaveUser_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxSaveUser = (CheckBox)sender;
            //перевірка чи вибраний чей пункт
            if (checkBoxSaveUser.Checked == true)
            {
                SaveUser = true;
            }
        }
    }
}
