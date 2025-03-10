﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("An error occurred. Please give a number in the range [{0}, {1}].", i_MinValue, i_MaxValue))
        {
            this.MinValue = i_MinValue;
            this.MaxValue = i_MaxValue;
        }
    }
}
