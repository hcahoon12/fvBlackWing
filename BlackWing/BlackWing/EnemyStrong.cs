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
    class EnemyStrong
    {
        public Texture2D StrongTexture;
        public Vector2 StrongPos;
        public float StrongSpeed;
        public bool isVisible = true;
        public EnemyStrong()
        {
            
        }
        public void LoadContent(ContentManager Content)
        {
            StrongTexture = Content.Load<Texture2D>("EnemyStrong");
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
