using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class RunningLeftAndRightMarioCommand : ICommand
    {
        private Mario myGame;

        public RunningLeftAndRightMarioCommand(Mario mario)
        {
            myGame = mario;
        }

        public void Execute()
        {
            myGame.InitializeRunningLeftAndRightMario();
            
        }
    }
}
