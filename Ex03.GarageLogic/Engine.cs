using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        internal float m_currentEnergy { get; set; } = 0;
        internal float m_maxEnergy { get; set; }

        protected internal abstract string ShowEngineDetails();

        internal virtual void FillEnergyInEngine(float i_EnergyToAdd)
        {
            if (this.m_currentEnergy + i_EnergyToAdd <= this.m_maxEnergy && i_EnergyToAdd >= 0)
            {
                this.m_currentEnergy += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_maxEnergy - this.m_currentEnergy);
            }
        }

    }

}

