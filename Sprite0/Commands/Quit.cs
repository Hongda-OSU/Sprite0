using System;
using System.Collections.Generic;
using System.Text;

namespace Sprite0.Commands
{
    class Quit : ICommand
    {
        private Mario myGame; 

        public Quit()
        {
            myGame = Mario.self;
        }

        public void Execute()
        {
            myGame.Exit();
        }
	}
}
