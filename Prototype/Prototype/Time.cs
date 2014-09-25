using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{
    class Time
    {
        #region Declarations

        public static int time;
        public static byte sec;
        public static byte min;

        #endregion

        #region Initialization
        public static void Initialize(ContentManager Content)
        {
            time = 0;
            min = 5;
            sec = 0;
        }
        #endregion

        #region update
        public static void Update(GameTime gameTime)
        {
            time++;
            if (time >= 60)
            {
                sec--;
                time = 0;
            }
            if (sec <= 0)
            {
                min--;
                sec = 59;
            }
        }
        #endregion

        #region Function

        #endregion
    }
}
