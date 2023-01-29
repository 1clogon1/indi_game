
using A_game_with_different_outcomes_1._0.Для_сушностей_различных_Entites_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_game_with_different_outcomes_1._0.Controllers
{
    public static class PhizikController//Для взаимодействия с картой
    {
        //Функция для проверки сталкнулась ли каким либо сушность с обьектом на карте
        public static bool IsCollaid(Entity entity, Point dir)//Entity entity -- сама сушность 
        {
            //Условие для границ карты, то есть запрет на выход за них
            if(entity.posX + dir.X <=0 || entity.posX+dir.X>=MapControllers.celSize*(MapControllers.mapWidth-1) || entity.posY + dir.Y <=0 || entity.posY + dir.Y >=MapControllers.celSize*(MapControllers.mapHight-1))
            {
                return true;
            }
            for(int i=0;i<MapControllers.mapObject.Count;i++)//Пробегаем по всем обьектам на карте с которыми мы можем сталкнутся
            {
                var currObject = MapControllers.mapObject[i];//И записываем их в переменную, что бы обрашатся к текушему обьекту
                PointF delta = new PointF();

                //Расчитываем растояние от центра обьекта до центра героя на карте//Суть такова в дельты мы записали растояние между обьектами и игроком по X и Y, и если одно из растояний по X или Y по одной из координат delta.X или delta.Y становится рана 0 или меньше самого растояни между обьектами это означает что мы вперлись в обьект и нас к примеру отталкнет или просто застопарит как будто мы идем в стену
                delta.X = (entity.posX + entity.size / 2) - (currObject.position.X + currObject.size.Width / 2);//Высчитываем дельту "X" - это растояни между центрами по X, тут позиция X + размер персонажа делить на пополам это и будет серединная координата нашег персонажа и высчитываем также серединную координату объекта на карте 
                delta.Y = (entity.posY + entity.size / 2) - (currObject.position.Y + currObject.size.Height / 2);//Высчитываем дельту "Y" - это растояни между центрами по Y, тут позиция X + размер персонажа делить на пополам это и будет серединная координата нашег персонажа и высчитываем также серединную координату объекта на карте 
                if(Math.Abs(delta.X)<= entity.size/2 + currObject.size.Width)//Проверка если у нас дельта "X" меньше чем сумма размероав половины ширины наших обьектов, то значит они нвходятся в колизии
                {
                    if (Math.Abs(delta.Y) <= entity.size / 2 + currObject.size.Height/2)//Если у нас половины высота нашего персонажа и текушего объекта на карте в сумме дают <= дельта "Y", то у нас колизия
                    { 
                        if(delta.X < 0 && dir.X==1 && entity.posY+ entity.size / 2 > currObject.position.Y &&  entity.posY+ entity.size / 2 < currObject.position.Y + currObject.size.Height)
                        {
                            return true;//Если произошло столкновение при движение в лево мы возвращаем true
                        }

                        if (delta.X > 0 && dir.X == -1 && entity.posY+ entity.size / 2 > currObject.position.Y && entity.posY + entity.size / 2 < currObject.position.Y + currObject.size.Height)
                        {
                            return true;//Если произошло столкновение при движение в право мы возвращаем true
                        }

                        if (delta.Y < 0 && dir.Y == 1 && entity.posX+ entity.size / 2 > currObject.position.X && entity.posX+ entity.size / 2 < currObject.position.X + currObject.size.Width)//Когда персонаж залезает на объекты и бегает по ним, соотвественно нам нужно проверить что персонаж находится в диапазоне относительно текушего обьекта на карте, что например позиция "X" в случае для delta.Y и dir.Y равным еденицы, что персонаж у нас по "X" находится в диапазоне от левого края обьекта на карте, до самого правого края обьекта на карте 
                        {
                            return true;//Если произошло столкновение при движение вниз мы возвращаем true
                        }

                        if (delta.Y > 0 && dir.Y == -1 && entity.posX+ entity.size / 2 > currObject.position.X && entity.posX+ entity.size / 2 < currObject.position.X + currObject.size.Width)
                        {
                            return true;//Если произошло столкновение при движение верх мы возвращаем true
                        }
                    }
                }
            }
            return false; //Столкновения не произошло
        }
    }
}
