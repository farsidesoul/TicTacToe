using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Board
    {
        public int movesMade = 0;

        private Rectangle[,] slots = new Rectangle[3,3];
        private Holder[,] holders = new Holder[3, 3];

        // Board squares, X = X, O = O, B = Blank square
        public const int X = 0;
        public const int O = 1;
        public const int B = 2;

        public void initBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slots[i, j] = new Rectangle(i * 167, j * 167, 167, 167);
                    holders[i, j] = new Holder();
                    holders[i, j].setValue(B);
                    holders[i, j].setLocation(new Point(i, j));
                }
            }
        }
        // Detects where the mouse is clicked and assigns it a x and y value.
        public void detectHit(Point loc)
        {
            // Checks if the board was clicked
            if (loc.Y <= 500)
            {
                int x = 0;
                int y = 0;

                if (loc.X < 167)
                {
                    x = 0;
                }
                else if (loc.X > 167 && loc.X < 334)
                {
                    x = 1;
                }
                else if (loc.X > 334)
                {
                    x = 2;
                }

                if (loc.Y < 167)
                {
                    y = 0;
                }
                else if (loc.Y > 167 && loc.Y < 334)
                {
                    y = 1;
                }
                else if (loc.Y > 334 && loc.Y < 500)
                {
                    y = 2;
                }

                movesMade++;

                if (movesMade % 2 == 0)
                {
                    GFX.drawX(new Point(x, y));
                }
                else
                {
                    GFX.drawO(new Point(x, y));
                }
            }

        }
    }

    class Holder
    {
        private Point location;
        private int value = Board.B;

        public void setLocation(Point p)
        {
            location = p;
        }

        public Point getLocation()
        {
            return location;
        }

        public void setValue(int i)
        {
            value = i;
        }

        public int getValue()
        {
            return value;
        }
    }
}
