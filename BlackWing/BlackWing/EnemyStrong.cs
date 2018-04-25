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
        public int direction;
        public bool isVisible;
        public EnemyStrong(Texture2D newTexture, Vector2 newpos)
        {
            health = 5;
            StrongTexture = newTexture;
            StrongSpeed = 3;
            direction = -1;
            hitbox = new Rectangle((int)newpos.X, (int)newpos.Y, 70, 70);
            isVisible = true;
        }
        public override void Update(BlackWing blackwing, BlackWing newcharacter, List<Line> Lines)
        {

            
            
          if (newcharacter.BlackWingbox.X > hitbox.X)
            {
                for (int i = 0; i < 3; i--)
                hitbox.X--;
                direction = 1;
            }
            if (newcharacter.BlackWingbox.X > hitbox.X)
            {
                for (int i = 0; i < 3; i++)
                    hitbox.X++;
                direction = -1;
            }
            if (blackwing.BlackWingbox.X > hitbox.X)
            {
                hitbox.X++;
                direction = 1;
            }
            else
            {
                hitbox.X--;
                direction = -1;

            }
            //still cant figure out enemy movement
            
            base.Update(blackwing,newcharacter,Lines);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(StrongTexture, hitbox, Color.White);
        }
    }
}
