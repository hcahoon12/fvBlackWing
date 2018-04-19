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
   public class Bullet
    {
        public Rectangle boundingbox;
        public Texture2D texture;
        public bool isVisible;
        public float speed;
        public Bullet(Texture2D newtexture, Vector2 position)
        {
            
            speed = 10;
            texture = newtexture;
            boundingbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            isVisible = true;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, boundingbox, Color.White);
        }
    }
}
