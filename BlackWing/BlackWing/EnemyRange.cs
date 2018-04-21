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
    class EnemyRange:Enemy
    {
        ContentManager content;
        public Texture2D RangeTexture;
        public List<Bullet> bulletlist;
        public Vector2 Rangepos;
        public int health, speed, Bulletdelay;
        public Rectangle Rangebox;
        Texture2D BulletTexture;
        public int direction;
        public bool isVisible;
        public EnemyRange(Texture2D newTexture , Vector2 newPos, Texture2D newBulletTexture,int Width , int Height)
        {
            bulletlist = new List<Bullet>();
            RangeTexture = newTexture;
            BulletTexture = newBulletTexture;
            health = 1;
            Rangepos = newPos;
            Bulletdelay = 40;
            speed = 5;
            isVisible = true;        
            direction = -1;
        }
  
        public void Update(BlackWing blackwing,BlackWing newcharacter, List<Line>Lines)
        {
         
            if(newcharacter.BlackWingbox.X > Rangebox.X || blackwing.BlackWingbox.X > Rangebox.X)
            {
                direction = 1;
            }
            else if(newcharacter.BlackWingbox.X < Rangebox.X || blackwing.BlackWingbox.X < Rangebox.X)
            {
                direction = -1;
               
            }
            //collision
            Rangebox = new Rectangle((int)Rangepos.X, (int)Rangepos.Y, 70, 70);
            EnemyShoot();
            if (Bulletdelay == 0)
            {
                EnemyShoot();
            }
            UpdateBullets(Lines);
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
                Bullet newBullet = new Bullet(BulletTexture, Rangebox.X, Rangebox.Y, direction);
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
            spriteBatch.Draw(RangeTexture, Rangebox, Color.White);
            foreach (Bullet b in bulletlist)
            {
                b.Draw(spriteBatch);
            }
            
        }
    
    }
}