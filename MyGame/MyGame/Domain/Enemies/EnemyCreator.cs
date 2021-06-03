
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Enemies;

namespace MyGame
{
    class EnemyCreator
    {
        public static List<IEnemy> Enemies => CreateEnemy();

        public static List<IEnemy> CreateEnemy()
        {
            var enemyList = new List<IEnemy>();
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (i == 0)
                        enemyList.Add(new FirstEnemy(7));
                    else
                        enemyList.Add(new SecondEnemy(14));
                }
            }

            return enemyList;
        }
    }
}
