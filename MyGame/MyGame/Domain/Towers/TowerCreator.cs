using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame.Towers
{
    class TowerCreator
    {
        public List<PictureBox> towerPlaces = new List<PictureBox>()
        {
            new PictureBox() {Size = new Size(70, 70), Location = new Point(429, 481)},
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
        };
    }
}
