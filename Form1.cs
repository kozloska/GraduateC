using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Gravity;
using WindowsFormsApp1.ob;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int task = 4;
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера
        Portal portal = null;

      //  GravityPoint point1; // добавил поле под первую точку
        //GravityPoint point2; // добавил поле под вторую точку


        public Form1()
        {
            InitializeComponent();

            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
        }

       /* private void task1(Graphics g)
        {
            int Xvector1, Xvector2, Yvector1, Yvector2;

            tbdValue1 = tbDirection.Value;
            speedV1 = speedBar.Value;
            tb1 = trackBar2.Value;

            g.DrawEllipse(new Pen(Color.LightCoral, 4), picDisplay.Width / 2 - Xcirlce / 2, picDisplay.Height / 2 - Ycirlce / 2 + 1, Xcirlce, Ycirlce);
            pos = pos + speed;

            emitter.X = (int)(picDisplay.Width / 2 + Xcirlce / 2 * Math.Cos(pos));
            emitter.Y = (int)(picDisplay.Height / 2 + Ycirlce / 2 * Math.Sin(pos));
            //координаты вектора радиуса
            Xvector1 = picDisplay.Width / 2 - emitter.X;
            Yvector1 = picDisplay.Height / 2 - emitter.Y;
            //координаты вектора касательной
            //   x = 0-(emitter.Y - picDisplay.Height / 2);
            //   y = emitter.X - picDisplay.Width / 2;
            Yvector2 = -5;
            Xvector2 = 5 - emitter.Y;
            //  angle = (180 /Math.PI)*Math.Acos(Math.Cos((Yvector1*Yvector2)/(Math.Sqrt(Math.Pow(Yvector2, 2) )* Math.Sqrt(Math.Pow(Xvector1,2)+ Math.Pow(Yvector1, 2)))));
            angle = (290 / Math.PI) * Math.Acos(Math.Cos((Yvector1 * Yvector2 + Xvector2 * Xvector1) / (Math.Sqrt(Math.Pow(Yvector2, 2) + Math.Pow(Xvector2, 2)) * Math.Sqrt(Math.Pow(Xvector1, 2) + Math.Pow(Yvector1, 2)))));
            //в зависимости от четверти оркужности задаём определённый угл поворота
            if (emitter.X < picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2)
            {
                emitter.Direction = -(int)(angle);
            }
            if (emitter.X < picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {
                emitter.Direction = 180 + (int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {
                emitter.Direction = 180 - (int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2)
            {
                emitter.Direction = (int)(angle);
            }
            emitter.Spreading = 100;


        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                if(task == 4)
                {
                    if (portal != null)
                    {

                        foreach (var particle in emitter.particles)
                        {
                            portal.Overlap(particle);
                        }
                        g.Clear(Color.Black); // А ЕЩЕ ЧЕРНЫЙ ФОН СДЕЛАЮ
                        emitter.Render(g);
                        portal.Draw(g);  // рендерим систему
                                           
                    }
                }
               
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            /* // это не трогаем
             foreach (var emitter in emitters)
             {
                 emitter.MousePositionX = e.X;
                 emitter.MousePositionY = e.Y;
             }

             // а тут передаем положение мыши, в положение гравитона
             point2.X = e.X;
             point2.Y = e.Y;*/
            if (task == 4)
            {
                //если портал не создан
                if (portal == null)
                {
                    portal = new Portal()
                    {
                        input = new Point(e.X, e.Y),
                        output = new Point(e.X, e.Y),
                        direction = emitter.Direction
                    };

                    //реакция на пересечение частицы с входом портала
                    portal.OnPortalParticle += (particle) =>
                    {
                        particle.X = portal.output.X;
                        particle.Y = portal.output.Y;

                        //перерасчёт направления с учётом направления портала
                        particle.SpeedX = (float)(Math.Cos((float)portal.direction / 180 * Math.PI) * particle.SpeedX);
                        particle.SpeedY = (float)(-Math.Sin((float)portal.direction / 180 * Math.PI) * particle.SpeedY);
                    };
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        portal.input.X = e.X;
                        portal.input.Y = e.Y;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        portal.output.X = e.X;
                        portal.output.Y = e.Y;
                    }
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
             emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll_2(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            task = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
