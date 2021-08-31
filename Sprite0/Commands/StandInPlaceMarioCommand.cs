using System;
using System.Collections.Generic;
using System.Text;

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
            myGame.marioSprite = 
        }
    }
}
