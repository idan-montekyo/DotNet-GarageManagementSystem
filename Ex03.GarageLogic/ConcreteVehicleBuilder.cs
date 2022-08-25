using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ConcreteVehicleBuilder
    {
        public static Car Build(string i_VehicleOwnersName, string i_VehicleOwnersPhoneNumber,
                                string i_VehiclesModel, string i_LicenseNumber, string i_WheelsModel,
                                float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                                float i_CurrentEnergyAmount, float i_MaxEnergyAmount, eCarColor i_CarColor,
                                eNumberOfCarDoors i_NumberOfDoors, eFuelType? i_FuelType = null)
        {
            Car newCar;
            if (null == i_FuelType)
            {
                newCar = new Car(i_VehicleOwnersName, i_VehicleOwnersPhoneNumber, i_VehiclesModel,
                                 i_LicenseNumber, i_WheelsModel, i_CurrentTireAirPressure,
                                 i_MaxTireAirPressureSetByManufacturer, i_CurrentEnergyAmount,
                                 i_MaxEnergyAmount, i_CarColor, i_NumberOfDoors);
            }
            else
            {
                newCar = new Car(i_VehicleOwnersName, i_VehicleOwnersPhoneNumber, i_VehiclesModel,
                                 i_LicenseNumber, i_WheelsModel, i_CurrentTireAirPressure,
                                 i_MaxTireAirPressureSetByManufacturer, i_FuelType.Value,
                                 i_CurrentEnergyAmount, i_MaxEnergyAmount, i_CarColor, i_NumberOfDoors);
            }

            return newCar;
        }
        public static Motorcycle Build(string i_VehicleOwnersName, string i_VehicleOwnersPhoneNumber,
                                       string i_VehiclesModel, string i_LicenseNumber, string i_WheelsModel,
                                       float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                                       float i_CurrentEnergyAmount, float i_MaxEnergyAmount, eMotorcycleLicenseType i_MotorcycleLicenseType,
                                       int i_MotorcycleEngineCapacity, eFuelType? i_FuelType = null)
        {
            Motorcycle newMotorcycle;
            if (null == i_FuelType)
            {
                newMotorcycle = new Motorcycle(i_VehicleOwnersName, i_VehicleOwnersPhoneNumber, i_VehiclesModel,
                                               i_LicenseNumber, i_WheelsModel, i_CurrentTireAirPressure,
                                               i_MaxTireAirPressureSetByManufacturer, i_CurrentEnergyAmount,
                                               i_MaxEnergyAmount, i_MotorcycleLicenseType, i_MotorcycleEngineCapacity);
            }
            else
            {
                newMotorcycle = new Motorcycle(i_VehicleOwnersName, i_VehicleOwnersPhoneNumber, i_VehiclesModel,
                                               i_LicenseNumber, i_WheelsModel, i_CurrentTireAirPressure,
                                               i_MaxTireAirPressureSetByManufacturer, i_FuelType.Value,
                                               i_CurrentEnergyAmount, i_MaxEnergyAmount, i_MotorcycleLicenseType, i_MotorcycleEngineCapacity);
            }

            return newMotorcycle;
        }
        public static Truck Build(string i_VehicleOwnersName, string i_VehicleOwnersPhoneNumber,
                                  string i_VehiclesModel, string i_LicenseNumber, string i_WheelsModel,
                                  float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                                  float i_CurrentEnergyAmount, float i_MaxEnergyAmount, bool i_HasFreezer,
                                  float i_TruckMaxCargoWeight, eFuelType i_FuelType)
        {
            return new Truck(i_VehicleOwnersName, i_VehicleOwnersPhoneNumber, i_VehiclesModel,
                             i_LicenseNumber, i_WheelsModel, i_CurrentTireAirPressure,
                             i_MaxTireAirPressureSetByManufacturer, i_FuelType,
                             i_CurrentEnergyAmount, i_MaxEnergyAmount, i_HasFreezer, i_TruckMaxCargoWeight);
        }
    }
}
