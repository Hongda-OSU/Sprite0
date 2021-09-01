using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class RunningInPlaceMarioCommand : ICommand
    {
        public void Execute()
        {
            Mario.self.InitializeRunningInPlaceMario();
        }
    }
}
