using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    class Controller
    {

        private readonly GameModel game;
        public Controller(GameModel game)
        {
            this.game = game;
        }

        public void UpdateTowers(Tower tower)
        {
            {
                tower.TowerPictureBox.Image = Resource1.Молоток;
                tower.TowerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                tower.TowerPictureBox.Click += (sender, args) =>
                {
                    if (game.Money <= 0) return;
                    game.Money--;
                    tower.TowerPictureBox.Image = Resource1.Tower;
                    tower.CanShoot = true;
                };

            }
        }

        public void ExitButton(Panel panel)
        {
            panel.Controls.Add(new TextBox()
            {
                Text = "Вы проиграли",
                Font = new Font(FontFamily.GenericSerif, 26),
                Size = new Size(260, 100),
                Location = new Point(175, 150),
                BorderStyle = BorderStyle.None
            });
            panel.Controls.Add(new TextBox()
            {
                Text = "Ваш счет " + game.Score,
                Font = new Font(FontFamily.GenericSerif, 24),
                Size = new Size(250, 100),
                Location = new Point(200, 220),
                BorderStyle = BorderStyle.None
            });
            var exitButton = new Button()
            {
                Text = "Выход",
                Size = new Size(110, 50),
                Location = new Point(245, 300)
            };

            exitButton.Click += (sender, args) => Form.ActiveForm?.Close();
            panel.Controls.Add(exitButton);
        }
    }
}
