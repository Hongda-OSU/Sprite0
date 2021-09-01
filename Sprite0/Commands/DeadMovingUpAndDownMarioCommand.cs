using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class DeadMovingUpAndDownMarioCommand : ICommand
    {
        private Mario myGame;

        public DeadMovingUpAndDownMarioCommand()
        {
            myGame = Mario.self;
        }

        public void Execute()
        {
            myGame.InitializeDeadMovingUpAndDownMario();
            myGame.SetCurrentSprite(3);
        }
    }
}
