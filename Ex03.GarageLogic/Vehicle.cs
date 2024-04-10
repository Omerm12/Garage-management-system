using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    // $G$ DSN-999 (-7) The Diagram should also contain the Tire class.
    // $G$ DSN-999 (-15) //Not good enough polymorphism You made engine class that the vehicle holds and the an electric and
    //   and fuel engine that inherits from it so why duplication of electric car\truck and engine car\truck etc 
    public abstract class Vehicle
    {
        internal string m_ModelName { get; set; }
        internal string m_LicenseNumber { get; set; }
        internal float m_LeftEnergy { get; set; }
        internal LinkedList<Tire> m_Tires { get; set; }
        internal Engine m_VehicleEngine { get; set; }
      
        protected internal void InitTires(int i_NumOfTires, float i_MaxAirPressure)
        {
            this.m_Tires = new LinkedList<Tire>();
            for (int i = 0; i < i_NumOfTires; i++)
            {
                m_Tires.AddLast(new Tire(i_MaxAirPressure));
            }
        }

        protected internal virtual string GetVehiclePropertiesNames()
        {
            return string.Format(string.Format("model name,single tire's manufacturer for all {0} tires", this.GetNumOfTires()));
        }

        protected internal virtual int GetNumberOfProperties()
        {
            return 2;
        }

        public int GetNumOfTires()
        {
            return this.m_Tires.Count;
        }

        protected internal virtual void SetVehicleProperties(string[] vehicleProperties)
        {
            this.m_LicenseNumber = vehicleProperties[0];
            this.m_ModelName = vehicleProperties[1];
            foreach (Tire tire in this.m_Tires)
            {
                tire.m_manufacturerName = vehicleProperties[2];
            }
        }

        protected internal virtual string ShowVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(
                string.Format(
@"License number: {0}.
Model name: {1}.
It has {2} tires with maximal air pressure {3}.
It's remaining Energy Percentage is {4}%.{5}",
                    this.m_LicenseNumber,
                    this.m_ModelName,
                    GetNumOfTires(),
                    this.m_Tires.First.Value.m_maxAirPressure,
                    this.m_LeftEnergy,
                    Environment.NewLine));
            vehicleDetails.Append(ShowTiresDetails());

            return vehicleDetails.ToString();
        }

        protected internal string ShowTiresDetails()
        {
            StringBuilder tiresDetails = new StringBuilder();
            int tireIndex = 1;

            foreach (Tire tire in this.m_Tires)
            {
                tiresDetails.Append(
                    string.Format(
                        "Tire Number {0} is manufactured by {1} and its current air pressure is: {2}.{3}",
                        tireIndex,
                        tire.m_manufacturerName,
                        tire.m_currentAirPressure,
                        Environment.NewLine));
                tireIndex++;
            }

            return tiresDetails.ToString();
        }

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public override bool Equals(Object i_OtherVehicle)
        {
            bool equals = false;

            Vehicle vehicleToCompare = i_OtherVehicle as Vehicle;
            if (vehicleToCompare != null)
            {
                equals = this.m_LicenseNumber == vehicleToCompare.m_LicenseNumber;
            }

            return equals;
        }

        public static bool operator ==(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return Equals(i_Vehicle1, i_Vehicle2);
        }

        public static bool operator !=(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return !Equals(i_Vehicle1, i_Vehicle2);
        }

    }
}
// $G$ CSS-027 (-3) Unnecessary blank lines.


