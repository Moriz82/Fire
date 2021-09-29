﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nexus.Graphics.Colors;
using Color = System.Drawing.Color;

namespace RBGColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Hide();
            DoCoolStuff(this);
        }
        
        
        
        public void DoCoolStuff(Form form)
        {
            form.Width = 1000;
            form.Height = 800;
            
            Bitmap map = new Bitmap(form.Width, form.Height);

            for (int x = 0; x < Width; x++)
            {
                for (int u = 0; u < Height; u++)
                {
                    map.SetPixel();
                }
            }
            
            form.Height = form.Height+40;
            Random random = new Random();
            Color[] p = GenPal(256);

            for (int x = 0; x < map.Width; x++)
            {
                map.SetPixel(x,map.Height-1, p[random.Next(256)]);
                map.SetPixel(x,map.Height-2, p[random.Next(256)]);
            }
            
            for (int y = map.Height - 3; y > 1; y--)
            {
                for (int x = 1; x < map.Width-1; x++)
                {
                    Color c1 = map.GetPixel(x - 1, y + 1);
                    Color c2 = map.GetPixel(x, y + 1);
                    Color c3 = map.GetPixel(x, y + 2);
                    Color c4 = map.GetPixel(x + 1, y + 1);

                    int r = ((c1.R + c2.R + c3.R + c4.R) /4);
                    int g = ((c1.G + c2.G + c3.G + c4.G) /4);
                    int b = ((c1.B + c2.B + c3.B + c4.B) /4);
                    
                    Color c = Color.FromArgb(r,g,b);
                    
                    map.SetPixel(x, y, c);
                }
            }
            Thread.Sleep(10);
            BackgroundImage = map;
        }

        public static Color[] GenPal(int num)
        {
            Color[] pal = new Color[num];

            for (int i = 0; i < pal.Length/2; i++)
            {
                HsbColor hsbColor = new HsbColor((float) 42 / 360, 1, (float) i * 2 / pal.Length);
                Nexus.Graphics.Colors.Color c = hsbColor.ToRgbColor();
                pal[i] = Color.FromArgb(c.R, c.G, c.B);
            }
            for (int i = pal.Length/2; i < pal.Length; i++)
            {
                HsbColor hsbColor = new HsbColor((float) 42 / 360, (float)pal.Length/2/i, (float)1);
                Nexus.Graphics.Colors.Color c = hsbColor.ToRgbColor();
                pal[i] = Color.FromArgb(c.R, c.G, c.B);
            }
            
            return pal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoCoolStuff(this);
        }
    }
}