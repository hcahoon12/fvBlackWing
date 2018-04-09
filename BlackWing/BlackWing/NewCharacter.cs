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

    public class NewCharacter
    {
        public int speed;
        //need list to be public
        List<Star> starlist;
        public Vector2 position;
        public Texture2D newcharacterTexture, startexture;
        public Texture2D BlackWingTexture2;
        KeyboardState oldState;
        public Rectangle ncbox;
        Vector2 velocity;
        bool jumped;
        public int health;
        Vector2 hposition;
        Texture2D HealthTexture;
        private int maxhealth;
        public float stardelay;
        public Rectangle Boundingbox;
        public bool iscoliding;
        ContentManager content;
        int Direction;
        bool blackwingright;
        bool blackwingleft;
        bool collide;
        bool starcollide;
        bool ismelee;


        public NewCharacter(Vector2 newposition, int Health, Vector2 HPosition)
        {
            //melee

            float MaxAttackTime = 0.33f;
            float AttackTime;

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
            ncbox = new Rectangle((int)newposition.X, (int)newposition.Y + 50,60, 60);
            jumped = true;
            oldState = Keyboard.GetState();
            Direction = 1;
        }
        protected void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            newcharacterTexture = Content.Load<Texture2D>("aquatowa (2)");
            BlackWingTexture2 = Content.Load<Texture2D>("aquatowa");
            HealthTexture = Content.Load<Texture2D>("RED");
            startexture = Content.Load<Texture2D>("starrrr");
            content = Content;
        }
        public void Update(KeyboardState keyState, List<Line> Lines)
        {
            // public void Attack()
            {
                //Melee
                if ((keyState.IsKeyDown(Keys.E)))
                {

                }
            }
            //shoot
            if ((keyState.IsKeyDown(Keys.F)))
            {
                Shoot();
            }
            UpdateStar(Lines);


            for (int i = 0; i < Math.Abs(velocity.Y); i++)
            {
                collide = false;
                if (velocity.Y >= 0)
                {
                    ncbox.Y++;

                }
                if (velocity.Y <= 0)
                {
                    ncbox.Y--;
                }
                for (int l = 0; l < Lines.Count; l++)
                    if (ncbox.Intersects(Lines[l].rectangle))
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
                        ncbox.Y--;
                    }
                    else
                    {
                        velocity.Y = 0;
                        ncbox.Y++;
                    }
                }
            }
            if ((keyState.IsKeyDown(Keys.W)) && jumped == false)
            {
                //collsion
                collide = false;
                for (int i = 0; i < 10; i++)
                {
                    ncbox.Y--;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (ncbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies
                    if (collide)
                    { ncbox.Y++; }
                }
                velocity.Y = -11f;
                jumped = true;
            }

            float K = 2.7f;
            velocity.Y += 0.17f * K;



            if (ncbox.Y + newcharacterTexture.Height >= 880)
            {
                jumped = false;
            }

            //movement
            if (keyState.IsKeyDown(Keys.A))
            {
                collide = false;
                blackwingright = false;
                blackwingleft = true;
                for (int i = 0; i < 10; i++)
                {
                    //collsion
                    ncbox.X--;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (ncbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies


                    if (collide)
                    {
                        ncbox.X += 2;
                    }

                    Direction = -1;
                }
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                blackwingright = true;
                blackwingleft = false;
                collide = false;
                for (int i = 0; i < 10; i++)
                {
                    //collsion
                    ncbox.X++;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        if (ncbox.Intersects(Lines[l].rectangle))
                        {
                            collide = true;
                            break;
                        }
                    //Enemies
                    if (collide)
                    {
                        ncbox.X -= 2;
                    }

                    Direction = 1;
                }
            }
            //boundaries
            if (ncbox.X <= 0)
            {
                ncbox.X = 0;
            }
            if (ncbox.Y <= 0)
            {
                ncbox.Y = 0;
            }
            if (ncbox.Y >= 530)
            {
                ncbox.Y = 530;
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
                Star newStar = new Star(startexture, ncbox.X, ncbox.Y, Direction);
                //add to list
                if (starlist.Count() < 1)
                {
                    starlist.Add(newStar);
                }
            }

            // reset delay
            if (stardelay == 0)
            {
                stardelay = 3;
            }
        }
        // update bullet function
        public void UpdateStar(List<Line> Lines)
        {

            for (int i = 0; i < starlist.Count; i++)
            {

                starlist[i].Update(Lines);
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
                    spriteBatch.Draw(newcharacterTexture, new Rectangle(ncbox.X, ncbox.Y, 60, 60), Color.White);
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(HealthTexture, new Rectangle(ncbox.X + i * ncbox.Width / maxhealth, ncbox.Y - 10, ncbox.Width / maxhealth - 3, 7), Color.White);
                    }

                }
            }
            if (blackwingleft == true)
            {
                if (health > 0)
                {
                    foreach (Star S in starlist)
                        S.Draw(spriteBatch);
                    spriteBatch.Draw(BlackWingTexture2, new Rectangle(ncbox.X, ncbox.Y, 60, 60), Color.White);
                    for (int i = 0; i < health; i++)
                    {
                        spriteBatch.Draw(HealthTexture, new Rectangle(ncbox.X + i * ncbox.Width / maxhealth, ncbox.Y - 10, ncbox.Width / maxhealth - 3, 7), Color.White);
                    }

                }

            }
        }
    }
}