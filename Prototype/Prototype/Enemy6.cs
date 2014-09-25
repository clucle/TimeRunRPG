using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Enemy6
    {
        #region Declarations
        public static int x;
        public static int y;

        public static byte target_xy;

        public static byte c_moving;
        public static byte i_direction;
        public static byte moving;
        public static byte Max_moving;

        public static byte pattern;
        public static byte pattern_max;
        public static byte pattern_on;
        public static int pattern_del;

        public static byte[,] Hit_Matrix1 = new byte[6, 11]{
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1},
        };


        public static int HP_num;
        public static int HP_max;
        public static byte life;
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            HP_num = 300;
            HP_max = 300;

            pattern = 0;
            pattern_max = 10;
            pattern_on = 0;
            pattern_del = 0;
            life = 1;
            x = 34;
            y = 16;

            c_moving = 0;
            moving = 0;
            Max_moving = 18;
            i_direction = 2;
        }
        #endregion


        #region update
        public static void Update(GameTime gameTime)
        {
            if (life == 1)
            {
                if (HP_num > 0)
                {

                    if (moving <= Max_moving) moving++;
                    if (moving >= Max_moving)
                    {
                        if (pattern <= pattern_max && pattern_del == 0) pattern++;

                        if (c_moving == 0)
                        {

                            if (pattern >= pattern_max && pattern_on == 0)
                            {
                                c_moving = 3;
                                pattern = 0;
                                pattern_on = 1;
                                Max_moving = 4;
                                pattern_del = 1;
                                SoundManager.PlayEnemy6_pattern1();
                            }
                            if (MyFunction.Cnct(x, y, Player.x, Player.y) == 1)
                            {
                                if (pattern_del == 0)
                                {
                                    c_moving = 2;
                                }
                                else
                                {
                                    SoundManager.PlayEnemy6_pattern1_2();
                                    c_moving = 8;
                                }
                                if (pattern >= pattern_max && pattern_on == 0)
                                {
                                    c_moving = 3;
                                    pattern = 0;
                                    pattern_on = 1;
                                    Max_moving = 4;
                                    pattern_del = 1;
                                    SoundManager.PlayEnemy6_pattern1();
                                }
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
                                    }
                                    else if (y < Player.y)
                                    {

                                        i_direction = 1;
                                        target_xy = 1;
                                        y++;

                                    }
                                    else if (x > Player.x)
                                    {
                                        i_direction = 2;
                                        target_xy = 0;
                                        x--;
                                    }
                                    else if (x < Player.x)
                                    {
                                        i_direction = 3;
                                        target_xy = 0;
                                        x++;
                                    }
                                }
                                else
                                {
                                    if (x > Player.x)
                                    {
                                        i_direction = 2;
                                        target_xy = 0;
                                        x--;
                                    }
                                    else if (x < Player.x)
                                    {
                                        i_direction = 3;
                                        target_xy = 0;
                                        x++;
                                    }
                                    else if (y > Player.y)
                                    {
                                        i_direction = 4;
                                        target_xy = 1;
                                        y--;
                                    }
                                    else if (y < Player.y)
                                    {

                                        i_direction = 1;
                                        target_xy = 1;
                                        y++;
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

                            if (pattern >= pattern_max && pattern_on == 0)
                            {
                                c_moving = 3;
                                pattern = 0;
                                pattern_on = 1;
                                Max_moving = 4;
                                pattern_del = 1;
                                SoundManager.PlayEnemy6_pattern1();
                            }
                            else
                            {
                                c_moving = 0;
                            }
                        }
                        else if (c_moving == 2)
                        {
                            Player.HP_num -= 2;
                            c_moving = 0;

                        }
                        else if (c_moving == 3)
                        {
                            pattern++;
                            if (pattern >= 10)
                            {
                                pattern = 0;
                                //SoundManager.PlayEnemy6_pattern1_2();
                                c_moving = 0;
                            }
                        }
                        else if (c_moving == 8)
                        {
                            c_moving = 9;

                        }
                        else if (c_moving == 9)
                        {
                            c_moving = 8;
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
                                int i = MyFunction.GetMoney(20);
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
            if (x1 >= x2 - 1 && x1 <= x2 + 3)
            {
                if (y1 >= y2 - 1 && y1 <= y2 + 3)
                {
                    HP_num -= attack;
                    if (HP_num <= 0)
                    {
                        moving = 0;
                        c_moving = 0;
                    }
                    return 1;
                }
            }
            return 0;
        }

        public static int Enemy_pattern1(int x1)
        {
            pattern_on++;
            pattern_del++;
            if (pattern_del >= 150)
            {
                Max_moving = 18;
                pattern_del = 0;
                pattern_on = 0;
                c_moving = 0;
            }
            if (x1 >= 2)
            {
                pattern_on = 0;
                return 0;
            }
            else if (x1>= 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
