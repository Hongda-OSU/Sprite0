using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class RunningInPlaceMarioCommand : ICommand
    {
        private Mario myGame;

        public RunningInPlaceMarioCommand(Mario mario)
        {
            myGame = mario;
        }
        public void Execute()
        {
            myGame.InitializeRunningInPlaceMario();
        }
    }
}
