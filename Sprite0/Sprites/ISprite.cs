using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Sprite0.Sprites
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
