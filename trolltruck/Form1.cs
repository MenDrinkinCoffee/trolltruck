using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trolltruck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;

  
        }
        public void dumpTruck()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            bool go = true;
            int speed = 2;
            int steps = 0;
            player.Stream = Properties.Resources.truckidle;
            player.PlayLooping();
            System.Threading.Thread.Sleep(2000);
            player.Stream = Properties.Resources.backup2;
            player.PlayLooping();
            string[] trolls = System.IO.File.ReadAllLines(@"C:\lp\trolls.txt");
            while (go)
            {
                int speed2 = 1;
                switch (steps)
                {
                    case 0:
                        Point newlocation = this.pictureBox1.Location;
                        newlocation.X += speed;
                        this.pictureBox1.Location = newlocation;
                        if (pictureBox1.Location.X > 800)
                        {
                            steps = 1;
                            player.Stream = Properties.Resources.truckidle;
                            player.PlayLooping();
                            System.Threading.Thread.Sleep(150);
                        }
                        break;
                    case 1:
                        Point newlocation2 = this.pictureBox2.Location;
                        newlocation2.Y -= speed2;
                        this.pictureBox2.Location = newlocation2;

                        if (pictureBox2.Location.Y < 50)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(50);
                            steps = 3;
                        }
                        break;
                    case 3:
                        Point initLocation = this.label1.Location;
                        foreach (string trollname in trolls)
                        {
                            label1.Text = trollname;
                            label1.Visible = true;
                            Application.DoEvents();
                            player.Stream = Properties.Resources.belch;
                            player.Play();
                            System.Threading.Thread.Sleep(2000);
                            while (this.label1.Location.Y < 95)
                            {
                                label1.Visible = true;
                                Point newlocation3 = this.label1.Location;
                                newlocation3.Y += speed2;
                                this.label1.Location = newlocation3;
                                Application.DoEvents();
                                System.Threading.Thread.Sleep(50);
                            }

                            if (this.label1.Location.Y >= 95)
                            {
                                label1.Visible = false;
                                Application.DoEvents();
                                this.label1.Location = initLocation;
                                label1.Visible = true;
                            }

                        }
                        label1.Visible = false;
                        Application.DoEvents();
                        go = false;
                        break;
                }
                Application.DoEvents();
                System.Threading.Thread.Sleep(30);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dumpTruck();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
