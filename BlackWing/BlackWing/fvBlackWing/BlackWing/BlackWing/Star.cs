using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace BlackWing
{
    class Star
    {
        Texture2D startexture;

        public Star()
        {
            List<int> starlist = new List<int>();
        }
        public void LoadContent(ContentManager Content)
        {
            startexture = Content.Load<Texture2D>("starrrr");
        }
        public void Update(KeyboardState keyState)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
