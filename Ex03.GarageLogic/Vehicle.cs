using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private VehicleOwner m_VehicleOwner;
        private eVehicleConditionInTheGarage m_VehicleConditionInTheGarage;
        private readonly string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnegryPercentage;
        private Wheel[] m_Wheels;

        public Vehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber, 
                       float i_EnergyPercentage, int i_NumberOfWheelsToCreate, string i_WheelModel, 
                       float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer)
        {
            this.m_VehicleOwner.Name = i_OwnerName;
            this.m_VehicleOwner.PhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleConditionInTheGarage = eVehicleConditionInTheGarage.UnderRepair;
            this.m_VehicleModel = i_VehicleModel;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnegryPercentage = i_EnergyPercentage;
            this.m_Wheels = new Wheel[i_NumberOfWheelsToCreate];
            for (int i = 0; i < i_NumberOfWheelsToCreate; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelModel, i_CurrentTireAirPressure, i_MaxTireAirPressureSetByManufacturer);
            }
        }

        public VehicleOwner VehicleOwner
        {
            get
            {
                return this.m_VehicleOwner;
            }
        }

        public eVehicleConditionInTheGarage VehicleCondition
        {
            get
            {
                return this.m_VehicleConditionInTheGarage;
            }
            set
            {
                this.m_VehicleConditionInTheGarage = value;
            }
        }

        public string VehicleModel
        {
            get
            {
                return this.m_VehicleModel;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return this.m_EnegryPercentage;
            }
            set
            {
                this.m_EnegryPercentage = value;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return this.m_Wheels;
            }
        }
    }
}
