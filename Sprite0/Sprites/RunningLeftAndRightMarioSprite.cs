using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningLeftAndRightMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Vector2 position;
        private float speed;
        private float width;
        private int currentFrame;
        private int updateCount;
        private int totalFrames;
        private float angle = 0;
        public Vector2 origin = new Vector2(0, 0);
        private SpriteEffects effect = SpriteEffects.None;

        public RunningLeftAndRightMarioSprite(Texture2D texture, Vector2 marioPosition, int rows, int columns, float marioSpeed, float graphicWidth)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            speed = marioSpeed;
            width = graphicWidth;
            position = marioPosition;
            currentFrame = 0;
            updateCount = 100;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            updateCount--;
            position.X -= speed;
            if (updateCount % totalFrames == 0)
            {
                currentFrame++;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                updateCount = 100;
            }
            
            if (position.X > width - Texture.Width/Columns) //touch the right end, change direction
            {
                position.X = width - Texture.Width / Columns;
                effect = SpriteEffects.None;
                speed = -speed;
            }
            else if (position.X < 0.5f * width) // touch quad4 left end
            {
                position.X = 0.5f * width;
                effect = SpriteEffects.FlipHorizontally;
                speed = -speed;
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

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, angle, origin, effect, 1);
        }
    }
}
