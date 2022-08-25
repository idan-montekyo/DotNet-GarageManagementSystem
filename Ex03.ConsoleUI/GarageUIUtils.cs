using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageUIUtils
    {
        public static bool s_IsGarageClosed = false;
        private static readonly Garage sr_Garage = new Garage();
        private static List<string> s_LicenseNumbersByCondition;
        private static byte s_UsersChoiceToExecute;

        private static string s_LicenseNumber;
        private static eVehicleType s_VehicleType;
        private static bool s_IsElectric;

        private static string s_VehicleOwnersName;
        private static string s_VehicleOwnersPhoneNumber;
        private static string s_VehiclesModel;
        private static string s_WheelsModel;
        private static float s_CurrentTireAirPressure;
        private static float s_MaxTireAirPressureSetByManufacturer;
        private static eFuelType s_FuelType;
        private static float s_CurrentEnergyAmount;
        private static float s_MaxEnergyAmount;

        private static eCarColor s_CarColor;
        private static eNumberOfCarDoors s_CarNumberOfDoors;
        private static eMotorcycleLicenseType s_MotorcycleLicenseType;
        private static int s_MotorcycleEngineCapacity;
        private static bool s_TruckHasFreezer;
        private static float s_TruckMaxCargoWeight;

        private static eFuelType s_FuelTypeToFill;
        private static float s_AmountOfEnergySourceToAdd;

        public static void PrintGarageMenu()
        {
            Console.Clear();
            string menuMessage = string.Format("Welcome to the Garage!{0}" +
                                               "Please choose your desired action from the menu below:{0}{0}" +
                                               "1. Add a new vehicle to the garage, or set an existing vehicle's condition to Under-Repair.{0}" +
                                               "2. Present a list of vehicles' license numbers according to their condition in the garage.{0}" +
                                               "3. Change a vehicle's condition in the garage.{0}" +
                                               "4. Inflate vehicle's tires.{0}" +
                                               "5. Fill gas for fuel based vehicle.{0}" +
                                               "6. Charge battery for electric vehicle.{0}" +
                                               "7. Present full information of a vehicle.{0}" +
                                               "8. Exit Idan and Oren's garage.{0}{0}" +
                                               "Enter your choice here: ", Environment.NewLine);
            Console.Write(menuMessage);
            s_UsersChoiceToExecute = ConsoleUtils.GetUsersChoiceAsByte(1, 8);
        }

        public static void InvokeSpecificAction()
        {
            Console.Clear();
            switch (s_UsersChoiceToExecute)
            {
                case 1:
                    addNewVehicle();
                    break;
                case 2:
                    presentListOfLicenseNumbers();
                    break;
                case 3:
                    changeVehiclesCondition();
                    break;
                case 4:
                    inflateVehiclesTiresToMaximum();
                    break;
                case 5:
                    fillGasForVehicle();
                    break;
                case 6:
                    chargeBatteryForVehicle();
                    break;
                case 7:
                    showVehicleFullInformation();
                    break;
                case 8:
                    s_IsGarageClosed = true;
                    Console.WriteLine("Bye bye . . .");
                    break;
            }
            if (!s_IsGarageClosed)
            {
                Console.WriteLine("{0}Press any key to continue. . .", Environment.NewLine);
                Console.ReadKey();
            }
        }

        private static void addNewVehicle()
        {
            Console.Write("Please insert your license number in length of 6-8 characters: ");
            s_LicenseNumber = ConsoleUtils.GetLicenseNumberFromUser();
            if (sr_Garage.IsExist(s_LicenseNumber))
            {
                sr_Garage.ChangeVehicleCondition(s_LicenseNumber, eVehicleConditionInTheGarage.UnderRepair);
                Console.WriteLine("{0}This vehicle is already in the garage. It is now under repair.", Environment.NewLine);
            }
            else
            {
                getPreliminaryInfoAboutVehicleTypeFromUser();
                getBasicVehicleInfoFromUser();
                getFuelBasedOrElectricVehicleInfoFromUser();
                getSpecificConcreteVehicleInfoFromUser();
                createNewVehicleAndAddToGarage();
            }
        }

        private static void getPreliminaryInfoAboutVehicleTypeFromUser()
        {
            string chooseVehicleToCreateMessage = string.Format("{0}What type is your vehicle?{0}" +
                                                                "1. Car{0}2. Motorcycle{0}3. Truck{0}" +
                                                                "Enter your choice here: ", Environment.NewLine);
            Console.Write(chooseVehicleToCreateMessage);
            byte usersChoiceOfVehicleType = ConsoleUtils.GetUsersChoiceAsByte(1, 3);
            s_VehicleType = (eVehicleType)usersChoiceOfVehicleType;

            if (s_VehicleType != eVehicleType.Truck)
            {
                string isTheVehicleFuelBasedOrElectricMessage = string.Format("{0}Is your {1} electric or fuel based?{0}" +
                                                                              "1. Electric{0}2. Fuel based{0}" +
                                                                              "Enter your choice here: ",
                                                                              Environment.NewLine, s_VehicleType.ToString().ToLower());
                Console.Write(isTheVehicleFuelBasedOrElectricMessage);
                byte usersChoiceOfEnergySource = ConsoleUtils.GetUsersChoiceAsByte(1, 2);
                s_IsElectric = usersChoiceOfEnergySource == 1 ? true : false;
            }
        }

        private static void getBasicVehicleInfoFromUser()
        {
            Console.Write("{0}Enter the vehicle's owner name: ", Environment.NewLine);
            s_VehicleOwnersName = ConsoleUtils.GetUnemptyStringFromUser();
            Console.Write("{0}Enter the vehicle's owner phone number (9-10 digits with no other characters): ", Environment.NewLine);
            initializeVehicleOwnersPhoneNumberFromUser();
            Console.Write("{0}Enter the vehicle's model (For example Mercedes, BMW, etc..): ", Environment.NewLine);
            s_VehiclesModel = ConsoleUtils.GetUnemptyStringFromUser();
            Console.Write("{0}Enter the vehicle's wheel's model (For example Eco, Giovanna, etc..): ", Environment.NewLine);
            s_WheelsModel = ConsoleUtils.GetUnemptyStringFromUser();
            Console.Write("{0}Enter the tires' maximum air pressure set by manufacturer: ", Environment.NewLine);
            s_MaxTireAirPressureSetByManufacturer = ConsoleUtils.GetUnsignedFloatFromUser();
            Console.Write("{0}Enter the tires' current air pressure (must be less than or equal to the maximum capacity): ", Environment.NewLine);
            s_CurrentTireAirPressure = ConsoleUtils.GetUnsignedFloatFromUser(s_MaxTireAirPressureSetByManufacturer);
        }

        private static void getFuelBasedOrElectricVehicleInfoFromUser()
        {
            if (!s_IsElectric)
            {
                string chooseFuelTypeMessage = string.Format("{0}What fuel type your {1} uses?{0}" +
                                                             "1. Octan98{0}2. Octan96{0}3. Octan95{0}4. Soler{0}" +
                                                             "Enter your choice here: ",
                                                             Environment.NewLine, s_VehicleType.ToString().ToLower());
                Console.Write(chooseFuelTypeMessage);
                byte usersChoiceOfFuelType = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
                s_FuelType = (eFuelType)usersChoiceOfFuelType;
            }

            string askForMaxFuelAmountMessage = string.Format("{0}Enter the vehicle's maximum fuel tank capacity in liters: ", Environment.NewLine);
            string askForMaxBatteryTimeMessage = string.Format("{0}Enter the vehicle's maximum battery capacity in minutes: ", Environment.NewLine);
            Console.Write(s_IsElectric ? askForMaxBatteryTimeMessage : askForMaxFuelAmountMessage);
            s_MaxEnergyAmount = ConsoleUtils.GetUnsignedFloatFromUser();
            string askForCurrentFuelAmountMessage = string.Format("{0}Enter the vehicle's current fuel amount in liters (must be less than or equal to the maximum capacity): ", Environment.NewLine);
            string askForCurrentBatteryTimeMessage = string.Format("{0}Enter the vehicle's current battery time left in minutes (must be less than or equal to the maximum capacity): ", Environment.NewLine);
            Console.Write(s_IsElectric ? askForCurrentBatteryTimeMessage : askForCurrentFuelAmountMessage);
            s_CurrentEnergyAmount = ConsoleUtils.GetUnsignedFloatFromUser(s_MaxEnergyAmount);
        }

        private static void getSpecificConcreteVehicleInfoFromUser()
        {
            switch (s_VehicleType)
            {
                case eVehicleType.Car:
                    string chooseCarColorMessage = string.Format("{0}What color is your car?{0}" +
                                                             "1. Gray{0}2. White{0}3. Black{0}4. Blue{0}" +
                                                             "Enter your choice here: ", Environment.NewLine);
                    Console.Write(chooseCarColorMessage);
                    byte usersChoiceOfCarColor = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
                    s_CarColor = (eCarColor)usersChoiceOfCarColor;
                    string chooseNumberOfDoorsMessage = string.Format("{0}How many doors your car have?{0}" +
                                                             "1. Two{0}2. Three{0}3. Four{0}4. Five{0}" +
                                                             "Enter your choice here: ", Environment.NewLine);
                    Console.Write(chooseNumberOfDoorsMessage);
                    byte usersChoiceOfNumberOfDoors = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
                    s_CarNumberOfDoors = (eNumberOfCarDoors)usersChoiceOfNumberOfDoors;
                    break;
                case eVehicleType.Motorcycle:
                    string chooseMotorcycleLicenseTypeMessage = string.Format("{0}What motorcycle license type do you own?{0}" +
                                                                              "1. BB{0}2. B1{0}3. AA{0}4. A{0}" +
                                                                              "Enter your choice here: ", Environment.NewLine);
                    Console.Write(chooseMotorcycleLicenseTypeMessage);
                    byte usersChoiceOfMotorcycleLicenseType = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
                    s_MotorcycleLicenseType = (eMotorcycleLicenseType)usersChoiceOfMotorcycleLicenseType;
                    Console.Write("{0}Enter the motorcycle's engine capacity: ", Environment.NewLine);
                    s_MotorcycleEngineCapacity = ConsoleUtils.GetUnsignedIntegerFromUser();
                    break;
                case eVehicleType.Truck:
                    string isTruckRefrigeratedMessage = string.Format("{0}Does your truck have a freezer to transport refrigirerated contents?{0}" +
                                                                      "1. Yes{0}2. No{0}" +
                                                                      "Enter your choice here: ", Environment.NewLine);
                    Console.Write(isTruckRefrigeratedMessage);
                    s_TruckHasFreezer = ConsoleUtils.GetUnsignedIntegerFromUser() == 1 ? true : false;
                    Console.Write("{0}Enter your truck's maximum cargo weight: ", Environment.NewLine);
                    s_TruckMaxCargoWeight = ConsoleUtils.GetUnsignedFloatFromUser();
                    break;
            }
        }

        private static void createNewVehicleAndAddToGarage()
        {
            IConcreteVehicle newVehicle = null;
            try
            {
                switch (s_VehicleType)
                {
                    case eVehicleType.Car:
                        if (s_IsElectric)
                        {
                            newVehicle = ConcreteVehicleBuilder.Build(s_VehicleOwnersName, s_VehicleOwnersPhoneNumber,
                                                                      s_VehiclesModel, s_LicenseNumber, s_WheelsModel,
                                                                      s_CurrentTireAirPressure, s_MaxTireAirPressureSetByManufacturer,
                                                                      s_CurrentEnergyAmount, s_MaxEnergyAmount, s_CarColor,
                                                                      s_CarNumberOfDoors);
                        }
                        else
                        {
                            newVehicle = ConcreteVehicleBuilder.Build(s_VehicleOwnersName, s_VehicleOwnersPhoneNumber,
                                                                      s_VehiclesModel, s_LicenseNumber, s_WheelsModel,
                                                                      s_CurrentTireAirPressure, s_MaxTireAirPressureSetByManufacturer,
                                                                      s_CurrentEnergyAmount, s_MaxEnergyAmount, s_CarColor,
                                                                      s_CarNumberOfDoors, s_FuelType);
                        }
                        break;
                    case eVehicleType.Motorcycle:
                        if (s_IsElectric)
                        {
                            newVehicle = ConcreteVehicleBuilder.Build(s_VehicleOwnersName, s_VehicleOwnersPhoneNumber,
                                                                      s_VehiclesModel, s_LicenseNumber, s_WheelsModel,
                                                                      s_CurrentTireAirPressure, s_MaxTireAirPressureSetByManufacturer,
                                                                      s_CurrentEnergyAmount, s_MaxEnergyAmount,
                                                                      s_MotorcycleLicenseType, s_MotorcycleEngineCapacity);
                        }
                        else
                        {
                            newVehicle = ConcreteVehicleBuilder.Build(s_VehicleOwnersName, s_VehicleOwnersPhoneNumber,
                                                                      s_VehiclesModel, s_LicenseNumber, s_WheelsModel,
                                                                      s_CurrentTireAirPressure, s_MaxTireAirPressureSetByManufacturer,
                                                                      s_CurrentEnergyAmount, s_MaxEnergyAmount,
                                                                      s_MotorcycleLicenseType, s_MotorcycleEngineCapacity,
                                                                      s_FuelType);
                        }
                        break;
                    case eVehicleType.Truck:
                        newVehicle = ConcreteVehicleBuilder.Build(s_VehicleOwnersName, s_VehicleOwnersPhoneNumber,
                                                                  s_VehiclesModel, s_LicenseNumber, s_WheelsModel,
                                                                  s_CurrentTireAirPressure, s_MaxTireAirPressureSetByManufacturer,
                                                                  s_CurrentEnergyAmount, s_MaxEnergyAmount, s_TruckHasFreezer,
                                                                  s_TruckMaxCargoWeight, s_FuelType);
                        break;
                }

                if (newVehicle != null)
                {
                    sr_Garage.AddVehicle(newVehicle);
                    Console.Clear();
                    Console.WriteLine("Your vehicle was added to the garage.");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                string exceptionMessage = string.Format("{0}Failed to create a new vehicle." +
                                                        "{0}Exception: {1}{0}Exception message: {2}", 
                                                        Environment.NewLine, e.GetType(), e.Message);
                Console.WriteLine(exceptionMessage);
            }
        }

        private static void initializeVehicleOwnersPhoneNumberFromUser()
        {
            bool validInput = false;
            while (!validInput)
            {
                s_VehicleOwnersPhoneNumber = Console.ReadLine();
                if (9 <= s_VehicleOwnersPhoneNumber.Length && s_VehicleOwnersPhoneNumber.Length <= 10)
                {
                    validInput = true;
                    foreach (char character in s_VehicleOwnersPhoneNumber)
                    {
                        if (!('0' <= character && character <= '9'))
                        {
                            validInput = false;
                            break;
                        }
                    }
                }

                if (!validInput)
                {
                    Console.Write("Ivalid phone number. Insert a phone number in length of 9-10 digits: ");
                }
            }
        }

        private static void presentListOfLicenseNumbers()
        {
            Console.Clear();
            string pickConditionMessage = string.Format("Pick what condition you would like to filter by from the following:{0}" +
                                                        "1. UnderRepair{0}2. Repaired{0}3. RepairedAndPaid{0}4. All{0}" +
                                                        "Enter your choice here: ", Environment.NewLine);
            Console.Write(pickConditionMessage);
            byte usersChoiceOfConditionToFilter = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
            if (4 == usersChoiceOfConditionToFilter)
            {
                s_LicenseNumbersByCondition = sr_Garage.GetVehiclesLicenseNumbersByConditions();
                Console.Clear();
                Console.WriteLine("{0}The list of all license numbers in the garage:", Environment.NewLine);
            }
            else
            {
                eVehicleConditionInTheGarage choiceToFilter = (eVehicleConditionInTheGarage)usersChoiceOfConditionToFilter;
                s_LicenseNumbersByCondition = sr_Garage.GetVehiclesLicenseNumbersByConditions(choiceToFilter);
                Console.Clear();
                Console.WriteLine("{0}The list of all license numbers in the garage under the condition {1}:", Environment.NewLine, choiceToFilter.ToString());
            }
            foreach (string licenseNumber in s_LicenseNumbersByCondition)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private static void changeVehiclesCondition()
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you would like to change condition to: ");
            string licenseNumber = ConsoleUtils.GetLicenseNumberFromUser();

            if (sr_Garage.IsExist(licenseNumber))
            {
                string pickConditionMessage = string.Format("{0}Pick what condition you would like to set to from the following:{0}" +
                                                            "1. UnderRepair{0}2. Repaired{0}3. RepairedAndPaid{0}" +
                                                            "Enter your choice here: ", Environment.NewLine);
                Console.Write(pickConditionMessage);
                byte usersChoiceOfConditionToFilter = ConsoleUtils.GetUsersChoiceAsByte(1, 3);
                eVehicleConditionInTheGarage newCondition = (eVehicleConditionInTheGarage)usersChoiceOfConditionToFilter;
                sr_Garage.ChangeVehicleCondition(licenseNumber, newCondition);
                Console.Clear();
                Console.WriteLine("Your vehicle is successfuly set as {1}.", Environment.NewLine, newCondition.ToString());
            }
            else
            {
                Console.WriteLine("{0}There is no vehicle with this license number in our garage.", Environment.NewLine);
            }
        }

        private static void inflateVehiclesTiresToMaximum()
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you would like to inflate it's tires completely: ");
            string licenseNumber = ConsoleUtils.GetLicenseNumberFromUser();

            if (sr_Garage.IsExist(licenseNumber))
            {
                sr_Garage.InflateVehiclesTiresCompletely(licenseNumber);
                Console.WriteLine("{0}Your vehicle's tires are completely full.", Environment.NewLine);
            }
            else
            {
                Console.WriteLine("{0}There is no vehicle with this license number in our garage.", Environment.NewLine);
            }
        }

        private static void fillGasForVehicle()
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you would like to fill gas in: ");
            string licenseNumber = ConsoleUtils.GetLicenseNumberFromUser();

            if (sr_Garage.IsExist(licenseNumber))
            {
                Console.WriteLine("{0}Enter the amount of liters you would like to fill, notice you can not fill more than the tank's capacity: ", Environment.NewLine);
                s_AmountOfEnergySourceToAdd = ConsoleUtils.GetUnsignedFloatFromUser();
                string pickFuelTypeMessage = string.Format("{0}What type of fuel would you like to fill?{0}" +
                                                           "1. Octan98{0}2. Octan96{0}3. Octan95{0}4. Soler{0}" +
                                                           "Enter your choice here: ", Environment.NewLine);
                Console.Write(pickFuelTypeMessage);
                byte usersChoiceOfFuelType = ConsoleUtils.GetUsersChoiceAsByte(1, 4);
                s_FuelTypeToFill = (eFuelType)usersChoiceOfFuelType;

                try
                {
                    bool isSucceededToFillGas = sr_Garage.TryFillEnergySource(licenseNumber, s_AmountOfEnergySourceToAdd, s_FuelTypeToFill);
                    if (isSucceededToFillGas)
                    {
                        Console.WriteLine("{0}You successfuly filled {1} liters of {2}.",
                                          Environment.NewLine, s_AmountOfEnergySourceToAdd, s_FuelTypeToFill);
                    }
                    else
                    {
                        Console.WriteLine("{0}You can not fill gas to an electric vehicle.", Environment.NewLine);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (ValueOutOfRangeException eaele)
                {
                    Console.WriteLine(eaele.Message);
                }
                catch (Exception e)
                {
                    string exceptionMessage = string.Format("{0}Failed to fill gas." +
                                                        "{0}Exception: {1}{0}Exception message: {2}",
                                                        Environment.NewLine, e.GetType(), e.Message);
                    Console.WriteLine(exceptionMessage);
                }
            }
            else
            {
                Console.WriteLine("{0}There is no vehicle with this license number in our garage.", Environment.NewLine);
            }
        }

        private static void chargeBatteryForVehicle()
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you would like to charge: ");
            string licenseNumber = ConsoleUtils.GetLicenseNumberFromUser();

            if (sr_Garage.IsExist(licenseNumber))
            {
                Console.WriteLine("{0}Enter the amount of minutes you would like to charge, notice you can not charge more than the battery's capacity: ", Environment.NewLine);
                s_AmountOfEnergySourceToAdd = ConsoleUtils.GetUnsignedFloatFromUser();

                try
                {
                    bool isSucceededToFillGas = sr_Garage.TryFillEnergySource(licenseNumber, s_AmountOfEnergySourceToAdd);
                    if (isSucceededToFillGas)
                    {
                        Console.WriteLine("{0}You successfuly charged your vehicle for another {1} minutes.",
                                          Environment.NewLine, s_AmountOfEnergySourceToAdd);
                    }
                    else
                    {
                        Console.WriteLine("{0}You can not charge a fuel-based vehicle.", Environment.NewLine);
                    }
                }
                catch (ValueOutOfRangeException eaele)
                {
                    Console.WriteLine(eaele.Message);
                }
                catch (Exception e)
                {
                    string exceptionMessage = string.Format("{0}Failed to fill gas." +
                                                        "{0}Exception: {1}{0}Exception message: {2}",
                                                        Environment.NewLine, e.GetType(), e.Message);
                    Console.WriteLine(exceptionMessage);
                }
            }
            else
            {
                Console.WriteLine("{0}There is no vehicle with this license number in our garage.", Environment.NewLine);
            }
        }

        private static void showVehicleFullInformation()
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you would like to see the full information of: ");
            string licenseNumber = ConsoleUtils.GetLicenseNumberFromUser();

            if (sr_Garage.IsExist(licenseNumber))
            {
                try
                {
                    string fullInfo = sr_Garage.GetVehicleFullInformation(licenseNumber);
                    Console.WriteLine("{0}{1}", Environment.NewLine, fullInfo);
                }
                catch (VehicleNotFoundException vnfe)
                {
                    Console.WriteLine(vnfe.Message);
                }
            }
            else
            {
                Console.WriteLine("{0}There is no vehicle with this license number in our garage.", Environment.NewLine);
            }
        }
    }
}
