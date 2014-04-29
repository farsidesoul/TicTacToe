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

                if (movesMade % 2 == 0)
                {
                    GFX.drawX(new Point(x, y));
                    holders[x, y].setValue(X);
                    if (detectRow())
                    {
                        MessageBox.Show("X Wins!");
                    }
                }
                else
                {
                    GFX.drawO(new Point(x, y));
                    holders[x, y].setValue(O);
                    if (detectRow())
                    {
                        MessageBox.Show("O Wins!");
                    }
                }

                movesMade++;
            }

        }

        public bool detectRow()
        {
            bool isWon = false;

            for (int x = 0; x < 3; x++)
            {
                if (holders[x, 0].getValue() == X && holders[x, 1].getValue() == X && holders[x, 2].getValue() == X)
                {
                    return true;
                }

                if (holders[x, 0].getValue() == O && holders[x, 1].getValue() == O && holders[x, 2].getValue() == O)
                {
                    return true;
                }

                // Detects diagonal lines
                switch (x)
                {
                    case 0:
                        if (holders[x,0].getValue() == X && holders[x+1,1].getValue() == X && holders[x+2,2].getValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x + 1, 1].getValue() == O && holders[x + 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;

                    case 2:
                        if (holders[x, 0].getValue() == X && holders[x - 1, 1].getValue() == X && holders[x - 2, 2].getValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].getValue() == O && holders[x - 1, 1].getValue() == O && holders[x - 2, 2].getValue() == O)
                        {
                            return true;
                        }
                        break;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                if (holders[0, y].getValue() == X && holders[1, y].getValue() == X && holders[2, y].getValue() == X)
                {
                    return true;
                }

                if (holders[0, y].getValue() == O && holders[1, y].getValue() == O && holders[2, y].getValue() == O)
                {
                    return true;
                }
            }

                return isWon;
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
