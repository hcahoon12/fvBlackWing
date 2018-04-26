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
    public class EnemyStrong:Enemy
    {
        public Texture2D StrongTexture;
        public int StrongSpeed;
        public bool isVisible;
        SpriteEffects Effect;
        public EnemyStrong(Texture2D newTexture, Vector2 newpos)
        {
            Effect=SpriteEffects.None;
            health = 5;
            StrongTexture = newTexture;
            StrongSpeed = 3;
            direction = -1;
            speed = 2;
            hitbox = new Rectangle((int)newpos.X, (int)newpos.Y, 70, 70);
            isVisible = true;
        }
        public override void Update(BlackWing blackwing, BlackWing newcharacter, List<Line> Lines)
        {
           int guyToP1= Math.Abs(hitbox.X - blackwing.BlackWingbox.X);

          if (newcharacter.BlackWingbox.X > hitbox.X )
            {
                Effect = SpriteEffects.FlipHorizontally;
                velocity.X =1;
                direction = 1;
            }
         else
            {
                Effect = SpriteEffects.None;
                velocity.X = -1;
                direction = -1;
            }
            if (blackwing.BlackWingbox.X > hitbox.X)
            {
                Effect = SpriteEffects.FlipHorizontally;
                velocity.X = 1;
                direction = 1;
            }
            else
            {
                Effect = SpriteEffects.None;
                velocity.X = -1;
                direction = -1;

            }
            //still cant figure out enemy movement
            
            base.Update(blackwing,newcharacter,Lines);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(StrongTexture, hitbox, null, Color.White, 0f, new Vector2(), Effect, 0f);
            base.Draw(spriteBatch);
        }
    }
}
