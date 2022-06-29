using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Input
{
    public static int GetNumberFromKeyboardInput() // ** this function hangs
    {
        ConsoleKeyInfo keyPressed;
        int number;

        while (true)
        {
            keyPressed = Console.ReadKey(true);

            number = (int)Char.GetNumericValue(keyPressed.KeyChar);

            if (number > -1)
            {   
                break;
            }
        }

        return number;
    }

    public static string GetMultipleNumbersFromKeyboardInput(bool shouldEcho, int echoX, int echoY) // ** this function hangs
    {
        Console.SetCursorPosition(echoY, echoX);

        ConsoleKeyInfo keyPressed;
        int keyValue;

        var input = new StringBuilder();

        while (true)
        {
            keyPressed = Console.ReadKey(!shouldEcho);

            // check for enter key
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                break;
            }

            keyValue = (int)Char.GetNumericValue(keyPressed.KeyChar);

            if (keyValue != -1)
            {
                input.Append(keyPressed.KeyChar);
            }
        }

        return input.ToString();
    }

    public static string GetFullKeyboardInput(bool shouldEcho, int echoX, int echoY, bool catchZero) // ** this function hangs
    {
        Console.SetCursorPosition(echoY, echoX);

        ConsoleKeyInfo keyPressed;
        var input = new StringBuilder();

        bool isFirstKeyPress = true;
        while (true)
        {
            keyPressed = Console.ReadKey(!shouldEcho);

            if (catchZero && isFirstKeyPress && keyPressed.Key == ConsoleKey.D0)
            {
                return "0";
            }

            // check for enter key
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                break;
            }

            // check for backspace key
            if (keyPressed.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
            }

            isFirstKeyPress = false;

            input.Append(keyPressed.KeyChar);
        }

        return input.ToString();
    }
}