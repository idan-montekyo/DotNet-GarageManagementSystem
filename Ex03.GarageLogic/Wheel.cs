using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_WheelModel;
        private float m_CurrentTireAirPressure;
        private readonly float m_MaxTireAirPressureSetByManufacturer;

        public Wheel(string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer)
        {
            if (i_CurrentTireAirPressure > i_MaxTireAirPressureSetByManufacturer)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_AIR_MESSAGE);
            }
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
            if (m_CurrentTireAirPressure + i_AirAmountToInflate > m_MaxTireAirPressureSetByManufacturer)
            {
                throw new ElementAmountExceedingLimitsException(ElementAmountExceedingLimitsException.sr_AIR_MESSAGE);
            }
            m_CurrentTireAirPressure += i_AirAmountToInflate;
        }
    }
}
