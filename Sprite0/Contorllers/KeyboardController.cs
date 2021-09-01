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

        public KeyboardController()
        {
            keyboardControllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand();
        }

        public void RegisterCommand()
        {
            keyboardControllerMappings.Add(Keys.D0, new Quit());
            keyboardControllerMappings.Add(Keys.D1, new StandInPlaceMarioCommand());
            keyboardControllerMappings.Add(Keys.D2, new RunningInPlaceMarioCommand());
            keyboardControllerMappings.Add(Keys.D3, new DeadMovingUpAndDownMarioCommand());
            keyboardControllerMappings.Add(Keys.D4, new RunningLeftAndRightMarioCommand());
        }
        
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            
            foreach (Keys key in pressedKeys)
            {
                if(keyboardControllerMappings.Keys.Contains(key))
                {
                    keyboardControllerMappings[key].Execute();
                }
               
            }
        }
	}   
}
