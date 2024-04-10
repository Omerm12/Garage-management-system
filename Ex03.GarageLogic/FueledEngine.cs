using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FueledEngine:Engine
    {
        internal eFuelType m_fuelType { get; set; }

        internal void FillEnergyInEngine(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != this.m_fuelType)
            {
                throw new ArgumentException("The given fuel type is not the right one.");
            }

            base.FillEnergyInEngine(i_FuelToAdd);
        }

        protected internal override string ShowEngineDetails()
        {
            return string.Format(
@"This vehicle is with fueled engine.
It has {0} fuel type, {1} liters fuel remaining on its tank, out of {2}.{3}",
                this.m_fuelType.ToString(),
                base.m_currentEnergy,
                base.m_maxEnergy,
                Environment.NewLine);
        }
    }
}
