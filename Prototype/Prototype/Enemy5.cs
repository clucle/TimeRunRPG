using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Enemy5
    {
        #region Declarations
        public static int x;
        public static int y;

        public static byte c_moving;
        public static byte i_direction;
        public static byte moving;
        public static byte Max_moving;

        public static byte pattern;
        public static byte pattern_max;
        public static byte pattern_on;
        public static int pattern_x;
        public static int pattern_y;
        public static byte[,] Hit_Matrix1 = new byte[4, 4]{
        {1,1,1,1},
        {1,0,0,1},
        {1,0,0,1},
        {1,1,1,1},
        };


        public static byte pattern2;
        public static byte pattern2_max;
        public static int pattern2_on;
        public static byte pattern2_del;
        public static int HP_num;
        public static int HP_max;
        public static byte life;
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            HP_num = 120;
            HP_max = 120;

            pattern = 0;
            pattern_max = 5;
            pattern_on = 0;

            pattern2 = 0;
            pattern2_max = 17;
            pattern2_on = 0;
            pattern2_del = 0;

            life = 1;
            x = 34;
            y = 16;

            c_moving = 0;
            moving = 0;
            Max_moving = 15;
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
                        if (pattern <= pattern_max) pattern++;
                        if (pattern2 <= pattern2_max) pattern2++;


                        if (c_moving == 0)
                        {


                            if (MyFunction.Cnct(x, y, Player.x, Player.y) == 1)
                            {
                                c_moving = 2;
                                if (pattern >= pattern_max && pattern_on == 0)
                                {
                                    c_moving = 4;
                                    pattern = 0;
                                }
                                else if (pattern2 >= pattern2_max)
                                {
                                    c_moving = 5;
                                    pattern2 = 0;
                                }
                            }
                            else
                            {
                                if (x > Player.x)
                                {
                                    i_direction = 2;
                                    x--;
                                }
                                else if (x < Player.x)
                                {
                                    i_direction = 3;
                                    x++;
                                }
                                else if (y > Player.y)
                                {
                                    i_direction = 4;
                                    y--;
                                }
                                else if (y < Player.y)
                                {

                                    i_direction = 1;
                                    y++;
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
                                c_moving = 4;
                                pattern = 0;
                            }
                            else if(pattern2 >= pattern2_max)
                            {
                                c_moving = 5;
                                pattern2 = 0;
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
                        }
                        else if (c_moving == 3)
                        {
                            Player.HP_num -= 5;
                            c_moving = 0;
                        }
                        else if (c_moving == 4)
                        {
                            pattern_x = x;
                            pattern_y = y;
                            pattern_on = 1;
                            c_moving = 0;
                        }
                        else if (c_moving == 5)
                        {
                            pattern2_on = 1;
                            c_moving = 0;
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
                if (y1 >= y2 -1 && y1 <= y2 + 3)
                {
                    if (Enemy5.pattern2_on == 0)
                    {
                        HP_num -= attack;
                        if (HP_num <= 0)
                        {
                            moving = 0;
                            c_moving = 0;
                        }
                        return 1;
                    }
                    else
                    {
                        Enemy5.pattern2_del = 1;

                    }
                }
            }
            return 0;
        }
        #endregion
    }
}
