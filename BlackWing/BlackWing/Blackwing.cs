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
        private Rectangle BlackWingbox;
        Vector2 velocity;
        bool jumped;
        public BlackWing(Vector2 newposition)
        {
            BlackWingbox = new Rectangle(0, 400, 100, 100);
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
                velocity.Y = -6f;
                jumped = true;
            }
            if (jumped == true)
            {
                float i = 1.5f;
                velocity.Y += 0.15f * i;
            }
            if(BlackWingbox.Y + BlackWingTexture.Height >= 800)
            {
                jumped = false;
            }
            if (jumped == false)
            {
                velocity.Y = 0f;
            }

            //movement
            if (keyState.IsKeyDown(Keys.Right))
                BlackWingbox.X+= 5;
            if (keyState.IsKeyDown(Keys.Left))
                BlackWingbox.X-= 5;
            //boundaries
            if (BlackWingbox.X <= 0)
            {
                BlackWingbox.X = 0;
            }
            if (BlackWingbox.Y <= 0)
            {
                BlackWingbox.Y = 0;
            }
            if (BlackWingbox.Y >= 380)
            {
                BlackWingbox.Y = 380;
            }






        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BlackWingTexture,new Rectangle(0,400,70,70), Color.White);
            spriteBatch.End();


         
        }
    }
}