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

    public class BlackWing
    {
        public int speed;
        public Vector2 position;
        public Texture2D BlackWingTexture, startexture;
        public Texture2D BlackWingTexture2;
        KeyboardState oldState;
        public Rectangle BlackWingbox;
        Vector2 velocity;
        bool jumped;
        public int health;
        Vector2 hposition;
        Texture2D HealthTexture;
        private int maxhealth;
        List<Star> starlist;
        public float stardelay;
        public Rectangle Boundingbox;
        public bool iscoliding;
        ContentManager content;
        int Direction;
        bool blackwingright;
        bool blackwingleft;
        bool collide;


        public BlackWing(Vector2 newposition , int Health , Vector2 HPosition)
        {
            blackwingright = true;
            blackwingleft = false;
            iscoliding = false;
            speed = 10;
            position = new Vector2(300, 300);
            stardelay = 3;
            starlist = new List<Star>();
            maxhealth = Health;
            health = Health;
            hposition = HPosition;
            BlackWingbox = new Rectangle((int)newposition.X, (int)newposition.Y+50, 60, 60);
            jumped = true;
            oldState = Keyboard.GetState();
            Direction = 1;

        }

        protected  void Initialize()
        {
          
        }


        public  void LoadContent(ContentManager Content)
        {
            BlackWingTexture = Content.Load<Texture2D>("blackwing");
            BlackWingTexture2 = Content.Load<Texture2D>("blackwing2");
            HealthTexture = Content.Load<Texture2D>("RED");
            startexture = Content.Load<Texture2D>("starrrr");
            content = Content;
        }



        public void Update(KeyboardState keyState, List<Line> Lines)
        {

            //shoot

            if ((keyState.IsKeyDown(Keys.E)))
            {
                Shoot();
            }
            UpdateStar();
            //jump
            for (int i = 0; i < Math.Abs(velocity.Y); i++)
            {
                collide = false;
                if (velocity.Y >= 0)
                {
                    BlackWingbox.Y++;
                   
                }
                if (velocity.Y <= 0)
                {
                    BlackWingbox.Y--;
                   
                }
                for (int l = 0; l < Lines.Count; l++)
                    if (BlackWingbox.Intersects(Lines[l].rectangle))
                    {
                        collide = true;
                        break;
                    }
                if (collide)
                {
                    if (velocity.Y >= 0)
                    {
                        jumped = false;
                        velocity.Y = 0;
                        BlackWingbox.Y--;
                    }
                    else
                    {
                        
                        velocity.Y = 0;
                        BlackWingbox.Y++;
                    }
                }
            }
            if ((keyState.IsKeyDown(Keys.Up)) && jumped == false)
            {
                //collsion
                collide = false;
                for (int i = 0; i < 10; i++)
                {
                    BlackWingbox.Y--;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (BlackWingbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies
                    if (collide)
                    { BlackWingbox.Y++; }
                }
                velocity.Y = -11f;
                jumped = true;
            }
           
                float K = 2.7f;
                velocity.Y += 0.15f * K;
            
          
            
            if (BlackWingbox.Y + BlackWingTexture.Height >= 880)
            {
                jumped = false;
            }
          
            //movement
            if (keyState.IsKeyDown(Keys.Left))
            {
                collide = false;
                blackwingright = false;
                blackwingleft = true;
                for (int i = 0; i < 7; i++)
                {
                    //collsion
                    BlackWingbox.X--;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (BlackWingbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies


                    if (collide)
                    {
                        BlackWingbox.X +=2;
                    }

                    Direction = -1;
                }
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                blackwingright = true;
                blackwingleft = false;
                collide = false;
                for (int i = 0; i < 7; i++)
                {
                    //collsion
                    BlackWingbox.X++;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (BlackWingbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies
                    if (collide)
                    {
                        BlackWingbox.X -=2;
                    }

                    Direction = 1;
                }
            }
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
        
        //shoot
        public void Shoot()
        {
            if (stardelay >= 0)
            {
                stardelay--;
            }
            if (stardelay <= 0)
            {
                Star newStar = new Star(startexture , BlackWingbox.X , BlackWingbox.Y , Direction);
                //add to list
                if (starlist.Count() < 1)
                {
                    starlist.Add(newStar);
                }
            }

            // reset delay
            if(stardelay == 0)
            {
                stardelay = 3;
            }
        }
        // update bullet function
        public void UpdateStar()
        {

            for (int i =0; i<starlist.Count; i++)
            {
                
                starlist[i].Update();
                if (!starlist[i].isvisible)
                {
                    starlist.RemoveAt(i);
                    i--;
                }
            }
        }

      
        public void Draw(SpriteBatch spriteBatch)
        {
            if (blackwingright == true)
            {
                if (health > 0)
                {
                    foreach (Star S in starlist)
                        S.Draw(spriteBatch);
                    spriteBatch.Draw(BlackWingTexture, new Rectangle(BlackWingbox.X, BlackWingbox.Y, 60, 60), Color.White);
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(HealthTexture, new Rectangle(BlackWingbox.X + i * BlackWingbox.Width / maxhealth, BlackWingbox.Y - 10, BlackWingbox.Width / maxhealth - 3, 7), Color.White);
                    }

                }
            }
            if (blackwingleft == true)
            {
                if (health > 0)
                {
                    foreach (Star S in starlist)
                        S.Draw(spriteBatch);
                    spriteBatch.Draw(BlackWingTexture2, new Rectangle(BlackWingbox.X, BlackWingbox.Y, 60, 60), Color.White);
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(HealthTexture, new Rectangle(BlackWingbox.X + i * BlackWingbox.Width / maxhealth, BlackWingbox.Y - 10, BlackWingbox.Width / maxhealth - 3, 7), Color.White);
                    }

                }

            }
        }
    }
}