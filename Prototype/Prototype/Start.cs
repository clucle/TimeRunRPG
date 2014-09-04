using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
 
namespace Prototype
{
    class Start
    {
        #region Declarations
        static byte mousedown;
        #endregion

        #region update
        public static void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)//마우스클릭
            {
                mousedown++;
                if (mousedown > 200)
                    mousedown = 200;
            }
            Rectangle mouserect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

            Rectangle rect1 = new Rectangle(279, 393, 238, 52);
            Rectangle rect2 = new Rectangle(279, 454, 238, 52);
            Rectangle rect3 = new Rectangle(279, 518, 238, 52);

            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect1) )
            {
                SoundManager.StopStart();
                SoundManager.PlayStage1_3();
                Game1.CurrentStage = 1;
                Player_Info.Accept_Info();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect2))//상점
            {

            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0 && mouserect.Intersects(rect3))//강화
            {
                Game1.CurrentStage = 100;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released && mousedown > 0)
            {
                mousedown = 0;
            }
        }
        #endregion
    }

}
