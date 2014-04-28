using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    class GFX
    {
        private Graphics gObject;

        public GFX(Graphics g)
        {
            gObject = g;
            setUpCanvas();
        }

        public void setUpCanvas()
        {
            Brush bg = new SolidBrush(Color.WhiteSmoke);
            Pen lines = new Pen(Color.Black);

            // Creates the background
            gObject.FillRectangle(bg, new Rectangle(0, 0, 500, 600));

            // Draws vertical lines
            gObject.DrawLine(lines, new Point(167, 0), new Point(167, 500));
            gObject.DrawLine(lines, new Point(334, 0), new Point(334, 500));

            // Draws horizontal lines
            gObject.DrawLine(lines, new Point(0, 167), new Point(500, 167));
            gObject.DrawLine(lines, new Point(0, 334), new Point(500, 334));
        }
    }
}
