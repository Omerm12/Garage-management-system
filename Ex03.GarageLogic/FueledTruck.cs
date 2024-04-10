using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     internal class FueledTruck:Truck
    {
        internal FueledTruck()
            : base()
        {
            base.m_VehicleEngine = new FueledEngine();
            base.m_VehicleEngine.m_maxEnergy = 110;
            (base.m_VehicleEngine as FueledEngine).m_fuelType = eFuelType.Soler;
        }
    }
}
