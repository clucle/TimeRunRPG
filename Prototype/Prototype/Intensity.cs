using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace Prototype
{
    class Intensity
    {
        #region Declarations
        //강화수치
        public static int head;
        public static int body;
        public static int leg;

        //장비 번호
        public static int gun;
        public static int armor;

        //돈
        public static int money;

        static byte mousedown;
        public static int[] Initialize_load = new int[6];
        #endregion
        #region Initialize
        public static void Initialize(ContentManager content)
        {
            int i;
            i = 0;
            FileStream fr = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fr, System.Text.Encoding.Default);
            while (!sr.EndOfStream && i < 6)
            {
                Initialize_load[i] = int.Parse(sr.ReadLine());
                switch (i)
                {
                    case 0:
                        head = Initialize_load[i];
                        break;
                    case 1:
                        body = Initialize_load[i];
                        break;
                    case 2:
                        leg = Initialize_load[i];
                        break;
                    case 3:
                        gun = Initialize_load[i];
                        break;
                    case 4:
                        armor = Initialize_load[i];
                        break;
                    case 5:
                        money = Initialize_load[i];
                        break;
                }
                i++;
            }
            sr.Close();
            fr.Close();

        }
        #endregion
        #region update
        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        head = Initialize_load[i];
                        break;
                    case 1:
                        body = Initialize_load[i];
                        break;
                    case 2:
                        leg = Initialize_load[i];
                        break;
                    case 3:
                        gun = Initialize_load[i];
                        break;
                    case 4:
                        armor = Initialize_load[i];
                        break;
                    case 5:
                        money = Initialize_load[i];
                        break;
                }
            }


            Rectangle mouserect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            Rectangle rect1 = new Rectangle(615, 340, 63, 38);
            Rectangle rect2 = new Rectangle(615, 395, 63, 38);
            Rectangle rect3 = new Rectangle(615, 450, 63, 38);
            Rectangle rect4 = new Rectangle(607, 525, 71, 38);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)//마우스클릭
            {
                mousedown++;
                if (mousedown > 200)
                    mousedown = 200;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect1) && head < 7)
            {
                F_Intensity(0, head);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect2) && body < 7)
            {
                F_Intensity(1, body);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect3) && leg < 7)
            {
                F_Intensity(2, leg);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect4))
            {
                Game1.CurrentStage = 99;
                Player_Info.Accept_Info();
            }


            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0)
            {
                mousedown = 0;
            }
        }
        #endregion

        #region Function
        public static void F_Intensity(int item_num, int Intensity)
        {
            if (money >= Intensity * Intensity)
            {
                Initialize_load[5] -= (Intensity * Intensity);
                money -= (Intensity * Intensity);
                
                Random rNum = new Random();
                int Mypercent = rNum.Next(1, 100);

                int Supercent = 0;//성공확률
                switch (Intensity)
                {
                    case 0:
                        Supercent = 100;
                        break;
                    case 1:
                        Supercent = 80;
                        break;
                    case 2:
                        Supercent = 60;
                        break;
                    case 3:
                        Supercent = 50;
                        break;
                    case 4:
                        Supercent = 40;
                        break;
                    case 5:
                        Supercent = 30;
                        break;
                    case 6:
                        Supercent = 20;
                        break;
                }
                if (Mypercent <= Supercent)//성공
                {
                    Initialize_load[item_num]++;
                }
                else
                {
                    if (Intensity > 1)
                    {
                        //Initialize_load[item_num]--;
                    }
                }
                Save_data();
            }
        }
        public static void Save_data()
        {
            int i = 0;
            FileStream fw = new FileStream("data.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fw, System.Text.Encoding.UTF8);
            for (i = 0; i < 6; i++)
            {
                sw.WriteLine(Initialize_load[i]);
            }
            sw.Close();
            fw.Close();
        }
        #endregion
    }
}
