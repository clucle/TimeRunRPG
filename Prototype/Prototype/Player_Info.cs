using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Prototype
{
    class Player_Info
    {
        #region Declarations

        //강화수치
        public static int Accept_head;
        public static int Accept_body;
        public static int Accept_leg;

        #endregion
        public static void Initialize(ContentManager Content)
        {
            Accept_head = 0;
            Accept_body = 0;
            Accept_leg = 0;
        }
        public static void Accept_Info()
        {
            Accept_head = 9 - Intensity.head;
            Accept_body = Intensity.body + 3;
            Accept_leg = 9 - Intensity.leg;

            Player.Max_moving = Accept_leg;
            Player.s_Max_moving = Accept_leg;
            Player.HP_max = 100 + Accept_body * Accept_body * Accept_body * 5;
            for (int k = 0; k <= 2; k++)
            {
                Cooldown.Skill_CoolDown[k].on = 1;
                Cooldown.Skill_CoolDown[k].num = 0;
                Cooldown.Skill_CoolDown[k].max = Accept_head * 6;
            }
            Player.Max_gun = 1;
        }

    }
}
