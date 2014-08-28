using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Prototype
{
    static class Player
    {
        #region Declarations
        public static int x;
        public static int y;
        public static byte i_direction;
        public static int d_moving;
        public static int Max_moving;

        public static int s_moving;//skill moving
        public static int s_Max_moving;

        public static byte d_gun;
        public static byte Max_gun;
        public static byte c_moving;
        public static byte i_mode;

        public static int HP_num;
        public static int HP_max;


        //skill
        public static byte skill_moving;
        public static byte skill_moving_direction;
        public static byte skill_moving_num;
        public static byte skill_moving_max;

        private static byte tan_checking;




        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            x = 2;
            y = 16;
            i_direction = 1;
            d_moving = 0;
            //Max_moving = Player_Info.Accept_leg;
            d_gun = 0;
            //Max_gun = 10;
            c_moving = 0;
            i_mode = 0;

            s_moving = 0;
            //s_Max_moving = Max_moving;


            skill_moving = 0;
            skill_moving_num = 0;
            skill_moving_max = 5;

            tan_checking = 0;

            HP_num = 100;
            HP_max = 100;

        }
        #endregion

        #region update
        public static void Update(GameTime gameTime)
        {
                    //캐릭터 무빙
            if (d_moving <= Max_moving) d_moving++;
            if (d_gun <= Max_gun) d_gun++;

            if (d_moving >= Max_moving)
            {
                if (i_mode == 0)
                {
                    if (c_moving == 0)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Up))//키코드
                        {
                            if (i_direction == 4)
                            {
                                d_moving = 0;
                                c_moving = 1;
                            }
                            else
                            {
                                i_direction = 4;
                                d_moving = Max_moving - 1;
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Down))//키코드
                        {
                            if (i_direction == 1)
                            {
                                d_moving = 0;
                                c_moving = 1;
                            }
                            else
                            {
                                i_direction = 1;
                                d_moving = Max_moving - 1;
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Right))//키코드
                        {
                            if (i_direction == 3)
                            {
                                d_moving = 0;
                                c_moving = 1;
                            }
                            else
                            {
                                i_direction = 3;
                                d_moving = Max_moving - 1;
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Left))//키코드
                        {
                            if (i_direction == 2)
                            {
                                d_moving = 0;
                                c_moving = 1;
                            }
                            else
                            {
                                i_direction = 2;
                                d_moving = Max_moving - 1;
                            }
                        }
                        //마우스로 공격
                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        //if (Mouse.GetState().LeftButton == ButtonState.Pressed)//마우스클릭
                        {
                            //if (c_moving == 0)
                            //{
                                i_mode = 1;
                                d_moving = 0;
                                c_moving = 1;
                                d_gun = 0;

                                SoundManager.PlayPlayerShot();

                                Player_Tan.c_Tan[tan_checking].on = 1;
                                Player_Tan.c_Tan[tan_checking].x = x;
                                Player_Tan.c_Tan[tan_checking].y = y;
                                Player_Tan.c_Tan[tan_checking].i_direction = i_direction;
                                Player_Tan.c_Tan[tan_checking].distance = 0;
                                tan_checking++;
                                if (tan_checking >= 50)
                                {
                                    tan_checking = 0;
                                }
                            //}
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Q))//이동사격
                        {
                            if (Cooldown.Skill_CoolDown[0].on == 1)
                            {
                                c_moving = 0;
                                d_moving = 0;
                                d_gun = 0;
                                skill_moving_num = 0;
                                i_mode = 3;
                                Cooldown.Skill_CoolDown[0].on = 0;
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.W))//빽샷
                        {
                            if (Cooldown.Skill_CoolDown[1].on == 1)
                            {
                                c_moving = 0;
                                d_moving = 0;
                                d_gun = 0;
                                skill_moving_num = 0;
                                i_mode = 2;
                                Cooldown.Skill_CoolDown[1].on = 0;
                            }
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
                        c_moving = 2;
                    }
                    else if (c_moving == 2)
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
                    d_moving = 0;
                }
                else if (i_mode == 1)
                {
                    if (d_gun >= Max_gun)
                    {
                        c_moving++;
                        if (c_moving == 4)
                        {
                            c_moving = 0;
                            i_mode = 0;
                        }
                        d_gun = 0;
                        d_moving = 0;
                    }
                }
                else if (i_mode == 2)
                {
                    if (s_moving <= s_Max_moving) s_moving++;

                    if (s_moving >= s_Max_moving)
                    {
                        s_moving = 0;
                        c_moving++;

                        switch (i_direction)
                        {
                            case 1:

                                y--;
                                break;
                            case 2:
                                x++;
                                break;
                            case 3:
                                x--;
                                break;
                            case 4:
                                y++;
                                break;
                        }

                        switch (c_moving)
                        {
                            case 2:
                                SoundManager.PlayPlayerShot();

                                Player_Tan.c_Tan[tan_checking].on = 1;
                                Player_Tan.c_Tan[tan_checking].x = x;
                                Player_Tan.c_Tan[tan_checking].y = y;
                                Player_Tan.c_Tan[tan_checking].i_direction = i_direction;
                                Player_Tan.c_Tan[tan_checking].distance = 0;
                                tan_checking++;
                                if (tan_checking >= 50)
                                {
                                    tan_checking = 0;
                                }
                                break;
                            case 4:
                                SoundManager.PlayPlayerShot();

                                Player_Tan.c_Tan[tan_checking].on = 1;
                                Player_Tan.c_Tan[tan_checking].x = x;
                                Player_Tan.c_Tan[tan_checking].y = y;
                                Player_Tan.c_Tan[tan_checking].i_direction = i_direction;
                                Player_Tan.c_Tan[tan_checking].distance = 0;
                                tan_checking++;
                                if (tan_checking >= 50)
                                {
                                    tan_checking = 0;
                                }
                                break;
                        }
                        if (c_moving == 4)
                        {
                            i_mode = 0;
                            c_moving = 0;
                            d_moving = 0;
                            d_gun = 0;
                            s_moving = 0;
                            skill_moving_num = 0;
                        }
                    }
                }
                else if (i_mode == 3)
                {
                    if (s_moving <= s_Max_moving) s_moving++;

                    if (s_moving >= s_Max_moving)
                    {
                        if (c_moving == 0)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Up))//키코드
                            {
                                c_moving = 1;
                                s_moving = 0;
                                skill_moving_direction = 4;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.Down))//키코드
                            {
                                c_moving = 1;
                                s_moving = 0;
                                skill_moving_direction = 1;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.Right))//키코드
                            {
                                c_moving = 1;
                                s_moving = 0;
                                skill_moving_direction = 3;
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.Left))//키코드
                            {
                                c_moving = 1;
                                s_moving = 0;
                                skill_moving_direction = 2;
                            }
                        }
                        else if (c_moving == 1)
                        {
                            SoundManager.PlayPlayerShot();

                            Player_Tan.c_Tan[tan_checking].on = 1;
                            Player_Tan.c_Tan[tan_checking].x = x;
                            Player_Tan.c_Tan[tan_checking].y = y;
                            Player_Tan.c_Tan[tan_checking].i_direction = i_direction;
                            Player_Tan.c_Tan[tan_checking].distance = 0;
                            tan_checking++;
                            if (tan_checking >= 50)
                            {
                                tan_checking = 0;
                            }
                            switch (skill_moving_direction)
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

                            c_moving = 2;
                            s_moving = 0;
                        }
                        else if (c_moving == 2)
                        {
                            switch (skill_moving_direction)
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
                            s_moving = 0;
                            c_moving = 0;
                            skill_moving_num++;
                            if (skill_moving_num >= skill_moving_max)
                            {
                                c_moving = 3;
                            }
                        }
                        else if (c_moving == 3)
                        {
                            i_mode = 0;
                            c_moving = 0;
                            d_moving = 0;
                            d_gun = 0;
                            skill_moving_num = 0;
                        }
                    }
                }//imode
            }



        }
        #endregion

        #region Function
        public static int Enemy_hit(int x1, int y1, int x2, int y2, int attack, int direction)
        {
            if (x1 == x2 && y1 == y2)
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
                return 1;
            }
            return 0;
        }
        #endregion

        #region Function
        public static int My_hit(int x1, int y1, int x2, int y2, int attack, int direction)
        {
            if (x1 == x2 && y1 == y2)
            {
                //switch (direction)
                //{
                //    case 1:
                //        y += 2;
                //        break;
                //    case 2:
                //        x -= 2;
                //        break;
                //    case 3:
                //        x += 2;
                //        break;
                //   case 4:
                //        y -= 2;
                //        break;
                //}
                //return 1;
                HP_num -= attack;
                return 1;
            }
            return 0;
        }
        public static int My_hit2(int x1, int y1, int x2, int y2, int w, int h ,int attack, int direction)
        {
            if (x1 >= x2 && y1 >= y2)
            {
                if (x1 <= x2 + w && y1 <= y2 + h)
                {
                    //switch (direction)
                    //{
                    //    case 1:
                    //        y += 2;
                    //        break;
                    //    case 2:
                    //        x -= 2;
                    //        break;
                    //    case 3:
                    //        x += 2;
                    //        break;
                    //   case 4:
                    //        y -= 2;
                    //        break;
                    //}
                    //return 1;
                    HP_num -= attack;
                    return 1;
                }
            }
            return 0;
        }
        #endregion
    }
}