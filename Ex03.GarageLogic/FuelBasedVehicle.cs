using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelBasedVehicle : Vehicle
    {
        private readonly eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private readonly float m_MaxFuelAmount;

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
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
            }
            this.m_FuelType = i_FuelType;
            this.m_CurrentFuelAmount = i_CurrentFuelAmount;
            this.m_MaxFuelAmount = i_MaxFuelAmount;
        }

        public eFuelType FuelType
        {
            get
            { 
                return this.m_FuelType; 
            }
        }

        public float CurrentFuelAmount
        {
            get
            { 
                return this.m_CurrentFuelAmount; 
            }
            set
            {
                this.m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount
        {
            get
            { 
                return this.m_MaxFuelAmount; 
            }
        }

        public void FillGas(float i_FuelAmountToFill, eFuelType i_FuelType)
        {
            if (m_FuelType == i_FuelType)
            {
                if (m_CurrentFuelAmount + i_FuelAmountToFill <= m_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelAmountToFill;
                }
                else
                {
                    throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_FUEL_MESSAGE);
                }
            }
            else
            {
                throw new WrongFuelTypeException();
            }
        }
    }
}
