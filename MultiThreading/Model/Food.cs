using MultiThreading.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Model
{
    public class Food
    {
        public Point Location { get; private set; }
        public Image Picture { get; private set; }

        public Food(Point coord)
        {
            this.Picture = FishGroupControl.scale(Image.FromFile("resources\\textures\\food.png"), 50, 50);
            this.Location = coord;
        }

    }
}
