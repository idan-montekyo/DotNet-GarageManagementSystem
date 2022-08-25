using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private readonly float r_MaxBatteryLifeTime;

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
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_BATTERY_MESSAGE_TAG);
            }

            this.m_BatteryTimeLeft = i_BatteryTimeLeft;
            this.r_MaxBatteryLifeTime = i_MaxBatteryLifeTime;
        }

        public void ChargeBattery(float i_TimeToCharge)
        {
            if (m_BatteryTimeLeft + i_TimeToCharge <= r_MaxBatteryLifeTime)
            {
                m_BatteryTimeLeft += i_TimeToCharge;
                base.EnergyPercentage = m_BatteryTimeLeft / r_MaxBatteryLifeTime;
            }
            else
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_BATTERY_MESSAGE_TAG);
            }
        }

        public override string ToString()
        {
            return string.Format("{1}{0}" +
                                 "Vehicle's energy source: Electric{0}" +
                                 "Vehicle's current battery state: {2} minutes left{0}" +
                                 "Vehicle's max battery capacity: {3} minutes",
                                 Environment.NewLine, base.ToString(), m_BatteryTimeLeft, r_MaxBatteryLifeTime);
        }
    }
}
