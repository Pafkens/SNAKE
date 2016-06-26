using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class SnakeGame : Form
    {
        Random randPunkty = new Random();

        Graphics paper;
        Snake snake = new Snake();
        Punkty food;

        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;

        int score = 0;

        public SnakeGame()
        {
            InitializeComponent();
            food = new Punkty(randPunkty);
        }

        private void SnakeGame_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawPunkty(paper);
            snake.drawSnake(paper);

          

        }

        private void SnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }

            if(e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            } 
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SnakeScoreLabel.Text= Convert.ToString(score);

            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (right) { snake.moveRight(); }
            if (left) { snake.moveLeft(); }
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.punktyRec))
                {
                    score += 10;
                    snake.growSnake();
                    food.PunktyLokacja(randPunkty);
                }
            }
            kolizja();

            this.Invalidate();
        }
        public void kolizja()
        {
            for (int i = 1; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    restart();
                }
            }
            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 500)
            {
                restart();

            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 500)
            {
                restart();
 
            }
        }

        public void restart()

        {
            score = 0;
            timer1.Enabled = false;
            MessageBox.Show("Koniec gry. Wciśnij spację by rozpocząć nową grę.");
            SnakeScoreLabel.Text = "0";
            spaceBarLabel.Text = "Wciśnij spację aby zacząć";
            snake = new Snake();

 
        }
    }
}
