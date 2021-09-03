using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class DeadMovingUpAndDownMarioCommand : ICommand
    {
        private Mario myGame;

        public DeadMovingUpAndDownMarioCommand(Mario mario)
        {
            myGame = mario;
        }
        public void Execute()
        {
            myGame.InitializeDeadMovingUpAndDownMario();
        }
    }
}
