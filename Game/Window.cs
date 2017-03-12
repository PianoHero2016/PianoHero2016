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
using System.Drawing.Drawing2D;

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

        int timePlayed = 0;

        bool gameOver = false;

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    handleKey(0, false);
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    handleKey(1, false);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    handleKey(2, false);
                }
            }
            catch (Exception ex)
            {
                moveObjects.Stop();
                MessageBox.Show("Your computer cannot keep up with the load, application will now close." + Environment.NewLine + ex.Message);
                Environment.Exit(0);
                return;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                handleKey(0, true);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                handleKey(1, true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                handleKey(2, true);
            }
        }

        private void gameClock_Tick(object sender, EventArgs e)
        {
            timePlayed++;
            if (timePlayed > 0)
            {
                int interval = 400 - (timePlayed);
                if (interval < 180) interval = 180;
                gameClock.Interval = interval;
                statusLabel.Text = "Game clock: " + gameClock.Interval;
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
            bool success = true;
            try
            {
                Rectangle rect = entity.Bounds;
                rect.X = rect.X - 25;
                rect.Y = rect.Y - 25;
                rect.Width = rect.Width + 50;
                rect.Height = rect.Height + 50;
                foreach (var key in entities.Keys.ToList())
                {
                    if (entities[key].Bounds.IntersectsWith(rect))
                    {
                        success = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (success)
            {
                Controls.Add(entity);
                pictureBox3.SendToBack();
                entities.Add(new Random().Next(), entity);
            }
        }

        private void moveEntities_Tick(object sender, EventArgs e)
        {

        }

        int speed = 10;

        int score = 0;
        int highScore = 0;

        int health = 10;

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
                            entities[key].Dispose();
                            entities.Remove(key);
                            score -= 100;
                            health--;
                            if (health < 0) health = 0;
                            if (score > highScore) highScore = score;
                            updateStats();
                            if (health <= 0)
                            {
                                gameClock.Stop();
                                gameOver = true;
                            }
                            return;
                        }
                        int preScore = (5 + (entities.Count) + (timePlayed / 10));
                        if (preScore > 20) preScore = 20;
                        if (preScore > 25) preScore = 22;
                        if (preScore > 30) preScore = 24;
                        if (preScore > 35) preScore = 26;
                        if (preScore > 40) preScore = 28;
                        if (preScore > 45) preScore = 30;
                        speed = preScore;
                        entities[key].Location = new Point(entities[key].Location.X, entities[key].Location.Y + speed);
                    }
                }
            } catch (Exception ex)
            {
                moveObjects.Stop();
                MessageBox.Show("Your computer cannot keep up with the load, application will now close." + Environment.NewLine + ex.Message);
                Environment.Exit(0);
                return;
            }
        }

        private void updateStats()
        {
            if (health > 20) health = 20;
            if (health < 0) health = 0;
            String nl = Environment.NewLine;
            ScoreLabel.Text = "High Score: " + highScore + nl + "Score: " + score + nl + "Speed: " + speed + nl + "Health: " + health;
        }

        private void Window_Load(object sender, EventArgs e)
        {
        }

        private void handleKey(int keyCode, bool up)
        {
            if (up)
            {
                if (keyCode == 0)
                {
                    pad1.Location = pad1a;
                }
                else if (keyCode == 1)
                {
                    pad2.Location = pad2a;
                }
                else if (keyCode == 2)
                {
                    pad3.Location = pad3a;
                }
            }
            else
            {
                if (keyCode == 0)
                {
                    pad1.Location = pad1b;
                    bool hit = false;
                    foreach (var key in entities.Keys.ToList())
                    {
                        Rectangle rect = entities[key].Bounds;
                        rect.Y = rect.Y - 25;
                        rect.Height = rect.Height + 50;
                        if (pad1.Bounds.IntersectsWith(rect))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            score += 100;
                            if (score > highScore) highScore = score;
                            Stream str = Properties.Resources.Pad1;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                            health++;
                            if (health > 20) health = 20;
                            hit = true;
                        }
                    }
                    if (!hit)
                    {
                        health--;
                    }
                    updateStats();
                }
                else if (keyCode == 1)
                {
                    pad2.Location = pad2b;
                    bool hit = false;
                    foreach (var key in entities.Keys.ToList())
                    {
                        Rectangle rect = entities[key].Bounds;
                        rect.Y = rect.Y - 25;
                        rect.Height = rect.Height + 50;
                        if (pad2.Bounds.IntersectsWith(rect))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            score += 100;
                            if (score > highScore) highScore = score;
                            Stream str = Properties.Resources.Pad2;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                            health++;
                            if (health > 20) health = 20;
                            hit = true;
                        }
                    }
                    if (!hit)
                    {
                        health--;
                    }
                    updateStats();
                }
                else if (keyCode == 2)
                {
                    pad3.Location = pad3b;
                    bool hit = false;
                    foreach (var key in entities.Keys.ToList())
                    {
                        Rectangle rect = entities[key].Bounds;
                        rect.Y = rect.Y - 25;
                        rect.Height = rect.Height + 50;
                        if (pad3.Bounds.IntersectsWith(rect))
                        {
                            Controls.Remove(entities[key]);
                            entities.Remove(key);
                            score += 100;
                            if (score > highScore) highScore = score;
                            Stream str = Properties.Resources.Pad3;
                            SoundPlayer snd = new SoundPlayer(str);
                            snd.Play();
                            health++;
                            if (health > 20) health = 20;
                            hit = true;
                        }
                    }
                    if (!hit)
                    {
                        health--;
                    }
                    updateStats();
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (gameOver)
                {
                    score = 0;
                    highScore = 0;
                    speed = 10;
                    health = 10;
                    timePlayed = 0;
                    updateStats();
                    Stream str = Properties.Resources.Pad2;
                    SoundPlayer snd = new SoundPlayer(str);
                    snd.Play();
                    gameClock.Start();
                    gameOver = false;
                }
                else
                {
                    if (gameClock.Enabled)
                    {
                        gameClock.Stop();
                    }
                    else
                    {
                        gameClock.Start();
                    }
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.D1 || e.KeyCode == Keys.A)
            {
                handleKey(0, false);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.D2 || e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                handleKey(1, false);
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D)
            {
                handleKey(2, false);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.D1 || e.KeyCode == Keys.A)
            {
                handleKey(0, true);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.D2 || e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                handleKey(1, true);
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D)
            {
                handleKey(2, true);
            }
        }
        
    }
}
