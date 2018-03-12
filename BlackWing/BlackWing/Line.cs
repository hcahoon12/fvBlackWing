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
    public class Line
    {
        Texture2D texture;
        Vector2 position;
        public Rectangle rectangle;
        ContentManager content;
        Color color;
        public Line(Texture2D newTexture, Vector2 newPosition, int Width,int Height,Color LineColor)
        {
            texture = newTexture;
            position = newPosition;
            rectangle = new Rectangle((int)position.X,(int)position.Y , Width , Height);
            color = LineColor;
        }
        public void Load(ContentManager Content)
        {
            content = Content;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, color);
        }
        public void AddHitbox()
        {

        }
    }
}
