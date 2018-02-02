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
        Vector2 position;
        Vector2 velocity;
        bool jumped;
        public BlackWing(Vector2 newposition)
        {
            position = newposition;
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
            position += velocity;
            if((keyState.IsKeyDown(Keys.Up)) && jumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                jumped = true;
            }
            if (jumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }
            if(position.Y + BlackWingTexture.Height >= 450)
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
            spriteBatch.Draw(BlackWingTexture,new Rectangle(BlackWingbox.X,BlackWingbox.Y,100,100), Color.White);
            spriteBatch.End();


         
        }
    }
}