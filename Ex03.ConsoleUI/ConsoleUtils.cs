using System;

namespace Ex03.ConsoleUI
{
    public class ConsoleUtils
    {
        public static byte GetUsersChoiceAsByte(byte i_Infimum, byte i_Supremum)
        {
            bool isSucceeded;
            byte usersChoice = 0;
            bool validInput = false;
            while (!validInput)
            {
                isSucceeded = byte.TryParse(Console.ReadLine(), out usersChoice);
                if (isSucceeded)
                {
                    if (i_Infimum <= usersChoice && usersChoice <= i_Supremum)
                    {
                        validInput = true;
                    }
                }

                if (!validInput)
                {
                    Console.Write("Ivalid input. Enter your choice again: ");
                }
            }

            return usersChoice;
        }

        public static string GetUnemptyStringFromUser()
        {
            string userInput = string.Empty;
            while (0 == userInput.Length)
            {
                userInput = Console.ReadLine();
                if (0 == userInput.Length)
                {
                    Console.Write("Invalid input! Enter again: ");
                }
            }

            return userInput;
        }

        public static string GetLicenseNumberFromUser()
        {
            bool validInput = false;
            string licenseNumberInput = string.Empty;
            while (!validInput)
            {
                licenseNumberInput = Console.ReadLine();
                if (6 <= licenseNumberInput.Length && licenseNumberInput.Length <= 8)
                {
                    validInput = true;
                    foreach (char character in licenseNumberInput)
                    {
                        if (!('0' <= character && character <= '9') &&
                            !('a' <= character && character <= 'z') &&
                            !('A' <= character && character <= 'Z'))
                        {
                            validInput = false;
                            break;
                        }
                    }
                }

                if (!validInput)
                {
                    Console.Write("Ivalid license number. Insert a license number in length of 6-8 characters: ");
                }
            }

            return licenseNumberInput;
        }

        public static float GetUnsignedFloatFromUser(in float? i_Supremum = null)
        {
            float userInputAsFloat = 0f;
            bool isSucceeded;
            bool validInput = false;
            while (!validInput)
            {
                isSucceeded = float.TryParse(Console.ReadLine(), out userInputAsFloat);
                if (isSucceeded)
                {
                    if (0 <= userInputAsFloat)
                    {
                        if (null == i_Supremum)
                        {
                            validInput = true;
                        }
                        else if (userInputAsFloat <= i_Supremum.Value)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.Write("You can not enter a number greater than the capacity. Enter again: ");
                        }
                    }
                    else
                    {
                        Console.Write("You can not enter a negative number in this field. Enter again: ");
                    }
                }
                else
                {
                    Console.Write("Invalid input! Enter again: ");
                }
            }

            return userInputAsFloat;
        }

        public static int GetUnsignedIntegerFromUser()
        {
            int userInputAsInt = 0;
            bool isSucceeded;
            bool validInput = false;
            while (!validInput)
            {
                isSucceeded = int.TryParse(Console.ReadLine(), out userInputAsInt);
                if (isSucceeded)
                {
                    if (0 <= userInputAsInt)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.Write("You can not enter a negative number in this field. Enter again: ");
                    }
                }
                else
                {
                    Console.Write("Invalid input! Enter again: ");
                }
            }

            return userInputAsInt;
        }
    }
}
