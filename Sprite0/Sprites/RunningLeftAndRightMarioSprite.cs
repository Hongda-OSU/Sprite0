using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class RunningLeftAndRightMarioSprite : ISprite
    {
        public Texture2D Texture;
        public int Rows;
        public int Columns;
        private Vector2 Position;
        private float Speed;
        private int Width;
        private int CurrentFrame;
        private int UpdateCount;
        private int TotalFrames;
        private float Angle = 0;
        public Vector2 Origin = new Vector2(0, 0);
        private SpriteEffects Effect = SpriteEffects.None;

        public RunningLeftAndRightMarioSprite(Texture2D texture, Vector2 position, int rows, int columns, float speed, int width)
        {
            Texture = texture;
            Position = position;
            Rows = rows;
            Columns = columns;
            Speed = speed;
            Width = width;
            CurrentFrame = 0;
            UpdateCount = 100;
            TotalFrames = Rows * Columns;
        }

        public void Update()
        {
            UpdateCount--;
            Position.X -= Speed;
            if (UpdateCount % TotalFrames == 0)
            {
                CurrentFrame++;
            }
            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
                UpdateCount = 100;
            }
            
            if (Position.X > Width - Texture.Width/Columns) //touch the right end, change direction
            {
                Position.X = Width - Texture.Width / Columns;
                Effect = SpriteEffects.None;
                Speed = -Speed;
            }
            else if (Position.X < 0.5f * Width) // touch quad4 left end
            {
                Position.X = 0.5f * Width;
                Effect = SpriteEffects.FlipHorizontally;
                Speed = -Speed;
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

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, Angle, Origin, Effect, 1);
        }
    }
}
