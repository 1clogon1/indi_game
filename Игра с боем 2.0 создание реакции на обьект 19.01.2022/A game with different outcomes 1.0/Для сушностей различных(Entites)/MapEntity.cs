using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_game_with_different_outcomes_1._0.Для_сушностей_различных_Entites_
{
    public class MapEntity
    {
        public PointF position;//Позиция
        public Size size;//Размер

        public MapEntity(PointF pos,  Size size)
        {
            this.position = pos;
            this.size = size;
        }
    }
}
