using System;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Motorcycle : IVehicle
    {
        private Vehicle m_Vehicle;
        private eMotorcycleLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;

        public Motorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                          string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                          eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                          eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
            }
            int numberOfWheelsToCreate = 2;
            this.m_Vehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                  numberOfWheelsToCreate, i_WheelModel, i_CurrentTireAirPressure,
                                                  i_MaxTireAirPressureSetByManufacturer,
                                                  i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public Motorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                          string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                          float i_BatteryTimeLeft, float i_MaxBatteryLifeTime,
                          eMotorcycleLicenseType i_LicenseType, int i_EngineCapacity)
        {
            if (i_BatteryTimeLeft > i_MaxBatteryLifeTime)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_BATTERY_MESSAGE);
            }
            int numberOfWheelsToCreate = 2;
            this.m_Vehicle = new ElectricVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                 numberOfWheelsToCreate, i_WheelModel, i_CurrentTireAirPressure,
                                                 i_MaxTireAirPressureSetByManufacturer,
                                                 i_BatteryTimeLeft, i_MaxBatteryLifeTime);
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public eMotorcycleLicenseType LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_AmountToCharge">Amount of energy to fill.</param>
        /// <returns>True if secceeded to fill the energy source. Otherwise false.</returns>
        /// <exception cref="ElementAmountExceedingLimitsException" cref="WrongFuelTypeException"></exception>
        public bool TryFillEnergySource(float i_AmountToCharge)
        {
            bool isSucceeded = false;
            if (this.m_Vehicle is ElectricVehicle)
            {
                ((ElectricVehicle)this.m_Vehicle).ChargeBattery(i_AmountToCharge);
            }
            else if (this.m_Vehicle is FuelBasedVehicle)
            {
                FuelBasedVehicle thisVehicle = this.m_Vehicle as FuelBasedVehicle;
                thisVehicle.FillGas(i_AmountToCharge, thisVehicle.FuelType);
            }
            isSucceeded = true;

            return isSucceeded;
        }
    }
}
