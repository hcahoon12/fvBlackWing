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
        private Vector2 velocity;
        int left;
        public int health;
        public Enemy()
        {
            left = hitbox.Left;
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
            if (blackwing.BlackWingbox.Intersects(hitbox))
            {
                blackwing.health--;
            }
            if (newcharacter.BlackWingbox.Intersects(hitbox))
            {
                newcharacter.health--;
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
            }
            for (int l = 0; l < Lines.Count; l++)
            {
                if (hitbox.Intersects(Lines[l].rectangle))
                {
                    collide = true;
                    break;
                }
                if (collide)
                {
                    if (velocity.Y >= 0)
                    {
                        velocity.Y = 0;
                        hitbox.Y--;
                    }
                    else
                    {
                        velocity.Y = 0;
                        hitbox.Y++;
                    }
                }
              //left and right collision
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
        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}


