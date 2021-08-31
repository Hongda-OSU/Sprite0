using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningInPlaceMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Vector2 position;
        private int currentFrame;
        private int updateCount;
        private int totalFrames;

        public RunningInPlaceMarioSprite(Texture2D texture, Vector2 marioPosition, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            position = marioPosition;
            currentFrame = 0;
            updateCount = 100;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            updateCount--;
            if (updateCount % totalFrames == 0)
            {
                currentFrame++;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                updateCount = 100;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
