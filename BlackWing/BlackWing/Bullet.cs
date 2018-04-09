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
        public Vector2 orgin;
        public Vector2 position;
        public bool isVisible;
        public float speed;
        public Bullet(Texture2D newtexture)
        {
            speed = 10;
            texture = newtexture;
            isVisible = false;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, Color.White);
        }
    }
}
