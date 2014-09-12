using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Enemy4
    {
        #region Declarations
        public static int x;
        public static int y;
        public static byte c_moving;
        public static int i_direction;
        public static byte target_on;
        public static byte delay_Effect;
        public static byte moving;
        public static byte Max_moving;
        public static byte target_xy;

        public static int revision;

        static int pattern;
        public static int patternline;
        public static int HP_num;
        public static int HP_max;
        public static byte life;

        public static byte Hit_x;
        public static byte Hit_y;
        public static byte[,] Hit_Matrix1 = new byte[3, 3]{
        {1,1,1},
        {0,0,1},
        {1,1,1}
        };
        public static byte[,] Hit_Matrix2 = new byte[3, 3]{
        {1,1,1},
        {1,0,1},
        {1,0,1}
        };
        public static byte[,] Hit_Matrix3 = new byte[3, 3]{
        {1,0,1},
        {1,0,1},
        {1,1,1}
        };
        public static byte[,] Hit_Matrix4 = new byte[3, 3]{
        {1,1,1},
        {1,0,0},
        {1,1,1}
        };
        public static byte condition;

        public struct Info_Skill
        {
            public int on;
            public int num;
            public int max;
        }
        public static Info_Skill Skill_CoolDown = new Info_Skill();
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            c_moving = 0;
            moving = 0;
            Max_moving = 10;
            target_on = 0;
            delay_Effect = 0;
            life = 1;
            x = 34;
            y = 16;
            Hit_x = 2;
            Hit_y = 2;

            pattern = 0;
            patternline = 0;
            revision = 0;

            HP_num = 120;
            HP_max = 120;

            Skill_CoolDown.on = 0;
            Skill_CoolDown.max = 20;
            Skill_CoolDown.num = 0;
        }
        #endregion
        #region update
        public static void Update(GameTime gameTime)
        {
            if (life == 1)
            {
                if (delay_Effect <= 3) delay_Effect++;
                if (HP_num > 0)
                {
                    if (moving <= Max_moving) moving++;
                    if (moving >= Max_moving)
                    {
                        if (pattern<=20 && patternline == 0)
                        {
                            pattern++;
                        }
                        if (c_moving == 0)
                        {

                            if (MyFunction.Cnct(x, y, Player.x, Player.y) == 1)
                            {
                                c_moving = 2;
                            }
                            else
                            {
                                if (target_xy == 0)
                                {
                                    if (y > Player.y)
                                    {
                                        i_direction = 4;
                                        target_xy = 1;
                                        y--;
                                        revision = 1;
                                    }
                                    else if (y < Player.y)
                                    {

                                        i_direction = 1;
                                        target_xy = 1;
                                        y++;
                                        revision = 1;

                                    }
                                    else if (x > Player.x)
                                    {
                                        i_direction = 2;
                                        target_xy = 0;
                                        x--;
                                        revision = 0;
                                    }
                                    else if (x < Player.x)
                                    {
                                        i_direction = 3;
                                        target_xy = 0;
                                        x++;
                                        revision = 0;
                                    }
                                }
                                else
                                {
                                    if (x > Player.x)
                                    {
                                        i_direction = 2;
                                        target_xy = 0;
                                        x--;
                                        revision = 0;
                                    }
                                    else if (x < Player.x)
                                    {
                                        i_direction = 3;
                                        target_xy = 0;
                                        x++;
                                        revision = 0;
                                    }
                                    else if (y > Player.y)
                                    {
                                        i_direction = 4;
                                        target_xy = 1;
                                        y--;
                                        revision = 1;
                                    }
                                    else if (y < Player.y)
                                    {

                                        i_direction = 1;
                                        target_xy = 1;
                                        y++;
                                        revision = 1;
                                    }
                                }

                                c_moving = 1;
                            }

                        }
                        else if (c_moving == 1)
                        {
                            switch (i_direction)
                            {
                                case 1:
                                    y++;
                                    break;
                                case 2:
                                    x--;
                                    break;
                                case 3:
                                    x++;
                                    break;
                                case 4:
                                    y--;
                                    break;
                            }
                            if (pattern >= 2)
                            {
                                patternline = MyFunction.LineCrush(Player.x, Player.y,x , y);
                                if (patternline > 0)
                                {
                                    pattern = 0;
                                    c_moving = 4;
                                }
                                else
                                {
                                    c_moving = 0;
                                }
                            }
                            else
                            {
                                c_moving = 0;
                            }
                        }
                        else if (c_moving == 2)
                        {
                            SoundManager.PlayEnemyShot();
                            c_moving++;
                            target_on = 1;
                            Player.HP_num -= 10;
                        }
                        else if (c_moving == 3)
                        {
                            c_moving = 0;
                        }
                        else if (c_moving == 4)
                        {
                            delay_Effect = 0;
                            c_moving = 5;
                            condition = 1;
                            Max_moving = 3;
                            target_on = 1;
                            i_direction = patternline;
                            switch (i_direction)
                            {
                                case 1:
                                    revision = 1;
                                    target_xy = 1;
                                    break;
                                case 2:
                                    revision = 0;
                                    target_xy = 0;
                                    break;
                                case 3:
                                    revision = 0;
                                    target_xy = 0;
                                    break;
                                case 4:
                                    revision = 1;
                                    target_xy = 1;
                                    break;
                            }
                        }
                        else if (c_moving == 5)
                        {
                            SoundManager.PlayExplosion();
                            switch (patternline)
                            {
                                case 1:
                                    y++;
                                    break;
                                case 2:
                                    x--;
                                    break;
                                case 3:
                                    x++;
                                    break;
                                case 4:
                                    y--;
                                    break;
                            }
                            c_moving = 6;
                            if ((x == 2 || x == 36) && (patternline == 2 || patternline == 3) || (y == 2 || y == 26) && (patternline == 1 || patternline == 4))
                            {
                                c_moving = 0;
                                Max_moving = 10;
                                moving = 0;
                                condition = 0;
                                pattern = 0;
                                target_on = 0;
                                patternline = 0;
                            }
                        }
                        else if (c_moving == 6)
                        {
                            switch (patternline)
                            {
                                case 1:
                                    y++;
                                    break;
                                case 2:
                                    x--;
                                    break;
                                case 3:
                                    x++;
                                    break;
                                case 4:
                                    y--;
                                    break;
                            }
                            c_moving = 5;

                            if ((x == 2 || x == 36) && (patternline == 2 || patternline == 3) || (y == 2 || y == 26) && (patternline == 1 || patternline == 4))
                            {
                                c_moving = 0;
                                Max_moving = 10;
                                moving = 0;
                                condition = 0;
                                pattern = 0;
                                target_on = 0;
                                patternline = 0;
                            }
                        }

                        moving = 0;
                    }
                }
                else
                {
                    if (moving <= Max_moving) moving++;
                    if (moving >= Max_moving)
                    {
                        switch (c_moving)
                        {
                            case 0:
                                life = 0;
                                break;
                        }

                    }
                }
            }
            else
            {

            }
        }
        #endregion

        #region Function
        public static int Enemy_hit(int x1, int y1, int x2, int y2, int attack, int direction)
        {
            if (y1 == y2 && (x1 == x2 || x1 - 1 == x2 || x1 + 3 == x2))
            {
                HP_num -= attack;
                if (HP_num <= 0)
                {
                    moving = 0;
                    c_moving = 0;
                }
                return 1;
            }

            return 0;
        }
        #endregion
    }
}
