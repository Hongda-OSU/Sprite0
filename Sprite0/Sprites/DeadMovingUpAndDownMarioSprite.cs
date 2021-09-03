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

        public void Update(double frameRate)
        {
            position.Y+= speed;
            // sprite touch the bottom, set position and change direction
            if (position.Y > height - texture.Height) 
            {
                position.Y = height - texture.Height;
                speed = -speed;
            }
            // sprite touch Quad3 top, set position and change direction
            else if (position.Y < 0.5f * height) 
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
