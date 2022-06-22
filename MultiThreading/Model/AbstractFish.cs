using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Model
{
    public abstract class AbstractFish
    {
        //
        //  Main Part
        //
        public Point Coord { get; set; }
        public Image Texture { get; protected set; }
        public Size TextureSize { get; private set; } = new Size(32, 32);
        public DateTime FeedingTime { get; set; } = DateTime.Now;
        public string Name { get; protected set; }

        //
        // Money
        //
        public double Cost { get; protected set; }

        //
        //  Destination
        //
        public int XAxis { get; set; } = 1;
        public int YAxis { get; set; } = 1;
        
        /* public void Ran(Size windowSize)
         {

            
             button1.Location = new Point(button1.Location.X + XAxis, button1.Location.Y + YAxis);
         }*/
    }
}
