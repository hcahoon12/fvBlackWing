using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace BlackWing
{

    public class BlackWing
    {
        private Texture2D BlackWingTexture;
        KeyboardState oldState;
        public Rectangle BlackWingbox;
        Vector2 velocity;
        bool jumped;

        public BlackWing(Vector2 newposition)
        {
            BlackWingbox = new Rectangle((int)newposition.X, (int)newposition.Y, 100, 100);
            jumped = true;
            oldState = Keyboard.GetState();

        }

        protected  void Initialize()
        {


        }


        public  void LoadContent(ContentManager Content)
        {
            BlackWingTexture = Content.Load<Texture2D>("BlackWing");
            
        }



        public  void Update(KeyboardState keyState)
        {
            //jump
            BlackWingbox.Y += (int)velocity.Y;
            if((keyState.IsKeyDown(Keys.Up)) && jumped == false)
            {
                BlackWingbox.Y -=10;
                velocity.Y = -11f;
                jumped = true;
            }
            if (jumped == true)
            {
                float i = 1.85f;
                velocity.Y += 0.15f * i;
            }
            if(BlackWingbox.Y + BlackWingTexture.Height >= 850)
            {
                jumped = false;
            }
            if (jumped == false)
            {
                velocity.Y = 0f;
            }

            //movement
            if (keyState.IsKeyDown(Keys.Right))
                BlackWingbox.X+= 12;
            if (keyState.IsKeyDown(Keys.Left))
                BlackWingbox.X-= 12;
            //boundaries
            if (BlackWingbox.X <= 0)
            {
                BlackWingbox.X = 0;
            }
            if (BlackWingbox.Y <= 0)
            {
                BlackWingbox.Y = 0;
            }
            if (BlackWingbox.Y >= 520)
            {
                BlackWingbox.Y = 520;
            }






        }

        public  void Draw(SpriteBatch spriteBatch)
        {  
            spriteBatch.Draw(BlackWingTexture,new Rectangle(BlackWingbox.X,BlackWingbox.Y,90,90), Color.White);
        }
    }
}