using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            if (Screen.PrimaryScreen.Bounds.Width < 1366 && Screen.PrimaryScreen.Bounds.Height < 768)
            {
                MessageBox.Show("Your resolution is required to be at minimum 1366x768 (768p).");
                Environment.Exit(0);
            }
            else
            {
                gameClock.Start();
                moveObjects.Start();
            }
        }

        Point pad1a = new Point(481, 583);
        Point pad2a = new Point(576, 583);
        Point pad3a = new Point(662, 583);

        Point pad1b = new Point(481, 563);
        Point pad2b = new Point(576, 563);
        Point pad3b = new Point(662, 563);

        Point spawn1 = new Point(481, -50);
        Point spawn2 = new Point(576, -50);
        Point spawn3 = new Point(662, -50);

        Point dummySpawn = new Point(500, 500);

        Dictionary<int, PictureBox> entities = new Dictionary<int, PictureBox>();

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    pad1.Location = pad1b;
                    foreach (var key in entities.Keys.ToList())
                    {
                        if (pad1.Bounds.IntersectsWith(entities[key].Bounds))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            ScoreLabel.Text = (int.Parse(ScoreLabel.Text) + 100).ToString();
                            Stream str = Properties.Resources.Pad1;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                        }
                    }
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    pad2.Location = pad2b;
                    foreach (var key in entities.Keys.ToList())
                    {
                        if (pad2.Bounds.IntersectsWith(entities[key].Bounds))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            ScoreLabel.Text = (int.Parse(ScoreLabel.Text) + 100).ToString();
                            Stream str = Properties.Resources.Pad2;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    pad3.Location = pad3b;
                    foreach (var key in entities.Keys.ToList())
                    {
                        if (pad3.Bounds.IntersectsWith(entities[key].Bounds))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            ScoreLabel.Text = (int.Parse(ScoreLabel.Text) + 100).ToString();
                            Stream str = Properties.Resources.Pad3;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                moveObjects.Stop();
                MessageBox.Show("Your computer cannot keep up with the load, application will now close.");
                Environment.Exit(0);
                return;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pad1.Location = pad1a;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pad2.Location = pad2a;
            }
            else if (e.Button == MouseButtons.Right)
            {
                pad3.Location = pad3a;
            }
        }

        private void gameClock_Tick(object sender, EventArgs e)
        {
            if (entities.Count > 25)
            {
                moveObjects.Stop();
                MessageBox.Show("Your computer cannot keep up with the load, application will now close.");
                Environment.Exit(0);
                return;
            }
            int pad = new Random().Next(1, 4);
            PictureBox entity = new PictureBox();
            entity.BorderStyle = BorderStyle.Fixed3D;
            if (pad == 1)
            {
                entity.Size = new Size(89, 44);
                entity.Location = spawn1;
                entity.BackColor = Color.Red;
            }
            else if (pad == 2)
            {
                entity.Size = new Size(80, 44);
                entity.Location = spawn2;
                entity.BackColor = Color.Yellow;
            }
            else if (pad == 3)
            {
                entity.Size = new Size(89, 44);
                entity.Location = spawn3;
                entity.BackColor = Color.Blue;
            }
            try
            {
                foreach (var key in entities.Keys.ToList())
                {
                    if (entities[key].Bounds.IntersectsWith(entity.Bounds))
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            Controls.Add(entity);
            pictureBox3.SendToBack();
            entities.Add(new Random().Next(), entity);
        }

        private void moveEntities_Tick(object sender, EventArgs e)
        {

        }

        private void moveObjects_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var key in entities.Keys.ToList())
                {
                    if (entities.ContainsKey(key))
                    {
                        if (entities[key].Location.Y > Height)
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            return;
                        }
                        entities[key].Location = new Point(entities[key].Location.X, entities[key].Location.Y + 3);
                        Application.DoEvents();
                    }
                }
            } catch (Exception ex)
            {
                moveObjects.Stop();
                MessageBox.Show("Your computer cannot keep up with the load, application will now close.");
                Environment.Exit(0);
                return;
            }
        }
    }
}
