using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Interfaces;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly List<IConcreteVehicle> r_Vehicles;

        public Garage()
        {
            this.r_Vehicles = new List<IConcreteVehicle>();
        }

        public bool IsExist(string i_LicenseNumber)
        {
            bool isVehicleExistInTheGarage = false;
            foreach (IConcreteVehicle vehicle in r_Vehicles)
            {
                if (vehicle.GetHashCode() == i_LicenseNumber.GetHashCode())
                {
                    isVehicleExistInTheGarage = true;
                    break;
                }
            }

            return isVehicleExistInTheGarage;
        }

        public void AddVehicle(IConcreteVehicle i_Vehicle)
        {
            this.r_Vehicles.Add(i_Vehicle);
        }

        private IConcreteVehicle getVehicleByLicenseNumber(string i_LicenseNumber)
        {
            IConcreteVehicle vehicleToReturn = null;
            foreach (IConcreteVehicle vehicle in r_Vehicles)
            {
                if (vehicle.GetHashCode() == i_LicenseNumber.GetHashCode())
                {
                    vehicleToReturn = vehicle;
                    break;
                }
            }

            return vehicleToReturn;
        }

        public List<string> GetVehiclesLicenseNumbersByConditions(eVehicleConditionInTheGarage? i_VehicleCondition = null)
        {
            List<string> licenseNumbers = new List<string>();

            if (null == i_VehicleCondition)
            {
                foreach (IConcreteVehicle vehicle in r_Vehicles)
                {
                    licenseNumbers.Add(vehicle.VehicleInfo.LicenseNumber);
                }
            }
            else
            {
                foreach (IConcreteVehicle vehicle in r_Vehicles)
                {
                    if (vehicle.VehicleInfo.VehicleCondition == i_VehicleCondition.Value)
                    {
                        licenseNumbers.Add(vehicle.VehicleInfo.LicenseNumber);
                    }
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleCondition(string i_LicenseNumber, eVehicleConditionInTheGarage i_VehicleCondition)
        {
            IConcreteVehicle vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            vehicle.VehicleInfo.VehicleCondition = i_VehicleCondition;
        }

        public void InflateVehiclesTiresCompletely(string i_LicenseNumber)
        {
            IConcreteVehicle vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            vehicle.VehicleInfo.InflateAllTiresCompletely();
        }

        /// <summary>
        /// This method tries to fill a vehicle's energy source, whether it's electric or fuel-based vehicle.
        /// Might throw exceptions.
        /// </summary>
        /// <returns>True if secceeded to fill the energy source. Otherwise false.</returns>
        /// <exception cref="ValueOutOfRangeException" cref="ArgumentException"
        ///            cref="VehicleNotFoundException"></exception>
        public bool TryFillEnergySource(string i_LicenseNumber, float i_AmountToCharge, eFuelType? i_FuelType = null)
        {
            bool isSucceeded = false;
            IConcreteVehicle vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicle == null)
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            Vehicle vehicleInfo = vehicle.VehicleInfo;
            if (i_FuelType == null && vehicleInfo is ElectricVehicle)
            {
                (vehicleInfo as ElectricVehicle).ChargeBattery(i_AmountToCharge);
                isSucceeded = true;
            }
            else if (i_FuelType != null && vehicleInfo is FuelBasedVehicle)
            {
                (vehicleInfo as FuelBasedVehicle).FillGas(i_AmountToCharge, i_FuelType.Value);
                isSucceeded = true;
            }

            return isSucceeded;
        }

        /// <summary>
        /// This method returns a string representing a vehicle's full information.
        /// Might throw an exception.
        /// </summary>
        /// <returns>A string containing the vehicle's full info.</returns>
        /// <exception cref="VehicleNotFoundException"></exception>
        public string GetVehicleFullInformation(string i_LicenseNumber)
        {
            IConcreteVehicle vehicle = getVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicle == null)
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            return vehicle.GetFullInformation();
        }
    }
}
