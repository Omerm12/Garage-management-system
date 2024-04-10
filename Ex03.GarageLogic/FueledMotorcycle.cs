using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FueledMotorcycle:Motorcycle
    {
        internal FueledMotorcycle()
            : base()
        {
            base.m_VehicleEngine = new FueledEngine();
            base.m_VehicleEngine.m_maxEnergy = 5.8F;
            (base.m_VehicleEngine as FueledEngine).m_fuelType = eFuelType.Octane98;
        }
    }
}
