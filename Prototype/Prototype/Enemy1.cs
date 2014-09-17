using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Enemy1
    {
        #region Declarations

        public static byte on;
        public static int x;
        public static int y;
        public static byte c_moving;
        public static byte i_direction;
        public static byte target_on;
        public static byte moving;
        public static byte Max_moving;
        public static byte target_xy;

        public static int HP_num;
        public static int HP_max;
        public static byte life;

        public static byte Hit_x;
        public static byte Hit_y;
        public static byte[,] Hit_Matrix = new byte[3,3]{
        {0,1,0},
        {1,0,1},
        {0,1,0}
        };
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            c_moving = 0;
            on = 1;
            moving = 0;
            Max_moving = 10;
            target_on = 0;
            life = 1;
            x = 34;
            y = 16;
            Hit_x = 2;
            Hit_y = 2;
            HP_num = 20;
            HP_max = 20;
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
                            c_moving = 0;
                        }
                        else if (c_moving == 2)
                        {
                            SoundManager.PlayEnemyShot();
                            c_moving++;
                            target_on = 1;
                            //c_Enemy_tan[0].x1 = x - 2;
                            //c_Enemy_tan[0].x2 = x + 2;
                            //c_Enemy_tan[0].y1 = y - 2;
                            //c_Enemy_tan[0].y2 = y + 2;
                        }
                        else if (c_moving == 3)
                        {
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
                                int i = MyFunction.GetMoney(1);
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
            if (direction == 2 || direction == 3)
            {
                if (y1 == y2 && (x1 == x2 || x1 - 1 == x2 || x1 + 1 == x2))
                {
                    switch (direction)
                    {
                        case 1:
                            y += 2;
                            break;
                        case 2:
                            x -= 2;
                            break;
                        case 3:
                            x += 2;
                            break;
                        case 4:
                            y -= 2;
                            break;
                    }
                    HP_num -= attack;
                    if (HP_num <= 0)
                    {
                        moving = 0;
                        c_moving = 0;
                    }
                    return 1;
                }
            }
            else
            {
                if (x1 == x2 && (y1 == y2 || y1 - 1 == y2 || y1 + 1 == y2))
                {
                    switch (direction)
                    {
                        case 1:
                            y += 2;
                            break;
                        case 2:
                            x -= 2;
                            break;
                        case 3:
                            x += 2;
                            break;
                        case 4:
                            y -= 2;
                            break;
                    }
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
        #endregion
    }
}
