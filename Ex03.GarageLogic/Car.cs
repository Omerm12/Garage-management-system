using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Car:Vehicle
    {
        internal eCarColors m_Color { get; set; }
        internal eNumOfDoors m_NumOfDoors { get; set; }

        internal Car()
        {
            base.InitTires(5, 30);
        }
        protected internal override int GetNumberOfProperties()
        {
            return base.GetNumberOfProperties() + 2;
        }

        protected internal override string GetVehiclePropertiesNames()
        {
            StringBuilder vehiclePropertiesNames = new StringBuilder();

            vehiclePropertiesNames.Append(base.GetVehiclePropertiesNames());
            vehiclePropertiesNames.Append(string.Format(" ,color ({0}) and the number of doors ({1})", EnumsFunc.PrintEnumMembers(typeof(eCarColors)), EnumsFunc.PrintEnumMembers(typeof(eNumOfDoors))));

            return vehiclePropertiesNames.ToString();
        }

        protected internal override void SetVehicleProperties(string[] vehicleProperties)
        {
            object enumAsObject;
            int numOfProperties = this.GetNumberOfProperties();

            if (vehicleProperties.Length-1 == numOfProperties)
            {
                base.SetVehicleProperties(vehicleProperties);
                if (!EnumsFunc.ParseToEnumMember(typeof(eCarColors), vehicleProperties[numOfProperties -1], out enumAsObject))
                {
                    throw new FormatException(string.Format("The color options are: {0} (by number or by string)", EnumsFunc.PrintEnumMembers(typeof(eCarColors))));
                }

                this.m_Color = (eCarColors)enumAsObject;
                if (!EnumsFunc.ParseToEnumMember(typeof(eNumOfDoors), vehicleProperties[numOfProperties], out enumAsObject))
                {
                    throw new FormatException(string.Format("The number of doors can be: {0} (by number or by string)", EnumsFunc.PrintEnumMembers(typeof(eNumOfDoors))));
                }

                this.m_NumOfDoors = (eNumOfDoors)enumAsObject;
            }
            else
            {
                throw new ArgumentException(string.Format("Car needs to set {0} properties.", numOfProperties));
            }
        }
        protected internal override string ShowVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append($"This is a Car.{Environment.NewLine}");
            vehicleDetails.Append(base.ShowVehicleDetails());
            vehicleDetails.Append(base.m_VehicleEngine.ShowEngineDetails());
            vehicleDetails.Append(string.Format("The car is {0} and has {1} doors.", this.m_Color, this.m_NumOfDoors));

            return vehicleDetails.ToString();
        }

    }
}
