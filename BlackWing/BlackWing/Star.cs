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
        public Rectangle starbox;
        public int speed;
        public bool isvisible;
       

        public Star(Texture2D StarTexture, int X , int Y, int direction)
        {
            speed = 10 * direction;
            int xOffset;
            int yOffset;
            if(direction < 0)
            {
                xOffset = 0;
                yOffset = 10;
                //left
            }
            else
            {
                xOffset = 60;
                yOffset = 10;
                //right
            }
            starbox = new Rectangle(X+xOffset, Y+yOffset , 20, 20);
            isvisible = true;
            startexture = StarTexture; 
        }
      
        public void Update()
        {
            starbox.X += speed;
            if (starbox.X>= 960 || starbox.X<=0)
            { 
                isvisible = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startexture, starbox, Color.White);
        }
    }
}
