using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class DeadMovingUpAndDownMarioSprite : ISprite
    {
        public Texture2D Texture;
        private Vector2 Position;
        private float Speed;
        private float Height; 

        public DeadMovingUpAndDownMarioSprite(Texture2D texture, Vector2 position, float speed, float height)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            Height = height;
        }

        public void Update()
        {
            Position.Y+= Speed;
            if (Position.Y > Height - Texture.Height) // touch the bottom, change direction
            {
                Position.Y = Height - Texture.Height;
                Speed = -Speed;
            }
            else if (Position.Y < 0.5f * Height) // touch quad3 top, change direction
            {
                Position.Y = 0.5f * Height;
                Speed = -Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
