using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class DeadMovingUpAndDownMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private Vector2 position;
        private float speed;
        private float height; 

        public DeadMovingUpAndDownMarioSprite(Texture2D texture, Vector2 marioPosition, float marioSpeed, float graphicHeight)
        {
            Texture = texture;
            position = marioPosition;
            speed = marioSpeed;
            height = graphicHeight;
        }

        public void Update()
        {
            position.Y+= speed;
            if (position.Y > height - Texture.Height) // touch the bottom, change direction
            {
                position.Y = height - Texture.Height;
                speed = -speed;
            }
            else if (position.Y < 0.5f * height) // touch quad3 top, change direction
            {
                position.Y = 0.5f * height;
                speed = -speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
    }
}
