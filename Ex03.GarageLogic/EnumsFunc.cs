using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class EnumsFunc
    {
        public static string PrintEnumMembers(Type i_EnumClass)
        {
            StringBuilder enumMembers = new StringBuilder();

            foreach (object enumMember in Enum.GetValues(i_EnumClass))
            {
                enumMembers.Append(string.Format("{0}: {1}, ", (int)enumMember, enumMember));
            }

            enumMembers.Remove(enumMembers.Length - 2, 2);

            return enumMembers.ToString();
        }

        public static bool ParseToEnumMember(Type i_EnumClass, string i_StringToParse, out object o_ParsedEnum)
        {
            bool isValid;
            o_ParsedEnum = null;

            try
            {
                o_ParsedEnum = Enum.Parse(i_EnumClass, i_StringToParse);
                isValid = Enum.IsDefined(i_EnumClass, o_ParsedEnum);
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
