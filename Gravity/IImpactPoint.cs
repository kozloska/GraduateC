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
        public int radius;
        public static Color color = Color.Yellow;

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
            float partX = X - particle.X;
            float partY = Y - particle.Y;

            double r = Math.Sqrt(partX * partX + partY * partY);
            //Если частица внутри точки
            if (r < radius && particle.Life > 0)
            {
                //Перекрасить частицу
                (particle as ParticleColorful).FromColor = color;
            }
        }
    }
}
