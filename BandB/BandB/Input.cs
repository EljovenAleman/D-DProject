using System;

namespace BandB
{
    static class Input
    {
        static ConsoleKey inputActionKey;
        static bool keyAvailable;

        public static bool UserPressedGameKey()
        {
            if (keyAvailable)
            {
                return true;
            }

            if (Console.KeyAvailable)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == ConsoleKey.RightArrow ||
                    pressedKey == ConsoleKey.LeftArrow ||
                    pressedKey == ConsoleKey.UpArrow ||
                    pressedKey == ConsoleKey.DownArrow||
                    pressedKey == ConsoleKey.Spacebar)
                {
                    keyAvailable = true;
                    inputActionKey = pressedKey;
                    return true;
                }
            }

            return false;
        }

        public static InputAction GetInputAction()
        {
            if (inputActionKey == ConsoleKey.RightArrow)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.MoveRight;
            }
            else if (inputActionKey == ConsoleKey.LeftArrow)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.MoveLeft;
            }
            else if (inputActionKey == ConsoleKey.UpArrow)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.MoveUp;
            }
            else if (inputActionKey == ConsoleKey.DownArrow)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.MoveDown;
            }
            else if (inputActionKey == ConsoleKey.Spacebar)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.PerformAction;
            }
            


            return InputAction.None;
        }

        public static InputAction GetInputMenuAction()
        {
            if (inputActionKey == ConsoleKey.NumPad1)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action1;
            }
            else if (inputActionKey == ConsoleKey.NumPad2)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action2;
            }
            else if (inputActionKey == ConsoleKey.NumPad3)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action3;
            }
            else if (inputActionKey == ConsoleKey.NumPad4)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action4;
            }
            else if (inputActionKey == ConsoleKey.NumPad5)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action5;
            }
            else if (inputActionKey == ConsoleKey.NumPad6)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action6;
            }
            else if (inputActionKey == ConsoleKey.NumPad7)
            {
                keyAvailable = false;
                inputActionKey = ConsoleKey.Y;
                return InputAction.Action7;
            }

            return InputAction.None;
        }

        
    }
}


