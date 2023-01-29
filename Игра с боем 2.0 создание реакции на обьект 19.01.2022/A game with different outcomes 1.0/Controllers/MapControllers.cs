using A_game_with_different_outcomes_1._0.Для_сушностей_различных_Entites_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_game_with_different_outcomes_1._0.Controllers
{
    public static class MapControllers
    {
        //Реализация карты
        public const int mapHight = 20;//высота
        public const int mapWidth = 20;//ширина
        public static int celSize = 31;//Размер обьекта на карте
        public static int[,] map = new int[mapHight, mapWidth];//карта

        //Набор ландшафта
        public static Image spriteSheet;

        //Лист для хранения обьектов, что бы проше было с ними взаимодействоватьЮ для дальнейшего расчета колизий персонажа и обьектов
        public static List<MapEntity> mapObject;

        //Функция для инициализации карты
        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Персонажи(Sprite)\\Forest.png"));
            mapObject = new List<MapEntity>();
        }


        //Функцтя для возврата карты для отображения
        public static int[,] GetMap()
        {
            return new int[,]{
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,12,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,12,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,11,0,0,0,0,12,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,12,0,9,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,12,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,12,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,12,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,12,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
            /*return new int[,]{
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,12,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,12,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,11,0,0,0,0,12,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,12,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,12,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,12,0,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,0,0,0,0,12,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,10,-1,-1,0,0,0,12,0,0,0,0,0,0,0,0,10,-1,-1,7},
                { 5,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };*/
        }

        //Функция для отрисовки ландшафта
        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHight; j++)
                {
                    if (map[i, j] == 10)
                    {//Так как деревья занимают больше одной клетки визуально хотя записываются в одну, то нужно еще нужно занимать две клетки справо от деревьев чтобы какбы визуально все было правильно и забить(внести) эти клетками пустыми барьерами что бы убрать пустоту и чтобы в деревья случайно не поставили камень или куст
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize * 3, celSize * 3)), 202, 297, 107, 114, GraphicsUnit.Pixel);//Большие деревья
                        MapEntity mapEntity = new MapEntity(new Point(j * celSize, i * celSize), new Size(celSize * 3, celSize * 3));//Передаем данные в переменную
                        mapObject.Add(mapEntity);//В лист передаем теже данные что и в графику
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(20, 11)), 581, 114, 19, 11, GraphicsUnit.Pixel);//Камень
                        MapEntity mapEntity = new MapEntity(new Point(j * celSize, i * celSize), new Size(20, 12));//Передаем данные в переменную
                        mapObject.Add(mapEntity);//В лист передаем теже данные что и в графику
                    }
                    if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);//Трава
                        MapEntity mapEntity = new MapEntity(new Point(j * celSize, i * celSize), new Size(20, 18));//Передаем данные в переменную
                        mapObject.Add(mapEntity);//В лист передаем теже данные что и в графику
                    }

                }
            }
        }

        //Функция корторая будет заниматься отрисовкой карты, в него в качестве аргуvента будем передавать графику
        public static void DrawMap(Graphics g)
        {
            for(int i=0;i<mapWidth;i++)
            {
                for (int j = 0; j < mapHight; j++)
                {
                    
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);//Левый верхний угол
                    }
                    else if(map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);//Правй верхнийугол
                    }
                    else if(map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);//Левый нижний угол
                    }
                    else if(map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);//Правый нижний угол
                    }
                    else if(map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);//Левый край стены
                    }
                    else if(map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);//Верхний край стены
                    }
                    else if(map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);//Правый край стены
                    }
                    else if(map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);//Нижний край стены
                    }
                    else if (map[i, j] == 9)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 129, 253, 33, 33, GraphicsUnit.Pixel);//Водопад
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * celSize, i * celSize), new Size(celSize, celSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }

                }
            }
            SeedMap(g);//Вызов функции для отрисовки ландшафта карты и передаем графику так как за счет нее мы выводим по тамеру все объекты
        }

        //Возврощает размер ширины нашей формы, функция расположенна в этом классе чтобы когда изменился размер карты, н ам не пришлось его менять в форме1, а просто он передастся
        public static int GetWidth()
        {
            return celSize * (mapWidth)+15;
        }
        //Возврощает высоту
        public static int GetHeight()
        {
            return celSize * (mapHight+1)+10;
        }
    }
}
