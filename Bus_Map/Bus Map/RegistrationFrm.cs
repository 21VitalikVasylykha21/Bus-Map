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
    public partial class RegistrationFrm : Form
    {
        BusMapFrm BusMap;
        //Словарь(ключ-значення) для збереження даних про користувача
        Dictionary<string, string> UsersData = new Dictionary<string, string>();
        //Регулярний вираз
        Regex Pattern = new Regex(@"\w{1,8}");
        //Зміна для перевірки даних 
        public static string prov;
        //зміна для перевірки чи зберігати користувача
        public bool SaveUser = false;



        public RegistrationFrm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void RegistrationFrm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            //Властивості форми
            ClientSize = new Size(800, 540);
            this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Registration.ico");
            this.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\FonFrm.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "Реєстрація";
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
            Button Reg = new Button();
            Reg.Name = "Registration";
            Reg.Text = "Зареєструватися";
            Reg.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Reg.Size = new Size(270, 60);
            Reg.BackColor = Color.FromArgb(82, 74, 221);
            Reg.Location = new Point(240, 450);
            Reg.FlatStyle = FlatStyle.Flat;
            Reg.FlatAppearance.BorderSize = 3;
            Reg.BackColor = Color.FromArgb(74, 153, 255);
            Reg.Click += new System.EventHandler(this.Reg_Click);
            Reg.Anchor = AnchorStyles.Top;
            this.Controls.Add(Reg);

            //Сторення мітки уведення Реєстрації, надання їй властивостей 
            Label RegLbl = new Label();
            RegLbl.Name = "Registration";
            RegLbl.Text = "Реєстрація";
            RegLbl.Font = new Font("Segoe Print", 30, FontStyle.Italic, GraphicsUnit.Point);
            RegLbl.Size = new Size(330, 100);
            RegLbl.BackColor = Color.Transparent;
            RegLbl.Location = new Point(250, 120);
            RegLbl.Anchor = AnchorStyles.Top;
            this.Controls.Add(RegLbl);

            //Сторення мітки уведення логіна, надання їй властивостей//
            Label Login = new Label();
            Login.Name = "Login";
            Login.Text = "Логін";
            Login.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Login.Size = new Size(100, 40);
            Login.BackColor = Color.Transparent;
            Login.Location = new Point(220, 210);
            Login.Anchor = AnchorStyles.Top;
            this.Controls.Add(Login);

            //Сторення мітки уведення паролю, надання їй властивостей//
            Label Password = new Label();
            Password.Name = "Password";
            Password.Text = "Пароль";
            Password.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            Password.Size = new Size(150, 40);
            Password.BackColor = Color.Transparent;
            Password.Location = new Point(200, 275);
            Password.Anchor = AnchorStyles.Top;
            this.Controls.Add(Password);

            //Сторення мітки уведення повторного паролю, надання їй властивостей//
            Label PowPassword = new Label();
            PowPassword.Name = "PowPassword";
            PowPassword.Text = "Повторіть пароль";
            PowPassword.Font = new Font("Segoe Print", 18, FontStyle.Italic, GraphicsUnit.Point);
            PowPassword.Size = new Size(420, 40);
            PowPassword.BackColor = Color.Transparent;
            PowPassword.Location = new Point(50, 335);
            PowPassword.Anchor = AnchorStyles.Top;
            this.Controls.Add(PowPassword);
        }


        //Функція для хешування даних
        public string GetHashMD5(string input)
        {
            var mD5 = MD5.Create();
            //хешування даних в формат MD5
            var HashMD5 = mD5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(HashMD5);
        }



        //Реєстрація користувача
        public void Reg_Click(object sender, EventArgs e)
        {
            try
            {
                //Перевірка на правильність вводу даних(Пустота)
                if (string.IsNullOrWhiteSpace((txtBoxLog.Text)) || string.IsNullOrWhiteSpace((txtBoxPass.Text)) || string.IsNullOrWhiteSpace((txtBoxPassPow.Text)))
                {
                    //Перевірка на правильність вводу Логіна
                    if (string.IsNullOrWhiteSpace((txtBoxLog.Text)))
                    {
                        MessageBox.Show("Логін не може бути пустим/складаючимся тільки з роздільних символів!",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    //Перевірка на пустоту Паролю
                    if (string.IsNullOrWhiteSpace((txtBoxPass.Text)))
                    {
                        MessageBox.Show("Пароль не може бути пустим/складаючимся тільки з роздільних символів!",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    //Перевірка на пустоту Паролю
                    if (string.IsNullOrWhiteSpace((txtBoxPassPow.Text)))
                    {
                        MessageBox.Show("Повторний пароль не може бути пустим/складаючимся тільки з роздільних символів!",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    return;
                }
                //Перевірка на правильність вводу Повторного паролю
                if (txtBoxPassPow.Text != txtBoxPass.Text)
                {
                    MessageBox.Show("Паролі не співпадають",
                        "Помилка реєстрації",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                //Перевірка на правильність вводу даних(Формат)
                if (!Pattern.IsMatch((txtBoxLog.Text)) || !Pattern.IsMatch((txtBoxPass.Text)))
                {
                    //Перевірка на правильність вводу Логіна
                    if (!Pattern.IsMatch((txtBoxLog.Text)))
                    {
                        MessageBox.Show("Невірний формат!", "" +
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    //Перевірка на правильність вводу Паролю
                    if (!Pattern.IsMatch((txtBoxPass.Text)))
                    {
                        MessageBox.Show("Невірний формат!",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    return;
                }

                //зчитування файлу з даними
                IEnumerable<string> Read = (File.ReadLines(@"Зовнішні файли\Text\User.txt"));
                // Перевірка на існуючий Логін
                foreach (string str in Read)
                {
                    string[] l = str.Split(' ');
                    prov = l[0];
                    if (GetHashMD5(txtBoxLog.Text) == prov)
                    {
                        MessageBox.Show("Користувач з таким іменем вже є!",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                //Зміна для логіна користувача
                string log = txtBoxLog.Text;
                //Хешування логіна і пароля
                string text = GetHashMD5(txtBoxLog.Text) + " " + GetHashMD5(txtBoxPass.Text) + Environment.NewLine;
                //Додання даних в  файл
                File.AppendAllText(@"Зовнішні файли\Text\User.txt", text);
                
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
                txtBoxPassPow.Text = "";

                //Сповіщення про вхід
                MessageBox.Show("Вітаю, ви успішно зареєструвались",
                    "Вхід",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //перехід на іншу сторінку
                BusMap = new BusMapFrm(log);
                BusMap.Show();
                Hide();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Перевірте файл за шляхом: Зовнішні файли\Text\User.txt",
                            "Помилка реєстрації",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }

        //Перехід на головне меню
        public void Menu_Click(object sender, EventArgs e)
        {
            //очищення полів вводу
            txtBoxLog.Text = "";
            txtBoxPass.Text = "";
            txtBoxPassPow.Text = "";
            //Відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        //Перехід на головне меню
        private void RegistrationFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //очищення полів вводу
            txtBoxLog.Text = "";
            txtBoxPass.Text = "";
            txtBoxPassPow.Text = "";
            //Відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        private void RegistrationFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //Закриття форми Escape
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void checkBoxSaveUser_CheckedChanged(object sender, EventArgs e)
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
