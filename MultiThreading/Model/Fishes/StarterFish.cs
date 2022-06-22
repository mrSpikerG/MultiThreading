using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Model.Fishes
{
    public class StarterFish : AbstractFish
    {
        public StarterFish(Point coord)
        {
            this.Cost = 100;
            this.Name = "Goldfish";
            this.Coord = coord;
            this.Texture = Image.FromFile("resources\\textures\\fish\\download.png");
        }        
    }
}
