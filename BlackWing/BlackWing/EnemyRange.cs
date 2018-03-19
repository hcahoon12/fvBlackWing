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
        public Texture2D RangeTexture, startexture;
        public Vector2 RangePos;
        List<Star> bulletlist;
        public float stardelay;
        public int health;
        public Rectangle Rangebox;
        Vector2 hposition;
        Texture2D HealthTexture;
        Texture2D BulletTexture;
        public bool isVisible = true;
        public bool iscoliding;
        bool collide;
        

        public EnemyRange(Vector2 newRangepos, int Health, Vector2 HPosition)
        {
            bulletlist = new List<Star>();
            RangePos = newRangepos;
            Rangebox = new Rectangle((int)newRangepos.X, (int)newRangepos.Y + 50, 60, 60);
            iscoliding = false;
        }
        public void LoadContent(ContentManager Content)
        {
            RangeTexture = Content.Load<Texture2D>("EnemyRange");
            startexture = Content.Load<Texture2D>("Bullet");
            content = Content;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}