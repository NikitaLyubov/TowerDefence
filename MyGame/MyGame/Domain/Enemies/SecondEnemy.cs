using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyGame.Enemies;

namespace MyGame 
{
    public class SecondEnemy : IEnemy
    {
        private int index;
        private List<Point> WayPoints => Map.Way();
        public PictureBox Picture { get; }

        public int Hp { get; private set; }

        public SecondEnemy(int hp)
        {
            Hp = hp;
            Picture = new PictureBox()
            {
                Image = Resource1.Plane,
                Location = new Point(0, 450),
                BackColor = Color.Transparent,
                Size = new Size(60, 60),
                SizeMode = PictureBoxSizeMode.Zoom
            };
        }

        public void DeadConflict(IEnemy enemy, Throne throne)
        {
            if (enemy.Picture.Bounds.IntersectsWith(throne.GetPictureBox.Bounds))
            {
                throne.Hp--;
                enemy.Picture.Dispose();
                index = 0;
            }
        }

        public void MoveToNewPosition(IEnemy enemy)
        {
            if (enemy.Hp <= 0) return;
            enemy.Picture.Location = new Point(WayPoints[index].X, WayPoints[index].Y + 50);
            index++;
        }

        public bool IsAlive(PictureBox projectile)
        {
            if (Picture.Bounds.IntersectsWith(projectile.Bounds))
                Hp--;
            return Hp > 0;
        }

    }
}
