using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using A_game_with_different_outcomes_1._0.Controllers;
/*//curretAnimation получает у нас число определенное которое и означает анимацию от первой половины или от второй просто это число умножается на опредленное и полуается что 4(5) номер и в первой половине и во второй половине это смерть, но в определенную сторону в зависимости от положения игрока. //То есть если минусвая, то естьповернули на лево то от середины картинки со sprite мы идем по нижней части поэтому -1, а если направо идем, то начинаем от самого верха так как положительная часть, поэтом и происходит деление на пополам   "posX-flip*size/2" то есть flip это и есть flip это и есть в лево -1, в право +1 и получается так в зависимости от стороны от обшего размера при минусе берется вторая половина, а при положительном то есть в право ,thtncz  gthdfz gjkjdbyf fybvfwb, а уже дальше там умножается на 0, 1, 2, 4  в зависимости от нажатой клавиши

 */

namespace A_game_with_different_outcomes_1._0.Для_сушностей_различных_Entites_

{
    public class Entity//Тут будет реализовываться суть игрока, то есть взаимодействия пользователя
    {//Класс где будут создаваться взаимодействия игрока и ботов
        
        //Позиции, то есть место куда будут передаватся изменения и храниться поиция
        public int posX;
        public int posY;

        //На скколько будет изменятся позиция игрока
        public int dirX;
        public int dirY;

        //Переменная которая определяет движется ли шас игрок
        public bool isMoving;

        //Переменна для хранения стороны куда направлен игрок(лево и право)//Если 1 это право, если -1 это в лево
        public int flip;
        //Переменная для отображения текушeй анимации
        public int curretAnimation;

        //Переменная для отображения текушeго кадра анимации
        public int currentFrame;

        //переменная для лимита по кадрам анимации
        public int currentLimit;

        //Количество кадров под каждое действие
        public int idleFrame;
        public int runFrame;
        public int attackframe;
        public int deathFrame;

        //Переменны для размера нашего персонажа
        public int size;

        //Переменная котора хранит текущую картинку для спрайта и будет ее передавать, в зависимости от картинки будут проигрываться те или иные анимации 
        public Image spriteSheet;

        //Конструктор где будем передавать позицию оп X и Y, и количество кадров для различных анимаций(их 4)
        public Entity(int posX, int posY, int idleFrame, int runFrame, int attackframe, int deathFrame, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrame = idleFrame;
            this.runFrame = runFrame;
            this.attackframe = attackframe;
            this.deathFrame = deathFrame;
            this.spriteSheet = spriteSheet;
            size = 31;//Размер нашего персонажа
            curretAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrame;//Передали анимацию ожидания, потому что при зугрузке обьект не двигается значит активируется нимация ожидания по дефолту, а меняется оно от выбранной анимации игроком то есть из основной формы передается какая анимация отработает
            flip = 1;
        }

        //Функция передачи для класса сушности, где будем изменять позицию 
        public void Move()
        {
            posX += dirX;
            posY += dirY;
            
        }

        //Функция для передачи определнной(текушей) анимации игрока
        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;

            //Вывод происходит определение кадра, а посл его вывод, что-бы не было проблем с выводом кадров
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 32 * currentFrame, 32 * curretAnimation, size, size, GraphicsUnit.Pixel);//Передаем картинку, потом Rectangle - это прямоугольник в который мы вставим вырезонную картинку, 0 0 - координаты по которым вырезать, player.size player.size - размер выреза из обшей картинки


        }

        //функция по которой будем устонавливать что за анимация будет активированна и определять значения для currentLimit(количество кадров в этой анимации)
        public void SetAnimationConfigurate(int curretAnimation)
        {
            this.curretAnimation = curretAnimation;//передаем анимацию

            switch(curretAnimation)
            {
                case 0:
                    currentLimit = idleFrame;
                    break;
                case 1:
                    currentLimit = runFrame;
                    break;
                case 2:
                    currentLimit = attackframe;
                    break;
                case 4:
                    currentLimit = deathFrame;
                    break;
                case 5:
                    currentLimit = idleFrame;
                    break;
                case 6:
                    currentLimit = runFrame;
                    break;
                case 7:
                    currentLimit = attackframe;
                    break;
                case 9:
                    currentLimit = deathFrame;
                    break;
            }

        }
    }
}
