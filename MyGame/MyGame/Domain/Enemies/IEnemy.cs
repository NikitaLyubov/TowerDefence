using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public interface IEnemy 
    {
        int Hp { get; }
        PictureBox Picture { get; }
        void DeadConflict(IEnemy enemy, Throne throne);
        void MoveToNewPosition(IEnemy enemy);
        bool IsAlive(PictureBox projectile);
    }
}
