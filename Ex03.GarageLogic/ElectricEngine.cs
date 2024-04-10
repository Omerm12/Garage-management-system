using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine:Engine
    {
        protected internal override string ShowEngineDetails()
        {
            return string.Format(
@"This vehicle is with electric engine.
It has {0} hours remaining on its battery, out of {1}.{2}",
                base.m_currentEnergy,
                base.m_maxEnergy,
                Environment.NewLine);
        }
    }
}
