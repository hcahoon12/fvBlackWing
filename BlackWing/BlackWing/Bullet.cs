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
        public int speed;
        int xOffset;
        int yOffset;
        int distravled;
        public Bullet(Texture2D newtexture,int X,int Y, int direction)
        {
            distravled = 0;
            speed = 10 * direction;
            texture = newtexture;
            if (direction < 0)
            {
                xOffset = 0;
                yOffset = 30;
                //left
            }
            else
            {
                xOffset = 45;
                yOffset = 30;
                //right
            }
            boundingbox = new Rectangle(X + xOffset, Y + yOffset, 12, 12);
            isVisible = true;
        }
        public void Update(List<Line> Lines)
        {
            boundingbox.X += speed;
            distravled += Math.Abs(speed);
            for (int l = 0; l < Lines.Count; l++)
            {
                if (boundingbox.Intersects(Lines[l].rectangle))
                {
                    isVisible = false;
                }
            }
            if (distravled > 500)
            {
                isVisible = false;
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, boundingbox, Color.White);
        }
    }
}
