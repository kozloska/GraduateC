using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    public class Circle : IImpactPoint
    {
        public float radius;
        public Color color;
        public Action<Particle> OnCirclelParticle = null;

        public override void Render(Graphics g)
        {
            //Нарисовать точку
            g.DrawEllipse(
                   new Pen(color, 3),
                   X - radius / 2,
                   Y - radius / 2,
                   radius,
                   radius
               );
        }
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы


            if (r + particle.Radius < radius / 2)  // если частица оказалось внутри окружности
            {
                (particle as ParticleColorful).FromColor = color;
            }


        }
    }

    public class Radar : IImpactPoint
    {
        public int R; 
        public int count = 0;
        public Action<Particle> DestroyParticle;
        public override void Render(Graphics g)
        {

            g.DrawEllipse(new Pen(Color.White, 4), X - R / 2, Y - R / 2, R, R);
            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
            //выводим количество частиц
            g.DrawString($"{count}", new Font("Verdana", 20), new SolidBrush(Color.Green), X, Y, stringFormat);

        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            //меняем цвет частицы на исходный
            (particle as ParticleColorful).FromColor = Color.Gold;
            (particle as ParticleColorful).ToColor = Color.FromArgb(0, Color.Red);

            if (r + particle.Radius < R / 2)  // если частица оказалось внутри окружности            
            {
                //меняем её цвет
                (particle as ParticleColorful).FromColor = Color.White;
                (particle as ParticleColorful).ToColor = Color.FromArgb(0, Color.White);
                //увеличиваем счётчик
                count++;
            }

        }
    }
}
