using System;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Truck : IVehicle
    {
        private FuelBasedVehicle m_FuelBasedVehicle;
        private bool m_HasFreezer;
        private float m_MaxCargoWeight;

        public Truck(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                     string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                     eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                     bool i_HasFreezer, float i_MaxCargoWeight)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
            }
            int numberOfWheelsToCreate = 16;
            this.m_FuelBasedVehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                           numberOfWheelsToCreate, i_WheelModel, i_CurrentTireAirPressure,
                                                           i_MaxTireAirPressureSetByManufacturer,
                                                           i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.m_HasFreezer = i_HasFreezer;
            this.m_MaxCargoWeight = i_MaxCargoWeight;
        }

        public bool HasFreezer
        {
            get
            {
                return this.m_HasFreezer;
            }
        }

        public float MaxCargoWeight
        {
            get
            {
                return this.m_MaxCargoWeight;
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
            this.m_FuelBasedVehicle.FillGas(i_AmountToCharge, m_FuelBasedVehicle.FuelType);
            isSucceeded = true;

            return isSucceeded;
        }
    }
}
