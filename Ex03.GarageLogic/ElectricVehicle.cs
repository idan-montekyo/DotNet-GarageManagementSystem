using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private readonly float m_MaxBatteryLifeTime;

        public ElectricVehicle(VehicleOwner i_VehicleOwner, string i_VehicleModel, string i_LicenseNumber, Wheel[] i_Wheels,
                               float i_BatteryTimeLeft, float i_MaxBatteryLifeTime) :
                               base(i_VehicleOwner, i_VehicleModel, i_LicenseNumber, i_BatteryTimeLeft / i_MaxBatteryLifeTime, i_Wheels)
        {
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
                // TODO: throw exception.
            }
        }
    }
}
