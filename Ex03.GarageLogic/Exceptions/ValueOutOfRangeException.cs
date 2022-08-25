using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_ErrorMessage;
        public static readonly string sr_FUEL_MESSAGE_TAG = "the fuel tank";
        public static readonly string sr_BATTERY_MESSAGE_TAG = "the battery";
        public static readonly string sr_AIR_MESSAGE_TAG = "the wheels with air";

        public ValueOutOfRangeException(string i_ElementExceedingItsLimit)
        {
            this.m_ErrorMessage = string.Format("There was an attempt to fill {0} more than it's capacity", i_ElementExceedingItsLimit);
        }

        public override string Message => this.m_ErrorMessage;
    }
}
