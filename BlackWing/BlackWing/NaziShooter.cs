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
    class NaziShooter
    {
        public Texture2D NaziShotTexture;
        public Vector2 NaziShotPos;
        public float NaziShotSpeed;
        public bool isVisible = true;
        public NaziShooter()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            NaziShotTexture = Content.Load<Texture2D>("NaziSldr");
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
