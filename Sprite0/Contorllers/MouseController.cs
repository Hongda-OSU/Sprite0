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

            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                new Quit().Execute();
            }

            if (newState.X > 0 && newState.X < Mario.ScreenWidth/2  && newState.Y > 0 && newState.Y < Mario.ScreenHeight/2 && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new StandInPlaceMarioCommand().Execute();
            }

            if (newState.X > Mario.ScreenWidth / 2 && newState.X < Mario.ScreenWidth && newState.Y > 0 && newState.Y < Mario.ScreenHeight / 2 && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new RunningInPlaceMarioCommand().Execute();
            }

            if (newState.X > 0 && newState.X < Mario.ScreenWidth / 2 && newState.Y > Mario.ScreenHeight / 2 && newState.Y < Mario.ScreenHeight && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new DeadMovingUpAndDownMarioCommand().Execute();
            }

            if (newState.X > Mario.ScreenWidth / 2 && newState.X < Mario.ScreenWidth && newState.Y > Mario.ScreenHeight / 2 && newState.Y < Mario.ScreenHeight && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                new RunningLeftAndRightMarioCommand().Execute();
            }

            oldState = newState;
        }

    }
}
