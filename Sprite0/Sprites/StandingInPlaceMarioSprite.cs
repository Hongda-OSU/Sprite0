using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class StandingInPlaceMarioSprite : ISprite
    {
        public Texture2D Texture;
        private Vector2 Position;

        public StandingInPlaceMarioSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
