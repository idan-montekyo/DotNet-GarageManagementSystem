using System;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Truck : IConcreteVehicle
    {
        private FuelBasedVehicle m_FuelBasedVehicle;
        private bool m_HasFreezer;
        private float m_MaxCargoWeight;
        private static readonly byte sr_NumberOfWheels = 16;

        public Truck(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber,
                     string i_WheelModel, float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer,
                     eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount,
                     bool i_HasFreezer, float i_MaxCargoWeight)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(ValueOutOfRangeException.sr_FUEL_MESSAGE_TAG);
            }

            this.m_FuelBasedVehicle = new FuelBasedVehicle(i_OwnerName, i_OwnerPhoneNumber, i_VehicleModel, i_LicenseNumber,
                                                           sr_NumberOfWheels, i_WheelModel, i_CurrentTireAirPressure,
                                                           i_MaxTireAirPressureSetByManufacturer,
                                                           i_FuelType, i_CurrentFuelAmount, i_MaxFuelAmount);
            this.m_HasFreezer = i_HasFreezer;
            this.m_MaxCargoWeight = i_MaxCargoWeight;
        }

        Vehicle IConcreteVehicle.VehicleInfo
        {
            get
            {
                return this.m_FuelBasedVehicle;
            }
        }

        string IConcreteVehicle.GetFullInformation()
        {
            string information = string.Format("Vehicle's type: {1}{0}" +
                                               "{2}{0}" +
                                               "Can the vehicle transport refrigirerated contents?: {3}{0}" +
                                               "Vehicle's maximum cargo weight: {4}{0}",
                                               Environment.NewLine, this.GetType().Name, m_FuelBasedVehicle.ToString(),
                                               m_HasFreezer ? "Yes" : "No", m_MaxCargoWeight);

            return information;
        }

        public override int GetHashCode()
        {
            return this.m_FuelBasedVehicle.LicenseNumber.GetHashCode();
        }
    }
}
