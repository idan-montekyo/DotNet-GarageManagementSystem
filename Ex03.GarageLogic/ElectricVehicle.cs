using System;
using Ex03.GarageLogic.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private readonly float m_MaxBatteryLifeTime;

        public ElectricVehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                               int i_NumberOfWheelsToCreate, string i_WheelModel, float i_CurrentTireAirPressure,
                               float i_MaxTireAirPressureSetByManufacturer,
                               float i_BatteryTimeLeft, float i_MaxBatteryLifeTime) :
                               base(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber, 
                                    i_BatteryTimeLeft / i_MaxBatteryLifeTime, i_NumberOfWheelsToCreate, i_WheelModel, 
                                    i_CurrentTireAirPressure, i_MaxTireAirPressureSetByManufacturer)
        {
            if (i_BatteryTimeLeft > i_MaxBatteryLifeTime)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_BATTERY_MESSAGE);
            }
            this.m_BatteryTimeLeft = i_BatteryTimeLeft;
            this.m_MaxBatteryLifeTime = i_MaxBatteryLifeTime;
        }

        public float BatteryTimeLeft
        {
            get
            {
                return this.m_BatteryTimeLeft;
            }
            set
            {
                this.m_BatteryTimeLeft = value;
            }
        }

        public float MaxBatteryLifeTime
        {
            get
            {
                return this.m_MaxBatteryLifeTime;
            }
        }

        public void ChargeBattery(float i_TimeToCharge)
        {
            if (m_BatteryTimeLeft + i_TimeToCharge <= m_MaxBatteryLifeTime)
            {
                m_BatteryTimeLeft += i_TimeToCharge;
            }
            else
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_BATTERY_MESSAGE);
            }
        }
    }
}
