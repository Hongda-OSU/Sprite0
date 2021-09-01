using System;
using System.Collections.Generic;
using System.Text;
using Sprite0.Sprites;

namespace Sprite0.Commands
{
    class StandInPlaceMarioCommand : ICommand
    {
        private Mario myGame;

        public StandInPlaceMarioCommand()
        {
            myGame = Mario.Self;
        }

        public void Execute()
        {
            myGame.InitializeStandingInPlaceMario();
            myGame.SetCurrentSprite(1);
        }
    }
}
