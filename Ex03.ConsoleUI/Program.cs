using System;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (!GarageUIUtils.s_IsGarageClosed)
            {
                GarageUIUtils.PrintGarageMenu();
                GarageUIUtils.InvokeSpecificAction();
            }

            Console.WriteLine("{0}End of program. Press any key to exit. . .", Environment.NewLine);
            Console.ReadKey();
        }
    }
}
