using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Truck:Vehicle
    {
        internal bool m_IsContainingDangerousMaterials { get; set; }
        internal float m_CargoTankVolume { get; set; }

        internal Truck()
        {
            base.InitTires(12, 28);
        }

        protected internal override string GetVehiclePropertiesNames()
        {
            StringBuilder vehiclePropertiesNames = new StringBuilder();

            vehiclePropertiesNames.Append(base.GetVehiclePropertiesNames());
            vehiclePropertiesNames.Append(", if it is containing dangerous materials (true/false) and the cargo tank volume");

            return vehiclePropertiesNames.ToString();
        }

        protected internal override int GetNumberOfProperties()
        {
            return base.GetNumberOfProperties() + 2;
        }

        protected internal override void SetVehicleProperties(string[] vehicleProperties)
        {
            bool isContainingCooledCargo;
            float cargoTankVolume;
            int numOfProperties = this.GetNumberOfProperties();

            if (vehicleProperties.Length-1 == numOfProperties)
            {
                base.SetVehicleProperties(vehicleProperties);
                if (!bool.TryParse(vehicleProperties[numOfProperties - 1], out isContainingCooledCargo))
                {
                    throw new FormatException("The containing of dangerous materials needs to be 'true' or 'false'.");
                }

                this.m_IsContainingDangerousMaterials = isContainingCooledCargo;
                if (!float.TryParse(vehicleProperties[numOfProperties], out cargoTankVolume))
                {
                    throw new FormatException("The truck's cargo tank volume needs to be a float value.");
                }

                this.m_CargoTankVolume = cargoTankVolume;
            }
            else
            {
                throw new ArgumentException(string.Format("Truck needs to set {0} properties.", numOfProperties));
            }
        }

        protected internal override string ShowVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder();
            string isContainingString = this.m_IsContainingDangerousMaterials ? "is" : "is not";

            vehicleDetails.Append($"This is a Truck.{Environment.NewLine}");
            vehicleDetails.Append(base.ShowVehicleDetails());
            vehicleDetails.Append(base.m_VehicleEngine.ShowEngineDetails());
            vehicleDetails.Append(string.Format("The truck {0} containing dangerous materials, and its cargo tank is: {1}", isContainingString, this.m_CargoTankVolume));

            return vehicleDetails.ToString();
        }
    }
}
