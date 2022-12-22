using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public int task = 0;
        List<Emitter> emitters = new List<Emitter>();
        List<Circle> circles = new List<Circle>();
        Emitter emitter; // добавим поле для эмиттера
        TopEmitter emitter2; // добавим поле для эмиттера
        Emitter emitter3; // добавим поле для эмиттера
        Portal portal = null;
        Radar radar;



        //  GravityPoint point1; // добавил поле под первую точку
        //GravityPoint point2; // добавил поле под вторую точку


        public Form1()
        {
            InitializeComponent();

            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
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
            emitter2 = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            emitters.Add(this.emitter2);

            circles.Add(new Circle
            {
                X = 70,
                Y = 50,
                radius = 35,
                color = Color.Yellow
            });

            circles.Add(new Circle
            {
                X = 170,
                Y = 50,
                radius = 35,
                color = Color.Red
            });

            circles.Add(new Circle
            {
                X = 270,
                Y = 50,
                radius = 35,
                color = Color.Blue
            });
            circles.Add(new Circle
            {
                X = 370,
                Y = 50,
                radius = 35,
                color = Color.Green
            });

            circles.Add(new Circle
            {
                X = 470,
                Y = 50,
                radius = 35,
                color = Color.Pink
            });
            radar = new Radar
            {
                X = 50,
                Y = 50,
                R = 75,
            };
            emitter3 = new Emitter
            {
                Direction = 90,
                Spreading = 90,
                SpeedMin = 8,
                SpeedMax = 25,
                ParticlesPerTick = 10,
                LifeMax = 120,

                //       ColorFrom = Color.Gold,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),

                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,

            };
            
        }
     
       private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (task == 4)
            {
                emitter.UpdateState(); // каждый тик обновляем систему

                using (var g = Graphics.FromImage(picDisplay.Image))
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

                    picDisplay.Invalidate();

                }
            }
            if (task == 5)
            {

                emitter2.UpdateState();
                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    //emitter2.Render(g);
                    //ColorFrom = Color.White;
                    foreach (var circle in circles)
                    {
                        foreach (var particle in emitter2.particles)
                        {
                            circle.ImpactParticle(particle);
                        }
                    }
                    g.Clear(Color.Black);
                    emitter2.Render(g);
                    foreach (var circle in circles)
                    {
                        circle.Render(g);

                    }
                    //emitter2.Render(g);
                    picDisplay.Invalidate();
                }

            }
            if (task == 8)
            {
                emitter3.UpdateState();
                using (var g = Graphics.FromImage(picDisplay.Image))
                {

                    g.Clear(Color.Black);
                    /*if (Math.Pow(emitter3.X - radar.X, 2) + Math.Pow(emitter3.Y - radar.Y, 2) < Math.Pow(radar.R / 2, 2))
                    {
                        emitter3.ColorFrom = Color.Black; ;
                        emitter3.ColorTo = Color.FromArgb(0, Color.Black);
                    }
                    else
                    {
                        emitter3.ColorFrom = Color.Gold;
                        emitter3.ColorTo = Color.FromArgb(0, Color.Red);
                    }*/
                    foreach (var particle in emitter3.particles)
                    {
                        radar.ImpactParticle(particle);
                        /*if (Math.Pow(emitter3.X - radar.X, 2) + Math.Pow(emitter3.Y - radar.Y, 2) < Math.Pow(radar.R / 2, 2))
                        {
                            emitter3.ColorFrom = Color.Red;
                            emitter3.ColorTo = Color.FromArgb(0, Color.Black);
                        }
                        else
                        {
                            emitter3.ColorFrom = Color.Gold;
                            emitter3.ColorTo = Color.FromArgb(0, Color.Red);
                        }*/
                    }
                    emitter3.Render(g);
                    radar.Render(g);
                    picDisplay.Invalidate();
                    // emitter3.UpdateState(); // каждый тик обновляем систему

                    /*using (var g = Graphics.FromImage(picDisplay.Image))
                    {
                        /* if (Math.Pow(emitter3.X - radar.X, 2) + Math.Pow(emitter3.Y - radar.Y, 2) < Math.Pow(radar.R / 2, 2))
                         {
                             emitter3.ColorFrom = Color.Red ;
                             emitter3.ColorTo = Color.FromArgb(0, Color.Black);
                         }
                         else
                         {
                             emitter3.ColorFrom = Color.Gold;
                             emitter3.ColorTo = Color.FromArgb(0, Color.Red);
                         }
                        g.Clear(Color.Black); // А ЕЩЕ ЧЕРНЫЙ ФОН СДЕЛАЮ
                        radar.Render(g);
                        emitter3.Render(g);
                        radar.Render(g);
                    }*/
                }

            }
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
            if (task == 8)
            {
                radar.X = e.X;
                radar.Y = e.Y;
                /*if (e.Delta > 0)
                {
                    radar.R = radar.R + 5;
                }

                else
                {
                    //минимальный радиус для предотвращения вырождения круга
                    if (radar.R > 30)
                    {
                        radar.R = radar.R - 5;
                    }

                }*/

            }
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                radar.R = radar.R + 5;
            }

            else
            {
                //минимальный радиус для предотвращения вырождения круга
                if (radar.R > 30)
                {
                    radar.R = radar.R - 5;
                }

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            if (task == 4)
            {
                emitter.Spreading = tbSpreading.Value;
                lblSpreading.Text = tbSpreading.Value.ToString();
            }
            if(task == 5)
            {
                emitter2.Spreading = tbSpreading.Value;
                lblSpreading.Text = tbSpreading.Value.ToString();
            }
            if (task == 8)
            {
                emitter3.Spreading = tbSpreading.Value;
                lblSpreading.Text = tbSpreading.Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {

            if (task == 4)
            {
                emitter.Direction = tbDirection.Value;
                lblDirection.Text = tbDirection.Value.ToString();
            }

            if (task == 5)
            {
                emitter2.Direction = tbDirection.Value;
                lblDirection.Text = tbDirection.Value.ToString();
            }
            if (task == 8)
            {
                emitter3.Direction = tbDirection.Value;
                lblDirection.Text = tbDirection.Value.ToString();
            }
        }

        private void trackBar1_Scroll_2(object sender, EventArgs e)
        {

            if (task == 4)
            {
                //минимальная скорость = 20% от максимальной
                emitter.SpeedMin = (int)(tbSpeed.Value * 0.2f);
                emitter.SpeedMax = tbSpeed.Value;
                lblSpeed.Text = tbSpeed.Value.ToString();
            }
            if (task == 5)
            {
                //минимальная скорость = 20% от максимальной
                emitter2.SpeedMin = (int)(tbSpeed.Value * 0.2f);
                emitter2.SpeedMax = tbSpeed.Value;
                lblSpeed.Text = tbSpeed.Value.ToString();
            }
            if (task == 8)
            {
                //минимальная скорость = 20% от максимальной
                emitter3.SpeedMin = (int)(tbSpeed.Value * 0.2f);
                emitter3.SpeedMax = tbSpeed.Value;
                lblSpeed.Text = tbSpeed.Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            task = 4;
            button3.Text = "Выбрать цвет портала";
            tbY.Visible = false;
            lblY.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            task = 8;
            button3.Visible = false;
            label5.Visible = false;
            lblY.Visible = false;
            tbRadiusPortal.Visible = false;
            lblRadiusPortal.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_3(object sender, EventArgs e)
        {

            if (task == 4)
            {
                //минимальная продолжительность жизни = 25% от максимума
                emitter.LifeMin = tbLife.Value / 4;
                emitter.LifeMax = tbLife.Value;
                lblLife.Text = tbLife.Value.ToString();
            }
            if (task == 5)
            {
                //минимальная продолжительность жизни = 25% от максимума
                emitter2.LifeMin = tbLife.Value / 2;
                emitter2.LifeMax = tbLife.Value;
                lblLife.Text = tbLife.Value.ToString();
            }
            if (task == 8)
            {
                //минимальная продолжительность жизни = 25% от максимума
                emitter3.LifeMin = tbLife.Value / 2;
                emitter3.LifeMax = tbLife.Value;
                lblLife.Text = tbLife.Value.ToString();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (task == 4)
            {
                if (portal != null)
                {
                    portal.radius = (float)tbRadiusPortal.Value;
                    lblRadiusPortal.Text = tbRadiusPortal.Value.ToString();
                }
            }
            if (task == 5)
            {
                foreach (Circle circle in circles)
                {
                    circle.radius = (float)tbRadiusPortal.Value;
                    lblRadiusPortal.Text = tbRadiusPortal.Value.ToString();
                }
                
            }
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            if (task == 4)
            {
                emitter.ParticlesPerTick = tbTick.Value;
                lblTick.Text = tbTick.Value.ToString();
            }
        }

        private void tbTick_Scroll(object sender, EventArgs e)
        {
            if (task == 4)
            {
                emitter.ParticlesPerTick = tbTick.Value;
                lblTick.Text = tbTick.Value.ToString();
            }
            if (task == 5)
            {
                emitter2.ParticlesPerTick = tbTick.Value;
                lblTick.Text = tbTick.Value.ToString();
            }
            if (task == 8)
            {
                emitter3.ParticlesPerTick = tbTick.Value;
                lblTick.Text = tbTick.Value.ToString();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            if (task == 4)
            {
                colorDialog1.ShowDialog();
                portal.color = colorDialog1.Color;
            }
            if(task == 5)
            {
                colorDialog1.ShowDialog();
                emitter2.ColorFrom = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            task = 5;
            emitter2.task = 2;
            button3.Text = "Выбрать цвет снега";
            tbY.Visible = true;
            lblY.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbY_Scroll(object sender, EventArgs e)
        {
            if (task == 5)
            {
                foreach (var circle in circles)
                {
                    circle.Y = tbY.Value;
                }
            }
        }
    }
}
