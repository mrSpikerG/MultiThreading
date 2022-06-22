using MultiThreading.Control;
using MultiThreading.Model;
using MultiThreading.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Form1 : Form
    {
        public FishGroupControl control;
        public static double Money;

        //
        //  Components
        //
        private PictureBox pic;
        public static Label coinlabel;
        private Button button;
        private Shop shop;


        public Form1()
        {
            InitializeComponent();
            this.control = new FishGroupControl();
            this.control.ClientSize = this.ClientSize;
            this.Paint += DrawFish;
            this.SizeChanged += ChangeControlSize;
            this.Click += AddFood;
            this.Text = "Aquarium";
            Money = 10000;

            //
            //  Coin image
            //
            this.pic = new PictureBox();
            this.pic.Image = FishGroupControl.scale(Image.FromFile("resources\\textures\\coin.png"), 50, 50);
            this.pic.Location = new Point(10, 10);
            this.pic.Size = new Size(50, 50);
            this.pic.BackColor = Color.Transparent;
            this.Controls.Add(this.pic);


            //
            // Coin number
            //
            coinlabel = new Label();
            coinlabel.Location = new Point(pic.Width + 20, 10);
            coinlabel.Size = new Size(50, 50);
            coinlabel.Text = Money.ToString();
            coinlabel.AutoSize = true;
            coinlabel.BackColor = Color.Transparent;
            Controls.Add(coinlabel);


            //
            //  Shop
            //
            this.button = new Button();
            this.button.BackgroundImage = Image.FromFile("resources\\textures\\building.png");
            this.button.Click += OpenShop;
            this.button.BackColor = Color.Transparent;
            this.button.Size = new Size(50, 50);
            this.button.Location = new Point(this.ClientSize.Width - 60, this.ClientSize.Height - 60);
            this.Controls.Add(this.button);





            DoubleBuffered = true;
            this.Update();
        }


        private void OpenShop(object sender, EventArgs e)
        {
            this.shop = new Shop();
            this.shop.Show();

        }

        private void AddFood(object sender, EventArgs e)
        {
            this.control.addFood(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            Money -= 10;
            coinlabel.Text = Money.ToString();
          //  this.Invalidate();
            this.Update();
        }

        private void ChangeControlSize(object sender, EventArgs e)
        {
            this.control.ClientSize = this.ClientSize;
        }

        private void DrawFish(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Aqua);

            //e.Graphics.DrawImage(Image.FromFile("resources\\textures\\building.png"), ClientSize.Width - 60, ClientSize.Height - 60);


            try
            {
                foreach (var food in control.MeatBalls)
                {
                    e.Graphics.DrawImage(food.Picture, food.Location);
                }
                foreach (var fish in FishGroupControl.FishGroup)
                {
                    Image temp = FishGroupControl.scale(fish.Texture, 50, 50);
                    e.Graphics.DrawImage(temp, fish.Coord);
                }
            }
            catch (Exception except)
            {

            }
            Thread.Sleep(100);
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread MoveButtonThread = new Thread(new ThreadStart(this.control.MakeStep));
            MoveButtonThread.IsBackground = true;
            MoveButtonThread.Start();

        }
    }
}
