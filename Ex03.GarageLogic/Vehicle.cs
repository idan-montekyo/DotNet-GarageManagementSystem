using System;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private VehicleOwner m_VehicleOwner;
        private eVehicleConditionInTheGarage m_VehicleConditionInTheGarage;
        private readonly string r_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnegryPercentage;
        private readonly Wheel[] r_Wheels;

        public Vehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber, 
                       float i_EnergyPercentage, int i_NumberOfWheelsToCreate, string i_WheelModel, 
                       float i_CurrentTireAirPressure, float i_MaxTireAirPressureSetByManufacturer)
        {
            this.m_VehicleOwner.Name = i_OwnerName;
            this.m_VehicleOwner.PhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleConditionInTheGarage = eVehicleConditionInTheGarage.UnderRepair;
            this.r_VehicleModel = i_VehicleModel;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnegryPercentage = i_EnergyPercentage;
            this.r_Wheels = new Wheel[i_NumberOfWheelsToCreate];
            for (int i = 0; i < i_NumberOfWheelsToCreate; i++)
            {
                r_Wheels[i] = new Wheel(i_WheelModel, i_CurrentTireAirPressure, i_MaxTireAirPressureSetByManufacturer);
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

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
        }

        public float EnergyPercentage
        {
            set
            {
                this.m_EnegryPercentage = value;
            }
        }

        public void InflateAllTiresCompletely()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateTire(wheel.MaxTireAirPressureSetByManufacturer - wheel.CurrentTireAirPressure);
            }
        }

        public override string ToString()
        {
            return string.Format("Vehicle's license number: {1}{0}" +
                                 "Owner's name: {2}{0}" +
                                 "Owner's phone number: {3}{0}" +
                                 "Vehicle's condition in the garage: {4}{0}" +
                                 "Vehicle's model: {5}{0}" +
                                 "Vehicle's energy percentage: {6}{0}" +
                                 "Vehicle's number of wheels: {7}{0}" +
                                 "Wheels' manufacturer: {8}{0}" +
                                 "Wheels' maximum tire air pressure: {9} for all tires{0}" +
                                 "Wheels' current tire air pressure: {10} for all tires",
                                 Environment.NewLine, m_LicenseNumber, m_VehicleOwner.Name, m_VehicleOwner.PhoneNumber,
                                 m_VehicleConditionInTheGarage, r_VehicleModel, m_EnegryPercentage, r_Wheels.Length,
                                 r_Wheels[0].WheelModel, r_Wheels[0].CurrentTireAirPressure, r_Wheels[0].MaxTireAirPressureSetByManufacturer);
        }
    }
}
