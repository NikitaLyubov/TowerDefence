using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    class Tower
    {
        public static readonly List<PictureBox> TowerPlaces = new List<PictureBox>()
        {
            new PictureBox() {Size = new Size(70, 70), Location = new Point(415, 481)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(813, 568)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(951, 565)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(728, 826)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(867, 826)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1012, 818)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1282, 712)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1287, 598)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1440, 595)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1268, 345)},
            new PictureBox() {Size = new Size(70, 70), Location = new Point(1539, 345)}
        }; // места для башен
        private IEnemy target;
        public PictureBox TowerPictureBox;
        private readonly PictureBox field;
        private readonly double radius;
        public bool CanShoot;
        private Projectile projectile;
        private readonly GameModel game;

        public Tower(PictureBox towerPictureBox, PictureBox field, GameModel game)
        {
            this.game = game;
            var timer = new Timer(){Interval = 1000};
            timer.Tick += (sender, args) => Shoot();
            timer.Start();
            TowerPictureBox = towerPictureBox;
            this.field = field;
            radius = Math.Sqrt(160 * 160 + 160 * 160);
        }

        //проверка на нахождении врага в радиусе атаки башни
        private bool InAttackRange(IEnemy targetEnemy) =>
            Math.Abs(targetEnemy.Picture.Location.X - TowerPictureBox.Location.X) <= radius
            && Math.Abs(targetEnemy.Picture.Location.Y - TowerPictureBox.Location.Y) <= radius;

        // Закрепление цели на первом вошедшем враге
        public void FindTarget(List<IEnemy> enemies)
        {
            if (target != null && target.Hp > 0 && InAttackRange(target)) 
                return;
            foreach (var enemy in enemies)
            {
                if (!InAttackRange(enemy) || enemy.Hp <= 0 || !CanShoot)
                    continue;
                target = enemy;
                return;
            }
        }

        private void Shoot()
        {
            if(target == null) return;
            if (target.Hp <= 0)
            {
                target = null;
                game.RedrawStats();
                game.Money++;
                game.Score += 100;
                return;
            }
            projectile = new Projectile(TowerPictureBox.Location, target);
            field.Controls.Add(projectile.ProjectileBox);
            projectile.DestroyEnemy();
        }
    }
}