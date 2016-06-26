using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Punkty
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle punktyRec;

        public Punkty(Random randPunkty)
        {
            x = randPunkty.Next(0, 29) * 10;
            y = randPunkty.Next(0, 29) * 10;

            brush = new SolidBrush(Color.Black);
            width = 10;
            height = 10;

            punktyRec = new Rectangle(x, y, width, height);

        }
        public void PunktyLokacja(Random randPunkty)
        {
            x = randPunkty.Next(0, 29) * 10;
            y = randPunkty.Next(0, 29) * 10;
        }
        public void drawPunkty(Graphics paper)
        {
            punktyRec.X = x;
            punktyRec.Y = y;

            paper.FillRectangle(brush, punktyRec);
        }
    }
}
