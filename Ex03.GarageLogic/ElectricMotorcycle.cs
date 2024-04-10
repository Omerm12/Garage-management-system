using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle:Motorcycle
    {
        internal ElectricMotorcycle()
           : base()
        {
            base.m_VehicleEngine = new ElectricEngine();
            base.m_VehicleEngine.m_maxEnergy = 2.8F;
        }
    }
}
