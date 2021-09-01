using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class DeadMovingUpAndDownMarioCommand : ICommand
    {
        public void Execute()
        {
            Mario.self.InitializeDeadMovingUpAndDownMario();
        }
    }
}
