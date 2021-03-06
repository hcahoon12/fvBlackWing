﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace BlackWing
{ 
    public class Game1 : Game
    {
        SpriteFont Ariel12;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BlackWing blackWing;
        BlackWing newcharacter;
        KeyboardState oldKeyState;
        List<Line> Lines = new List<Line>();
        List<EnemyFast> fastlist = new List<EnemyFast>();
        public int enemybulletdamage;
        List<EnemyRange> rangelist = new List<EnemyRange>();
        List<EnemyStrong> stronglist = new List<EnemyStrong>();
        List<PowerUps> healthlist = new List<PowerUps>();
        List<SOM> somlist = new List<SOM>();
        public int killcounter;
        public bool iskilled;
        //screens
        bool selectscreen;
        bool whiteseen;
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
        bool lastlevelseen;
        bool goseen;
        bool singleplayer;
        bool twoplayer;
        //textures
        Texture2D titlescreentexture;
        Texture2D FLtexture;
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
        Texture2D whitetexture;
        Texture2D selecttexture;
        Texture2D lastleveltexture;
        Rectangle EmblemREC;
        private MouseState oldState;

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
            titlescreenseen = false;
            selectscreen = false;
            lastlevelseen = false;
            whiteseen = true;
            enemybulletdamage = 1;
            //screensize
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            //mouse input
            this.IsMouseVisible = false;
        }
        protected override void Initialize()
        {
            EmblemREC = new Rectangle(313, 269, 100, 90);
            newcharacter = new BlackWing(7,new Vector2(100, 450), 5 , new Vector2(400 , 400), Keys.W, Keys.D,Keys.A,Keys.F,Keys.S,Keys.RightShift);
            blackWing = new BlackWing(7,new Vector2(0, 550), 5, new Vector2(400, 400), Keys.Up , Keys.Right , Keys.Left,Keys.RightControl , Keys.Down,Keys.E);
            KeyboardState keyState = Keyboard.GetState();
            oldKeyState = Keyboard.GetState();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //HealthTexture = Content.Load<Texture2D>("Health");
            selecttexture = Content.Load<Texture2D>("White");
            whitetexture = Content.Load<Texture2D>("Tutorial");
            titlescreentexture = Content.Load<Texture2D>("title screen");
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
            gotexture = Content.Load<Texture2D>("SOM");
            lastleveltexture = Content.Load<Texture2D>("lastlevel-pixilart");
            Ariel12 = Content.Load<SpriteFont>("file");
            blackWing.LoadContent(Content,"blackwing","blackwing2","starrrr","Sword");
            newcharacter.LoadContent(Content, "aquatowa", "aquatowa2", "fireball", "Firesword");
           
        }
        protected override void Update(GameTime gameTime)
        {
            //Mouse input
            MouseState newState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();
            oldState = newState; // resets old state so it is ready for use next time
            if (stronglist.Count > 0)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 900;
                }
                if (newcharacter.BlackWingbox.X >= 900)
                {
                    newcharacter.BlackWingbox.X = 900;
                }
            }
            if(fastlist.Count > 0)
            {
                if (blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 900;
                }
                if (newcharacter.BlackWingbox.X >= 900)
                {
                    newcharacter.BlackWingbox.X = 900;
                }
            }
            if(rangelist.Count > 0)
            {
                if(blackWing.BlackWingbox.X >= 900)
                {
                    blackWing.BlackWingbox.X = 900;
                }
                if(newcharacter.BlackWingbox.X >= 900)
                {
                    newcharacter.BlackWingbox.X = 900;
                }
            }
            foreach (PowerUps p in healthlist)
            {
                p.Update();

                if (p.powerrec.Intersects(blackWing.BlackWingbox) && keyState.IsKeyDown(Keys.Down))
                {
                    blackWing.health++;
                    p.isVisible = false;
                }
                if(p.powerrec.Intersects(newcharacter.BlackWingbox) && keyState.IsKeyDown(Keys.S))
                {
                    newcharacter.health++;
                    p.isVisible = false;
                }
            }
            foreach(SOM s in somlist)
            {
                s.Update(blackWing, newcharacter, Lines);
                if(s.health <= 0)
                {
                    s.isVisible = false;
                }
            }
            foreach(EnemyFast f in fastlist)
            {
                f.Update(blackWing, newcharacter, Lines);
                if (f.health <= 0)
                {
                    f.isVisible = false;
                }
            }
            foreach(EnemyStrong s in stronglist)
            {
                s.Update(blackWing, newcharacter, Lines);
                if (s.health <= 0)
                {
                    s.isVisible = false;
                }
            }
            foreach (EnemyRange e in rangelist)
            {
                e.Update(blackWing, newcharacter, Lines);
               
                //check bullet collison 
                for (int i = 0; i < e.bulletlist.Count; i++)
                {
                    if (blackWing.BlackWingbox.Intersects(e.bulletlist[i].boundingbox))
                    {
                        blackWing.health -= enemybulletdamage;
                        e.bulletlist[i].isVisible = false;
                    }
                }
                for (int i = 0; i < e.bulletlist.Count; i++)
                {
                    if (newcharacter.BlackWingbox.Intersects(e.bulletlist[i].boundingbox))
                    {
                        newcharacter.health -= enemybulletdamage;
                        e.bulletlist[i].isVisible = false;
                    }
                }
            }

            if (whiteseen == true)
            {
                if (keyState.IsKeyDown(Keys.Space))
                {
                    whiteseen = false;
                    selectscreen = true;
                }
            }
          else  if (selectscreen == true)
            {
                if (keyState.IsKeyDown(Keys.NumPad1) || keyState.IsKeyDown(Keys.D1))
                {
                    singleplayer = true;
                    titlescreenseen = true;
                    whiteseen = false;
                    twoplayer = false;
                    selectscreen = false;
                   
                }
            else    if (keyState.IsKeyDown(Keys.NumPad2)|| keyState.IsKeyDown(Keys.D2))
                {
                    twoplayer = true;
                    titlescreenseen = true;
                    whiteseen = false;
                    singleplayer = false;
                    selectscreen = false;
                }
            }
            /* 






                  single player






                  */
            if (singleplayer == true)
            {
                if (blackWing.health > 0)
                {
                    blackWing.Update(keyState, Lines);
                }
                if (blackWing.health == 1)
                {
                    blackWing.speed = 3;
                }
                if (blackWing.health == 2)
                {
                    blackWing.speed = 4;
                }
                if (blackWing.health == 3)
                {
                    blackWing.speed = 5;
                }
                if (blackWing.health == 4)
                {
                    blackWing.speed = 6;
                }
                if (blackWing.health == 5)
                {
                    blackWing.speed = 7;
                }
                if (blackWing.health== 6)
                {
                    blackWing.speed = 8;
                }
                if (blackWing.health == 7)
                {
                    blackWing.speed = 9;
                }
                if (blackWing.health == 8)
                {
                    blackWing.speed = 10;
                }
              
                if (blackWing.health >= 8)
                {
                    blackWing.health = 8;
                }
                if (titlescreenseen == true)
                {
                    if (keyState.IsKeyDown(Keys.D1))
                    {
                        titlescreenseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Ofl();
                    }
                    if (keyState.IsKeyDown(Keys.D2))
                    {
                        titlescreenseen = false;
                        Slseen = true;
                        SecondLevelLoad();
                        Osl();
                    }
                    if (keyState.IsKeyDown(Keys.D3))
                    {
                        titlescreenseen = false;
                        Tlseen = true;
                        ThirdLevelLoad();
                        Otl();
                    }
                    if (keyState.IsKeyDown(Keys.D4))
                    {
                        titlescreenseen = false;
                        fiftlseen = true;
                        FithLevelLoad();
                        Ofol();
                    }
                    if (keyState.IsKeyDown(Keys.D5))
                    {
                        titlescreenseen = false;
                        sixlseen = true;
                        SixLevelLoad();
                        Osil();
                    }
                    if (keyState.IsKeyDown(Keys.D6))
                    {
                        titlescreenseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Osel();
                    }
                    if (keyState.IsKeyDown(Keys.D7))
                    {
                        titlescreenseen = false;
                        elseen = true;
                        EightLevelLoad();
                        Oel();
                    }
                    if (keyState.IsKeyDown(Keys.D8))
                    {
                        titlescreenseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Onl();
                    }
                    if (keyState.IsKeyDown(Keys.D9))
                    {
                        titlescreenseen = false;
                        tenlseen = true;
                        TenLevelLoad();
                        Otenl();
                    }
                    if (keyState.IsKeyDown(Keys.D0))
                    {
                        titlescreenseen = false;
                        elelseen = true;
                        ElevenLevelLoad();
                        Oelel();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad7))
                    {
                        titlescreenseen = false;
                        twelseen = true;
                        TwelveLevelLoad();
                        Otwl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad8))
                    {
                        titlescreenseen = false;
                        thirtlseen = true;
                        ThirteenLevelLoad();
                        Othl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad9))
                    {
                        titlescreenseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Oftl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad4))
                    {
                        titlescreenseen = false;
                        fiftlseen = true;
                        FithteenLevelLoad();
                        Ofil();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad5))
                    {
                        titlescreenseen = false;
                        sixtlseen = true;
                        SixteenLevelLoad();
                        Ostl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad6))
                    {
                        titlescreenseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Osetl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad3))
                    {
                        titlescreenseen = false;
                        lastlevelseen = true;
                        LastLevelLoad();
                        OLL();
                    }
                    if (blackWing.BlackWingbox.X >= 960)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        titlescreenseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Ofl();
                    }
                }

                else if (Flseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        Flseen = false;
                        Tlseen = true;
                        ThirdLevelLoad();
                        Otl();
                    }
                    if (blackWing.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        Flseen = false;
                        Slseen = true;
                        SecondLevelLoad();
                        Osl();
                    }
                    if (blackWing.BlackWingbox.X > 180 && blackWing.BlackWingbox.X < 730 && blackWing.BlackWingbox.Y > 490)
                    {
                        blackWing.health--;
                    }
                }
                else if (Slseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        Slseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Osel();
                    }
                }
                else if (Tlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900)
                    {
                        blackWing.health = 0;
                    }
                    if (blackWing.BlackWingbox.X > 320 && blackWing.BlackWingbox.X < 450 && keyState.IsKeyDown(Keys.Down) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        Tlseen = false;
                        Filseen = true;
                        FithLevelLoad();
                        Ofol();
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                    }
                }

                else if (Filseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        Filseen = false;
                        sixlseen = true;
                        SixLevelLoad();
                        Osil();
                    }
                }
                else if (sixlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        sixlseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Onl();
                    }
                }
                else if (sevlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        sevlseen = false;
                        elseen = true;
                        EightLevelLoad();
                        Oel();
                    }
                }
                else if (elseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        //cutscene would be dope
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        elelseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Osl();
                    }
                    if (blackWing.BlackWingbox.X > 800 && blackWing.BlackWingbox.X < 850 && keyState.IsKeyDown(Keys.Down) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        elseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Onl();
                    }
                }
                else if (nlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        tenlseen = true;
                        nlseen = false;
                        TenLevelLoad();
                        Otenl();

                    }
                }
                else if (tenlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        tenlseen = false;
                        elelseen = true;
                        ElevenLevelLoad();
                        Oelel();
                    }
                }
                else if (elelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        elelseen = false;
                        twelseen = true;
                        TwelveLevelLoad();
                        Otwl();
                    }
                }
                else if (twelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        twelseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Oftl();
                    }
                    if (blackWing.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        twelseen = false;
                        thirtlseen = true;
                        ThirteenLevelLoad();
                        Othl();
                    }
                }
                else if (thirtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        thirtlseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Oftl();
                    }
                }
                else if (fourtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y < 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        fourtlseen = false;
                        fiftlseen = true;
                        FithteenLevelLoad();
                        Ofil();
                    }
                    if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y > 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        fourtlseen = false;
                        sixtlseen = true;
                        SixteenLevelLoad();
                        Ostl();
                    }
                }
                else if (fiftlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        fiftlseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Osetl();
                    }

                }
                else if (sixtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 520;
                        sixtlseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Osetl();
                    }
                }
                else if (sevtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 435;
                        sevtlseen = false;
                        lastlevelseen = true;
                        LastLevelLoad();
                        TLL();
                    }
                }
                else if (lastlevelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 435;
                    }
                }
                if (blackWing.health <= 0)
                {
                    
                    Flseen = false;
                    Tlseen = false;
                    Slseen = false;
                    Flseen = false;
                    fiftlseen = false;
                    sixlseen = false;
                    sevlseen = false;
                    elseen = false;
                    nlseen = false;
                    tenlseen = false;
                    elelseen = false;
                    twelseen = false;
                    thirtlseen = false;
                    fourtlseen = false;
                    fiftlseen = false;
                    sixtlseen = false;
                    sevtlseen = false;
                    lastlevelseen = false;
                    goseen = true;
                    gameoverload();
                    if (keyState.IsKeyDown(Keys.Space))
                    {
                        blackWing.health = 5;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 600;
                        Flseen = true;
                        FirstLevelLoad();
                        Ofl();
                        goseen = false;
                    }
                }
            }

            /*




                two player below



                */
            else if (twoplayer == true)
            {
                if (blackWing.health == 1)
                {
                    blackWing.speed = 3;
                }
                if (blackWing.health == 2)
                {
                    blackWing.speed = 4;
                }
                if (blackWing.health == 3)
                {
                    blackWing.speed = 5;
                }
                if (blackWing.health == 4)
                {
                    blackWing.speed = 6;
                }
                if (blackWing.health == 5)
                {
                    blackWing.speed = 7;
                }
                if (blackWing.health == 6)
                {
                    blackWing.speed = 8;
                }
                if (newcharacter.health == 1)
                {
                    newcharacter.speed = 3;
                }
                if (newcharacter.health == 2)
                {
                    newcharacter.speed = 4;
                }
                if (newcharacter.health == 3)
                {
                    newcharacter.speed = 5;
                }
                if (newcharacter.health == 4)
                {
                    newcharacter.speed = 6;
                }
                if (newcharacter.health == 5)
                {
                    newcharacter.speed = 7;
                }
                if (newcharacter.health == 6)
                {
                    newcharacter.speed = 8;
                }
           
                if (blackWing.health > 0)
                {
                    blackWing.Update(keyState, Lines);
                }
                if (newcharacter.health > 0)
                {
                    newcharacter.Update(keyState, Lines);
                }
                if (blackWing.health >= 6)
                {
                    blackWing.health = 6;
                }
                if (newcharacter.health >= 6)
                {
                    newcharacter.health = 6;
                }
                if (titlescreenseen == true)
                {
                  if (keyState.IsKeyDown(Keys.D1))
                    {
                        titlescreenseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Tfl();
                    }
                    if (keyState.IsKeyDown(Keys.D2))
                    {
                        titlescreenseen = false;
                        Slseen = true;
                        SecondLevelLoad();
                        Tsl();
                    }
                    if (keyState.IsKeyDown(Keys.D3))
                    {
                        titlescreenseen = false;
                        Tlseen = true;
                        ThirdLevelLoad();
                        Ttl();
                    }
                    if (keyState.IsKeyDown(Keys.D4))
                    {
                        titlescreenseen = false;
                        fiftlseen = true;
                        FithLevelLoad();
                        Tfol();
                    }
                    if (keyState.IsKeyDown(Keys.D5))
                    {
                        titlescreenseen = false;
                        sixlseen = true;
                        SixLevelLoad();
                        Tsil();
                    }
                    if (keyState.IsKeyDown(Keys.D6))
                    {
                        titlescreenseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Tsel();
                    }
                    if (keyState.IsKeyDown(Keys.D7))
                    {
                        titlescreenseen = false;
                        elseen = true;
                        EightLevelLoad();
                        Tel();
                    }
                    if (keyState.IsKeyDown(Keys.D8))
                    {
                        titlescreenseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Tnl();
                    }
                    if (keyState.IsKeyDown(Keys.D9))
                    {
                        titlescreenseen = false;
                        tenlseen = true;
                        TenLevelLoad();
                        Ttenl();
                    }
                    if (keyState.IsKeyDown(Keys.D0))
                    {
                        titlescreenseen = false;
                        elelseen = true;
                        ElevenLevelLoad();
                        Telel();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad7))
                    {
                        titlescreenseen = false;
                        twelseen = true;
                        TwelveLevelLoad();
                        Ttwl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad8))
                    {
                        titlescreenseen = false;
                        thirtlseen = true;
                        ThirteenLevelLoad();
                        Tthl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad9))
                    {
                        titlescreenseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Tftl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad4))
                    {
                        titlescreenseen = false;
                        fiftlseen = true;
                        FithteenLevelLoad();
                        Tfil();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad5))
                    {
                        titlescreenseen = false;
                        sixtlseen = true;
                        SixteenLevelLoad();
                        Tstl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad6))
                    {
                        titlescreenseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Tsetl();
                    }
                    if (keyState.IsKeyDown(Keys.NumPad3))
                    {
                        titlescreenseen = false;
                        lastlevelseen = true;
                        LastLevelLoad();
                        TLL();
                    }
                    if (blackWing.BlackWingbox.X >= 960 || newcharacter.BlackWingbox.X >= 960)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        titlescreenseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Tfl();
                    }
                }
                if (keyState.IsKeyDown(Keys.B) && keyState.IsKeyDown(Keys.V))
                {
                    blackWing.health = 10;
                    newcharacter.health = 10;
                }
                if (Flseen == true)
                { 
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        Flseen = false;
                        Tlseen = true;
                        ThirdLevelLoad();
                        Ttl();
                    }
                    if (blackWing.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        Flseen = false;
                        Slseen = true;
                        SecondLevelLoad();
                        Tsl();
                    }
                    if (blackWing.BlackWingbox.X > 180 && blackWing.BlackWingbox.X < 730 && blackWing.BlackWingbox.Y > 490)
                    {
                        blackWing.health--;
                    }
                    if (newcharacter.BlackWingbox.X > 180 && newcharacter.BlackWingbox.X < 730 && newcharacter.BlackWingbox.Y > 490)
                    {
                        newcharacter.health--;
                    }
                }
                else if (Slseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        Slseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Tsel();
                    }
                }
                else if (Tlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900)
                    {
                        blackWing.health = 0;
                    }
                    if (newcharacter.BlackWingbox.X >= 900)
                    {
                        newcharacter.health = 0;
                    }
                    if (blackWing.BlackWingbox.X > 320 && blackWing.BlackWingbox.X < 450 && keyState.IsKeyDown(Keys.Down) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X > 320 && newcharacter.BlackWingbox.X < 450 && keyState.IsKeyDown(Keys.S) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        Tlseen = false;
                        Filseen = true;
                        FithLevelLoad();
                        Tfol();
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                    }
                }
                else if (Filseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        Filseen = false;
                        sixlseen = true;
                        SixLevelLoad();
                        Tsil();
                    }
                }
                else if (sixlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        sixlseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Tnl();
                    }
                }
                else if (sevlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        sevlseen = false;
                        elseen = true;
                        EightLevelLoad();
                        Tel();
                    }
                }
                else if (elseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        //cutscene would be dope
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        elseen = false;
                        sevlseen = true;
                        SevenLevelLoad();
                        Tsel();
                    }
                    if (blackWing.BlackWingbox.X > 800 && blackWing.BlackWingbox.X < 850 && keyState.IsKeyDown(Keys.Down) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X > 800 && newcharacter.BlackWingbox.X < 850 && keyState.IsKeyDown(Keys.S) && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        elseen = false;
                        nlseen = true;
                        NineLevelLoad();
                        Tnl();
                    }
                }
                else if (nlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        tenlseen = true;
                        nlseen = false;
                        TenLevelLoad();
                        Ttenl();
                    }
                }
                else if (tenlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        tenlseen = false;
                        elelseen = true;
                        ElevenLevelLoad();
                        Telel();
                    }
                }
                else if (elelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        elelseen = false;
                        twelseen = true;
                        TwelveLevelLoad();
                        Ttwl();
                    }
                }
                else if (twelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        twelseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Tftl();
                    }
                    if (blackWing.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.Y <= 0 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        twelseen = false;
                        thirtlseen = true;
                        ThirteenLevelLoad();
                        Tthl();
                    }
                }
                else if (thirtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        thirtlseen = false;
                        fourtlseen = true;
                        FourteenLevelLoad();
                        Tftl();
                    }
                }
                else if (fourtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y < 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && newcharacter.BlackWingbox.Y < 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        fourtlseen = false;
                        fiftlseen = true;
                        FithteenLevelLoad();
                        Tfil();
                    }
                    if (blackWing.BlackWingbox.X >= 900 && blackWing.BlackWingbox.Y > 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && newcharacter.BlackWingbox.Y > 400 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        fourtlseen = false;
                        sixtlseen = true;
                        SixteenLevelLoad();
                        Tstl();
                    }
                }
                else if (fiftlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        fiftlseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Tsetl();
                    }

                }
                else if (sixtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 550;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 550;
                        sixtlseen = false;
                        sevtlseen = true;
                        SeventeenLevelLoad();
                        Tsetl();
                    }
                }
                else if (sevtlseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0 || newcharacter.BlackWingbox.X >= 900 && rangelist.Count == 0 && fastlist.Count == 0 && stronglist.Count == 0)
                    {
                        newcharacter.BlackWingbox.X = 100;
                        newcharacter.BlackWingbox.Y = 435;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 435;
                        sevtlseen = false;
                        lastlevelseen = true;
                        LastLevelLoad();
                        TLL();
                    }
                }
                else if (lastlevelseen == true)
                {
                    if (blackWing.BlackWingbox.X >= 900 && newcharacter.BlackWingbox.X >= 900)
                    {
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 435;
                        newcharacter.BlackWingbox.X = 0;
                        newcharacter.BlackWingbox.Y = 435;
                    }
                }
                if (blackWing.health <= 0)
                {
                    blackWing.BlackWingbox.X = -10000;
                    blackWing.BlackWingbox.Y = 100000;
                    if (keyState.IsKeyDown(Keys.Space))
                    {
                        newcharacter.health = 5;
                        newcharacter.BlackWingbox.X = 60;
                        newcharacter.BlackWingbox.Y = 600;
                        blackWing.health = 5;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 600;
                        goseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Tfl();
                    }
                }
                if (newcharacter.health <= 0)
                {
                    newcharacter.BlackWingbox.Y = 10000;
                    newcharacter.BlackWingbox.X = -10000;
                    if (keyState.IsKeyDown(Keys.Space))
                    {
                        newcharacter.health = 5;
                        newcharacter.BlackWingbox.X = 60;
                        newcharacter.BlackWingbox.Y = 600;
                        blackWing.health = 5;
                        blackWing.BlackWingbox.X = 0;
                        blackWing.BlackWingbox.Y = 600;
                        goseen = false;
                        Flseen = true;
                        FirstLevelLoad();
                        Tfl();
                    }
                }
                if(newcharacter.health <= 0 && blackWing.health <= 0)
                {
                    Flseen = false;
                    Tlseen = false;
                    Slseen = false;
                    Flseen = false;
                    fiftlseen = false;
                    sixlseen = false;
                    sevlseen = false;
                    elseen = false;
                    nlseen = false;
                    tenlseen = false;
                    elelseen = false;
                    twelseen = false;
                    thirtlseen = false;
                    fourtlseen = false;
                    fiftlseen = false;
                    sixtlseen = false;
                    sevtlseen = false;
                    lastlevelseen = false;
                    goseen = true;
                    gameoverload();
                }
                if (goseen == true)
                    {
                        if (keyState.IsKeyDown(Keys.Space))
                        {
                        newcharacter.health = 5;
                        newcharacter.BlackWingbox.X = 60;
                        newcharacter.BlackWingbox.Y = 600;
                        blackWing.health = 5;
                            blackWing.BlackWingbox.X = 0;
                            blackWing.BlackWingbox.Y = 600;
                            goseen = false;
                            Flseen = true;
                            FirstLevelLoad();
                        Tfl();
                        }
                    }

                   
                }
                    enemyload();
                    healthload();
                    base.Update(gameTime);
                    oldKeyState = keyState;
        }
    public void enemyload()
        {
            for (int i = 0; i < rangelist.Count; i++)
            {
                if (!rangelist[i].isVisible)
                {
                    rangelist.RemoveAt(i);
                    i--;
                }
            }
            for(int s = 0; s<somlist.Count; s++)
            {
                if (!somlist[s].isVisible)
                {
                    somlist.RemoveAt(s);
                    s--;
                }
            }
            for (int i = 0; i < stronglist.Count; i++)
            {
                if (!stronglist[i].isVisible)
                {
                    stronglist.RemoveAt(i);
                    i--;
                }
            }
            for(int f =0; f < fastlist.Count; f++)
            {
                if (!fastlist[f].isVisible)
                {
                    fastlist.RemoveAt(f);
                   f--;
                }
            }
        }
        public void healthload()
        {
            for (int i = 0; i < healthlist.Count; i++)
            {
                if (!healthlist[i].isVisible)
                {
                    healthlist.RemoveAt(i);
                    i--;
                }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            //recs
    
            if (whiteseen == true)
            {
                spriteBatch.Draw(whitetexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.Draw(blackWing.BlackWingTexture, new Rectangle(500, 200, 300, 300), Color.White);
                spriteBatch.Draw(newcharacter.AquaTexture, new Rectangle (100, 200, 300, 300), Color.White);
                spriteBatch.DrawString(Ariel12, "for first player arrow keys move you", new Vector2(600, 50), Color.LimeGreen);
                spriteBatch.DrawString(Ariel12, "for second player use a,w,d", new Vector2(150, 50), Color.LimeGreen);
                spriteBatch.DrawString(Ariel12, "first player shoot is Ctrl", new Vector2(600, 80), Color.Blue);
                spriteBatch.DrawString(Ariel12, "and melee is shift", new Vector2(600, 110), Color.Blue);
                spriteBatch.DrawString(Ariel12, "for second player shoot is F", new Vector2(150, 80), Color.Red);
                spriteBatch.DrawString(Ariel12, "and melee is E", new Vector2(150, 110), Color.Red);
                spriteBatch.DrawString(Ariel12, "Press space to continue", new Vector2(370, 570), Color.Black);
            }
       else if (selectscreen == true)
            {
                spriteBatch.Draw(selecttexture, new Rectangle(0, 0, 960, 600), Color.White);
                spriteBatch.Draw(blackWing.BlackWingTexture, new Rectangle(500, 200, 300, 300), Color.White);
                spriteBatch.Draw(newcharacter.AquaTexture, new Rectangle(100, 200, 300, 300), Color.White);
                spriteBatch.DrawString(Ariel12, "Press 2 for duo", new Vector2(0, 570), Color.Black);
                spriteBatch.DrawString(Ariel12, "Press 1 for single player", new Vector2(450, 570), Color.Black);
            }
         if (singleplayer == true)
            {
            
               
              if (titlescreenseen == true)
                {
                    spriteBatch.Draw(titlescreentexture, new Rectangle(0, 0, 960, 600), Color.White);
                }
                else if (Flseen == true)
                {
                    spriteBatch.Draw(FLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "Press B for healthpickups", new Vector2(0, 570), Color.Black);
                }
                else if (Slseen == true)
                {
                    spriteBatch.Draw(SLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "No copyright intended", new Vector2(0, 570), Color.Black);
                }
                else if (Tlseen == true)
                {
                    spriteBatch.Draw(TLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "Pretend a dog named cave is on you what would you say?", new Vector2(0, 550), Color.Black);
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
                 
                    spriteBatch.DrawString(Ariel12, "Time to go back DOWN to Earth", new Vector2(0, 570), Color.Black);
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
              else if(lastlevelseen == true)
                {
                    spriteBatch.Draw(lastleveltexture, new Rectangle(0, 0, 960, 600), Color.White);
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
                foreach (PowerUps p in healthlist)
                {
                    p.Draw(spriteBatch);
                }
                foreach(EnemyStrong s in stronglist)
                {
                    s.Draw(spriteBatch);
                }
                foreach (EnemyRange e in rangelist)
                {
                    e.Draw(spriteBatch);
                }
                foreach(SOM s in somlist)
                {
                    s.Draw(spriteBatch);
                }
                foreach(EnemyFast f in fastlist)
                {
                    f.Draw(spriteBatch);
                }
                if (blackWing.health > 0)
                {
                    blackWing.Draw(spriteBatch);
                }
            
            }
        /*
        

                    two player
                  

                */
            else if (twoplayer == true)
            {
               
                if (titlescreenseen == true)
                {
                    spriteBatch.Draw(titlescreentexture, new Rectangle(0, 0, 960, 600), Color.White);
                }
              else  if (Flseen == true)
                {
                    spriteBatch.Draw(FLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "Press B for healthpickups", new Vector2(0, 570), Color.Black);
                }
                else if (Slseen == true)
                {
                    spriteBatch.Draw(SLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "No copyright intended", new Vector2(0, 570), Color.Black);
                }
                else if (Tlseen == true)
                {
                    spriteBatch.Draw(TLtexture, new Rectangle(0, 0, 960, 600), Color.White);
                    spriteBatch.DrawString(Ariel12, "Pretend a dog named cave is on you what would you say?", new Vector2(0, 570), Color.Black);
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
                    spriteBatch.DrawString(Ariel12, "", new Vector2(0, 550), Color.Black);
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
                else if(lastlevelseen == true)
                {
                    spriteBatch.Draw(lastleveltexture, new Rectangle(0, 0, 960, 600), Color.White);
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
                foreach (PowerUps p in healthlist)
                {
                    p.Draw(spriteBatch);
                }
                foreach (EnemyStrong s in stronglist)
                {
                    s.Draw(spriteBatch);
                }
                foreach (EnemyRange e in rangelist)
                {
                    e.Draw(spriteBatch);
                }
                foreach (EnemyFast f in fastlist)
                {
                    f.Draw(spriteBatch);
                }
                foreach(SOM s in somlist)
                {
                    s.Draw(spriteBatch);
                }
                if (newcharacter.health > 0)
                {
                    newcharacter.Draw(spriteBatch);
                }
                if (blackWing.health > 0)
                {
                    blackWing.Draw(spriteBatch);
                }
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
            healthlist.Clear();
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
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(770, 415), 153, 10, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(925, 285), 5, 153, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(870, 280), 60, 15, Color.White));
        }
        private void FithLevelLoad()
        {
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(735, 532), 60, 7, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(853, 480), 56, 4, Color.White));
        }
        private void SixLevelLoad()
        {
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(495, 558), 60, 5, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(687, 480), 50, 4, Color.White));
        }
        private void NineLevelLoad()
        {
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("CCTexture"), new Vector2(607, 510), 86, 3, Color.Gold));
        }
        private void ElevenLevelLoad()
        {
            healthlist.Clear();
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
            healthlist.Clear();
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
            healthlist.Clear();
            Lines.Clear();
        }
        private void ThirteenLevelLoad()
        {
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(365, 442), 120, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(485, 444), 3, 130, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CCTexture"), new Vector2(759, 354), 220, 3, Color.Gold));
        }
        private void FourteenLevelLoad()
        {
            healthlist.Clear();
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
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(295, 543), 3, 160, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(225, 543), 3, 160, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("BROWN"), new Vector2(225, 541), 70, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GOLD"), new Vector2(710, 470), 10, 200, Color.Gold));
        }
        private void SixteenLevelLoad()
        {
            healthlist.Clear();
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
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 480), 150, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 305), 150, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(815, 129), 150, 8, Color.White));     
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(655, 445), 2, 125, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(250, 293), 423, 3, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(249, 294),3, 277, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(81, 353), 30, 3, Color.Black));
            Lines.Add(new Line(Content.Load<Texture2D>("GREY"), new Vector2(141, 442), 30, 3, Color.Black));
            Lines.Add(new Line(Content.Load<Texture2D>("White"), new Vector2(3, 245), 75, 3, Color.White));
        }
        private void LastLevelLoad()
        {
            healthlist.Clear();
            Lines.Clear();
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(28, 495), 905, 8, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(28, 355), 150, 4, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(793, 355), 140, 4, Color.White));
            Lines.Add(new Line(Content.Load<Texture2D>("CYAN"), new Vector2(390, 0), 170, 6, Color.White));
        }
        //o means one player and the fl is first level
        public void Ofl()
        {
            healthlist.Clear();
            stronglist.Clear();
            rangelist.Clear();
            fastlist.Clear();
            somlist.Clear();
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(20, 78)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(330, 395), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(20, 322), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Osl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(200, 200)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(800, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(100, 128)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(100, 83), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(750, 260), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Otl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(850, 347)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(800, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(850, 347), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Ofol()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(675, 550)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(740, 462), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Osil()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(700, 550)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(800, 550)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(690, 410), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Osel()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(50, 436)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(690, 312), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(210, 338), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Oel()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(500, 425), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(270, 360), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Onl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(630, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(630, 575)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(590, 443), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Otenl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(400, 580)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(650, 580)));
        }
        public void Oelel()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(340, 405)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(760, 523), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(760, 223), Content.Load<Texture2D>("Bullet"), 50, 50));
           
        }
        public void Otwl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(190, 105)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 515)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(850, 330)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(820, 470), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(10, 210), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(190, 105), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Othl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(510, 580)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(400, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 330)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 575)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(395, 375), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(765, 288), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Oftl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(233, 94)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(155, 243), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(875, 343), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(405, 266), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(625, 172), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Ofil()
        {                               
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(620, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(705, 343), Content.Load<Texture2D>("Bullet"), 50, 50));
        }

        public void Ostl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(800, 583)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 190)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(812, 575)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(750, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(590, 202), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(305, 292), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(885, 180), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Osetl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(550, 200)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(25, 220)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(450, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(10, 177), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 60), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 239), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 413), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
     public void OLL()
        {
            somlist.Add(new SOM(Content.Load<Texture2D>("SOM"), new Vector2(800, 430), Content.Load<Texture2D>("WaterBall"), 60, 50));
        }
        //T means two player 
        public void Tfl()
        {
            healthlist.Clear();
            stronglist.Clear();
            rangelist.Clear();
            fastlist.Clear();
            somlist.Clear();
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(20, 78)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(330, 395), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(20, 322), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(670, 390), Content.Load<Texture2D>("Bullet"), 50, 50));
          
           
        }
        public void Tsl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 255)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(800, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(100, 128)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(320,330), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(100, 83), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(750, 260), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Ttl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(800, 580)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(850, 347)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(850, 347), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tfol()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(675, 550)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(740, 462), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tsil()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(700, 550)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(800, 550)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(690, 410), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tsel()
        {
            healthlist.Clear();
            rangelist.Clear();
            fastlist.Clear();
            stronglist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(50, 436)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(690, 312), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(210, 338), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tel()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(500, 425), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(270, 360), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tnl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 550)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(630, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(630, 575)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(590, 443), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Ttenl()
        {
            healthlist.Clear();
            rangelist.Clear();
            fastlist.Clear();
            stronglist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(650, 580)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(800, 580)));
        }
        public void Telel()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(400, 65)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(760, 523), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(330, 403), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(760, 223), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(320, 65), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Ttwl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(850, 330)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(190, 105)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 515)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(820, 470), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(835, 335), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(10, 210), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(190, 105), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tthl()
        {
            healthlist.Clear();
            rangelist.Clear();
            fastlist.Clear();
            stronglist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(530, 580)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(400, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 330)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(870, 575)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(395, 375), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(895, 288), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("EnemyRange"), new Vector2(765, 288), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tftl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(233, 94)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 343)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(200, 50), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(155, 243), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(875, 343), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(405, 266), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(625, 172), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tfil()
        {
            healthlist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            rangelist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(620, 580)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(320, 580)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(705, 343), Content.Load<Texture2D>("Bullet"), 50, 50));
        }

        public void Tstl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(800, 583)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(900, 190)));
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(750, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(812, 575)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(590, 202), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(305, 292), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 349), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(920, 180), Content.Load<Texture2D>("Bullet"), 50, 50));
        }
        public void Tsetl()
        {
            healthlist.Clear();
            rangelist.Clear();
            stronglist.Clear();
            fastlist.Clear();
            stronglist.Add(new EnemyStrong(Content.Load<Texture2D>("Enemystrong"), new Vector2(450, 580)));
            healthlist.Add(new PowerUps(Content.Load<Texture2D>("Powerup"), new Vector2(25, 220)));
            fastlist.Add(new EnemyFast(Content.Load<Texture2D>("Enemyfast"), new Vector2(550, 200)));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(10, 177), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 60), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 239), Content.Load<Texture2D>("Bullet"), 50, 50));
            rangelist.Add(new EnemyRange(Content.Load<Texture2D>("nazisdlr"), new Vector2(845, 413), Content.Load<Texture2D>("Bullet"), 50, 50));

        }
        public void TLL()
        {
            somlist.Add((new SOM(Content.Load<Texture2D>("SOM"), new Vector2(800, 430), Content.Load<Texture2D>("WaterBall"), 60, 50)));
        }
        public void gameoverload()
        {
            rangelist.Clear();
            healthlist.Clear();
            fastlist.Clear();
            stronglist.Clear();
            Lines.Clear();
        }
    }
}