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

using WindowsFormsApp1.ob;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public int task = 2;
        List<Emitter> emitters = new List<Emitter>();
        List<Circle> circles = new List<Circle>();
        Emitter emitter; // добавим поле для эмиттера 
        TopEmitter emitter2; // добавим поле для эмиттера
        Emitter emitter3; // добавим поле для эмиттера
        Emitter emitter4; // добавим поле для эмиттера
        Portal portal = null; // добавим поле для портала задание 4
        Radar radar;//добавим поле для радара задние 8

        public Form1()
        {
            InitializeComponent();
            if(task == 2)
            {
                button3.Visible = false;
                label5.Visible = false;
                lblY.Visible = false;
                tbRadiusPortal.Visible = false;
                lblRadiusPortal.Visible = false;
                button3.Visible = false;
            }

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
            emitter2 = new TopEmitter// создаю эмиттер и привязываю его к полю emitter2
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            emitters.Add(this.emitter2);
            circles.Add(new Circle   // создаю круг и привязываю его к листу
            {
                X = 70,
                Y = 50,
                radius = 35,
                color = Color.Yellow
            });

            circles.Add(new Circle  //создаю круг и привязываю его к листу
            {
                X = 170,
                Y = 50,
                radius = 35,
                color = Color.Red
            });

            circles.Add(new Circle  //создаю круг и привязываю его к листу
            {
                X = 270,
                Y = 50,
                radius = 35,
                color = Color.Blue
            });
            circles.Add(new Circle  //создаю круг и привязываю его к листу
            {
                X = 370,
                Y = 50,
                radius = 35,
                color = Color.Green
            });

            circles.Add(new Circle  //создаю круг и привязываю его к листу
            {
                X = 470,
                Y = 50,
                radius = 35,
                color = Color.Pink
            });
            radar = new Radar   //создаю радар 
            {
                X = 50,
                Y = 50,
                R = 75,
            };
            emitter3 = new Emitter // создаю эмиттер и привязываю его к полю emitter3
            {
                Direction = 90,
                Spreading = 90,
                SpeedMin = 8,
                SpeedMax = 25,
                ParticlesPerTick = 10,
                LifeMax = 120,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,

            };
            emitter4 = new Emitter // создаю эмиттер и привязываю его к полю emitter4
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

        private void timer1_Tick(object sender, EventArgs e) // метод таймера
        {

            if (task == 4) // если задание номер 4
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
                        g.Clear(Color.Black); // ЧЕРНЫЙ ФОН 
                        emitter.Render(g);
                        portal.Draw(g);  // рендерим систему


                    }

                    picDisplay.Invalidate();

                }
            }

            if (task == 2) // если задание номер 2
            {
                emitter4.UpdateState(); // каждый тик обновляем систему

                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                        g.Clear(Color.Black); // ЧЕРНЫЙ ФОН 
                        emitter4.Render(g);
                }
                picDisplay.Invalidate();

            }
            if (task == 5) // если задание номер 5
            {

                emitter2.UpdateState();// каждый тик обновляем систему
                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    foreach (var circle in circles)
                    {
                        foreach (var particle in emitter2.particles)
                        {
                            circle.ImpactParticle(particle);
                        }
                    }
                    g.Clear(Color.Black);//чёрный фон
                    emitter2.Render(g);
                    foreach (var circle in circles)
                    {
                        circle.Render(g);

                    }
                    picDisplay.Invalidate();
                }

            }
            if (task == 8) // если задание 8
            {
                emitter3.UpdateState();// каждый тик обновляем систему
                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.Black);
                    foreach (var particle in emitter3.particles)
                    {
                        radar.ImpactParticle(particle);
                    }
                    emitter3.Render(g);
                    radar.Render(g);
                    picDisplay.Invalidate();
                }

            }
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e) // метод действия мышки
        {
            if (task == 4)// если задание номер 4
            {
                //если портал не создан
                if (portal == null)
                {
                    portal = new Portal() // координаты портала равны курсору
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
            if (task == 8) // если задание номер 8
            {
                radar.X = e.X;//координаты радара равны координатам курсора мышки
                radar.Y = e.Y;
            }
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)//увеличение радиуса окружности радара 
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

        private void trackBar1_Scroll(object sender, EventArgs e) //изменение разброса направления частиц эмиттера
        {

            if (task == 4)
            {
                emitter.Spreading = tbSpreading.Value;
                lblSpreading.Text = tbSpreading.Value.ToString();
            }
            if (task == 2)
            {
                emitter4.Spreading = tbSpreading.Value;
                lblSpreading.Text = tbSpreading.Value.ToString();
            }
            if (task == 5)
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

        private void trackBar1_Scroll_1(object sender, EventArgs e)//изменение направления частиц эмиттера
        {

            if (task == 4)
            {
                emitter.Direction = tbDirection.Value;
                lblDirection.Text = tbDirection.Value.ToString();
            }
            if (task == 2)
            {
                emitter4.Direction = tbDirection.Value;
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

        private void trackBar1_Scroll_2(object sender, EventArgs e)//изменение скорости частиц эмиттера
        {
            if (task == 2)
            {
                //минимальная скорость = 20% от максимальной
                emitter4.SpeedMin = (int)(tbSpeed.Value * 0.2f);
                emitter4.SpeedMax = tbSpeed.Value;
                lblSpeed.Text = tbSpeed.Value.ToString();
            }
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

        private void button2_Click(object sender, EventArgs e) // выполнение задания номер 2
        {
            task = 2;
            button3.Visible = false;
            label5.Visible = false;
            lblY.Visible = false;
            tbRadiusPortal.Visible = false;
            lblRadiusPortal.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e) // выполнение задания номер 4
        {
            task = 4;
            button3.Text = "Выбрать цвет портала";
            tbY.Visible = false;
            lblY.Visible = false;
            button3.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)//выполнение задания номер 8
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

        private void trackBar1_Scroll_3(object sender, EventArgs e)//изменение времени жизни частиц эмиттера
        {
            if (task == 4)
            {
                //минимальная продолжительность жизни = 25% от максимума
                emitter.LifeMin = tbLife.Value / 4;
                emitter.LifeMax = tbLife.Value;
                lblLife.Text = tbLife.Value.ToString();
            }
            if (task == 2)
            {
                //минимальная продолжительность жизни = 25% от максимума
                emitter4.LifeMin = tbLife.Value / 4;
                emitter4.LifeMax = tbLife.Value;
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

        private void trackBar2_Scroll(object sender, EventArgs e) //изменение радиуса круга и портала
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

        private void tbTick_Scroll(object sender, EventArgs e)//изменение количества частиц эмиттера
        {
            if (task == 4)
            {
                emitter.ParticlesPerTick = tbTick.Value;
                lblTick.Text = tbTick.Value.ToString();
            }
            if (task == 2)
            {
                emitter4.ParticlesPerTick = tbTick.Value;
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

        private void button3_Click_2(object sender, EventArgs e) // выбор палитры для задания 4 и 5
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

        private void button5_Click(object sender, EventArgs e)//выполнить задание номер 5
        {

            emitter2.task = 5;
            task = 5;
            button3.Text = "Выбрать цвет снега";
            tbY.Visible = true;
            lblY.Visible = true;
            tbRadiusPortal.Visible = true;
            lblRadiusPortal.Visible = true;
            label5.Visible = true;
            button3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbY_Scroll(object sender, EventArgs e) //изменение направления кругов для задания номер 5
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
