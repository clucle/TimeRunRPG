using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    class MyFunction
    {
        public static int Mypercent;
        public static int Cnct(int x1, int y1, int x2, int y2)//충돌검사(몹과 나) 대각선포함
        {
            int x_Minus = x1 - x2;
            int y_Minus = y1 - y2;
            if (x_Minus >= -2 && x_Minus <= 2 && y_Minus >= -2 && y_Minus <= 2)
            {
                return 1;
            }
            return 0;
        }
        public static int Cnct_2(int x1, int y1, int x2, int y2)//충돌검사(몹과 나) 정확한 상화좌우
        {
            int x_Minus = x1 - x2;
            int y_Minus = y1 - y2;
            if (((x_Minus >= -2 && x_Minus <= 2) && (y_Minus >= -1 && y_Minus <= 1)) || ((x_Minus >= -1 && x_Minus <= 1) && (y_Minus >= -2 && y_Minus <= 2)))
            {
                return 1;
            }
            return 0;
        }
        
        public static int LineCrush(int x1, int y1, int x2, int y2)//충돌검사(몹과 나)
        {
            if (x1 == x2)
            {
                if (y1 > y2)
                {
                    return 1;
                }
                else if (y1 < y2)
                {
                    return 4;
                }
            }
            if (y1 == y2)
            {
                if (x1 > x2)
                {
                    return 3;
                }
                else if (x1 < x2)
                {
                    return 2;
                }
            }
            return 0;
        }
        public static int GetMoney(int x1)
        {

            Random rNum = new Random();
            Mypercent = rNum.Next(1, 100);
            if (Mypercent <= 8)//성공 *77
            {
                Intensity.Initialize_load[5] += (x1 * 77);
                Intensity.money += (x1 * 77);
                Intensity.Save_data();
                return 2;
            }
            else if (Mypercent <= 20)//성공 * 7
            {
                Intensity.Initialize_load[5] += (x1 * 7);
                Intensity.money += (x1 * 7);
                Intensity.Save_data();
                return 1;
            }
            else
            {
                Intensity.Initialize_load[5] += x1;
                Intensity.money += x1;
                Intensity.Save_data();
                return 0;

            }
            
        }
    }
}
