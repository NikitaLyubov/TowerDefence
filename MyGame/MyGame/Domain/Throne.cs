using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public class Throne
    {
        public int Hp;
        public PictureBox GetPictureBox { get; }

        public Throne(int hp)
        {
            Hp = hp;
            GetPictureBox = new PictureBox
            {
                Image = Resource1.Asset_1,
                Location = new Point(1600, 450),
                Size = new Size(200, 100),
                BackColor = Color.Transparent
            };
        }


    }
}