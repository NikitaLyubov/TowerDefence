using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MyGame
{
    public class GameModel
    {
        public readonly PictureBox FieldBox;
        private readonly List<Tower> towers;
        private readonly List<IEnemy> enemies;
        private readonly Controller controller;
        private readonly Form1 gameForm;
        private readonly Throne throne;
        private int enemyPosInList;
        private Timer updateUnits;
        private Timer moveEnemyTimer;
        private int score;
        private int money = 1;
        public int Money
        {
            get => money;
            set
            {
                money = value;
                gameForm.RedrawStats(Money, Score);
            }
        }
        public int Score
        {
            get => score;
            set
            {
                score = value;
                gameForm.RedrawStats(Money, Score);
            }
        }
       

        public GameModel(PictureBox fieldBox, Form1 gameForm)
        {
            this.gameForm = gameForm;
            FieldBox = fieldBox;
            throne = new Throne(1);
            enemies = new List<IEnemy>();
            towers = new List<Tower>();
            controller = new Controller(this);
            FieldBox.Controls.Add(throne.GetPictureBox);
            foreach (var tower in Tower.TowerPlaces.Select(place => new Tower(place, FieldBox, this)))
            {
                towers.Add(tower);
                controller.UpgradeTowers(tower);
                FieldBox.Controls.Add(tower.TowerPictureBox);
            }
            Timers();
            FieldBox.Invalidate();
        }

        public void RedrawStats() => gameForm.RedrawStats(Money, Score);

        private void Timers()
        {
            updateUnits = new Timer() { Interval = 1000 };
            moveEnemyTimer = new Timer() { Interval = 50 };
            updateUnits.Tick += SpawnAndKill;
            moveEnemyTimer.Tick += Update;
            updateUnits.Start();
            moveEnemyTimer.Start();
        }

        // Добавление врага в лист с интервалом в один тик, для того что бы спавнить их с промежутком во времени 
        private void SpawnAndKill(object sender, EventArgs e)
        {
            if (enemyPosInList < EnemyCreator.Enemies.Count && enemyPosInList >= 0)
            {
                enemies.Add(EnemyCreator.Enemies[enemyPosInList]);
                FieldBox.Controls.Add(enemies[enemyPosInList].Picture);
                enemyPosInList++;
            }

            // Запуск поиска цели для выстрела
            foreach (var tower in towers)
            {
                tower.FindTarget(enemies);
            }
        }

        // Таймер для движения врага и проверки не проиграл ли игрок
        private void Update(object sender, EventArgs e)
        {
            foreach (var enemy in enemies)
            {
                enemy.MoveToNewPosition(enemy);
                enemy.DeadConflict(enemy, throne);
            }
            
            EndGame();
        }

        private void EndGame()
        {
            if (throne.Hp > 0) return;
            foreach (Control fieldBoxControl in FieldBox.Controls)
            {
                fieldBoxControl.Visible = false;
            }
            updateUnits.Stop();
            moveEnemyTimer.Stop();
            var panel = new Panel()
            {
                BackColor = Color.White, 
                Size = new Size(600, 500), 
                Location = new Point(600, 200)
            };
            controller.ExitButton(panel);
            FieldBox.Controls.Add(panel);
        }
    }
}
