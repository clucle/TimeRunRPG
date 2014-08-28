using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Cooldown
    {
        #region Declarations 
        public static int Time_Second;
        //on    num     max//
        public struct Info_Skill
        {
            public int on;
            public int num;
            public int max;
        }
        public static Info_Skill[] Skill_CoolDown = new Info_Skill[5];
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {

            Time_Second = 0;

            for (int k = 0; k <= 1; k++)
            {
                Skill_CoolDown[k].on = 1;
                Skill_CoolDown[k].num = 0;
                Skill_CoolDown[k].max = 1;
            }

        }
        #endregion

        #region update
        public static void Update(GameTime gameTime)
        {
            if (Time_Second <= 10) Time_Second++;

            if (Time_Second >= 10)
            {
                for (int k = 0; k <= 1; k++)
                {
                    if (Skill_CoolDown[k].on == 0)
                    {
                        if (Skill_CoolDown[k].num <= Skill_CoolDown[k].max)
                        {
                            Skill_CoolDown[k].num++;
                        }
                        else
                        {
                            Skill_CoolDown[k].on = 1;
                            Skill_CoolDown[k].num = 0;
                        }

                    }
                }
                Time_Second = 0;
            }
        }
        #endregion
    }
}
