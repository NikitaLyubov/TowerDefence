using System;
using System.Drawing;
using System.Windows.Forms;
using MyGame;
using MyGame.Domain;
using MyGame.Enemies;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class SomeTests
    {
        [Test]
        public void Test()
        {
            var game = new Game(new PictureBox() { Size = new Size(1900, 950), BackColor = Color.Transparent });
            
        }
    }
}
