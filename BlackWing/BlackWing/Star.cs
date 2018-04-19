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
   public class Star
    {
        Texture2D startexture;
        public Rectangle starbox;
        public int speed;
        public bool isvisible;
        int xOffset;
        int yOffset;
        bool collide;
        int distravled;


        public Star(Texture2D StarTexture, int X , int Y, int direction)
        {
            distravled = 0;
            speed = 10 * direction;
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
      
        public void Update(List<Line> Lines)
        {
            starbox.X += speed;
            distravled += Math.Abs(speed);
            for (int l = 0; l < Lines.Count; l++)
            {
                if (starbox.Intersects(Lines[l].rectangle))
                {
                    isvisible = false;
                }
            }
            if (distravled> 500)
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
