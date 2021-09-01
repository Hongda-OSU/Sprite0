using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class StandingInPlaceMarioSprite : ISprite
    {
        public Texture2D texture;
        private Vector2 position;

        public StandingInPlaceMarioSprite(Texture2D standingInPlaceMarioTexture, Vector2 standingInPlaceMarioPosition)
        {
            texture = standingInPlaceMarioTexture;
            position = standingInPlaceMarioPosition;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
