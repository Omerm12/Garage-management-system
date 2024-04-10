using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FueledCar:Car
    {
        internal FueledCar()
           : base()
        {
            base.m_VehicleEngine = new FueledEngine();
            base.m_VehicleEngine.m_maxEnergy = 58;
            (base.m_VehicleEngine as FueledEngine).m_fuelType = eFuelType.Octane95;
        }
    }
}
