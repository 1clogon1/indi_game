using A_game_with_different_outcomes_1._0.Controllers;
using A_game_with_different_outcomes_1._0.Models;
using A_game_with_different_outcomes_1._0.Для_сушностей_различных_Entites_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_game_with_different_outcomes_1._0//Тут нед вижения вверх и вниз, но картинку со sprite как бы поделена на пополам первые пать для анимации в право, а от 6 до 10 влево
{
    
    public partial class Form1 : Form
    {
        //Переменный для подгрузки героев из папки
        public Image dwarfSheet;
        public Image GladiatorSheet;

        //Наш игрок, вынесен в глобальную переменную чтобы им можно было проше пользоваться при вызове
        public Entity player;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public Form1()
        {
            InitializeComponent();

            //Интервад для таймера
            timer1.Interval = 20;

            //Функция обработки
            timer1.Tick += new EventHandler(Update);

            //Изменение позиции игроку
            KeyDown += new KeyEventHandler(onPress);

            //Событи при отпускание клавиши, то есть стоит игрок
            KeyUp += new KeyEventHandler(OnKeyUp);
            Init();
        }


        //Функция где будет обрабатываться события нажатия кнопки и будет выполнятся то действие взависимости от нажатой кнопки
        private void onPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -1;
                    player.isMoving = true;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    if (player.flip == 1)
                    {
                        player.SetAnimationConfigurate(1);
                    }
                    else
                    {
                        player.SetAnimationConfigurate(6);
                    }
                    break;
                case Keys.A:
                    player.dirX = -1;
                    player.isMoving = true;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    player.SetAnimationConfigurate(6);
                    player.flip = -1;
                    break;
                case Keys.S:
                    player.dirY = 1;
                    player.isMoving = true;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    if (player.flip == 1)
                    {
                        player.SetAnimationConfigurate(1);
                    }
                    else
                    {
                        player.SetAnimationConfigurate(6);
                    }
                    break;
                case Keys.D:
                    player.dirX = 1;
                    player.isMoving = true;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    player.SetAnimationConfigurate(1);
                    player.flip = 1;
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    if (player.flip == 1)
                    {
                        player.SetAnimationConfigurate(2);
                    }
                    else
                    {
                        player.SetAnimationConfigurate(7);
                    }
                        
                    break;
                case Keys.F:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;//В момент нажатия даем переменной значения true, обозначающее что обьект движется
                    if (player.flip == 1)
                    {
                        player.SetAnimationConfigurate(4);
                    }
                    else
                    {
                        player.SetAnimationConfigurate(9);
                    }
                    break;
            }

            
            
        }

        //Функция при отпускание клавиши, то есть персонаж стоит в ужном направление обнуляется его сторона направления
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }
            //Анимаци когда только появился герой и в зависот направления когда герой стоит срабатывает в нужном направление анимация ожидания
            if(player.dirX == 0 && player.dirY==0)
            {
                player.isMoving = false;
                if(player.flip == 1)
                {
                    player.SetAnimationConfigurate(0);
                }
                else
                {
                    player.SetAnimationConfigurate(5);
                }
            }
        }

       

        //Функция отвечающая за инициализацию всей игры
        public void Init()
        {
            MapControllers.Init();

            //Размер карты
            this.Width = MapControllers.GetWidth();//Умножаем размер ячейки на ширину нашей карты
            this.Height = MapControllers.GetHeight();//Умножаем размер ячейки на высоту нашей карты
            //this.Height = MapControllers.celSize * MapControllers.mapHight;//Умножаем размер ячейки на высоту нашей карты
            
            //Тут обьединяем полученный путь до файла и прописанный путь до sprite
            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),"Персонажи(Sprite)\\Dwarf.png"));

            player = new Entity(310, 310, Hero.idleFrame, Hero.runFrame, Hero.attackframe, Hero.deathFrame, dwarfSheet);//310 310 - чтобы появился в центре карты
            timer1.Start();//Запуск таймера
        }

        public void Update(object sender, EventArgs e)
        {
            //Убрали просчет колизий для нашего игрока - PhizikController.IsCollaid(player);//Передали в класс для функции над кем будет происходить проверки, то есть взаимодействияс с картой
           
            if(!PhizikController.IsCollaid(player,new Point(player.dirX,player.dirY)))//Если у нас не проходит колизия нашего игрока с камим либо объектом на карте, то персонаж может двигаться
            {
                if(player.isMoving == true)//Это нужно чтобы убрать задержку при нажатие клавиши
                {//Если isMoving==true, то активируем движения игрока
                    player.Move();
                }
            }
            

            Invalidate();//Для перерисовки(как я понимаю для обновления кадра), что бы стары прорисовки исчезали и могли появится новые с изменненной позицией
        }

        //Отрисовка всего необходимого тоесть игроков и фон
        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // g.DrawImage(dwarfSheet, new PointF(100, 100));
            //g.DrawImage(dwarfSheet, 100, 100, new Rectangle(new Point(0, 0), new Size(31, 31)), GraphicsUnit.Pixel);
            //g.DrawImage(player.spriteSheet, new Rectangle(new Point(player.posX, player.posY), new Size(player.size, player.size)), 0,0, player.size, player.size, GraphicsUnit.Pixel);//Передаем картинку, потом Rectangle - это прямоугольник в который мы вставим вырезонную картинку, 0 0 - координаты по которым вырезать, player.size player.size - размер выреза из обшей картинки
            
            //Вывод карты
            MapControllers.DrawMap(g);
            
            //Передаем готовую графику(вывод героя)
            player.PlayAnimation(g);

            
        
        }
    }
}
