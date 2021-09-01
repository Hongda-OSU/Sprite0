using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningInPlaceMarioSprite : ISprite
    {
        public Texture2D texture;
        private Vector2 position;
        private int rows;
        private int columns;
        private int currentFrame;
        private int counter;
        private int totalFrames;

        public RunningInPlaceMarioSprite(Texture2D runningInPlaceMarioTexture, Vector2 runningInPlaceMarioPosition, int spriteRows, int spriteColumns)
        {
            texture = runningInPlaceMarioTexture;
            position = runningInPlaceMarioPosition;
            rows = spriteRows;
            columns = spriteColumns;
            currentFrame = 0;
            counter = 100;
            totalFrames = rows * columns;
        }

        public void Update()
        {
            counter--;
            if (counter % totalFrames == 0)
            {
                currentFrame++;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                counter = 100;
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

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
