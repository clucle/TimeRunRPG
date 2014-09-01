using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Prototype
{
    class Enemy3
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

        public static int HP_num;
        public static int HP_max;
        public static byte life;

        public static byte Hit_x;
        public static byte Hit_y;

        static byte pattern1;
        static byte pattern1_max;
        static byte pattern1_tannum;

        public static byte condition;

        public struct Info_tan
        {
            public int on;
            public int x;
            public int y;

            public byte pattern1_tan_Graphic;
            public int i_direction;
        }
        public static Info_tan[] Tan = new Info_tan[5];

        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            c_moving = 0;
            on = 1;
            moving = 0;
            i_direction = 0;
            Max_moving = 10;
            target_on = 0;
            life = 1;
            x = 34;
            y = 15;
            Hit_x = 2;
            Hit_y = 2;
            HP_num = 80;
            HP_max = 80;

            pattern1 = 0;
            pattern1_max = 8;

            condition = 1;

            for (int k = 0; k < 5; k++)
            {
                Tan[k].on = 0;
            }
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
                        if (pattern1 <= pattern1_max)
                        {
                            pattern1++;
                        }
                        else
                        {
                            pattern1 = 0;
                            Tan[pattern1_tannum].x = x;
                            Tan[pattern1_tannum].y = y;
                            Tan[pattern1_tannum].on = 1;
                            pattern1_tannum++;
                            //SoundManager.PlayExplosion();
                            SoundManager.Enemy3Shot();
                            if (pattern1_tannum == 5) pattern1_tannum = 0;
                        }
                        for (int k = 0; k < 5; k++)
                        {
                            if (Tan[k].on == 1)
                            {
                                Tan[k].x--;
                                Tan[k].pattern1_tan_Graphic++;
                                if (Tan[k].pattern1_tan_Graphic == 2) Tan[k].pattern1_tan_Graphic = 0;
                                if (Tan[k].x <= -10)
                                {
                                    Tan[k].on = 0;
                                }
                            }
                        }
                        
                        

                        if (c_moving == 0)
                        {
                            switch (i_direction)
                            {
                                case 0:
                                    y++;
                                    break;
                                case 1:
                                    y--;
                                    break;
                            }
                            if (MyFunction.Cnct(x, y, Player.x, Player.y) == 1)
                            {
                                c_moving = 2;
                            }
                            else
                            {
                                c_moving = 1;
                            }

                        }
                        else if (c_moving == 1)
                        {
                            switch (i_direction)
                            {
                                case 0:
                                    y++;
                                    break;
                                case 1:
                                    y--;
                                    break;
                            }
                            if (y >= 23)
                            {
                                i_direction = 1;
                            }
                            else if (y <= 1)
                            {
                                i_direction = 0;
                            }
                            c_moving = 2;
                        }
                        else if (c_moving == 2)
                        {
                            switch (i_direction)
                            {
                                case 0:
                                    y++;
                                    break;
                                case 1:
                                    y--;
                                    break;
                            }
                            c_moving = 3;
                        }
                        else if (c_moving == 3)
                        {
                            switch (i_direction)
                            {
                                case 0:
                                    y++;
                                    break;
                                case 1:
                                    y--;
                                    break;
                            }
                            if (y >= 23)
                            {
                                i_direction = 1;
                            }
                            else if (y <= 1)
                            {
                                i_direction = 0;
                            }
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
            if (x1 >= x2 && x1 <= x2 + 6)
            {
                if (y1 >= y2 && y1 <= y2 + 5)
                {
                    HP_num -= attack;
                    if (HP_num <= 0)
                    {
                        moving = 0;
                        c_moving = 0;
                    }
                    if (condition == 1)
                    {
                        if (HP_num <= 40)
                        {
                            condition = 2;
                            pattern1_max = 6;
                            Max_moving = 8;
                            HP_num = 45;
                        }
                    }
                    return 1;
                }
            }
            return 0;
        }
        #endregion
    }

}
