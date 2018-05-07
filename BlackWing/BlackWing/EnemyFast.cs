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
    class EnemyFast:Enemy
    {
        public Texture2D FastTexture;
        public Vector2 FastPos;
        public bool isVisible;

        SpriteEffects Effect;
        public EnemyFast(Texture2D newTexture, Vector2 newpos)
        {
             
        isVisible = true;
            health = 2;
            Effect = SpriteEffects.None;
            FastPos = newpos;
            FastTexture = newTexture;
            hitbox = new Rectangle((int)newpos.X, (int)newpos.Y, 55,45);
        }
        public override void Update(BlackWing blackwing, BlackWing newcharacter, List<Line> Lines)
        {
             
            if (hitbox.Intersects(blackwing.BlackWingbox))
            {
                blackwing.health -= 1;
                isVisible = false;
            }
            if (hitbox.Intersects(newcharacter.BlackWingbox))
            {
                newcharacter.health -= 1;
                isVisible = false;
            }
            if (newcharacter.BlackWingbox.X > hitbox.X)
            {
                Effect = SpriteEffects.FlipHorizontally;
                velocity.X = 4;
                direction = 1;
            }
            else
            {
                Effect = SpriteEffects.None;
                velocity.X = -4;
                direction = -1;
            }
            if (blackwing.BlackWingbox.X > hitbox.X)
            {
                Effect = SpriteEffects.FlipHorizontally;
                velocity.X = 4;
                direction = 1;
            }
            else
            {
                Effect = SpriteEffects.None;
                velocity.X = -4;
                direction = -1;

            }
         
            base.Update(blackwing, newcharacter, Lines);
        }
    
        public override void Draw(SpriteBatch spriteBatch)
        {
        spriteBatch.Draw(FastTexture, hitbox, null, Color.White, 0f, new Vector2(), Effect, 0f);
        base.Draw(spriteBatch);
        }
    }
}
