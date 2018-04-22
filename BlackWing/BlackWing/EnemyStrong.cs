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
    class EnemyStrong:Enemy
    {
        public Texture2D StrongTexture;
        public Vector2 StrongPos;
        public int StrongSpeed;
        public int health;
        public int direction;
        public Rectangle strongbox;
        public bool isVisible;
        Vector2 Velocity;
        public EnemyStrong(Texture2D newTexture, Vector2 newpos)
        {
            health = 5;
            StrongTexture = newTexture;
            StrongPos = newpos;
            StrongSpeed = 3;
            direction = -1;
            isVisible = true;
        }
        public void Update(BlackWing blackwing, BlackWing newcharacter, List<Line> Lines)
        {

            for (int i = 0; i < blackwing.starlist.Count; i++)
            {
                if (blackwing.starlist[i].starbox.Intersects(strongbox))
                {
                    blackwing.starlist[i].isvisible = false;
                    health--;
                }
            }
            for (int i = 0; i < newcharacter.starlist.Count; i++)
            {
                if (newcharacter.starlist[i].starbox.Intersects(strongbox))
                {
                    newcharacter.starlist[i].isvisible = false;
                    health--;
                }
            }
            if (blackwing.BlackWingbox.Intersects(strongbox))
            {
                blackwing.health--;
            }
            if (newcharacter.BlackWingbox.Intersects(strongbox))
            {
                newcharacter.health--;
            }
         /* if (newcharacter.BlackWingbox.X > strongbox.X)
            {
                for (int i = 0; i < 3; i--)
                strongbox.X--;
                direction = 1;
            }
            if (newcharacter.BlackWingbox.X > strongbox.X)
            {
                for (int i = 0; i < 3; i++)
                    strongbox.X++;
                direction = -1;
            }
            if (blackwing.BlackWingbox.X > strongbox.X)
            {
                strongbox.X++;
                direction = 1;
            }
            else
            {
                direction = -1;

            }*/
            //still cant figure out enemy movement
            strongbox = new Rectangle((int)StrongPos.X, (int)StrongPos.Y, 70, 70);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(StrongTexture, strongbox, Color.White);
        }
    }
}
