using System;
using System.Collections.Generic;
using System.Text;
using Sprite0.Sprites;

namespace Sprite0.Commands
{
    class StandInPlaceMarioCommand : ICommand
    {
        public void Execute()
        {
            Mario.self.InitializeStandingInPlaceMario();
        }
    }
}
