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
    public class EnemyRange:Enemy
    {
        ContentManager content;
        public Texture2D RangeTexture;
        public List<Bullet> bulletlist;
        public int health, speed, Bulletdelay;
        Texture2D BulletTexture;
        public int direction;
        public bool isVisible;
        SpriteEffects Effect;

        public EnemyRange(Texture2D newTexture , Vector2 newPos, Texture2D newBulletTexture,int Width , int Height)
        {
            bulletlist = new List<Bullet>();
            RangeTexture = newTexture;
            BulletTexture = newBulletTexture;
            health = 1;
            Bulletdelay = 40;
            speed = 5;
            isVisible = true;        
            direction = -1;
            Effect = SpriteEffects.None;
            hitbox = new Rectangle((int)newPos.X, (int)newPos.Y, 70, 70);
        }
  
        public override void Update(BlackWing blackwing,BlackWing newcharacter, List<Line>Lines)
        {
         
            if(newcharacter.BlackWingbox.X > hitbox.X || blackwing.BlackWingbox.X > hitbox.X)
            {
                direction = 1;
                Effect = SpriteEffects.FlipHorizontally;
            }
            else if(newcharacter.BlackWingbox.X < hitbox.X || blackwing.BlackWingbox.X < hitbox.X)
            {
                direction = -1;
                Effect = SpriteEffects.None;
            }
            //collision
            
            EnemyShoot();
            if (Bulletdelay == 0)
            {
                EnemyShoot();
            }
            UpdateBullets(Lines);
            //flip

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
            if (Bulletdelay >= 0)
            {
                Bulletdelay--;
            }
            if (Bulletdelay <= 0)
            {
                //new bullet and position
                Bullet newBullet = new Bullet(BulletTexture, hitbox.X, hitbox.Y, direction);
                if (bulletlist.Count < 1)
                {
                    bulletlist.Add(newBullet);
                }
            }
            if (Bulletdelay == 0)
            {
                Bulletdelay = 8;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(RangeTexture, hitbox, null, Color.White, 0f, new Vector2(), Effect, 0f);
            foreach (Bullet b in bulletlist)
            {
                b.Draw(spriteBatch);
            }
            
        }
    
    }
}