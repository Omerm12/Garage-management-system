using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Tire
    {
        internal string m_manufacturerName { get; set; }
        internal float m_currentAirPressure { get; set; }
        internal float m_maxAirPressure { get; }

        internal Tire(float i_MaxAirPressure)
        {
            this.m_maxAirPressure = i_MaxAirPressure;
        }

        internal void Inflating(float i_AddAir)
        {
            if(this.m_currentAirPressure + i_AddAir <= this.m_maxAirPressure && i_AddAir >= 0)
            {
                this.m_currentAirPressure += i_AddAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_maxAirPressure - this.m_currentAirPressure);
            }
        }
    }
}
