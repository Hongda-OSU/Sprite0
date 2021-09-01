using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class DeadMovingUpAndDownMarioSprite : ISprite
    {
        public Texture2D texture;
        private Vector2 position;
        private float speed;
        private float height; 

        public DeadMovingUpAndDownMarioSprite(Texture2D deadMovingUpAndDownMarioTexture, Vector2 deadMovingUpAndDownMarioPosition, float marioSpeed, float graphicHeight)
        {
            texture = deadMovingUpAndDownMarioTexture;
            position = deadMovingUpAndDownMarioPosition;
            speed = marioSpeed;
            height = graphicHeight;
        }

        public void Update()
        {
            position.Y+= speed;
            if (position.Y > height - texture.Height) // touch the bottom, change direction
            {
                position.Y = height - texture.Height;
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
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
