using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGraficsMyName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DrawStringFloatFormat(PaintEventArgs e)
        {

            // Create string to draw.
            String drawString = "Sample Text";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y = 50.0F;

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        struct MyName
        {
            string FIO;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Font fnt = new System.Drawing.Font("Arial", (float)50);
            Brush br = new SolidBrush(Color.Red);
            Point pt = new Point(100, 100);
            Graphics g = e.Graphics;
            g.DrawString("Текст", fnt, br, pt);
            FontFamily[] a = FontFamily.Families;
        }
    }
}
