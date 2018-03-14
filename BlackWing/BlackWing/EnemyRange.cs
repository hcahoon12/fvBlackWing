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
        public Texture2D RangeTexture;
        public Vector2 RangePos;
        public Vector2 Velocity;
        public bool isVisible = true;
        public float RangeSpeed;
        List<Bullets> bullets = new List<Bullets>();
        Texture2D BulletTexture;
        Random random = new Random();
        int randX, randY;
        public EnemyRange(Texture2D newrangeTexture, Vector2 newRangepos, Texture2D newbulletTexture)
        {
            RangeTexture = newrangeTexture;
            RangePos = newRangepos;
            BulletTexture = newbulletTexture;
            randY = random.Next(-4, 4);
            randX = random.Next(-4, 1);
            Velocity = new Vector2(randX, randY);

        }
        public void LoadContent(ContentManager Content)
        {
            RangeTexture = Content.Load<Texture2D>("EnemyRange");
            BulletTexture = Content.Load<Texture2D>("Bullet");
        }
        public void Update()
        {
            RangePos += Velocity;
            if(RangePos.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
            }
            //if (RangePos.X < 0 - Texture.Width)
            {
                isVisible = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}