using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    class StandingInPlaceMarioSprite
    {

        public Texture2D Texture { get; set; }

        public StandingInPlaceMarioSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location){
        
            spriteBatch.Draw(Texture, location , Color.White);
        }
    }
}
