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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            blackWing = new BlackWing(new Vector2(100, 100));
            oldKeyState = Keyboard.GetState();
            base.Initialize();
        }

      
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            blackWing.LoadContent(Content);
        }
        
        protected override void UnloadContent()
        {
           
        }

     
        protected override void Update(GameTime gameTime)
        {

            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            blackWing.Update(keyState);
            base.Update(gameTime);
            oldKeyState = keyState;
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            blackWing.Draw(spriteBatch);
     

            base.Draw(gameTime);
        }
    }
}
