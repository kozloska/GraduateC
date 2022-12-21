using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
