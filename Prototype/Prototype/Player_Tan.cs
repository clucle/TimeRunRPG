using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Player_Tan
    {
        #region Declarations
        public struct Info_tan
        {
            public int on;
            public int x;
            public int y;

            public byte distance;
            public byte Max_distance;
            public byte i_direction;
        }
        public static Info_tan[] c_Tan = new Info_tan[50];
        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {

            for (int k = 0; k <= 49; k++)
            {
                c_Tan[k].Max_distance = 8;
                c_Tan[k].distance = 0;
                c_Tan[k].on = 0;
            }
        }
        #endregion

        #region update
        public static void Update(GameTime gameTime)
        {

            for (int k = 0; k <= 49; k++)
            {
                if (c_Tan[k].on == 1)
                {
                    c_Tan[k].distance++;
                    switch (c_Tan[k].i_direction)
                    {
                      
                        case 1:
                            c_Tan[k].y++;
                            break;
                        case 2:
                            c_Tan[k].x--;
                            break;
                        case 3:
                            c_Tan[k].x++;
                            break;
                        case 4:
                            c_Tan[k].y--;
                            break;
                    }
                }
                if (c_Tan[k].x < -20 || c_Tan[k].x > 820 || c_Tan[k].y < -20 || c_Tan[k].y > 620)
                {
                    c_Tan[k].on = 0;
                }
                if (c_Tan[k].distance >= c_Tan[k].Max_distance)
                {
                    c_Tan[k].on = 0;
                    c_Tan[k].distance = 0;
                }
            }
        }
        #endregion
    }
}
