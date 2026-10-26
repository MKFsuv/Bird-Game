using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird_Game
{
    public class PurpleSparrow
    {

        public float speed = 1;
        public int sidespeed = 10;
        public float x = 800;
        public float y = 400;


        public static void Movement(PurpleSparrow sparrow)
        {
            float jumpStrength = 150;
            bool isGrounded = false;

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W) && isGrounded)
            {
                sparrow.y -= jumpStrength;
                isGrounded = false;

            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                sparrow.x += sparrow.sidespeed;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                sparrow.x -= sparrow.sidespeed;
            }

        }



      


    }
}

