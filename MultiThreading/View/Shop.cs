using MultiThreading.Model;
using MultiThreading.Model.Fishes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading.View
{
    public partial class Shop : Form
    {
        private Random rand = new Random();
        public Shop()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ClientSize = new Size(400, 500);
            this.BackColor = Color.LightGray;

            this.Controls.Add(new ItemInShop(0, new StarterFish(new Point(rand.Next(100,500),rand.Next(100,500)))));
        }
    }
}
