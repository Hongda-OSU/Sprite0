using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class StandingInPlaceMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private Vector2 position;

        public StandingInPlaceMarioSprite(Texture2D texture, Vector2 marioPosition)
        {
            Texture = texture;
            position = marioPosition;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
    }
}
