using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Prototype
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Declarations


            #region Texture
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;

            Texture2D Back_start;
            Texture2D Back_intensity;

            Texture2D Tile;
            Texture2D tile1;
            Texture2D Map1;
            Texture2D character1;
            Texture2D location; 
            Texture2D tan;
            Texture2D Enemy_1_1;
            Texture2D Effect_1_1;

            Texture2D Enemy_2_1;
            Texture2D Enemy_2_1_tan;
            Texture2D Skill_Enemy_2_1;

            Texture2D Enemy_3_1;
            Texture2D Enemy_3_1_tan;

            Texture2D Enemy_4_1;

            Texture2D Skill_backshot;
            Texture2D Skill_cooldown;
            Texture2D Skill_moving;

            Texture2D HP_in;
            Texture2D HP_out;

            Texture2D Mousepoint;
            Texture2D number;
            Texture2D portal;
            #endregion

        public static byte CurrentStage;

        public Game1()
        {
            Window.Title = "Prototype"; //타이틀 바꾸기
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800; //화면 크기 조정
            graphics.PreferredBackBufferHeight = 600;
            CurrentStage = 99;
        }
        #endregion

        #region Initialization
        protected override void Initialize()
        {
            base.Initialize();
        }
        #endregion

        #region Load
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Back_start = Content.Load<Texture2D>(@"Image\\Back_start");

            Tile = Content.Load<Texture2D>(@"Image\\Tile");
            tile1 = Content.Load<Texture2D>(@"Image\\tile1");
            Map1 = Content.Load<Texture2D>(@"Image\\Map1");
            character1 = Content.Load<Texture2D>(@"Image\\character1");
            location = Content.Load<Texture2D>(@"Image\\location");
            tan = Content.Load<Texture2D>(@"Image\\tan");
            Enemy_1_1 = Content.Load<Texture2D>(@"Image\\Enemy_1_1");
            Effect_1_1 = Content.Load<Texture2D>(@"Image\\Effect_1_1");

            Enemy_2_1 = Content.Load<Texture2D>(@"Image\\Enemy_2_1");
            Enemy_2_1_tan = Content.Load<Texture2D>(@"Image\\Enemy_2_1_tan");
            Skill_Enemy_2_1 = Content.Load<Texture2D>(@"Image\\Skill1_Enemy_2_1");


            Enemy_3_1 = Content.Load<Texture2D>(@"Image\\Enemy_3_1");
            Enemy_3_1_tan = Content.Load<Texture2D>(@"Image\\Enemy_3_1_tan");

            Enemy_4_1 = Content.Load<Texture2D>(@"Image\\Enemy_4_1");

            Skill_backshot = Content.Load<Texture2D>(@"Image\\Skill_backshot");
            Skill_cooldown = Content.Load<Texture2D>(@"Image\\Skill_cooldown");
            Skill_moving = Content.Load<Texture2D>(@"Image\\Skill_moving");

            HP_in = Content.Load<Texture2D>(@"Image\\HP_in");
            HP_out = Content.Load<Texture2D>(@"Image\\HP_out");

            Mousepoint = Content.Load<Texture2D>(@"Image\\Mousepoint");
            number = Content.Load<Texture2D>(@"Image\\number");
            Back_intensity = Content.Load<Texture2D>(@"Image\\Back_intensity");
            portal = Content.Load<Texture2D>(@"Image\\portal");

            Player.Initialize(Content);
            Player_Tan.Initialize(Content);
            Cooldown.Initialize(Content);
            Player_Info.Initialize(Content);
            Intensity.Initialize(Content);
            SoundManager.Initialize(Content);
            Enemy1.Initialize(Content);

            SoundManager.PlayStart();
        }

        protected override void UnloadContent()
        {

        }
        #endregion

        #region Update
        /// <summary>
        /// 게임이 레벨 업데이트, 충돌 감지, 입력 감지 및 오디오 재생과
        /// 같은 게임 논리 코드를 실행할 수 있습니다.
        /// </summary>
        /// <param name="gameTime">타이밍 값의 스냅샷을 제공합니다.</param>
        protected override void Update(GameTime gameTime)
        {
            // 게임이 종료할 수 있게 함
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: 여기에 업데이트 논리 추가

            if (CurrentStage <= 50)
            {
                Player.Update(gameTime);
                Player_Tan.Update(gameTime);
            }
            switch (CurrentStage)
            {
                case 1:
                    Enemy1.Update(gameTime);
                    break;
                case 2:
                    Enemy2.Update(gameTime);
                    break;
                case 3:
                    Enemy3.Update(gameTime);
                    break;
                case 99:
                    Start.Update(gameTime);
                    break;
                case 100:
                    Intensity.Update(gameTime);
                    break;
            }
            Cooldown.Update(gameTime);


             
            base.Update(gameTime);
        }
        #endregion

        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (CurrentStage == 99)
            {
                spriteBatch.Draw(Back_start, new Vector2(0, 0), new Rectangle(0, 0, 800, 600), Color.White);
            }else if(CurrentStage == 100){
                spriteBatch.Draw(Back_intensity, new Vector2(0, 0), new Rectangle(0, 0, 800, 600), Color.White);
                for (int i = 0; i < 3; i++)//0,1,2가 강화
                {
                    spriteBatch.Draw(number, new Vector2(575, 335 + (i * 50)), new Rectangle(Intensity.Initialize_load[i] * 20, 0, 20, 50), Color.White);
                }
            }else{
                spriteBatch.Draw(Tile, new Vector2(0, 0), new Rectangle(0, 0, 800, 600), Color.White);
                for (int k = 0; k <= 20; k++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        spriteBatch.Draw(tile1, new Vector2(k * 40, j * 40), new Rectangle(0, 0, 40, 40), Color.White);
                    }
                }
                //캐릭터
                int MyHP = 292 * Player.HP_num / Player.HP_max;

                spriteBatch.Draw(HP_out, new Vector2(50, 20), new Rectangle(0, 0, 300, 30), Color.White);
                spriteBatch.Draw(HP_in, new Vector2(54 + 292 - MyHP, 24), new Rectangle(0, 0, MyHP, 22), Color.White);

                spriteBatch.Draw(location, new Vector2((Player.x * 20) + 1, (Player.y * 20) + 10), new Rectangle(0, 0, 38, 20), Color.White);

                spriteBatch.Draw(character1, new Vector2((Player.x * 20) + 4, (Player.y * 20) - 22), new Rectangle(Player.c_moving * 32, (Player.i_direction - 1) * 48 + (Player.i_mode * 48 * 4), 32, 48), Color.White);

                //스킬과 쿨다운
                spriteBatch.Draw(Skill_moving, new Vector2(50, 70), new Rectangle(0, 0, 50, 50), Color.White);
                spriteBatch.Draw(Skill_backshot, new Vector2(50, 140), new Rectangle(0, 0, 50, 50), Color.White);
                for (int k = 0; k <= 1; k++)
                {
                    if (Cooldown.Skill_CoolDown[k].on == 0)
                    {
                        int Cool = 50 * Cooldown.Skill_CoolDown[k].num / Cooldown.Skill_CoolDown[k].max;
                        spriteBatch.Draw(Skill_cooldown, new Vector2(50, 70 + (70 * k)), new Rectangle(0, 0, 50, 50 - Cool), Color.White);
                    }
                }

            }
            if (CurrentStage <= 50)
            {
                spriteBatch.Draw(HP_out, new Vector2(450, 20), new Rectangle(0, 0, 300, 30), Color.White);
                for (int k = 0; k <= 49; k++)
                {
                    if (Player_Tan.c_Tan[k].on == 1)
                    {
                        spriteBatch.Draw(tan, new Vector2(Player_Tan.c_Tan[k].x * 20, Player_Tan.c_Tan[k].y * 20), new Rectangle((Player_Tan.c_Tan[k].i_direction - 1) * 40, 0, 40, 40), Color.White);
                    }
                }
            }

            #region Enemy
            //1탄


            if (CurrentStage == 1)
            {
                
                if (Enemy1.life == 1)
                {
                    int EnemyHP = 292 * Enemy1.HP_num / Enemy1.HP_max;
                    spriteBatch.Draw(HP_out, new Vector2(450, 20), new Rectangle(0, 0, 300, 30), Color.White);
                    spriteBatch.Draw(HP_in, new Vector2(454 + 292 - EnemyHP, 24), new Rectangle(0, 0, EnemyHP, 22), Color.White);

                    spriteBatch.Draw(Enemy_1_1, new Vector2((Enemy1.x * 20) + 8, (Enemy1.y * 20) - 4), new Rectangle(Enemy1.c_moving * 24, (Enemy1.i_direction - 1) * 32, 24, 32), Color.White);

                    for (int k = 0; k <= 49; k++)
                    {
                        if (Player_Tan.c_Tan[k].on == 1)
                        {
                            int check = Enemy1.Enemy_hit(Player_Tan.c_Tan[k].x, Player_Tan.c_Tan[k].y, Enemy1.x, Enemy1.y, 3, Player_Tan.c_Tan[k].i_direction);
                            if (check == 1) Player_Tan.c_Tan[k].on = 0;
                        }
                    }

                    if (Enemy1.target_on >= 1)
                    {
                        for (int h1 = 0; h1 <= Enemy1.Hit_y; h1++)
                        {
                            for (int h2 = 0; h2 <= Enemy1.Hit_x; h2++)
                            {
                                if (Enemy1.Hit_Matrix[h1, h2] == 1)
                                {
                                    spriteBatch.Draw(Effect_1_1, new Vector2(Enemy1.x * 20 + ((h1 - 1) * 40) - 30, Enemy1.y * 20 + ((h2 - 1) * 40) - 30), new Rectangle((Enemy1.target_on - 1) * 100, 0, 100, 100), Color.White);
                                    int check = Player.My_hit(Player.x, Player.y, Enemy1.x + ((h2 - 1) * 2), Enemy1.y + ((h1 - 1) * 2), 3, 0);
                                    //if (check == 1) Enemy2.Tan[k].on = 0;
                                }
                            }
                        }
                        if (Enemy1.target_on <= 3)
                        {
                            Enemy1.target_on++;
                        }
                        else
                        {
                            Enemy1.target_on = 0;
                        }
                    }
                }
                else
                {
                    if (Player.x >= 18 && Player.x <= 22)
                    {
                        if (Player.y == 26)
                        {
                            Player.Initialize(Content);
                            Enemy2.Initialize(Content);
                            CurrentStage++;
                        }
                    }
                    spriteBatch.Draw(portal, new Vector2(350, 460), new Rectangle(0, 0, 100, 100), Color.White);
                }
            }
            else if (CurrentStage == 2)
            {
                if (Enemy2.life == 1)
                {
                    int EnemyHP = 292 * Enemy2.HP_num / Enemy2.HP_max;
                    spriteBatch.Draw(HP_in, new Vector2(454 + 292 - EnemyHP, 24), new Rectangle(0, 0, EnemyHP, 22), Color.White);

                    spriteBatch.Draw(Enemy_2_1, new Vector2((Enemy2.x * 20) + 8, (Enemy2.y * 20) - 12), new Rectangle(Enemy2.c_moving * 30, (Enemy2.i_direction - 1) * 36, 30, 36), Color.White);

                    for (int k = 0; k <= 49; k++)
                    {
                        if (Player_Tan.c_Tan[k].on == 1)
                        {
                            int check = Enemy2.Enemy_hit(Player_Tan.c_Tan[k].x, Player_Tan.c_Tan[k].y, Enemy2.x, Enemy2.y, 3, Player_Tan.c_Tan[k].i_direction);
                            if (check == 1) Player_Tan.c_Tan[k].on = 0;
                        }
                    }


                    for (int k = 0; k <= 3; k++)
                    {
                        if (Enemy2.Tan[k].on == 1)
                        {
                            spriteBatch.Draw(Enemy_2_1_tan, new Vector2((Enemy2.Tan[k].x * 20) + 8, (Enemy2.Tan[k].y * 20) - 12), new Rectangle(0, 0, 40, 40), Color.White);
                            int check = Player.My_hit(Player.x, Player.y, Enemy2.Tan[k].x, Enemy2.Tan[k].y, 11, Enemy2.Tan[k].i_direction);
                            if (check == 1) Enemy2.Tan[k].on = 0;
                        }
                    }

                    spriteBatch.Draw(Skill_Enemy_2_1, new Vector2(700, 70), new Rectangle(0, 0, 50, 50), Color.White);
                    int Cool = 50 * Enemy2.Skill_CoolDown.num / Enemy2.Skill_CoolDown.max;
                    spriteBatch.Draw(Skill_cooldown, new Vector2(700, 70), new Rectangle(0, 0, 50, 50 - Cool), Color.White);

                }
                else
                {
                    if (Player.x >= 18 && Player.x <= 22)
                    {
                        if (Player.y == 26)
                        {
                            Player.Initialize(Content);
                            Enemy3.Initialize(Content);
                            CurrentStage++;
                        }
                    }
                    spriteBatch.Draw(portal, new Vector2(350, 460), new Rectangle(0, 0, 100, 100), Color.White);
                }
            }
            else if (CurrentStage == 3)
            {
                if (Enemy3.life == 1)
                {
                    int EnemyHP = 292 * Enemy3.HP_num / Enemy3.HP_max;
                    spriteBatch.Draw(HP_in, new Vector2(454 + 292 - EnemyHP, 24), new Rectangle(0, 0, EnemyHP, 22), Color.White);
                    if (Enemy3.condition == 1)
                    {
                        spriteBatch.Draw(Enemy_3_1, new Vector2((Enemy3.x * 20) + 8, (Enemy3.y * 20) - 4), new Rectangle(Enemy3.c_moving * 120, 0, 120, 140), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(Enemy_3_1, new Vector2((Enemy3.x * 20) + 8, (Enemy3.y * 20) - 4), new Rectangle(Enemy3.c_moving * 120, 140, 120, 140), Color.White);
                    }
                    for (int k = 0; k <= 49; k++)
                    {
                        if (Player_Tan.c_Tan[k].on == 1)
                        {
                            int check = Enemy3.Enemy_hit(Player_Tan.c_Tan[k].x, Player_Tan.c_Tan[k].y, Enemy3.x, Enemy3.y, 3, Player_Tan.c_Tan[k].i_direction);
                            if (check == 1) Player_Tan.c_Tan[k].on = 0;
                        }
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        if (Enemy3.Tan[k].on == 1)
                        {
                            spriteBatch.Draw(Enemy_3_1_tan, new Vector2((Enemy3.Tan[k].x * 20) + 8, (Enemy3.Tan[k].y * 20) - 12), new Rectangle(Enemy3.Tan[k].pattern1_tan_Graphic * 150, 0, 150, 100), Color.White);
                            int check = Player.My_hit2(Player.x, Player.y, Enemy3.Tan[k].x, Enemy3.Tan[k].y,4,2,3, 2);
                            if (check == 1) Enemy3.Tan[k].on = 0;
                        }
                    }

                }
                else
                {
                    if (Player.x >= 18 && Player.x <= 22)
                    {
                        if (Player.y == 28)
                        {
                            Player.Initialize(Content);
                            //Enemy4.Initialize(Content);
                            CurrentStage++;
                        }
                    }
                    spriteBatch.Draw(portal, new Vector2(350, 500), new Rectangle(0, 0, 100, 100), Color.White);
                }

            }
            spriteBatch.Draw(Mousepoint, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new Rectangle(0, 0, 50, 50), Color.White);
            #endregion
            spriteBatch.End();
            base.Draw(gameTime);
        }
            
        #endregion


    }
}
