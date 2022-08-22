using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Wheel wheel1 = new Wheel("BMW", 16.6f, 70f);
            Wheel wheel2 = new Wheel("BMW", 13f, 70f);
            Wheel wheel3 = new Wheel("BMW", 23.8f, 70f);
            Wheel wheel4 = new Wheel("BMW", 23.8f, 70f);
            Wheel[] wheels = { wheel1, wheel2, wheel3, wheel4 };

            Garage garage = new Garage();

            try
            {
                Car electricCar = new Car("Avi", "0505050505", "VW", "123456789", "Michelin", 20f, 10f, 15f, 40f, eCarColor.Black, eNumberOfCarDoors.Four);
                garage.Vehicles.Add(electricCar);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} - {1}", e.GetType(), e.Message);
            }

            try
            {
                Car fuelCar = new Car("Ron", "0530530530", "BMW", "987654321", "Dunlop", 10f, 20f, eFuelType.Soler, 10f, 25f, eCarColor.Black, eNumberOfCarDoors.Four);
                garage.Vehicles.Add(fuelCar);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} - {1}", e.GetType(), e.Message);
            }

            foreach (Car car in garage.Vehicles)
            {
                try
                {
                    car.TryFillEnergySource(20f);
                }
                catch(Exception e)
                {
                    Console.WriteLine("{0} - {1}", e.GetType(), e.Message);
                }
            }

            Console.WriteLine("End of program. Press any key to exit . . .");
            Console.ReadKey();

            // TODO: add modifiers to each class + class members (readonly, static, etc...)
            //  use Enviroment.newline instead of \n
        }
    }
}
