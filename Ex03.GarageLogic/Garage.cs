using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Owner> r_VehicleOwnersDict = new Dictionary<string, Owner>();
        private readonly Dictionary<string, eVehicleStatus> r_VehicleStatusesDict = new Dictionary<string, eVehicleStatus>();
        private readonly List<Vehicle> r_VehiclesInGarage = new List<Vehicle>();

        internal void AddVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            r_VehicleOwnersDict.Add(i_Vehicle.m_LicenseNumber, new Owner(i_OwnerName, i_OwnerPhone));
            r_VehicleStatusesDict.Add(i_Vehicle.m_LicenseNumber, eVehicleStatus.InRepair);
            r_VehiclesInGarage.Add(i_Vehicle);
        }

        public void ChangeStatus(string i_LicenseNumber, eVehicleStatus i_Status = eVehicleStatus.InRepair)
        {
            if (isVehicleInGarage(i_LicenseNumber))
            {
                r_VehicleStatusesDict[i_LicenseNumber] = i_Status;
            }
            else
            {
                throw new ArgumentException("The requested vehicle is not in the garage.");
            }
        }

        public LinkedList<string> GetLicenseNumbers(LinkedList<eVehicleStatus> i_FilterStatuses)
        {
            LinkedList<string> filteredVehicles;

            if (i_FilterStatuses.Count == 0)
            {
                filteredVehicles = new LinkedList<string>(r_VehicleStatusesDict.Keys);
            }
            else
            {
                filteredVehicles = new LinkedList<string>(r_VehicleStatusesDict.Keys.Where(vehicle => i_FilterStatuses.Contains(r_VehicleStatusesDict[vehicle])));
            }

            return filteredVehicles;
        }

        public void InflateTiresToFull(string i_LicenseNumber)
        {
            LinkedList<Tire> vehicleTires = findVehicleInGarage(i_LicenseNumber).m_Tires;

            foreach (Tire tire in vehicleTires)
            {
                tire.Inflating(tire.m_maxAirPressure - tire.m_currentAirPressure);
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelToAdd)
        {
            Vehicle vehicle = findVehicleInGarage(i_LicenseNumber);

            if (vehicle.m_VehicleEngine is FueledEngine)
            {
                (vehicle.m_VehicleEngine as FueledEngine).FillEnergyInEngine(i_FuelToAdd, i_FuelType);
                vehicle.m_LeftEnergy = (vehicle.m_VehicleEngine.m_currentEnergy / vehicle.m_VehicleEngine.m_maxEnergy) * 100;
            }
            else
            {
                throw new ArgumentException("The vehicle is not with fueled engine.");
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_HoursToAdd)
        {
            Vehicle vehicle = findVehicleInGarage(i_LicenseNumber);

            if (vehicle.m_VehicleEngine is ElectricEngine)
            {
                vehicle.m_VehicleEngine.FillEnergyInEngine(i_HoursToAdd);
                vehicle.m_LeftEnergy = (vehicle.m_VehicleEngine.m_currentEnergy / vehicle.m_VehicleEngine.m_maxEnergy) * 100;
            }
            else
            {
                throw new ArgumentException("The vehicle is not with electric engine.");
            }
        }

        public string VehicleInfo(string i_LicenseNumber)
        {
            string info;
            Vehicle vehicle = findVehicleInGarage(i_LicenseNumber);

            info = string.Format(
@"{0}
The vehicle's owner name is: {1}, and his/her phone number is: {2}.
The vehicle's status in the garage is: {3}.",
                vehicle.ShowVehicleDetails(),
                r_VehicleOwnersDict[i_LicenseNumber].m_OwnerName,
                r_VehicleOwnersDict[i_LicenseNumber].m_OwnerPhone,
                r_VehicleStatusesDict[i_LicenseNumber]);

            return info;
        }

        private Vehicle findVehicleInGarage(string i_LicenseNumber)
        {
            Vehicle vehicleFound = r_VehiclesInGarage.Find(vehicle => vehicle.m_LicenseNumber == i_LicenseNumber);

            if (vehicleFound == null)
            {
                throw new ArgumentException("The requested vehicle is not in the garage.");
            }

            return vehicleFound;
        }

        private bool isVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.Exists(vehicle => vehicle.m_LicenseNumber == i_LicenseNumber);
        }
    }
}
