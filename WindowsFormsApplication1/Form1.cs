using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image file;
        Image file1;
        Image file2;
        private void Bupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();

            if (f.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(f.FileName);
                pictureBox1.Image = file;
            }
        }

        private void Brgb_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(file);
                pictureBox1.Image = file;
                int width = bmp.Width;
                int height = bmp.Height;
                Bitmap rbmp = new Bitmap(bmp);
                Bitmap gbmp = new Bitmap(bmp);
                Bitmap bbmp = new Bitmap(bmp);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color p = bmp.GetPixel(x, y);
                        byte a = p.A;
                        byte r = p.R;
                        byte g = p.G;
                        byte b = p.B;
                        rbmp.SetPixel(x, y, Color.FromArgb(r, 0, 0));
                        gbmp.SetPixel(x, y, Color.FromArgb(0, g, 0));
                        bbmp.SetPixel(x, y, Color.FromArgb(0, 0, b));
                    }
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    pictureBox2.Image = rbmp;
                }
                else if (comboBox1.SelectedIndex == 1)
                { pictureBox2.Image = gbmp; }
                else if (comboBox1.SelectedIndex == 2)
                { pictureBox2.Image = bbmp; }
                pictureBox1.Image = file;
            }
            catch
            {
                MessageBox.Show("Please Enter A Picture First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Bbrightness_Click(object sender, EventArgs e)
        {
            try
            {
                int brightness = hScrollBar1.Value;
                Bitmap bmap = new Bitmap(file);
                pictureBox1.Image = file;
                if (brightness < -255) brightness = -255;
                if (brightness > 255) brightness = 255;
                Color c;
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        c = bmap.GetPixel(i, j);
                        int cR = c.R + brightness;
                        int cG = c.G + brightness;
                        int cB = c.B + brightness;
                        if (cR < 0) cR = 1;
                        if (cR > 255) cR = 255;
                        if (cG < 0) cG = 1;
                        if (cG > 255) cG = 255;
                        if (cB < 0) cB = 1;
                        if (cB > 255) cB = 255;
                        bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                    }
                }
                pictureBox2.Image = bmap;
                pictureBox1.Image = file;
            }

            catch
            {
                MessageBox.Show("Please Enter A Picture First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            Color c;

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = 255 - c.R;
                    int cG = 255 - c.G;
                    int cB = 255 - c.B;
                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                    pictureBox2.Image = bmap;
                }

                pictureBox1.Image = file;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double contrast = hScrollBar2.Value;
            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;
                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;
                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;
                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                    pictureBox2.Image = bmap;
                }
            }
            pictureBox1.Image = file;
        }

    
            /*   for (int i = 0; i <= bmap.Height; i++)
            {
                for (int j = 0; j <= bmap.Width; j++)
                {
                    Color c;
                    c = bmap.GetPixel(i, j);
                    double pR = c.R ;
                    double pG = c.G ;
                    double pB = c.B ;
                    int x =bmap.Width-j;
                    bmap.SetPixel(i,-x , Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                    pictureBox2.Image = bmap;
                }

            }*/
        

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            Bitmap returnBitmap = new Bitmap(bmap.Height, bmap.Width);
            Graphics g = Graphics.FromImage(returnBitmap);
            if (comboBox2.SelectedIndex == 0)
            {
                g.TranslateTransform((float)bmap.Width / 2, (float)bmap.Height / 2);
                g.RotateTransform(90);
                g.TranslateTransform(-(float)bmap.Width / 2, -(float)bmap.Height / 2);
                g.DrawImage(bmap, new Point(0, 0));
                pictureBox2.Image = returnBitmap;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                g.TranslateTransform((float)bmap.Width / 2, (float)bmap.Height/2 );
                g.RotateTransform(180);
                g.TranslateTransform(-(float)bmap.Width / 2, -(float)bmap.Height/2  );
                g.DrawImage(bmap, new Point(0, 0));
                pictureBox2.Image = returnBitmap;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                g.TranslateTransform((float)bmap.Width / 2, (float)bmap.Height / 2);
                g.RotateTransform(270);
                g.TranslateTransform(-(float)bmap.Width / 2, -(float)bmap.Height / 2);
                g.DrawImage(bmap, new Point(0, 0));
                pictureBox2.Image = returnBitmap;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                g.TranslateTransform((float)bmap.Width / 2, (float)bmap.Height / 2);
                g.RotateTransform(360);
                g.TranslateTransform(-(float)bmap.Width / 2, -(float)bmap.Height / 2);
                g.DrawImage(bmap, new Point(0, 0));
                pictureBox2.Image = returnBitmap;
            }
            pictureBox1.Image = file;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            Color b0, b1, b2, b3, b4, b5, b6, b7, b8;
            double avg = 0;
            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    b0=bmap.GetPixel(i, j);
                    b1=bmap.GetPixel(i + 1, j + 1);
                    b2=bmap.GetPixel(i - 1, j - 1);
                    b3=bmap.GetPixel(i, j + 1);
                    b4=bmap.GetPixel(i, j - 1);
                    b5=bmap.GetPixel(i + 1, j);
                    b6=bmap.GetPixel(i - 1, j);
                    b7=bmap.GetPixel(i + 1, j - 1);
                    b8=bmap.GetPixel(i - 1, j + 1);
                    avg=(b0.R + b1.R + b2.R + b3.R + b4.R + b5.R + b6.R + b7.R + b8.R)/9;
                    bmap.SetPixel(i, j, Color.FromArgb((byte)avg, (byte)avg, (byte)avg));
                }
            pictureBox2.Image = bmap;

            }
            pictureBox1.Image = file;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[] red = new double[9];
            double[] green = new double[9];
            double[] blue = new double[9];
            double avgr = 0, avgg = 0, avgb = 0;
            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    red[0] = bmap.GetPixel(i - 1, j - 1).R;
                    red[1] = bmap.GetPixel(i - 1, j).R;
                    red[2] = bmap.GetPixel(i - 1, j + 1).R;
                    red[3] = bmap.GetPixel(i, j - 1).R;
                    red[4] = bmap.GetPixel(i, j).R;
                    red[5] = bmap.GetPixel(i, j + 1).R;
                    red[6] = bmap.GetPixel(i + 1, j - 1).R;
                    red[7] = bmap.GetPixel(i + 1, j).R;
                    red[8] = bmap.GetPixel(i + 1, j + 1).R;

                    green[0] = bmap.GetPixel(i - 1, j - 1).G;
                    green[1] = bmap.GetPixel(i - 1, j).G;
                    green[2] = bmap.GetPixel(i - 1, j + 1).G;
                    green[3] = bmap.GetPixel(i, j - 1).G;
                    green[4] = bmap.GetPixel(i, j).G;
                    green[5] = bmap.GetPixel(i, j + 1).G;
                    green[6] = bmap.GetPixel(i + 1, j - 1).G;
                    green[7] = bmap.GetPixel(i + 1, j).G;
                    green[8] = bmap.GetPixel(i + 1, j + 1).G;

                    blue[0] = bmap.GetPixel(i - 1, j - 1).B;
                    blue[1] = bmap.GetPixel(i - 1, j).B;
                    blue[2] = bmap.GetPixel(i - 1, j + 1).B;
                    blue[3] = bmap.GetPixel(i, j - 1).B;
                    blue[4] = bmap.GetPixel(i, j).B;
                    blue[5] = bmap.GetPixel(i, j + 1).B;
                    blue[6] = bmap.GetPixel(i + 1, j - 1).B;
                    blue[7] = bmap.GetPixel(i + 1, j).B;
                    blue[8] = bmap.GetPixel(i + 1, j + 1).B;

                    Array.Sort(red);
                    Array.Sort(green);
                    Array.Sort(blue);

                    avgr = red[4];
                    avgg = green[4];
                    avgb = blue[4];
                    bmap.SetPixel(i, j, Color.FromArgb((byte)avgr, (byte)avgg, (byte)avgb));
                }
            }
            pictureBox2.Image = bmap;
            pictureBox1.Image = file;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            double r, g, b;
            double[,] m = new double[3, 3];
            m[0, 0] = 0.0625;
            m[0, 1] = 0.125;
            m[0, 2] = 0.0625;
            m[1, 0] = 0.125;
            m[1, 1] = 0.25;
            m[1, 2] = 0.125;
            m[2, 0] = 0.0625;
            m[2, 1] = 0.125;
            m[2, 2] = 0.0625;
            Bitmap bmap = new Bitmap(file);
            pictureBox1.Image = file;
            Color x, x1, x2, x3, x4, x5, x6, x7, x8;
            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    x = bmap.GetPixel(i, j);
                    x1 = bmap.GetPixel(i + 1, j + 1);
                    x2 = bmap.GetPixel(i - 1, j - 1);
                    x3 = bmap.GetPixel(i, j + 1);
                    x4 = bmap.GetPixel(i, j - 1);
                    x5 = bmap.GetPixel(i + 1, j);
                    x6 = bmap.GetPixel(i - 1, j);
                    x7 = bmap.GetPixel(i + 1, j - 1);
                    x8 = bmap.GetPixel(i - 1, j + 1);
                    r = (x.R * m[0, 0]) + (x1.R * m[0, 1]) + (x2.R * m[0, 2]) + (x3.R * m[1, 0]) + (x4.R * m[1, 1]) + (x5.R * m[1, 2]) + (x6.R * m[2, 0]) + (x7.R * m[2, 1]) + (x8.R * m[2, 2]);
                    g = (x.G * m[0, 0]) + (x1.G * m[0, 1]) + (x2.G * m[0, 2]) + (x3.G * m[1, 0]) + (x4.G * m[1, 1]) + (x5.G * m[1, 2]) + (x6.G * m[2, 0]) + (x7.G * m[2, 1]) + (x8.G * m[2, 2]);
                    b = (x.B * m[0, 0]) + (x1.B * m[0, 1]) + (x2.B * m[0, 2]) + (x3.B * m[1, 0]) + (x4.B * m[1, 1]) + (x5.B * m[1, 2]) + (x6.B * m[2, 0]) + (x7.B * m[2, 1]) + (x8.B * m[2, 2]);
                    bmap.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
                }

            }
            pictureBox2.Image = bmap;
            pictureBox1.Image = file;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            Bitmap bmap1 = new Bitmap(file);
            Bitmap bmap2 = new Bitmap(file1);
            Color x, y;
            double r, g, b;
            for (int i = 0; i < bmap1.Width; i++)
            {
                for (int j = 0; j < bmap1.Height; j++)
                {
                    x = bmap1.GetPixel(i, j);
                    y = bmap2.GetPixel(i, j);
                    if (x.R == y.R && x.G == y.G && x.B == y.B)
                    {
                        r = (x.R - y.R);
                        g = (x.G - y.G);
                        b = (x.B - y.B);

                    }
                    else
                    {
                        r = x.R;
                        g = x.G;
                        b = x.B;
                    }
                    bmap2.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));


                }
            }
            pictureBox1.Image = file;
            pictureBox2.Image = file1;

            for (int i = 0; i < bmap2.Width; i++)
            {
                for (int j = 0; j < bmap2.Height; j++)
                {
                    Color z,n;
                    n = bmap2.GetPixel(i + 1, j + 1);
                    z = bmap2.GetPixel(i, j);
                    if (z.R > 0 && z.G > 0 && z.B > 0)
                    {
                        if(n.R==n.G && n.R==n.B)
                        bmap2.SetPixel(i - 1, j - 1, Color.FromArgb((byte)255, (byte)0, (byte)0));
                    }


                }
            }
            pictureBox3.Image = bmap2;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ff = new OpenFileDialog();

            if (ff.ShowDialog() == DialogResult.OK)
            {
                file1 = Image.FromFile(ff.FileName);
                pictureBox2.Image = file1;

            }
        }
    }
            
   
}
