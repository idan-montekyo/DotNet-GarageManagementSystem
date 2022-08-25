using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Car : IConcreteVehicle
    {
        private Vehicle m_Vehicle;
        private readonly eCarColor r_Color;
        private readonly eNumberOfCarDoors r_NumberOfDoors;
        private static readonly byte sr_NumberOfWheels = 4;

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                   string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                   eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                   eCarColor i_CarColor, eNumberOfCarDoors i_NumberOfDoors)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
            }

            this.m_Vehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                  sr_NumberOfWheels, i_WheelModel, i_CurrentTireAirPressure,
                                                  i_MaxTireAirPressureSetByManufacturer,
                                                  i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.r_Color = i_CarColor;
            this.r_NumberOfDoors = i_NumberOfDoors;
        }

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                   string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                   float i_BatteryTimeLeft, float i_MaxBatteryLifeTime,
                   eCarColor i_CarColor, eNumberOfCarDoors i_NumberOfDoors)
        {
            if (i_BatteryTimeLeft > i_MaxBatteryLifeTime)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
            }

            this.m_Vehicle = new ElectricVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                 sr_NumberOfWheels, i_WheelModel, i_CurrentTireAirPressure,
                                                 i_MaxTireAirPressureSetByManufacturer,
                                                 i_BatteryTimeLeft, i_MaxBatteryLifeTime);
            this.r_Color = i_CarColor;
            this.r_NumberOfDoors = i_NumberOfDoors;
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
                                               "Vehicle's color: {3}{0}" +
                                               "Vehicle's number of doors: {4}{0}",
                                               Environment.NewLine, this.GetType().Name, m_Vehicle.ToString(), r_Color.ToString(),
                                               r_NumberOfDoors.ToString());
            
            return information;
        }

        public override int GetHashCode()
        {
            return this.m_Vehicle.LicenseNumber.GetHashCode();
        }
    }
}
