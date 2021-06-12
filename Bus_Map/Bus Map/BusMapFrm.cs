using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

// Библиотеки для карты
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace Bus_Map
{
    public partial class BusMapFrm : Form
    {
        //зміна для імені користувача
        string UserName;

        //Ініцілізація форми
        public BusMapFrm(string _UserName)
        {
            InitializeComponent();
            UserName = _UserName;
        }

        //Масив кнопок
        public Button[] BusNumber = new Button[22];
        //Масив назв цих кнопок
        public string[] NumberBus = new string[] { "1", "2", "3", "7", "7Д", "8", "9", "10",
                                                   "11", "12П", "14", "15", "17", "18", "20",
                                                   "21", "22", "24", "26", "38", "58", "156" };

        public Label[] BusInfo = new Label[22];
        //Масив назв цих кнопок
        public string[] Info = new string[] { "Автобус №", "Ціна ", "Інтервал ", "Робочі дні ", "Графік роботи ", "Маршут " };
        //Для двойного кліку на кнопки
        public bool DoubleClik = false;
        public string Bus;

        //клас для списку точок
        public class CPoint
        {
            // Точка х
            public double x { get; set; }
            // Точка У
            public double y { get; set; }
            public CPoint(double _x, double _y)
            {
                x = _x;
                y = _y;
            }
        }

        private void BusMapFrm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            //Властивості форми
            ClientSize = new Size(1400, 700);
            this.Icon = new Icon(@"Зовнішні файли\Photo\Icons\Map.ico");
            this.Text = "Карта Ужгорода. Привіт " + UserName + "!";

            //Створення нового обєкту контейнера
            GroupBox GroupBoxBus = new GroupBox();
            //Надання імені контейнору
            GroupBoxBus.Name = "GroupBoxBus";
            //Надання тексту контейнеру
            GroupBoxBus.Text = "Автобуси:";
            //Задання шрифту текстові
            GroupBoxBus.Font = new Font("Times New Roman", 14);
            //Встановлення розміру контейнера
            GroupBoxBus.Size = new Size(400, 180);
            //Встановлення розміщення на формі
            GroupBoxBus.Location = new Point(5, 10);
            //Задання кольору
            GroupBoxBus.BackColor = Color.SteelBlue;
            //Всановлюєся видимість контейнера
            GroupBoxBus.Visible = true;
            //Доданя його на цю форму
            PanelElements.Controls.Add(GroupBoxBus);

            //Створення нового обєкту контейнера розміщення
            FlowLayoutPanel PanelButtonBus = new FlowLayoutPanel();
            //Встановлення розміру широти
            PanelButtonBus.Width = 370;
            //Встановлення розміру довжини
            PanelButtonBus.Height = 150;
            //Встановлення розміщення на контейнері
            PanelButtonBus.Location = new Point(10, 20);
            //Додання контейнера розміщення на GroupBoxBus
            GroupBoxBus.Controls.Add(PanelButtonBus);

            //Цикл створюющий кнопки із масива
            for (int i = 0; i < NumberBus.Length; i++)
            {
                //Створення нового обєкту кнопки
                BusNumber[i] = new Button();
                //Встановлення розміру кнопки
                BusNumber[i].Size = new Size(45, 30);
                //Надання імені кнопки
                BusNumber[i].Name = "BusNumber " + NumberBus[i];
                //Надання тексту кнопці
                BusNumber[i].Text = NumberBus[i];
                BusNumber[i].BackColor = Color.SteelBlue;
                //Встановлення нової події кліку на кнопки
                BusNumber[i].Click += BusNumber_Click;

                //Додання кнопки на контейнер розміщення
                PanelButtonBus.Controls.Add(BusNumber[i]);
            }

            //Створення нового обєкту контейнера розміщення
            FlowLayoutPanel PanelInfoBus = new FlowLayoutPanel();
            //Встановлення розміру широти
            PanelInfoBus.Width = 150;
            //Встановлення розміру довжини
            PanelInfoBus.Height = 245;
            //Встановлення розміщення на контейнері
            PanelInfoBus.Location = new Point(1, 30);
            //Додання елементів ствобчем у низ
            PanelInfoBus.FlowDirection = FlowDirection.TopDown;
            //Додання контейнера розміщення на GroupBoxBus
            GroupBoxInfoBus.Controls.Add(PanelInfoBus);

            //цикл створення міток для інформації про автобус
            for (int k = 0; k < Info.Length; k++)
            {
                BusInfo[k] = new Label();
                BusInfo[k].Size = new Size(140, 40);
                BusInfo[k].Text = Info[k];
                BusInfo[k].TextAlign = ContentAlignment.TopCenter;
                PanelInfoBus.Controls.Add(BusInfo[k]);
            }

            // Створення нової кнопки Головного меню, надання їй властивість
            Button Menu = new Button();
            Menu.Name = "Menu";
            Menu.BackgroundImage = Image.FromFile(@"Зовнішні файли\Photo\House.png");
            Menu.FlatStyle = FlatStyle.Flat;
            Menu.BackgroundImageLayout = ImageLayout.Stretch;
            Menu.FlatAppearance.BorderSize = 0;
            Menu.Size = new Size(60, 60);
            Menu.BackColor = Color.SteelBlue;
            Menu.Location = new Point(2, 2);
            Menu.Click += new System.EventHandler(this.Menu_Click);
            GMapUzhorod.Controls.Add(Menu);

            //Створення кнопки для пошуку по адресу
            Button Find = new Button();
            Find.Name = "Find";
            Find.Text = "Знайти";
            Find.Font = new Font("Times New Roman;", 13);
            Find.Size = new Size(78, 30);
            Find.Location = new Point(3, 27);
            Find.Click += Find_Click;
            GroupBoxAdres.Controls.Add(Find);
        }

        private void GMapUzhorod_Load(object sender, EventArgs e)
        {
            // Налаштування для компонента GMap 
            // Угол карти
            GMapUzhorod.Bearing = 0;
            // Перетягування лівої кнопки миші
            GMapUzhorod.CanDragMap = true;
            // Перетягування карти лівою кнопкою миші
            GMapUzhorod.DragButton = MouseButtons.Left;

            GMapUzhorod.GrayScaleMode = true;
            // Всі маркери будуть показані
            GMapUzhorod.MarkersEnabled = true;
            // Максимальне наближення
            GMapUzhorod.MaxZoom = 18;
            // Мінімальне наближення
            GMapUzhorod.MinZoom = 3;
            // Курсор миші в центр карти
            GMapUzhorod.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            // Відключення нігатівного режиму
            GMapUzhorod.NegativeMode = false;
            // Дозвіл полігонів
            GMapUzhorod.PolygonsEnabled = true;
            // Дозвіл маршутів 
            GMapUzhorod.RoutesEnabled = true;
            // Приховування зовнішньої сітки карти
            GMapUzhorod.ShowTileGridLines = false;
            // При завантаженні 13-кратне збільшення
            GMapUzhorod.Zoom = 13;
            // Прибрати червоний хрестик по центру
            GMapUzhorod.ShowCenter = false;

            // Використовування гугл карт
            GMapUzhorod.MapProvider = GMapProviders.GoogleMap;

            // Задання початкої точки загрузки (місто Ужгород)           
            GMapUzhorod.Position = new PointLatLng(48.621134, 22.287740);
            // Для кліка по адресу
            GMapUzhorod.MouseClick += new MouseEventHandler(map_MouseClick);
        }

        private void RotateGMapUzhorod_Scroll(object sender, EventArgs e)
        {
            // Обертання карти
            GMapUzhorod.Bearing = RotateGMapUzhorod.Value;
        }

        // Шар для маршруту
        GMapOverlay AtoB = new GMapOverlay("AtoB");
        //Список точок по яких відбудовуєся маршут
        List<CPoint> WayAtoB = new List<CPoint>();
        public void BusNumber_Click(object sender, EventArgs e)
        {
            DoubleClik = !DoubleClik;
            //Перевірка на другий клік по кнопці
            if (Bus != (sender as Button).Text) DoubleClik = true;

                //Первірка на двійний клік
            if (DoubleClik)
            {
                //Цикл перебирає імена кнопок
                for (int k = 0; k < NumberBus.Length; k++)
                {

                    //повертає всім кнопкам одинаковий вигляд
                    BusNumber[k].BackColor = Color.SteelBlue;
                    //визначає кнопку
                    if (sender == BusNumber[k])
                    {
                        try
                        {
                            //Очищення шару щоб не накладувалося однин маршут на другий
                            AtoB.Clear();
                            //Очищення списку щоб не накладувалося однин маршут на другий
                            WayAtoB.Clear();
                            //Додававння шару
                            GMapUzhorod.Overlays.Add(AtoB);
                            //очищення шару
                            GMapUzhorod.Overlays.Clear();

                            //Відкривання файлу із точками
                            string[] temp = File.ReadAllLines(@"Зовнішні файли\Route\" + NumberBus[k] + ".txt");
                            //Зчитування точок
                            for (int i = 0; i < temp.Length; i++)
                            {
                                //Проходження по точках, пасинг двох double чисел
                                string[] OneStringWithCoor = temp[i].Split(new char[] { ';' });
                                //Добавлення double чисел у список
                                WayAtoB.Add(new CPoint(Convert.ToDouble(OneStringWithCoor[0]), Convert.ToDouble(OneStringWithCoor[1])));
                            }

                            //Список із готовими точками 
                            List<PointLatLng> WayAtoBPoints = new List<PointLatLng>();
                            //Перебирання списку
                            for (int i = 0; i < WayAtoB.Count; i++)
                            {
                                //Утворення точок
                                CPoint pointnew = new CPoint(WayAtoB[i].x, WayAtoB[i].y);
                                //Добавляємо його в список точок
                                WayAtoBPoints.Add(new PointLatLng(pointnew.x, pointnew.y));
                            }


                            // Очищаємо всі маршрути
                            AtoB.Routes.Clear();

                            // Створюємо маршрут на основі списку контрольних точок
                            GMapRoute route = new GMapRoute(WayAtoBPoints, "Route");
                            // Зазначаємо, що даний маршрут повинен відображатися
                            route.IsVisible = true;
                            //Рандомний колір
                            Random rnd = new Random(DateTime.Now.Millisecond);
                            int Green = rnd.Next(256);
                            int Blue = rnd.Next(256);
                            int Red = rnd.Next(256);
                            // Встановлює колір марушуту
                            route.Stroke.Color = Color.FromArgb(Red, Green, Blue);
                            BusNumber[k].BackColor = Color.FromArgb(Red, Green, Blue);
                            // Добавляє маршут
                            AtoB.Routes.Add(route);
                            // Додаємо в компонент, список маркерів і маршрутів
                            GMapUzhorod.Overlays.Add(AtoB);

                            //створення нового обєкту документа xml
                            XmlDocument xml = new XmlDocument();
                            //відкриття документа
                            xml.Load(@"Зовнішні файли\Route\BUS" + NumberBus[k] + ".xml");
                            //створення великого коріний елемент
                            XmlElement element = xml.DocumentElement;

                            //перебирання всіх дочірніх узлів
                            foreach (XmlElement xnode in element)
                            {
                                //перевірка на наявність атрибутів
                                if (xnode.Attributes.Count > 0)
                                {
                                    //зчитуємо атрибут name
                                    XmlNode name = xnode.Attributes.GetNamedItem("name");

                                    //перевірка на пустоту
                                    if (name != null)
                                    {
                                        //присвоєння зміній Name імя атрибута
                                        txtNameBus.Text = $"{name.Value}";
                                    }
                                }
                                //перебирання всіх дочірніх узлів дочірного узла 
                                foreach (XmlNode cildnode in xnode.ChildNodes)
                                {
                                    //Пошук узла route
                                    if (cildnode.Name == "route")
                                    {
                                        //присвоєння зміній значення із xml файла
                                        txtRoutBus.Text = $"{ cildnode.InnerText}";
                                    }
                                    //Пошук узла price"
                                    if (cildnode.Name == "price")
                                    {
                                        //присвоєння зміній значення із xml файла
                                        txtPriceBus.Text = $"{ cildnode.InnerText}";
                                    }
                                    //Пошук узла interval
                                    if (cildnode.Name == "interval")
                                    {
                                        //присвоєння зміній значення із xml файла
                                        txtIntervalBus.Text = $"{ cildnode.InnerText}";
                                    }
                                    //Пошук узла day
                                    if (cildnode.Name == "day")
                                    {
                                        //присвоєння зміній значення із xml файла
                                        txtDayBus.Text = $"{ cildnode.InnerText}";
                                    }
                                    //Пошук узла time
                                    if (cildnode.Name == "time")
                                    {
                                        //присвоєння зміній значення із xml файла
                                        txtTimeBus.Text = $"{ cildnode.InnerText}";
                                    }

                                }
                             
                            }
                        }
                        catch
                        {
                            MessageBox.Show(@"Перевірте файли з маршутами та інформацією про них за шляхом: Зовнішні файли\Route",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        }

                        Bus = BusNumber[k].Text;
                    }
                }
            }

            else
            {
                //Очищення шару з карти
                AtoB.Clear();

                //Повернення однакової закраски всім кнопкам
                for (int k = 0; k < NumberBus.Length; k++)
                {
                    //повертає всім кнопкам одинаковий вигляд
                    BusNumber[k].BackColor = Color.SteelBlue;
                }
                //повернення до початково стану полів вводу
                txtNameBus.Text = "-";
                txtRoutBus.Text = "-";
                txtPriceBus.Text = "-";
                txtIntervalBus.Text = "-";
                txtDayBus.Text = "-";
                txtTimeBus.Text = "-";
            }
        }


        // Шар для маркерів адресів по кліку на карті
        GMapOverlay AddressClick = new GMapOverlay("AddressClick");
        // Клік по карті ПКМ и установка маркера з даними про нього
        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Якщо нажати ПКМ
                if (e.Button == MouseButtons.Right)
                {
                    //Очищення шару щоб не накладувалося однин маркер на другий
                    AddressClick.Clear();

                    double lat = GMapUzhorod.FromLocalToLatLng(e.X, e.Y).Lat;
                    double lng = GMapUzhorod.FromLocalToLatLng(e.X, e.Y).Lng;

                    // Запит 
                    string zaput = "https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=true_or_false&language=ru&key=AIzaSyBFZDV04ts8VGMxP8aF0Z7L0b-J1511FNM";
                    // Запит до API
                    string url = string.Format(zaput, lat.ToString().Replace(",", "."), lng.ToString().Replace(",", "."));

                    // Виконання запиту
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    // Отримуємо відповідь від інтернет-ресурса
                    WebResponse response = request.GetResponse();
                    // Читання даних від інтернет-ресурса
                    Stream dataStream = response.GetResponseStream();
                    // Читання
                    StreamReader sreader = new StreamReader(dataStream);
                    // Зчитування потіку від поточного положення до кінця         
                    string responsereader = sreader.ReadToEnd();
                    // Закриття потіку відповіді
                    response.Close();

                    //Створення Xml документа
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responsereader);

                    //Перевірка на правильність запиту
                    if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                    {
                        // Отриммання інформаціЇ про найдений обєкт
                        string formatted_address = xmldoc.SelectNodes("//formatted_address").Item(0).InnerText.ToString();
                        string[] words = formatted_address.Split(',');
                        string dataMarker = string.Empty;
                        //Перебирання і записування інформації в зміну
                        foreach (string word in words)
                        {
                            dataMarker += word + ";" + Environment.NewLine;
                        }

                        //Додання шару на карту
                        GMapUzhorod.Overlays.Add(AddressClick);
                        //Створення ToolTip 
                        GMarkerGoogle addresmarker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_dot);
                        addresmarker.ToolTip = new GMapRoundedToolTip(addresmarker);
                        addresmarker.ToolTipMode = MarkerTooltipMode.Always;
                        addresmarker.ToolTipText = dataMarker;
                        //Додання шару з ToolTip а карту
                        AddressClick.Markers.Add(addresmarker);
                    }
                    else
                    {
                        MessageBox.Show("Не змогли отримати дані, виберіть інший адрес",
                                 "Помилка",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Сталася помилка, виберіть інший адрес",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        // Шар для маркерів адресів по кліку на карті
        GMapOverlay OverlayForAddress = new GMapOverlay("Address");
        // Ввід адреса в текстбокс и відобразити на карті координати цього адресу
        private void Find_Click(object sender, EventArgs e)
        {
            try
            {
                //Очищення шару щоб не накладувалося однин маркер на другий
                OverlayForAddress.Clear();

                // Запит
                string zaput = "https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true_or_false&language=ru&key=AIzaSyBFZDV04ts8VGMxP8aF0Z7L0b-J1511FNM";
                // Запми
                string url = string.Format(zaput, Uri.EscapeDataString(txtBoxAdres.Text));

                // Виконання запит
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // Отримуємо відповідь від інтернет-ресурса
                WebResponse response = request.GetResponse();
                // Читання даних від інтернет-ресурса
                Stream dataStream = response.GetResponseStream();
                // Читання
                StreamReader sreader = new StreamReader(dataStream);
                // Зчитування потіку від поточного положення до кінця         
                string responsereader = sreader.ReadToEnd();
                // Закриття потіку відповіді
                response.Close();

                //Створення Xml документа
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);



                //Перевірка на правильність запиту
                if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                {
                    // Отримання широти и довготи
                    XmlNodeList nodes = xmldoc.SelectNodes("//location");

                    // Широти и довготи
                    double latitude = 0.0;
                    double longitude = 0.0;

                    // Отримання широти и довготи
                    foreach (XmlNode node in nodes)
                    {
                        latitude = XmlConvert.ToDouble(node.SelectSingleNode("lat").InnerText.ToString());
                        longitude = XmlConvert.ToDouble(node.SelectSingleNode("lng").InnerText.ToString());
                    }


                    // Отриммання інформаціЇ про найдений адрес
                    string formatted_address = xmldoc.SelectNodes("//formatted_address").Item(0).InnerText.ToString();

                    string[] words = formatted_address.Split(',');
                    string dataMarker = string.Empty;
                    //Перебирання і записування інформації в зміну
                    foreach (string word in words)
                    {
                        dataMarker += word + ";" + Environment.NewLine;
                    }

                    //Додання шару на карту
                    GMapUzhorod.Overlays.Add(OverlayForAddress);
                    //Створення ToolTip
                    GMarkerGoogle addressmarker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.blue_pushpin);
                    addressmarker.ToolTip = new GMapRoundedToolTip(addressmarker);
                    addressmarker.ToolTipMode = MarkerTooltipMode.Always;
                    addressmarker.ToolTipText = dataMarker;
                    // Додання шару з ToolTip а карту
                    OverlayForAddress.Markers.Add(addressmarker);
                    GMapUzhorod.Position = new PointLatLng(latitude, longitude);

                }
                //Вибиття помилки якщо не знайдено адрес
                else
                {
                    MessageBox.Show("Не існує такого адресу, введіть інший адрес",
                             "Помилка",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Уведіть дані в поле вводу",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }


        public void Menu_Click(object sender, EventArgs e)
        {
            //користувач активний
            ActiveUser.sValue = 1;
            //Відкриття головної форми
            MainFrm M = new MainFrm();
            M.Show();
            Hide();
        }

        //закриття проекту
        private void BusMapFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //користувач активний
            ActiveUser.sValue = 1;
            //Відкриття головної форми
            MainFrm M = new MainFrm();
            M.Show();
            Hide();
        }

        // Гарячі клавіші
        private void BusMapFrm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Закриття форми Escape
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            // Поворот карти за годиноковою стрілкою Ctrl + Z
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                GMapUzhorod.Bearing += 10;
            }
            // Поворот карти проти годинокової стрілки Ctrl + X
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.X)
            {
                GMapUzhorod.Bearing -= 10;
            }
            // Збільшення масштабу карти Ctrl + клавіша (+)
            if (e.KeyCode == Keys.Add)
            {
                GMapUzhorod.Zoom += 1;
            }
            // Зманшення мастабу карти Ctrl  + клавіша (-)
            if (e.KeyCode == Keys.Subtract)
            {
                GMapUzhorod.Zoom -= 1;
            }
            //Повернення карти до стартних настройок
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                AtoB.Clear();
                OverlayForAddress.Clear();
                AddressClick.Clear();

                for (int k = 0; k < NumberBus.Length; k++)
                {
                    //повертає всім кнопкам одинаковий вигляд
                    BusNumber[k].BackColor = Color.SteelBlue;
                }

                txtNameBus.Text = "-";
                txtRoutBus.Text = "-";
                txtPriceBus.Text = "-";
                txtIntervalBus.Text = "-";
                txtDayBus.Text = "-";
                txtTimeBus.Text = "-";
            }
            // Зберігання скріншота карти Ctrl + S
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                try
                {
                    //Откривання діалового вікна для збереження файла. 
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        //Допустимі значення для зберігання карти в форматі.                    
                        dialog.Filter = "PNG (*.png)|*.png";
                        //Задаємо імя зберігаючого файлу.
                        dialog.FileName = "Карта Ужгорода";

                        Image image = this.GMapUzhorod.ToImage();

                        if (image != null)
                        {
                            using (image)
                            {
                                //Запуск діалового вікна, і якщо натиснувся ОК.
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {
                                    //Задаємо імя файла.
                                    string fileName = dialog.FileName;
                                    //Додаєм розширення файлу якшо не вибраний
                                    if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                    {
                                        fileName += ".png";
                                    }

                                    //Зберігаєм карту
                                    image.Save(fileName);
                                    MessageBox.Show("Карта успішно збережена в папці: "
                                        + Environment.NewLine
                                        + dialog.FileName, "Карта Ужгорода",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Помилка при зберіганні карти: "
                        + Environment.NewLine
                        + exception.Message,
                        "Карта Ужгорода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
        }
    }
}

