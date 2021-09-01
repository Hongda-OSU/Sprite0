using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningInPlaceMarioSprite : ISprite
    {
        public Texture2D Texture;
        private int Rows;
        private int Columns;
        private Vector2 Position;
        private int CurrentFrame;
        private int UpdateCount;
        private int TotalFrames;

        public RunningInPlaceMarioSprite(Texture2D texture, Vector2 position, int rows, int columns)
        {
            Texture = texture;
            Position = position;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            UpdateCount = 100;
            TotalFrames = Rows * Columns;
        }

        public void Update()
        {
            UpdateCount--;
            if (UpdateCount % TotalFrames == 0)
            {
                CurrentFrame++;
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
                UpdateCount = 100;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
