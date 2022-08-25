using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        private string m_ErrorMessage;

        public VehicleNotFoundException(string i_LicenseNumber)
        {
            this.m_ErrorMessage = string.Format("There is no vehicle with the specific license number {0} in the garage.", i_LicenseNumber);
        }

        public override string Message => this.m_ErrorMessage;
    }
}
