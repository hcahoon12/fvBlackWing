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
        //need list to be public
        public List<Star> starlist;
        public Vector2 position;
        public Texture2D BlackWingTexture, startexture, swordTexture;
        public Texture2D AquaTexture;
        public Texture2D AquaTexture2;
        public Texture2D BlackWingTexture2;
        KeyboardState oldState;
        public Rectangle BlackWingbox;
        Vector2 velocity;
        bool jumped;
        public int health;
        Vector2 hposition;
        Texture2D HealthTexture;
        private int maxhealth;
        public List<Weapon> weaponlist;
        public float stardelay;
        public Rectangle Boundingbox;
        public bool iscoliding;
        ContentManager content;
        public int Direction;
        bool blackwingright;
        bool blackwingleft;
        bool collide;
        Keys up;
        Keys right;
        Keys left;
        Keys shootbutton;
        Keys down;
        Keys melee;
        public float weapondelay;
        
        public BlackWing(int speed, Vector2 newposition , int Health , Vector2 HPosition,Keys up,Keys right, Keys left, Keys shootbutton, Keys down, Keys melee)
        {
            //melee
            
            this.right = right;
            this.left = left;
            this.up = up;
            this.down = down;
            this.shootbutton = shootbutton;
            this.melee = melee;
            blackwingright = true;
            blackwingleft = false;
            iscoliding = false;
            this.speed = speed;
            position = new Vector2(300, 300);
            stardelay = 0;
            starlist = new List<Star>();
            maxhealth = Health;
            health = Health;
            weapondelay = 0;
            hposition = HPosition;
            BlackWingbox = new Rectangle((int)newposition.X, (int)newposition.Y, 60, 60);
            jumped = true;
            oldState = Keyboard.GetState();
            Direction = 1;
            
        }

        protected  void Initialize()
        {
          
        }


        public  void LoadContent(ContentManager Content, string PTextureRight, string PTextureLeft, string shoottexture, string swordtexture)
        {
            BlackWingTexture = Content.Load<Texture2D>(PTextureRight);
            BlackWingTexture2 = Content.Load<Texture2D>(PTextureLeft);
            AquaTexture = Content.Load<Texture2D>(PTextureRight);
            AquaTexture2 = Content.Load<Texture2D>(PTextureLeft);
            HealthTexture = Content.Load<Texture2D>("RED");
            startexture = Content.Load<Texture2D>(shoottexture);
            swordTexture = Content.Load<Texture2D>(swordtexture);

            content = Content;
        }

        public void Update(KeyboardState keyState, List<Line> Lines)
        
        { 
            //Melee
            if ((keyState.IsKeyDown(melee)))
                {
                    
                    Attack();
                
                }
        
            //shoot
            if ((keyState.IsKeyDown(shootbutton)))
            {
                Shoot();
            }
          
                UpdateStar(Lines);
            

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
            if ((keyState.IsKeyDown(up)) && jumped == false)
            {
             
                for (int i = 0; i < speed*2-2; i++)
                {
                    //collsion
                    collide = false;
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
                velocity.Y = -12f;
                jumped = true;
            }
           
                float K = 2.9f;
                velocity.Y += 0.17f * K;

           if (BlackWingbox.Y + BlackWingbox.Height >= 590)
            {
                jumped = false;
            }
          
            //movement
            if (keyState.IsKeyDown(left))
            {
               
                blackwingright = false;
                blackwingleft = true;
                for (int i = 0; i < speed; i++)
                {
                    collide = false;
                    //collsion
                    BlackWingbox.X--;
                    //Lines
                    for (int l = 0; l < Lines.Count; l++)
                        while (BlackWingbox.Intersects(Lines[l].rectangle))
                        {
                            BlackWingbox.X += 1;
                        }
                    //Enemies

                    Direction = -1;
                }
            }
            if (keyState.IsKeyDown(right))
            {
                blackwingright = true;
                blackwingleft = false;
                
                for (int i = 0; i < speed; i++)
                {
                    collide = false;
                    //collsion
                    BlackWingbox.X++;
                    //Lines
               
                    for (int l = 0; l < Lines.Count; l++)
                        while (BlackWingbox.Intersects(Lines[l].rectangle))
                        {
                            BlackWingbox.X -= 1;
                        }
                    //Enemies

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
            if (BlackWingbox.Y >= 540)
            {
                BlackWingbox.Y = 540;
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
        public void UpdateStar(List<Line> Lines)
        {

            for (int i =0; i<Math.Abs(starlist.Count); i++)
            {
                
                starlist[i].Update(Lines);
                if (!starlist[i].isvisible)
                {
                    starlist.RemoveAt(i);
                    i--;
                }
            }
        }
        public void Attack()
        {
            
            if (weapondelay >= 0)
            {
                weapondelay--;
            }
            if (weapondelay <= 0)
            {
                Weapon newWeapon = new Weapon(swordTexture, BlackWingbox.X, BlackWingbox.Y, Direction);
                //add to list
                /*   if (weaponlist.Count() < 1)
                   {
                       weaponlist.Add(newWeapon);
                   }
                   */
            }

            // reset delay
            if (weapondelay == 0)
            {
                weapondelay = 6;
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
                  /*  foreach(Weapon W in weaponlist)
                    {
                        W.Draw(spriteBatch);
                    }*/
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