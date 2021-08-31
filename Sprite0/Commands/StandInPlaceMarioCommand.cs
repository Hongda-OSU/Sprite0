using System;
using System.Collections.Generic;
using System.Text;
using Sprite0.Sprites;

namespace Sprite0.Commands
{
    class StandInPlaceMarioCommand : ICommand
    {
        private Mario myGame;

        public StandInPlaceMarioCommand(Mario mario)
        {
            myGame = mario;
        }

        public void Execute()
        {
            myGame.marioSprite = new StandingInPlaceMarioSprite();
        }
    }
}
