using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_WheelModel;
        private float m_CurrentTireAirPressure;
        private readonly float m_MaxTireAirPressureSetByManufacturer;

        public Wheel(string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer)
        {
            this.m_WheelModel = i_WheelModel;
            this.m_CurrentTireAirPressure = i_CurrentTireAirPressure;
            this.m_MaxTireAirPressureSetByManufacturer = i_MaxTireAirPressureSetByManufacturer;
        }

        public string WheelModel
        {
            get
            {
                return this.m_WheelModel;
            }
        }

        public float CurrentTireAirPressure
        {
            get
            {
                return this.m_CurrentTireAirPressure;
            }
            set
            {
                this.m_CurrentTireAirPressure = value;
            }
        }

        public float MaxTireAirPressureSetByManufacturer
        {
            get
            {
                return this.m_MaxTireAirPressureSetByManufacturer;
            }
        }

        public void InflateTire(float i_AirAmountToInflate)
        {
            if (m_CurrentTireAirPressure + i_AirAmountToInflate <= m_MaxTireAirPressureSetByManufacturer)
            {
                m_CurrentTireAirPressure += i_AirAmountToInflate;
            }
            else
            {
                // TODO: throw exception.
            }
        }
    }
}
