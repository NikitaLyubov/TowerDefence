﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    class Projectile
    {
        private readonly Point spawnPos;
        private readonly Point endPos;
        private readonly IEnemy enemy;
        //private readonly Controller controller;
        public PictureBox ProjectileBox { get; }

        public Projectile(Point spawnPos, IEnemy enemy)
        {
            this.enemy = enemy;
            this.spawnPos = spawnPos;
            this.endPos = enemy.Picture.Location;
            ProjectileBox = new PictureBox()
            {
                Size = new Size(50, 50),
                Image = Resource1.bomb_PNG22,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = spawnPos
            };
        }

        private void Shoot(PictureBox projectile)
        {
            var vec = new Point((endPos.X - spawnPos.X) / 10, (endPos.Y - spawnPos.Y) / 10);
            ProjectileBox.Location = new Point(ProjectileBox.Location.X + vec.X, ProjectileBox.Location.Y + vec.Y);
        }

        public void Fire()
        {
            
            var timer = new Timer() {Interval = 20};
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                Shoot(ProjectileBox);
                if (Math.Abs(ProjectileBox.Location.X - endPos.X) < 50 && Math.Abs(ProjectileBox.Location.Y - endPos.Y) < 50)
                {
                    ProjectileBox.Dispose();

                    if (!enemy.IsAlive(ProjectileBox))
                    {
                        //timer.Stop();
                        enemy.Picture.Dispose();
                        
                    }
                }
            };
        }
    }
}
