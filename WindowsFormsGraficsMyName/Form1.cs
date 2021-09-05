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
        Graphics grafics;
        const float PointDefolt = 50;

        /* Дополнительное значение для лучшей визуального выравнивания. Чтобы не работать сильно с дробями.*/
        const int FloatingConstantHeight = 1; 
        const int FloatingConstantWidth = 1;

        /* Коэффициент для поиска подходящего point в зависемости от размера формы */
        int coefficientWidth;
        int coefficientHeight;

        const string FamilyName = "Arial";
        const string MyName = "Коробкова Татьяна";

        public Form1()
        {
            InitializeComponent();
        }


        private int coefficientWidthFunct(Size sizeForm, string mes, string familyName)
        {
            Graphics g;
            float fontPoint = PointDefolt;
            Font fnt = new System.Drawing.Font(familyName, fontPoint);
            Brush br = new SolidBrush(Color.Red);
            Point pt = new Point(0, 0);

            Form form = new Form();
            form.Size = sizeForm;

            g = form.CreateGraphics();

            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(mes, fnt);

            while (stringSize.Width >= form.ClientSize.Width)
            {
                fontPoint -= 1;
                fnt = new System.Drawing.Font(familyName, fontPoint);
                stringSize = g.MeasureString(mes, fnt);
            }

            return (int)Math.Floor(form.Width / fontPoint) + FloatingConstantWidth;

        }

        private int coefficientHeightFunct(Size sizeForm, string mes, string familyName)
        {
            Graphics g;
            float fontPoint = PointDefolt;
            Font fnt = new System.Drawing.Font(familyName, fontPoint);
            Brush br = new SolidBrush(Color.Red);
            Point pt = new Point(0, 0);

            Form form = new Form();
            form.Size = sizeForm;

            g = form.CreateGraphics();
            //g.DrawString(mes, fnt, br, pt);

            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(mes, fnt);

            while (stringSize.Height >= form.Height)
            {
                fontPoint -= 1;
                fnt = new System.Drawing.Font(familyName, fontPoint);
                stringSize = g.MeasureString(mes, fnt);
            }

            return (int)Math.Floor(form.Height / fontPoint) + FloatingConstantHeight;
        }

        public void FunctDrawMyName(int width, int hight, string fio, string familyName, int kw, int kh)
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

            if (width < 0 || hight < 0 || kw <= 1 || kh <= 1)
                return;

            int lenWord = fio.Length;

            fontW = width / kw;
            fontH = hight / kh;

            if (fontW > fontH)
                font = fontH;
            else
                font = fontW;

            Font fnt = new System.Drawing.Font(familyName, font);
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
            FunctDrawMyName(this.Width, this.Height, MyName, FamilyName, coefficientWidth, coefficientHeight);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            FunctDrawMyName(this.Width, this.Height, MyName, FamilyName, coefficientWidth, coefficientHeight);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size formSize = this.ClientSize;
            coefficientHeight = coefficientHeightFunct(formSize, MyName, FamilyName);
            coefficientWidth = coefficientWidthFunct(formSize, MyName, FamilyName);
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
