using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedVehicle : Vehicle
    {
        private readonly eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private readonly float m_MaxFuelAmount;

        public FuelBasedVehicle(VehicleOwner i_VehicleOwner, string i_VehicleModel, string i_LicenseNumber, Wheel[] i_Wheels,
                                eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount) : 
                                base(i_VehicleOwner, i_VehicleModel, i_LicenseNumber, i_CurrentFuelAmount / i_MaxFuelAmount, i_Wheels)
        {
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
                    // TODO: throw exception.
                }
            }
            else
            {
                // TODO: throw exception of wrong fuel type.
            }
        }
    }
}
