using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scribble
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Point> Stroke = new List<Point>(); // need to set point MousePos if this isn't there.

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush br = new SolidBrush(c); //see where he defines c and as what?

            foreach (Point pt in Stroke)
            {
                g.FillRectangle(br, pt.X, pt.Y, 10, 10);
                g.DrawRectangle(Pens.Blue, pt.X, pt.Y, 10, 10);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                Stroke.Add(e.Location); // was MousePos = 
                Invalidate(); // refreshes screen.
            }
        }
        List<PointWithAttributes> pt = new List<PointWithAttributes>();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                c = Color.Red;
            }
            if (e.KeyCode == Keys.B)
            {
                c = Color.Black;
            }
            if (e.KeyCode == Keys.Z && e.Control && Stroke.Count > 0)
            {
                //undo
                Redo.Add(Stroke[Stroke.Count - 1]); // need to define Redo as list<pointwithattributes> see where Class is defined!
                Stroke.RemoveAt(Stroke.Count - 1);
                Invalidate();//repaint
            }
            if (e.KeyCode == Keys.Y && e.Control && Redo.Count > 0)
            {
                //redo
                Stroke.Add(Redo[Redo.Count - 1]);
                Redo.RemoveAt(Redo.Count - 1);
                Invalidate();
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Form1_MouseMove()//what gets passed?
        }
    }
}
