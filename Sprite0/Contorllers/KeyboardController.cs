using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Sprite0.Commands;

namespace Sprite0.Contorllers
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyboardControllerMappings;
        private Mario myGame;
        public KeyboardController(Mario mario)
        {
            keyboardControllerMappings = new Dictionary<Keys, ICommand>();
            myGame = mario;
            RegisterCommand();
        }

        // register each key with different command
        public void RegisterCommand()
        {
            keyboardControllerMappings.Add(Keys.D0, new Quit(myGame));
            keyboardControllerMappings.Add(Keys.D1, new StandInPlaceMarioCommand(myGame));
            keyboardControllerMappings.Add(Keys.D2, new RunningInPlaceMarioCommand(myGame));
            keyboardControllerMappings.Add(Keys.D3, new DeadMovingUpAndDownMarioCommand(myGame));
            keyboardControllerMappings.Add(Keys.D4, new RunningLeftAndRightMarioCommand(myGame));
        }
        
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                // only execute the command when the stored key is pressed
                if(keyboardControllerMappings.Keys.Contains(key))
                {
                    keyboardControllerMappings[key].Execute();
                }
               
            }
        }
	}   
}
