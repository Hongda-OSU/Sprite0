using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class RunningLeftAndRightMarioCommand : ICommand
    {
        private Mario myGame;

        public RunningLeftAndRightMarioCommand()
        {
            myGame = Mario.Self;
        }

        public void Execute()
        {
            myGame.InitializeRunningLeftAndRightMario();
            myGame.SetCurrentSprite(4);
        }
    }
}
