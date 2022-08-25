using System;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Motorcycle : IConcreteVehicle
    {
        private Vehicle m_Vehicle;
        private eMotorcycleLicenseType m_LicenseType;
        private readonly int r_EngineCapacity;
        private static readonly byte sr_NumberOfWheels = 2;

        public Motorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                          string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                          eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                          eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
            }

            this.m_Vehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                  sr_NumberOfWheels, i_WheelModel, i_CurrentTireAirPressure,
                                                  i_MaxTireAirPressureSetByManufacturer,
                                                  i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.m_LicenseType = i_LicenseType;
            this.r_EngineCapacity = i_EngineCapacity;
        }

        public Motorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                          string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                          float i_BatteryTimeLeft, float i_MaxBatteryLifeTime,
                          eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity)
        {
            if (i_BatteryTimeLeft > i_MaxBatteryLifeTime)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_BATTERY_MESSAGE_TAG);
            }

            this.m_Vehicle = new ElectricVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                 sr_NumberOfWheels, i_WheelModel, i_CurrentTireAirPressure,
                                                 i_MaxTireAirPressureSetByManufacturer,
                                                 i_BatteryTimeLeft, i_MaxBatteryLifeTime);
            this.m_LicenseType = i_LicenseType;
            this.r_EngineCapacity = i_EngineCapacity;
        }

        Vehicle IConcreteVehicle.VehicleInfo
        {
            get
            {
                return this.m_Vehicle;
            }
        }
        
        string IConcreteVehicle.GetFullInformation()
        {
            string information = string.Format("Vehicle's type: {1}{0}" +
                                               "{2}{0}" +
                                               "Vehicle's license type: {3}{0}" +
                                               "Vehicle's engine capacity: {4}{0}",
                                               Environment.NewLine, this.GetType().Name, m_Vehicle.ToString(), m_LicenseType.ToString(), r_EngineCapacity);
            
            return information;
        }

        public override int GetHashCode()
        {
            return this.m_Vehicle.LicenseNumber.GetHashCode();
        }
    }
}
