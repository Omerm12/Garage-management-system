using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle:Vehicle
    {

        internal eLicenseType m_licenseType { get; set; }
        internal int m_engineVolume { get; set; }

        internal Motorcycle()
        {
            base.InitTires(2, 29);
        }

        protected internal override string GetVehiclePropertiesNames()
        {
            StringBuilder vehiclePropertiesNames = new StringBuilder();

            vehiclePropertiesNames.Append(base.GetVehiclePropertiesNames());
            vehiclePropertiesNames.Append(string.Format(" ,license type ({0}) and engine's volume", EnumsFunc.PrintEnumMembers(typeof(eLicenseType))));

            return vehiclePropertiesNames.ToString();
        }

        protected internal override int GetNumberOfProperties()
        {
            return base.GetNumberOfProperties() + 2;
        }

        protected internal override void SetVehicleProperties(string[] vehicleProperties)
        {
            int engineVolume;
            object enumAsObject;
            int numOfProperties = this.GetNumberOfProperties();

            if (vehicleProperties.Length-1 == numOfProperties)
            {
                base.SetVehicleProperties(vehicleProperties);
                if (!EnumsFunc.ParseToEnumMember(typeof(eLicenseType), vehicleProperties[numOfProperties - 1], out enumAsObject))
                {
                    throw new FormatException(string.Format("The license's type options are: {0} (by number or by string)", EnumsFunc.PrintEnumMembers(typeof(eLicenseType))));
                }

                this.m_licenseType = (eLicenseType)enumAsObject;
                if (!int.TryParse(vehicleProperties[numOfProperties], out engineVolume))
                {
                    throw new FormatException("The motorcycle's engine volume needs to be an integer value.");
                }

                this.m_engineVolume = engineVolume;
            }
            else
            {
                throw new ArgumentException(string.Format("Motorcycle needs to set {0} properties.", numOfProperties));
            }
        }

        protected internal override string ShowVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append($"This is a Motorcycle.{Environment.NewLine}");
            vehicleDetails.Append(base.ShowVehicleDetails());
            vehicleDetails.Append(base.m_VehicleEngine.ShowEngineDetails());
            vehicleDetails.Append(string.Format("The motorcycle's license type is: {0}, and its engine's volume is: {1}.", this.m_licenseType, this.m_engineVolume));

            return vehicleDetails.ToString();
        }
    }
}
