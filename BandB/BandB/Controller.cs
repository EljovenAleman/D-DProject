using System;
using System.Dynamic;
using System.Media;

namespace BandB
{
    static class Controller
    {
        static public bool menuActive = false;

        static void MovementControl(Classes player, InputAction action)
        {
            if(action == InputAction.MoveRight)
            {
                player.Move(player.position.x + 1, player.position.y);
            }
            else if(action == InputAction.MoveLeft)
            {
                player.Move(player.position.x - 1, player.position.y);
            }
            else if(action == InputAction.MoveDown)
            {
                player.Move(player.position.x, player.position.y+1);
            }
            else if(action == InputAction.MoveUp)
            {
                player.Move(player.position.x, player.position.y - 1);
            }
            
        }

        /*static public void MenuControl(string [] options, InputAction action)
        {
            for(int f=0; f<options.Length; f++)
            {
                Console.SetCursorPosition(3, 26 + f);
                Console.Write(f+1);
            }


        }*/


    }

    
}


