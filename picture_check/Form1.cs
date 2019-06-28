using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picture_check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMyImage("C:/Users/Misha_MKR/Documents/Visual Studio 2015/Projects/picture_check/0005.bmp", 512, 384);
            ShowMyImage2("C:/Users/Misha_MKR/Documents/Visual Studio 2015/Projects/picture_check/0006.bmp", 512, 384);
        }

        public Bitmap MyImage;
        public Bitmap MyImage2;
        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            if (MyImage != null)
            {
                MyImage.Dispose();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)MyImage;
        }

        public void ShowMyImage2(String fileToDisplay, int xSize, int ySize)
        {
            if (MyImage2 != null)
            {
                MyImage2.Dispose();
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage2 = new Bitmap(fileToDisplay);
            pictureBox2.ClientSize = new Size(xSize, ySize);
            pictureBox2.Image = (Image)MyImage2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bit = Convert.ToInt32(textBox3.Text);
            int[] maspic1 = new int[pictureBox1.Size.Width * 3*bit];
            int[] maspic2 = new int[pictureBox1.Size.Width * 3*bit];
            int countpic1 = 0;
            int countpic2 = 0;
            int i = Convert.ToInt32(textBox5.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            Color pixelColor;
            //for (int i = 0; i < pictureBox1.Size.Width; i++)
            for (int j = 0; j < pictureBox1.Size.Height; j++)
            {
                pixelColor = MyImage.GetPixel(i, j);
                byte r = pixelColor.R;
                byte g = pixelColor.G;
                byte b = pixelColor.B;

                for (int count = 0; count < bit; count++)
                {
                    maspic1[countpic1] = r % 2;
                    countpic1++;
                    textBox1.Text += (r % 2).ToString();
                    r = (byte)(r / 2);
                }

                for (int count = 0; count < bit; count++)
                {
                    maspic1[countpic1] = g % 2;
                    countpic1++;
                    textBox1.Text += (g % 2).ToString();
                    g = (byte)(g / 2);
                }

                for (int count = 0; count < bit; count++)
                {
                    maspic1[countpic1] = b % 2;
                    countpic1++;
                    textBox1.Text += (b % 2).ToString();
                    b = (byte)(b / 2);
                }

                pixelColor = MyImage2.GetPixel(i, j);
                r = pixelColor.R;
                g = pixelColor.G;
                b = pixelColor.B;

                for (int count = 0; count < bit; count++)
                {
                    maspic2[countpic2] = r % 2;
                    countpic2++;
                    textBox2.Text += (r % 2).ToString();
                    r = (byte)(r / 2);
                }

                for (int count = 0; count < bit; count++)
                {
                    maspic2[countpic2] = g % 2;
                    countpic2++;
                    textBox2.Text += (g % 2).ToString();
                    g = (byte)(g / 2);
                }

                for (int count = 0; count < bit; count++)
                {
                    maspic2[countpic2] = b % 2;
                    countpic2++;
                    textBox2.Text += (b % 2).ToString();
                    b = (byte)(b / 2);
                }
            }

            int mismatch_counter = 0;
            for (i = 0; i < pictureBox1.Size.Width; i++)
                if (maspic1[i] != maspic2[i])
                {
                    mismatch_counter++;
                    //textBox8.Text = (i/3).ToString();
                }
            textBox4.Text = mismatch_counter.ToString();

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color pixelColor2 = MyImage.GetPixel(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
            byte r2 = pixelColor2.R;
            byte g2 = pixelColor2.G;
            byte b2 = pixelColor2.B;
            Color pixelColor3 = MyImage2.GetPixel(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
            byte r3 = pixelColor3.R;
            byte g3 = pixelColor3.G;
            byte b3 = pixelColor3.B;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            for (int i = 0; i < 8; i++)
            {
                textBox8.Text += (r2 % 2).ToString();
                r2 = (byte)(r2 / 2);
                textBox9.Text += (g2 % 2).ToString();
                g2 = (byte)(g2 / 2);
                textBox10.Text += (b2 % 2).ToString();
                b2 = (byte)(b2 / 2);
                textBox13.Text += (r3 % 2).ToString();
                r3 = (byte)(r3 / 2);
                textBox12.Text += (g3 % 2).ToString();
                g3 = (byte)(g3 / 2);
                textBox11.Text += (b3 % 2).ToString();
                b3 = (byte)(b3 / 2);
            }
        }
    }
}
