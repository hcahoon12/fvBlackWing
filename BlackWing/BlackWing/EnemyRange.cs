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
    class EnemyRange
    {
        ContentManager content;
        public Texture2D RangeTexture;
        public List<Bullet> bulletlist;
        public Vector2 Rangepos;
        public int health, speed, Bulletdelay;
        public Rectangle Rangebox;
        Texture2D BulletTexture;
        public bool isVisible;
        public EnemyRange(Texture2D newTexture , Vector2 newPos, Texture2D newBulletTexture)
        {
            bulletlist = new List<Bullet>();
            RangeTexture = newTexture;
            BulletTexture = newBulletTexture;
            health = 1;
            Rangepos = newPos;
            Bulletdelay = 40;
            speed = 5;
            isVisible = true;
        }
  
        public void Update()
        {

            //collision
            Rangebox = new Rectangle((int)Rangepos.X, (int)Rangepos.Y, RangeTexture.Width, RangeTexture.Height);
            //movement
            Rangepos.X += speed;
            EnemyShoot();
           // UpdateBullets();
        }
     
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(RangeTexture, Rangepos, Color.White);
            foreach (Bullet b in bulletlist)
            {
                b.Draw(spriteBatch);
            }
            
        }
      /*public void UpdateBullets()
        {
          foreach(Bullet b in bulletlist)
            {
                b.boundingbox = new Rectangle((int)b.position.X, (int)b.position.Y, b.texture.Width, b.texture.Height);
                b.position.X = b.position.X - b.speed;
                if(b.position.X <= 0)
                {
                    b.isVisible = false;
                }
                for (int i =0; i<bulletlist.Count; i++)
                {
                    if (bulletlist[i].isVisible)
                    {
                        bulletlist.RemoveAt(i);
                        i--;
                    }
                }
            }
        }*/
        public void EnemyShoot()
        {
            if (Bulletdelay >= 0)
            {
                Bulletdelay--;
            }
            if (Bulletdelay <= 0)
            {
                //new bullet and position
                Bullet newBullet = new Bullet(BulletTexture);
                newBullet.position = new Vector2(Rangepos.X + RangeTexture.Width / 2 - newBullet.texture.Width / 2, Rangepos.Y + 30);
                newBullet.isVisible = true;
                if(bulletlist.Count < 20)
                {
                    bulletlist.Add(newBullet);
                }
            }
            if (Bulletdelay == 0)
            {
                Bulletdelay = 20;
            }
        }
    }
}