using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    class MyFunction
    {
        public static int Cnct(int x1, int y1, int x2, int y2)//충돌검사(몹과 나)
        {
            int x_Minus = x1 - x2;
            int y_Minus = y1 - y2;
            if (x_Minus >= -2 && x_Minus <= 2 && y_Minus >= -2 && y_Minus <= 2)
            {
                return 1;
            }
            return 0;
        }
        static void My_hit(int x1, int y1, int x2, int y2, int attack)//적의 공격)
        {
            //x랑 y 범위 attack만큼 공격 받음
        }

    }
}
