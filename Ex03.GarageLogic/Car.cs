using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Car : IVehicle
    {
        private Vehicle m_Vehicle;
        private readonly eCarColor m_Color;
        private readonly eNumberOfCarDoors m_NumberOfDoors;

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                   string i_WheelModel, float i_CurrentTireAirPressure,float i_MaxTireAirPressureSetByManufacturer,
                   eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                   eCarColor i_CarColor, eNumberOfCarDoors i_NumberOfDoors)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
            }
            int numberOfWheelsToCreate = 4;
            this.m_Vehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                  numberOfWheelsToCreate, i_WheelModel, i_CurrentTireAirPressure,
                                                  i_MaxTireAirPressureSetByManufacturer,
                                                  i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.m_Color = i_CarColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                   string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                   float i_BatteryTimeLeft, float i_MaxBatteryLifeTime,
                   eCarColor i_CarColor, eNumberOfCarDoors i_NumberOfDoors)
        {
            if (i_BatteryTimeLeft > i_MaxBatteryLifeTime)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
            }
            int numberOfWheelsToCreate = 4;
            this.m_Vehicle = new ElectricVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                 numberOfWheelsToCreate, i_WheelModel, i_CurrentTireAirPressure,
                                                 i_MaxTireAirPressureSetByManufacturer,
                                                 i_BatteryTimeLeft, i_MaxBatteryLifeTime);
            this.m_Color = i_CarColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public eCarColor Color
        {
            get
            {
                return this.m_Color;
            }
        }

        public eNumberOfCarDoors NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
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
