using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private VehicleOwner m_VehicleOwner;
        private readonly string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnegryPercentage;
        private Wheel[] m_Wheels;

        public Vehicle(VehicleOwner i_VehicleOwner, string i_VehicleModel, string i_LicenseNumber, 
                       float i_EnergyPercentage, Wheel[] i_Wheels)
        {
            this.m_VehicleOwner = i_VehicleOwner;
            this.m_VehicleModel = i_VehicleModel;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnegryPercentage = i_EnergyPercentage;
            m_Wheels = i_Wheels;
        }

        public VehicleOwner VehicleOwner
        {
            get
            {
                return this.m_VehicleOwner;
            }
            set
            {
                this.m_VehicleOwner = value;
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

        // TODO: new classes - ElectricVehicle : Vehicle, NonElectricVehicle : Vehicle
        //      - add all the features to each.
        //          - Motorcycle / ElectricMotorcycle / Car / ElectricCar / Truck - extends them.

        // TODO: (?) where do we save the info? owner's name & phone number, vehicle's condition
    }
}
