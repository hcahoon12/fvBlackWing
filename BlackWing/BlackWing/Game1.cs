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

    public class Game1 : Game
    {
        SpriteFont Ariel12;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BlackWing blackWing;
        KeyboardState oldKeyState;
        List<Line> Lines = new List<Line>();
        //screens
        bool titlescreenseen;
        bool Flseen;
        bool Slseen;
        bool Tlseen;
        bool Filseen;
        bool sixlseen;
        bool sevlseen;
        bool elseen;
        bool nlseen;
        bool tenlseen;
        bool elelseen;
        bool twelseen;
        bool thirtlseen;
        bool fourtlseen;
        bool fiftlseen;
        bool sixtlseen;
        bool sevtlseen;
        bool goseen;
        //textures
        Texture2D titlescreentexture;
        Texture2D FLtexture;
        Texture2D backgroundTexture;
        Texture2D SLtexture;
        Texture2D TLtexture;
        Texture2D FiLtexture;
        Texture2D SixLtexture;
        Texture2D SevLtexture;
        Texture2D ELtexture;
        Texture2D nltexture;
        Texture2D tenltexture;
        Texture2D eleltexture;
        Texture2D tweltexture;
        Texture2D thirttexture;
        Texture2D forttexture;
        Texture2D fifttexture;
        Texture2D sixttexture;
        Texture2D sevttexture;
        Texture2D gotexture;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Flseen = false;
            Slseen = false;
            Tlseen = false;
            Filseen = false;
            sixlseen = false;
            sevlseen = false;
            elseen = false;
            nlseen = false;
            tenlseen = false;
            elelseen = false;
            twelseen = false;
            goseen = false;
            thirtlseen = false;
            fourtlseen = false;
            fiftlseen = false;
            sixtlseen = false;
            sevtlseen = false;
            titlescreenseen = true;
            //screensize
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
        }


        protected override void Initialize()
        {
            blackWing = new BlackWing(new Vector2(0, 550), 5, new Vector2(400, 400));
            KeyboardState keyState = Keyboard.GetState();
            oldKeyState = Keyboard.GetState();

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


            titlescreentexture = Content.Load<Texture2D>("Heros War");
            FLtexture = Content.Load<Texture2D>("startlvl");
            TLtexture = Content.Load<Texture2D>("Forest Level");
            FiLtexture = Content.Load<Texture2D>("Cave1");
            SixLtexture = Content.Load<Texture2D>("cave2");
            SLtexture = Content.Load<Texture2D>("Secret Level 1 (2)");
            SevLtexture = Content.Load<Texture2D>("nasalvl1");
            ELtexture = Content.Load<Texture2D>("nasalvl2");
            nltexture = Content.Load<Texture2D>("desert");
            tenltexture = Content.Load<Texture2D>("Beachlvl");
            eleltexture = Content.Load<Texture2D>("SeaLevel");
            tweltexture = Content.Load<Texture2D>("SeaLevel2");
            thirttexture = Content.Load<Texture2D>("Boat");
            forttexture = Content.Load<Texture2D>("DDay");
            fifttexture = Content.Load<Texture2D>("bunkerlvl");
            sixttexture = Content.Load<Texture2D>("grass");
            sevttexture = Content.Load<Texture2D>("Final Level");
            gotexture = Content.Load<Texture2D>("GameOver");
            Ariel12 = Content.Load<SpriteFont>("file");
            blackWing.LoadContent(Content);


        }

        protected override void UnloadContent()
        {

        }



        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            //collision with recs
           
            if (blackWing.health > 0)
            {
                blackWing.Update(keyState, Lines);
            }
            if (titlescreenseen == true)
            {
                backgroundTexture = titlescreentexture;

                if (blackWing.BlackWingbox.X >= 960)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    titlescreenseen = false;
                    Flseen = true;
                    FirstLevelLoad();
                }
            }
            if (keyState.IsKeyDown(Keys.F) && keyState.IsKeyDown(Keys.V))
            {
                blackWing.health = 10;
            } 
            else if (Flseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    Flseen = false;
                    Tlseen = true;
                    ThirdLevelLoad();
                }
                if (blackWing.BlackWingbox.Y <= 0)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    Flseen = false;
                    Slseen = true;
                    SecondLevelLoad();
                }
                if (blackWing.BlackWingbox.X > 180 && blackWing.BlackWingbox.X < 730 && blackWing.BlackWingbox.Y > 490)
                {
                    blackWing.health--;
                }
            }
            else if (Slseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    Slseen = false;
                    sevlseen = true;
                    SevenLevelLoad();
                }
            }
            else if (Tlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.health = 0;
                }
                if (blackWing.BlackWingbox.X > 320 && blackWing.BlackWingbox.X < 450 && keyState.IsKeyDown(Keys.Down))
                {
                    Tlseen = false;
                    Filseen = true;
                    FithLevelLoad();
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                }
            }

            else if (Filseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    Filseen = false;
                    sixlseen = true;
                    SixLevelLoad();
                }
            }
            else if (sixlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    sixlseen = false;
                    nlseen = true;
                    NineLevelLoad();
                }
            }
            else if (sevlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    sevlseen = false;
                    elseen = true;
                    EightLevelLoad();
                }
            }
            else if (elseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    //cutscene would be dope
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    sevlseen = true;
                    SevenLevelLoad();
                }
                    if (blackWing.BlackWingbox.X > 800 && blackWing.BlackWingbox.X < 850 && keyState.IsKeyDown(Keys.Down))
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    elseen = false;
                    nlseen = true;
                    NineLevelLoad();
                }
            }
            else if (nlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    tenlseen = true;
                    nlseen = false;
                    TenLevelLoad();

                }
            }
            else if (tenlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    tenlseen = false;
                    elelseen = true;
                    ElevenLevelLoad();
                }
            }
            else if (elelseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    elelseen = false;
                    twelseen = true;
                    TwelveLevelLoad();
                }
            }
            else if (twelseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    twelseen = false;
                    fourtlseen = true;
                    FourteenLevelLoad();
                }
                if (blackWing.BlackWingbox.Y <= 0)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    twelseen = false;
                    thirtlseen = true;
                    ThirteenLevelLoad();
                }
            }
            else if (thirtlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    thirtlseen = false;
                    fourtlseen = true;
                    FourteenLevelLoad();
                }
            }
            else if (fourtlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y < 400)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    fourtlseen = false;
                    fiftlseen = true;
                    FithteenLevelLoad();
                }
                if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y > 400)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    fourtlseen = false;
                    sixtlseen = true;
                    SixteenLevelLoad();
                }
            }
            else if (fiftlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    fiftlseen = false;
                    sevtlseen = true;
                    SeventeenLevelLoad();
                }

            }
            else if (sixtlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                    sixtlseen = false;
                    sevtlseen = true;
                    SeventeenLevelLoad();
                }
            }
            else if (sevtlseen == true)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 520;
                }
            }
            if (blackWing.health <= 0)
            {
                goseen = true;
                if (keyState.IsKeyDown(Keys.Space))
                {
                    blackWing.health = 5;
                    blackWing.BlackWingbox.X = 0;
                    blackWing.BlackWingbox.Y = 600;
                    Flseen = true;
                    FirstLevelLoad();
                    goseen = false;
                }
            }


            MouseState mouseState = Mouse.GetState();

            base.Update(gameTime);
            oldKeyState = keyState;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            //recs
            
            if (titlescreenseen == true)
            {
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Press E to shoot", new Vector2(0, 570), Color.Black);
                spriteBatch.DrawString(Ariel12, "Press W for melee", new Vector2(790, 570), Color.Black);
            }
            if (Flseen == true)
            {
                spriteBatch.Draw(FLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Look up (;", new Vector2(0, 570), Color.Black);
            }
            else if (Slseen == true)
            {
                spriteBatch.Draw(SLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "No copyright intended", new Vector2(0, 570), Color.Black);
            }
            else if (Tlseen == true)
            {
                spriteBatch.Draw(TLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Pretend a dog named cave is on you what would you say?", new Vector2(0, 400), Color.Black);
            }
            else if (Filseen == true)
            {
                spriteBatch.Draw(FiLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Aye you made it my guy", new Vector2(0, 570), Color.Black);
            }
            else if (sixlseen == true)
            {
                spriteBatch.Draw(SixLtexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (sevlseen == true)
            {
                spriteBatch.Draw(SevLtexture, new Rectangle(0, 0, 960, 600), Color.White);

            }
            else if (elseen == true)
            {
                spriteBatch.Draw(ELtexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Time to go back DOWN to Earth", new Vector2(0, 550), Color.Black);
            }
            else if (nlseen == true)
            {
                spriteBatch.Draw(nltexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (tenlseen == true)
            {
                spriteBatch.Draw(tenltexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (elelseen == true)
            {
                spriteBatch.Draw(eleltexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "F opens doors", new Vector2(0, 550), Color.Black);
            }
            else if (twelseen == true)
            {
                spriteBatch.Draw(tweltexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "That's a nice boat on top.", new Vector2(0, 570), Color.Black);
            }
            else if (thirtlseen == true)
            {
                spriteBatch.Draw(thirttexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (fourtlseen == true)
            {
                spriteBatch.Draw(forttexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (fiftlseen == true)
            {
                spriteBatch.Draw(fifttexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (sixtlseen == true)
            {
                spriteBatch.Draw(sixttexture, new Rectangle(0, 0, 960, 600), Color.White);
            }
            else if (sevtlseen == true)
            {
                spriteBatch.Draw(sevttexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.DrawString(Ariel12, "Yup thats game over", new Vector2(0, 570), Color.Black);
            }
            else if (goseen == true)
            {
                spriteBatch.Draw(gotexture, new Rectangle(0, 0, 960, 600), Color.Black);
                spriteBatch.DrawString(Ariel12, "git good scrub", new Vector2(0, 570), Color.Black);
            }
            foreach (Line Lines in Lines)
            {
                Lines.Draw(spriteBatch);
            }
            if (blackWing.health > 0)
            {
                blackWing.Draw(spriteBatch);
            }


            spriteBatch.End();



            base.Draw(gameTime);
        }
        private void FirstLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(608, 463), 110, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(357, 464), 110, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(0, 102), 100, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(0, 392), 95, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(143, 233), 95, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(182, 510), 50, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(775, 500), 60, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(775, 500), 3, 99, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(232, 510), 3, 99, Color.White));
        }
        private void SecondLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(19, 458), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(19, 266), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(108, 377), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(217, 274), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(456, 342), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(93, 152), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(645, 365), 3, 143, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(649, 365), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(320, 398), 80, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(739, 328), 61, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(801, 304), 190, 3, Color.White));
        }
        private void SevenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(43, 461), 100, 6, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(224, 404), 95, 6, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(460, 473), 95, 6, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(680, 380), 110, 6, Color.White));
        }
        private void EightLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(118, 474), 103, 5, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(300, 428), 130, 5, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(510, 491), 131, 5, Color.White));
        }
        private void ThirdLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(770, 415), 153, 10, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(925, 285), 5, 153, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(870, 280), 60, 15, Color.White));

        }
        private void FithLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(735, 532), 60, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(853, 480), 56, 4, Color.White));
        }
        private void SixLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(495, 558), 60, 5, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(687, 480), 50, 4, Color.White));
        }
        private void NineLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("CCTexture"), new Vector2(607, 510), 86, 3, Color.Gold));
        }
        private void ElevenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(325, 400), 25, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(322, 478), 394, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(428, 295), 394, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(821, 133), 6, 500, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(321, 133), 7, 352, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(322, 133), 390, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(825, 133), 150, 7, Color.White));
        }
        private void TwelveLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(145, 540), 810, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(0, 404), 167, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(289, 404), 700, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(954, 274), 7, 450, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(508, 404), 450, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(0, 279), 790, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(0, 173), 390, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(73, 84), 125, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(280, 84), 700, 7, Color.White));
        }
        private void TenLevelLoad()
        {
            Lines.Clear();
        }
        private void ThirteenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(365, 442), 120, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(485, 444), 3, 130, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CCTexture"), new Vector2(759, 354), 220, 3, Color.Gold));
        }
        private void FourteenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(290, 551), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(390, 334), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(623, 548), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(195, 119), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(133, 310), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(620, 240), 90, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(580, 410), 400, 3, Color.White));
        }
        private void FithteenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(295, 543), 3, 160, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(225, 543), 3, 160, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(225, 541), 70, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(710, 470), 10, 200, Color.Gold));
        }
        private void SixteenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(740, 416), 200, 3, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(740, 416), 3, 95, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(935, 416), 3, 230, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(290,360), 120, 3, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(575, 270), 100, 3, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(450, 500), 110, 3, Color.Brown));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(885, 247), 120, 3, Color.Black));
        }
        private void SeventeenLevelLoad()
        {
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 480), 150, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 305), 150, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 129), 150, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(722, 517), 40, 2, Color.Black));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(655, 445), 2, 125, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(250, 293), 423, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(249, 294),3, 277, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(81, 353), 30, 3, Color.Black));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(141, 442), 30, 3, Color.Black));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(3, 245), 75, 3, Color.White));
        }
    }
}