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
    class EnemyFast
    {
        public Texture2D FastTexture;
        public Vector2 FastPos;
        public float FastSpeed;
        public bool isVisible = true;
        public EnemyFast()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            FastTexture = Content.Load<Texture2D>("EnemyFast");
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
