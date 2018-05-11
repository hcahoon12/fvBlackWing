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
        Texture2D bullettexture;
        public List<Bullet> bulletlist;
        public int bulletdelay;
        SpriteEffects Effect;
        public SOM(Texture2D texture, Vector2 position, Texture2D bullettexture, int Width, int Height)
        {
            this.bullettexture = bullettexture;
            bulletlist = new List<Bullet>();
            Effect = SpriteEffects.None;
            SOMTexture = texture;
            SOMPos = position;
            health = 10;
            isVisible = true;
            bulletdelay = 40;
            somrec = new Rectangle((int)position.X, (int)position.Y, 60, 60);
        }
        public void Update(BlackWing blackwing, BlackWing newcharacter, List<Line>Lines)
        {
            int guytoplayer = Math.Abs(blackwing.BlackWingbox.X - somrec.X);
            int guytoother = Math.Abs(newcharacter.BlackWingbox.X - somrec.X);
            if (health > 5)
            {
                EnemyShoot();
                if (bulletdelay == 0)
                {
                    EnemyShoot();
                }
                UpdateBullets(Lines);

                if (guytoother > guytoplayer)
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
                        somrec.Y -= 2;
                    }
                    else
                    {
                        somrec.Y += 2;
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
            
                for (int i = 0; i < bulletlist.Count; i++)
                {
                    if (blackwing.BlackWingbox.Intersects(bulletlist[i].boundingbox))
                    {
                        blackwing.health -= 1;
                        bulletlist[i].isVisible = false;
                    }
                }
                for (int i = 0; i < bulletlist.Count; i++)
                {
                    if (newcharacter.BlackWingbox.Intersects(bulletlist[i].boundingbox))
                    {
                        newcharacter.health -= 1;
                        bulletlist[i].isVisible = false;
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
        public void UpdateBullets(List<Line> Lines)
        {
            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Update(Lines);
                if (!bulletlist[i].isVisible)
                {
                    bulletlist.RemoveAt(i);
                    i--;
                }
            }
        }
        public void EnemyShoot()
        {
            if (bulletdelay > 0)
            {
                bulletdelay--;
            }
            if (bulletdelay <= 0)
            {
                //new bullet and position
                Bullet newBullet = new Bullet(bullettexture, somrec.X, somrec.Y, -1);
                if (bulletlist.Count < 1)
                {
                    bulletlist.Add(newBullet);
                }
            }
            if (bulletdelay == 0)
            {
                bulletdelay = 8;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(SOMTexture, somrec, null, Color.White, 0f, new Vector2(), Effect, 0f);
            foreach (Bullet b in bulletlist)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
