using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Interfaces;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly List<IVehicle> m_Vehicles;

        public Garage()
        {
            this.m_Vehicles = new List<IVehicle>();
        }

        public List<IVehicle> Vehicles
        {
            get
            {
                return this.m_Vehicles;
            }
        }

        // p.2
        public List<string> GetVehiclesLicenseNumbersByConditions(eVehicleConditionInTheGarage i_VehicleCondition)
        {
            List<string> licenseNumbers = new List<string>();

            // loop the IVehicles list, add license-number only if condition == i_condition

            return licenseNumbers;
        }
    }
}
