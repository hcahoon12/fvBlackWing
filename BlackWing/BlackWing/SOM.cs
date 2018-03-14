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
    class SOM
    {
        public Texture2D SOMTexture;
        public Vector2 SOMPos;
        public float SOMSpeed;
        public bool isVisible = true;
        public SOM()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            SOMTexture = Content.Load<Texture2D>("S.O.M");
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
