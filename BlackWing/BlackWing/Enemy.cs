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
   public class Enemy
    {
        public Rectangle hitbox;
        bool collide;
        public Vector2 velocity;
        public int health;
        public int direction;
        public int speed;
        public Enemy()
        {
            direction = -1;
            velocity.X = 0;
            velocity.Y = 0;
        }
        public virtual void Update(BlackWing blackwing, BlackWing newcharacter, List<Line> Lines)
        {
            for (int i = 0; i < blackwing.starlist.Count; i++)
            {
                if (blackwing.starlist[i].starbox.Intersects(hitbox))
                {
                    blackwing.starlist[i].isvisible = false;
                    health--;
                }
            }
            for (int i = 0; i < newcharacter.starlist.Count; i++)
            {
                if (newcharacter.starlist[i].starbox.Intersects(hitbox))
                {
                    newcharacter.starlist[i].isvisible = false;
                    health--;
                }
            }
            for (int i = 0; i < Math.Abs(velocity.Y); i++)
            {
                collide = false;
                if (velocity.Y >= 0)
                {
                    hitbox.Y++;
                }
                if (velocity.Y <= 0)
                {
                    hitbox.Y--;
                }

                //downward collision
                for (int l = 0; l < Lines.Count; l++)
                {
                    if (hitbox.Intersects(Lines[l].rectangle))
                    {
                       
                        if (velocity.Y >= 0)
                        {
                            velocity.Y = 0;
                            hitbox.Y--;
                        }
                     
                            break;
                    }
                   

                }
            }
            //left and right collision
            for (int i = 0; i < Math.Abs(velocity.X); i++)
            {
                collide = false;
                if (velocity.X > 0)
                {
                    hitbox.X++;
                }
                if (velocity.X < 0)
                {
                    hitbox.X--;
                }

               
                for (int l = 0; l < Lines.Count; l++)
                {
                    if (hitbox.Intersects(Lines[l].rectangle))
                    {

                        if (velocity.X > 0)
                        {
                            velocity.X = 0;
                            hitbox.X--;
                        }
                        if(velocity.X < 0)
                        {
                            velocity.X = 0;
                            hitbox.X++;
                        }

                        break;
                    }


                }
            }
          
       


            if (hitbox.X >= 810)
            {
                hitbox.X = 810;
            }
            if (hitbox.X <= 0)
            {
                hitbox.X = 0;
            }
            if (hitbox.Y >= 540)
            {
                hitbox.Y = 540;
            }
            if (hitbox.Y <= 0)
            {
                hitbox.Y = 0;
            }
            float K = 2.9f;
            velocity.Y += 0.17f * K;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}


