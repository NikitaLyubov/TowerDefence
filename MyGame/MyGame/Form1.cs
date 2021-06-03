using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MyGame.Enemies;

namespace MyGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            var game = new GameModel(new PictureBox() {Size =  new Size(1900,950), BackColor = Color.Transparent }, this);
            
            Controls.Add(game.FieldBox);
        }

        public void RedrawStats(int money, int score)
        {
            Stats.Text = $"Money: {money} \n Score: {score}";
        }
    }

    /*
     * 1. Механика выстрелов из башен
     *
     * 2. GameOver после n врагов в доме
     *
     * 3. Механика смерти врагов
     */
}