using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprite0.Sprites
{
    interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
