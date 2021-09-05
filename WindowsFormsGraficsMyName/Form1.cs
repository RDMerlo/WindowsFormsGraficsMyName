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

        Bitmap bitmap;
        Graphics grafics;

        public Form1()
        {
            InitializeComponent();
            
        }

        public void FunctDrawMyName(int width = 0, int hight = 0, string fio="")
        {
            /*
             * point = 50;
             * width = 500;
             * height = 120;
             * 
             * pointW = 96;
             * pointH = 76;
             * 
             */

            this.BackColor = Color.White;
            float font;
            float fontW;
            float fontH;

            if (width < 0 || hight < 0)
                return;

            int lenWord = fio.Length;

            fontW = width / 10;
            fontH = hight / 3;

            if (fontW > fontH)
                font = fontH;
            else
                font = fontW;

            Font fnt = new System.Drawing.Font("Arial", font);
            Brush br = new SolidBrush(Color.Red);
            Point pt = new Point(0, 0);

            grafics = this.CreateGraphics();
            grafics.Clear(Color.White);
            grafics.DrawString(fio, fnt, br, pt);

            SizeF stringSize = new SizeF();
            stringSize = grafics.MeasureString(fio, fnt);

            int t = (int)(Math.Floor(this.ClientSize.Height / 2.0) - (fnt.Height/2));
            int top = t < 0 || t + fnt.Height >= this.ClientSize.Height ? 0 : t;
            int l = (int)Math.Ceiling((this.Width - (int)stringSize.Width) / 2.0);
            int left = l < 0 || l + (int)stringSize.Width >= this.ClientSize.Width ? 0 : l;

            pt = new Point(left, top);
            grafics.Clear(Color.White);
            grafics.DrawString(fio, fnt, br, pt);

            //MessageBox.Show($"{ this.ClientSize.Height } {t + fnt.Height}");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            FunctDrawMyName(this.Width, this.Height, "Султанов Дим");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            FunctDrawMyName(this.Width, this.Height, "Султанов Дим");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
