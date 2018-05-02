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
    class PowerUps
    {
        ContentManager content;
        public Texture2D poweruptexture;
        public Rectangle powerrec;
        public bool isVisible;
        public Vector2 healthpos;
        public PowerUps(Texture2D newTexture, Vector2 newPos)
        {
            poweruptexture = newTexture;
            healthpos = newPos;
            isVisible = true;
        }
        public void LoadContent(ContentManager Content)
        {
           
        }
        public void Update()
        {
            
            //collision
            powerrec = new Rectangle((int)healthpos.X, (int)healthpos.Y, 25, 25);
        }
            public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(poweruptexture, powerrec, Color.White);
            }
        }
    }
}
