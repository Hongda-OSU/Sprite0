using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class RunningInPlaceMarioCommand : ICommand
    {
        private Mario myGame;

        public RunningInPlaceMarioCommand()
        {
            myGame = Mario.self;
        }

        public void Execute()
        {
            myGame.InitializeRunningInPlaceMario();
            myGame.SetCurrentSprite(2);
        }
    }
}
