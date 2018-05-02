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
   public class Weapon
    {
        public Rectangle swordrec;
        public Texture2D swordtexture;
       public int xoffset;
        public int yoffset;
        public int Direction;
        SpriteEffects UP;
        SpriteEffects Right;
        public Weapon( Texture2D swordtexture, int Direction,int X, int Y)
        {
            UP = SpriteEffects.None;
            Right = SpriteEffects.None;
            this.swordtexture = swordtexture;
            Direction = 1;
            if (Direction > 0)
            {
                xoffset = 0;
                yoffset = 30;
            }
            else
            {
                xoffset = 60;
                yoffset = 30;
            }
            swordrec = new Rectangle(X + xoffset, Y + yoffset, 20, 20);
        }
        public void Update(KeyboardState keystate, Enemy enemy, BlackWing blackWing)
        {
            if (keystate.IsKeyDown(Keys.RightShift))
            {
              if(Direction > 0)
                {
                    xoffset = 60;
                    UP = SpriteEffects.FlipVertically;
                    Right = SpriteEffects.FlipHorizontally;
                }
              else if (Direction < 0)
                {
                    xoffset = 0;
                    UP = SpriteEffects.FlipVertically;
                    Right = SpriteEffects.FlipHorizontally;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(swordtexture, swordrec, Color.White);
        }
    }
}
