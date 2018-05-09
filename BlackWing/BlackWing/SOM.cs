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
        public int health;
        Random rand = new Random();
        int randx, randy;
        SpriteEffects Effect;
        public SOM(Vector2 position, Texture2D texture)
        {
            Effect = SpriteEffects.None;
            SOMTexture = texture;
            randx = rand.Next(0, 900);
            randy = rand.Next(0, 600);
            SOMPos = position;
            health = 10;
            isVisible = true;
            somrec = new Rectangle((int)position.X, (int)position.Y, 70, 70);
        }
        public void Update(BlackWing blackwing, BlackWing newcharacter)
        {
            int guytoplayer = Math.Abs(blackwing.BlackWingbox.X - somrec.X);
            int guytoother = Math.Abs(newcharacter.BlackWingbox.X - somrec.X);
            if (health > 5)
            {
                if(guytoother > guytoplayer)
                {
                    if (blackwing.BlackWingbox.Y < somrec.Y)
                    {
                        somrec.Y -= 3;
                    }
                    else
                    {
                        somrec.Y += 3;
                    }
                    if (guytoplayer > 400)
                    {
                        somrec.X-=3;
                    }
                    if (guytoplayer <= 400)
                    {
                        //closer to p1 Xpos
                        if (blackwing.BlackWingbox.X >= somrec.X)
                        {
                            Effect = SpriteEffects.FlipHorizontally;
                            somrec.X -= 4;

                        }
                        else
                        {
                            somrec.X += 4;
                            Effect = SpriteEffects.None;
                        }
                    }
                }
                else
                {
                    if (newcharacter.BlackWingbox.Y < somrec.Y)
                    {
                        somrec.Y -= 3;
                    }
                    else
                    {
                        somrec.Y += 3;
                    }
                    if (guytoother > 400)
                    {
                        somrec.X-= 3;
                    }
                    if (guytoother <= 400)
                    {

                        //closer to p2 xpos
                        if (newcharacter.BlackWingbox.X >= somrec.X)
                        {
                            Effect = SpriteEffects.FlipHorizontally;
                            somrec.X -= 4;

                        }
                        else
                        {
                            somrec.X += 4;
                            Effect = SpriteEffects.None;
                        }
                    }
                }
              
              
                
            

                if (somrec.Intersects(blackwing.BlackWingbox))
                {
                    blackwing.BlackWingbox.X -= 300;
                    blackwing.health -= 1;
                }
                if (somrec.Intersects(newcharacter.BlackWingbox))
                {
                    newcharacter.BlackWingbox.X -= 300;
                    newcharacter.health -= 1;
                }
            }
            //HEALTH LOW
            else
            {
                if (guytoother > guytoplayer)
                {
                    if (blackwing.BlackWingbox.X >= somrec.X)
                    {
                        Effect = SpriteEffects.FlipHorizontally;
                        somrec.X += 4;
                    }
                    else
                    {
                        somrec.X -= 4;
                        Effect = SpriteEffects.None;
                    }
                    if (blackwing.BlackWingbox.Y < somrec.Y)
                    {
                        somrec.Y -= 3;
                    }
                    else
                    {
                        somrec.Y += 3;
                    }
                }
                if (guytoplayer> guytoother)
                {
                    if (newcharacter.BlackWingbox.X >= somrec.X)
                    {
                        Effect = SpriteEffects.FlipHorizontally;
                        somrec.X += 4;
                    }
                    else
                    {
                        somrec.X -= 4;
                        Effect = SpriteEffects.None;
                    }
                    if (newcharacter.BlackWingbox.Y < somrec.Y)
                    {
                        somrec.Y -= 4;
                    }
                    else
                    {
                        somrec.Y += 4;
                    }
                }
                if (somrec.Intersects(blackwing.BlackWingbox))
                {
                    blackwing.BlackWingbox.X -= 700;
                    blackwing.health -= 2;
                }
                if (somrec.Intersects(newcharacter.BlackWingbox))
                {
                    newcharacter.BlackWingbox.X -= 700;
                    newcharacter.health -= 2;
                }
            }
                for (int i = 0; i < blackwing.starlist.Count; i++)
                {
                    if (blackwing.starlist[i].starbox.Intersects(somrec))
                    {
                        blackwing.starlist[i].isvisible = false;
                        health--;
                    }
            }
                for (int i = 0; i < newcharacter.starlist.Count; i++)
                {
                    if (newcharacter.starlist[i].starbox.Intersects(somrec))
                    {
                        newcharacter.starlist[i].isvisible = false;
                        health--;
                    }
                }
            if (somrec.X>= 900)
            {
             somrec.X = 900;
            }
           if(somrec.X<= 0)
            {
                somrec.X = 0;
            }
           if(somrec.Y>= 530)
            {
                somrec.Y = 530;
            }
           if(somrec.Y<= 0)
            {
                somrec.Y = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(SOMTexture, somrec, null, Color.White, 0f, new Vector2(), Effect, 0f);
        }
    }
}
