using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Sprite0.Commands;

namespace Sprite0.Contorllers
{
    class MouseController : IController
    {
        private MouseState oldState;

        public void Update()
        {
            MouseState newState = Mouse.GetState();
            // click right button to quit
            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                new Quit().Execute();
            }
            // click Quad 1 
            if (newState.X > 0 && newState.X < Mario.screenWidth/2  && newState.Y > 0 && newState.Y < Mario.screenHeight/2 && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new StandInPlaceMarioCommand().Execute();
            }
            // click Quad 2 
            if (newState.X > Mario.screenWidth / 2 && newState.X < Mario.screenWidth && newState.Y > 0 && newState.Y < Mario.screenHeight / 2 && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new RunningInPlaceMarioCommand().Execute();
            }
            // click Quad 3 
            if (newState.X > 0 && newState.X < Mario.screenWidth / 2 && newState.Y > Mario.screenHeight / 2 && newState.Y < Mario.screenHeight && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new DeadMovingUpAndDownMarioCommand().Execute();
            }
            // click Quad 4 
            if (newState.X > Mario.screenWidth / 2 && newState.X < Mario.screenWidth && newState.Y > Mario.screenHeight / 2 && newState.Y < Mario.screenHeight && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new RunningLeftAndRightMarioCommand().Execute();
            }

            oldState = newState;
        }

    }
}
