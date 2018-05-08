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
    public class SOM
    {
        public Rectangle somrec;
        public Texture2D SOMTexture;
        public Vector2 SOMPos;
        public bool isVisible = true;
        public Vector2 Velocity;
        Random rand = new Random();
        int randx, randy;
        public SOM(Vector2 position, Texture2D texture)
        {
            SOMTexture = texture;
            randx = rand.Next(0, 900);
            randy = rand.Next(0, 600);
            SOMPos = position;
        }
        public void Update()
        {
            if(somrec.X>= 900)
            {
                somrec.X = 900;
            }
           if(somrec.X<= 0)
            {
                somrec.X = 0;
            }
           if(somrec.Y>= 600)
            {
                somrec.Y = 600;
            }
           if(somrec.Y<= 0)
            {
                somrec.Y = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
