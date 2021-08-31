using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Sprite0.Commands;

namespace Sprite0.Contorllers
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyboardControllerMappings;
        private Mario mario;

        public KeyboardController()
        {
            keyboardControllerMappings = new Dictionary<Keys, ICommand>();
            this.RegisterCommand();
        }

        public void RegisterCommand()
        {
            keyboardControllerMappings.Add(Keys.D0, new Quit(mario));
            keyboardControllerMappings.Add(Keys.D1, new StandInPlaceMarioCommand(mario));
            keyboardControllerMappings.Add(Keys.D2, new RunningInPlaceMarioCommand(mario));
            keyboardControllerMappings.Add(Keys.D3, new DeadMovingUpAndDownMarioCommand(mario));
            keyboardControllerMappings.Add(Keys.D4, new RunningLeftAndRightMarioCommand(mario));
        }
        
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            
            foreach (Keys key in pressedKeys)
            {
                keyboardControllerMappings[key].Execute();
            }
            
        }
	}
}
