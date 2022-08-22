using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ElementAmountExceedingLimitsException : Exception
    {
        private string m_ErrorMessage;
        public static readonly string sr_FUEL_MESSAGE = "the fuel tank";
        public static readonly string sr_BATTERY_MESSAGE = "the battery";
        public static readonly string sr_AIR_MESSAGE = "the wheels with air";

        public ElementAmountExceedingLimitsException(string i_ElementExceedingItsLimit)
        {
            this.m_ErrorMessage = string.Format("There was an attempt to fill {0} more than it's capacity", i_ElementExceedingItsLimit);
        }

        public override string Message => this.m_ErrorMessage;
    }
}
