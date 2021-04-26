using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_6
{
    public partial class Form1 : Form
    {
        int height, width;
        private string odswiez;
        private int value;
        private Boolean jest = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                odswiez = openFileDialog1.FileName;

                pictureBox1.Load(odswiez);
                pictureBox2.Load(odswiez);

                width = pictureBox1.Image.Width;

                height = pictureBox1.Image.Height;

                jest = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                trackBar1.Maximum = 126;
                trackBar1.Minimum = 0;
                wariant_1a();
            }
            else if (radioButton2.Checked)
            {
                trackBar1.Maximum = -1;
                trackBar1.Minimum = -128;
                wariant_1b();
            }
            else if (radioButton3.Checked)
            {
                trackBar1.Maximum = 127;
                trackBar1.Minimum = 1;
                wariant_2a();
            }
            else if (radioButton4.Checked)
            {
                trackBar1.Maximum = -1;
                trackBar1.Minimum = -126;
                wariant_2b();
            }
            else { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (jest)
            {
                pictureBox1.Load(odswiez);
            }
        }

        

        private void wariant_1a()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            value = trackBar1.Value;

            Color k;
            int r, g, b;



            for (int x = 0; x < width; x++)

            {
                for (int y = 0; y < height; y++)

                {

                    k = b2.GetPixel(x, y);
                    

                    
                    r = (127 / (127 - value)) * (k.R - value);
                    
                    if(r > 255)
                    {
                        r = 255;
                    }
                    else if (r < 0)
                    {
                        r = 0;
                    }
                    

                    g = (127 / (127 - value)) * (k.G - value);

                    if (g > 255)
                    {
                        g = 255;
                    }
                    else if (g < 0)
                    {
                        g = 0;
                    }

                    b = (127 / (127 - value)) * (k.B - value);

                    if (b > 255)
                    {
                        b = 255;
                    }
                    else if (b < 0)
                    {
                        b = 0;
                    }

                    b1.SetPixel(x, y, Color.FromArgb(r, g, b));

                }


                pictureBox1.Refresh();

            }
        }
            
        

        private void wariant_1b()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            value = trackBar1.Value;

            Color k;
            int r, g, b;



            for (int x = 0; x < width; x++)

            {
                for (int y = 0; y < height; y++)

                {

                    k = b2.GetPixel(x, y);

                    r = ((127 + value) / 127) * k.R - value;

                    g = ((127 + value) / 127) * k.G - value;
                    
                    b = ((127 + value) / 127) * k.B - value;



                    b1.SetPixel(x, y, Color.FromArgb(r, g, b));

                }


                pictureBox1.Refresh();

            }
        }

        private void wariant_2a()
        { 

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            value = trackBar1.Value;

            Color k;
            int r, g, b;

            

            for (int x = 0; x < width; x++)

            {
                for (int y = 0; y < height; y++)

                {

                    k = b2.GetPixel(x, y);


                    
                        if (k.R < 127)
                        {
                            r = ((127 - value) / 127) * k.R;
                        }
                        else if (k.R >= 127)
                        {
                            r = ((127 - value) / 127) * k.R + 2 * value;
                        }
                        else
                        {
                            r = k.R;
                        }



                        if (k.G < 127)
                        {
                            g = ((127 - value) / 127) * k.G;
                        }
                        else if (k.G >= 127)
                        {
                            g = ((127 - value) / 127) * k.G + 2 * value;
                        }
                        else
                        {
                            g = k.G;
                        }

                        if (k.B < 127)
                        {
                            b = ((127 - value) / 127) * k.B;
                        }
                        else if (k.B >= 127)
                        {
                            b = ((127 - value) / 127) * k.B + 2 * value;
                        }
                        else
                        {
                            b = k.B;
                        }
                    
                   


                    b1.SetPixel(x, y, Color.FromArgb(r, g, b));

                }


                pictureBox1.Refresh();

            }
        }

        private void wariant_2b()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            value = trackBar1.Value;

            Color k;
            int r, g, b;



            for (int x = 0; x < width; x++)

            {
                for (int y = 0; y < height; y++)

                {

                    k = b2.GetPixel(x, y);

                    if (k.R < 127 + value)
                    {
                        r = (127 / (127 + value)) * k.R;
                    }
                    else if (k.R > 127 - value)
                    {
                        r = (127 * k.R + 255 * value) / (127 + value);
                    }
                    else
                    {
                        r = 127;
                    }



                    if (k.G < 127 + value)
                    {
                        g = (127 / (127 + value)) * k.G;
                    }
                    else if (k.G > 127 - value)
                    {
                        g = (127 * k.G + 255 * value) / (127 + value);
                    }
                    else
                    {
                        g = 127;
                    }



                    if (k.B < 127 + value)
                    {
                        b = (127 / (127 + value)) * k.B;
                    }
                    else if (k.B > 127 - value)
                    {
                        b = (127 * k.B + 255 * value) / (127 + value);
                    }
                    else
                    {
                        b = 127;
                    }







                    b1.SetPixel(x, y, Color.FromArgb(r, g, b));

                }


                pictureBox1.Refresh();

            }
        }
    }
}
