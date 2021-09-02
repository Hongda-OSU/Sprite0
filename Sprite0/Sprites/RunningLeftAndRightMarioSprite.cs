using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningLeftAndRightMarioSprite : ISprite
    {
        public Texture2D texture;
        public int rows;
        public int columns;
        private Vector2 position;
        private float speed;
        private int width;
        private int currentFrame;
        private int counter;
        private int totalFrames;
        private float angle = 0f;
        public Vector2 origin = new Vector2(0, 0);
        private SpriteEffects effect = SpriteEffects.None;

        public RunningLeftAndRightMarioSprite(Texture2D runningLeftAndRightMarioTexture, Vector2 runningLeftAndRightMarioPosition, int spriteRows, int spriteColumns, float marioSpeed, int graphicWidth)
        {
            texture = runningLeftAndRightMarioTexture;
            position = runningLeftAndRightMarioPosition;
            rows = spriteRows;
            columns = spriteColumns;
            speed = marioSpeed;
            width = graphicWidth;
            currentFrame = 0;
            counter = 100;
            totalFrames = rows * columns;
        }

        public void Update()
        {
            counter--;
            position.X -= speed;
            // counter will help to slow down the speed of updating current frame
            if (counter % totalFrames == 0)
            {
                currentFrame++;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                counter = 100;
            }
            // sprite touch the right end, set position, mirror sprite if sprite is mirrored and change direction
            if (position.X > width - texture.Width/columns) 
            {
                position.X = width - texture.Width / columns;
                effect = SpriteEffects.None;
                speed = -speed;
            }
            // sprite touch Quad4 left end, set position, mirror sprite and change direction
            else if (position.X < 0.5f * width) 
            {
                position.X = 0.5f * width;
                effect = SpriteEffects.FlipHorizontally;
                speed = -speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            // an overload for Draw that could flip sprite
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, angle, origin, effect, 1);
        }
    }
}
