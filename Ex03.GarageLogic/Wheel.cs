using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_WheelModel;
        private float m_CurrentTireAirPressure;
        private readonly float r_MaxTireAirPressureSetByManufacturer;

        public Wheel(string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer)
        {
            if (i_CurrentTireAirPressure > i_MaxTireAirPressureSetByManufacturer)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_AIR_MESSAGE_TAG);
            }
            this.r_WheelModel = i_WheelModel;
            this.m_CurrentTireAirPressure = i_CurrentTireAirPressure;
            this.r_MaxTireAirPressureSetByManufacturer = i_MaxTireAirPressureSetByManufacturer;
        }

        public string WheelModel
        {
            get
            {
                return this.r_WheelModel;
            }
        }

        public float CurrentTireAirPressure
        {
            get
            {
                return this.m_CurrentTireAirPressure;
            }
        }

        public float MaxTireAirPressureSetByManufacturer
        {
            get
            {
                return this.r_MaxTireAirPressureSetByManufacturer;
            }
        }

        public void InflateTire(float i_AirAmountToInflate)
        {
            if (m_CurrentTireAirPressure + i_AirAmountToInflate > r_MaxTireAirPressureSetByManufacturer)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_AIR_MESSAGE_TAG);
            }
            m_CurrentTireAirPressure += i_AirAmountToInflate;
        }
    }
}
