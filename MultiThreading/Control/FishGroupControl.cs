using MultiThreading.Model;
using MultiThreading.Model.Fishes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Control
{
    public class FishGroupControl
    {
        public Size ClientSize { get; set; }
        public static List<AbstractFish> FishGroup { get; private set; }
        public List<Food> MeatBalls { get; set; }


        //Death Time
        private TimeSpan DeathTime = new TimeSpan(0, 0, 10);

        public FishGroupControl()
        {
            this.MeatBalls = new List<Food>();
            FishGroup = new List<AbstractFish>();
        }

        public static bool tryAddFish(AbstractFish fish)
        {
            if (fish.Cost <= Form1.Money)
            {
                fish.FeedingTime = DateTime.Now;
                FishGroup.Add(fish);
                Form1.Money = Form1.Money - fish.Cost;
                Form1.coinlabel.Text = Form1.Money.ToString();
                return true;
            }
            return false;
        }
        public void addFood(int x, int y)
        {
            this.MeatBalls.Add(new Food(new Point(x - 25, y - 50)));
        }
        public void MakeStep()
        {
            while (true)
            {
                try
                {
                    foreach (AbstractFish fish in FishGroup)
                    {
                        if (fish.Coord.X < 0 || fish.Coord.X + 32 >= this.ClientSize.Width)
                        {
                            fish.Texture.RotateFlip(RotateFlipType.Rotate180FlipY);
                            fish.XAxis = -fish.XAxis;
                        }
                        if (fish.Coord.Y < 0 || fish.Coord.Y + 32 >= this.ClientSize.Height)
                        {
                            fish.YAxis = -fish.YAxis;
                        }

                        //this.BeginInvoke(new Action(() =>
                        //{
                        if (DateTime.Now - fish.FeedingTime >= DeathTime)
                        {
                            FishGroup.Remove(fish);
                        }
                        fish.Coord = new Point(fish.Coord.X + fish.XAxis, fish.Coord.Y);
                        //}));


                        Task.Factory.StartNew(() =>
                        {
                            Rectangle TEMP1 = new Rectangle(fish.Coord, new Size(50, 50));
                            foreach (var food in MeatBalls)
                            {
                                Rectangle TEMP2 = new Rectangle(food.Location, new Size(50, 50));
                                if (TEMP1.IntersectsWith(TEMP2))
                                {
                                    fish.FeedingTime = DateTime.Now;
                                    Form1.Money += 11;
                                    Form1.coinlabel.Text = Form1.Money.ToString();
                                    this.MeatBalls.Remove(food);
                                }
                            }
                        });
                    }
                }
                catch (Exception e)
                {

                }
                Thread.Sleep(50);
            }
        }

        public static Image scale(Image img, int maxWidth, int maxHeight)
        {
            double scale = 1;

            if (img.Width > maxWidth || img.Height > maxHeight)
            {
                double scaleW, scaleH;

                scaleW = maxWidth / (double)img.Width;
                scaleH = maxHeight / (double)img.Height;

                scale = scaleW < scaleH ? scaleW : scaleH;
            }
            return img.GetThumbnailImage((int)(img.Width * scale), (int)(img.Height * scale), null, IntPtr.Zero);
        }
    }
}
