using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class FuelBasedVehicle : Vehicle
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount;
        private readonly float r_MaxFuelAmount;

        public FuelBasedVehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                                int i_NumberOfWheelsToCreate, string i_WheelModel, float i_CurrentTireAirPressure, 
                                float i_MaxTireAirPressureSetByManufacturer,
                                eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount) : 
                                base(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber, 
                                     i_CurrentFuelAmount / i_MaxFuelAmount, i_NumberOfWheelsToCreate, i_WheelModel,
                                     i_CurrentTireAirPressure,  i_MaxTireAirPressureSetByManufacturer)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
            }

            this.r_FuelType = i_FuelType;
            this.m_CurrentFuelAmount = i_CurrentFuelAmount;
            this.r_MaxFuelAmount = i_MaxFuelAmount;
        }

        public void FillGas(float i_FuelAmountToFill, eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                if (m_CurrentFuelAmount + i_FuelAmountToFill <= r_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelAmountToFill;
                    base.EnergyPercentage = m_CurrentFuelAmount / r_MaxFuelAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
                }
            }
            else
            {
                throw new ArgumentException("There was an attempt to fill the wrong fuel type.");
            }
        }

        public override string ToString()
        {
            return string.Format("{1}{0}" +
                                 "Vehicle's energy source: Fuel-based{0}" +
                                 "Vehicle's fuel type: {2}{0}" +
                                 "Vehicle's current fuel amount: {3} liters{0}" +
                                 "Vehicle's max fuel tank's capacity: {4} liters",
                                 Environment.NewLine, base.ToString(), r_FuelType.ToString(), m_CurrentFuelAmount, r_MaxFuelAmount);
        }
    }
}
