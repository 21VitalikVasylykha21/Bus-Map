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
    public partial class InformationFrm : Form
    {
      
        public InformationFrm()
        {
            InitializeComponent();
         
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InformationFrm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            //Властивості форми
            ClientSize = new Size(1000, 600);
            this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Info.ico");
            this.Text = "Довідка";


            // Створення нової кнопки Головного меню, надання їй властивість
            Button Menu = new Button();
            Menu.Name = "Menu";
            Menu.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\House.png");
            Menu.FlatStyle = FlatStyle.Flat;
            Menu.BackgroundImageLayout = ImageLayout.Stretch;
            Menu.BackColor = Color.Transparent;
            Menu.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Menu.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Menu.FlatAppearance.BorderSize = 1;
            Menu.Size = new Size(60, 60);
            Menu.Location = new Point(20, 20);
            Menu.Click += new EventHandler(this.Menu_Click);
            Fon.Controls.Add(Menu);

            //Сторення мітки уведення Довідка, надання їй властивостей
            Label Info = new Label();
            Info.Name = "Login";
            Info.Text = "Довідка";
            Info.Font = new Font("Segoe Print", 30, FontStyle.Italic, GraphicsUnit.Point);
            Info.Size = new Size(330, 100);
            Info.BackColor = Color.Transparent;
            Info.Location = new Point(370, 100);
            Info.Anchor = AnchorStyles.Top;
            Fon.Controls.Add(Info);

            //Зчитування даних із файлів//
            try
            {

                //Про програму
                using (StreamReader InfoProgram = new StreamReader(@"Зовнішні файли\Text\Про програму.txt", Encoding.Default))
                {
                    lblInfoProgram.Text = InfoProgram.ReadToEnd();
                }

                //Інструкція
                using (StreamReader InfoProgram = new StreamReader(@"Зовнішні файли\Text\Інструкція по використаню програми.txt", Encoding.Default))
                {
                    txtBoxInfoInstruction.Text = InfoProgram.ReadToEnd();
                }
                //Про автора
                using (StreamReader InfoProgram = new StreamReader(@"Зовнішні файли\Text\Про автора.txt", Encoding.Default))
                {
                    lblInfoAuthor.Text = InfoProgram.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show(@"Перевірте файли ""Про програму.txt, Інструкція по використаню програми.txt, Про автора.txt ""за шляхом: Зовнішні файли\Text",
                     "Помилка",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        public void Menu_Click(object sender, EventArgs e)
        {
            //відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        private void InformationFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //відкриття головної форми
            MainFrm m = new MainFrm();
            m.Show();
            Hide();
        }

        private void InformationFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //Закриття форми на клавішу Escape
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
