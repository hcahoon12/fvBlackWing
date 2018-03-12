using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlackWing
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BlackWing blackWing;
        KeyboardState oldKeyState;
        bool titlescreenseen;
        bool Flseen;
        Texture2D titlescreentexture;
        Texture2D FLtexture;
        Texture2D backgroundTexture;
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Flseen = false;
            titlescreenseen = true;
            //screensize
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;

        }


        protected override void Initialize()
        {
            blackWing = new BlackWing(new Vector2(0, 500));

            oldKeyState = Keyboard.GetState();
            base.Initialize();
        }

      
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            titlescreentexture = Content.Load<Texture2D>("Heros War");
            FLtexture = Content.Load<Texture2D>("game over");
            blackWing.LoadContent(Content);
        }
        
        protected override void UnloadContent()
        {
           
        }

     
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (titlescreenseen == true)
            {
                backgroundTexture = titlescreentexture;
            }
            if (blackWing.BlackWingbox.X >= 960)
            {
                blackWing.BlackWingbox.X = 0;
                blackWing.BlackWingbox.Y = 520;
                titlescreenseen = false;
                
                Flseen = true;
            }
           
            MouseState mouseState = Mouse.GetState();

            blackWing.Update(keyState);
            base.Update(gameTime);
            oldKeyState = keyState;
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
           
            if (titlescreenseen == true)
            {
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 960, 600), Color.White);
                
            }
            if (Flseen == true)
            {
               
                spriteBatch.Draw(FLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                
            }
            blackWing.Draw(spriteBatch);
            spriteBatch.End();
          
     

            base.Draw(gameTime);
        }
    }
}
