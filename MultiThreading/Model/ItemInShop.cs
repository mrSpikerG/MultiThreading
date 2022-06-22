using MultiThreading.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading.Model
{
    public partial class ItemInShop : UserControl
    {

        public double Price { get; set; }
        public Image Texture { get; set; }
        public string Info { get; set; }
        private AbstractFish ThisFish { get; set; }
        public ItemInShop(int count,AbstractFish fish)//string name,int price,string texture)
        {
            this.ThisFish = fish;

            this.Price = fish.Cost;
            this.Texture = fish.Texture;
            this.Info = fish.Name;


            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.Size = new Size(380, 40);
            this.Location = new Point(10, 10 + 50 * count);

            PictureBox image = new PictureBox();
            image.Location = new Point(2, 1);
            image.Image = FishGroupControl.scale(Texture, 38, 38);
            image.Size = new Size(38, 38);
            this.Controls.Add(image);

            Label info = new Label();
            info.AutoSize = true;
            info.Text = Info;
            info.Location = new Point(45, 20);
            this.Controls.Add(info);

            Label pricelabel = new Label();
            pricelabel.AutoSize = true;
            pricelabel.Text = $"{Price} $";
            pricelabel.Location = new Point(45, 27);
            this.Controls.Add(pricelabel);

            Button buy = new Button();
            buy.Size = new Size(38, 38);
            buy.Text = "Buy";
            buy.Click += addFish;
            buy.Location = new Point(340, 1);
            this.Controls.Add(buy);

        }

        private void addFish(object sender, EventArgs e)
        {
            FishGroupControl.tryAddFish(this.ThisFish);
        }
    }
}
