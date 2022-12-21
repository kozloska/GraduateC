using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ob
{
    public class Portal
    {
        //две точки - вход и выход
        public Point input;
        public Point output;
        public float radius = 40;
        //направление нчастиц на выходе из портала
        public float direction;

        //действие на пересечение частицы с входом портала
        public Action<Particle> OnPortalParticle = null;

        public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red),
                input.X - radius, input.Y - radius,
                radius * 2, radius * 2);
            g.DrawEllipse(new Pen(Color.Red),
                output.X - radius, output.Y - radius,
                radius * 2, radius * 2);
            g.DrawLine(new Pen(Color.Red, 2),
                input.X, input.Y,
                output.X, output.Y);
        }

        //пересечение частиц с входом портала
        public void Overlap(Particle particle)
        {
            float gX = input.X - particle.X;
            float gY = input.Y - particle.Y;

            bool overlap = Math.Sqrt(gX * gX + gY * gY) <= radius;

            if (overlap)
            {
                if (OnPortalParticle != null)
                {
                    OnPortalParticle.Invoke(particle);
                }
            }
        }
    }
}
