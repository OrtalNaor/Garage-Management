using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        public static readonly float k_WeelMaxAirPressure = 30f;

        internal Car(eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels) : base(i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public float WeelMaxAirPressure
        {
            get
            {
                return k_WeelMaxAirPressure;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(string.Format(
@"Car Color: {0}
Number Of Doors : {1}",
m_CarColor,
m_NumberOfDoors));

            return stringBuilder.ToString();
        }
    }
}
