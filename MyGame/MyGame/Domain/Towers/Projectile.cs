using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    class Projectile
    {
        private readonly Point spawnPos;
        private readonly Point endPos;
        private readonly IEnemy enemy;
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

        // Перемещение снаряда
        private void Shoot()
        {
            var vec = new Point((endPos.X - spawnPos.X) / 10, (endPos.Y - spawnPos.Y) / 10);
            ProjectileBox.Location = new Point(ProjectileBox.Location.X + vec.X, ProjectileBox.Location.Y + vec.Y);
        }

        // Уничтожение врага
        public void DestroyEnemy()
        {
            var timer = new Timer() {Interval = 20};
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                Shoot();
                if (Math.Abs(ProjectileBox.Location.X - endPos.X) < 50 && Math.Abs(ProjectileBox.Location.Y - endPos.Y) < 50)
                {
                    ProjectileBox.Dispose();

                    if (!enemy.IsAlive(ProjectileBox))
                    {
                        timer.Stop();
                        enemy.Picture.Dispose();
                    }
                }
            };
        }
    }
}
