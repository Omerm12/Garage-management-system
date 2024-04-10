using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Owner
    {
        internal string m_OwnerName;
        internal string m_OwnerPhone;

        internal Owner(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
        }

    }
}
