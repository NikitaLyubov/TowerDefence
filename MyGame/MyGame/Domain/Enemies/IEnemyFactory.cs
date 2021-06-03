using System.Collections.Generic;

namespace MyGame
{
    public interface IEnemyFactory
    {
       List<IEnemy> CreateEnemy();
    } 
}
