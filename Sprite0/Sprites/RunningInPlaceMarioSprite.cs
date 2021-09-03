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
        private double currentFrame;
        private int totalFrames;

        public RunningInPlaceMarioSprite(Texture2D runningInPlaceMarioTexture, Vector2 runningInPlaceMarioPosition, int spriteRows, int spriteColumns)
        {
            texture = runningInPlaceMarioTexture;
            position = runningInPlaceMarioPosition;
            rows = spriteRows;
            columns = spriteColumns;
            currentFrame = 0;
            totalFrames = rows * columns;
        }

        public void Update(double frameRate)
        {
            // Update current frame base on frame rate
            currentFrame += frameRate;
            if (currentFrame > totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)currentFrame / columns;
            int column = (int)currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
