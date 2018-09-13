using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        public static readonly float k_WeelMaxAirPressure = 28f;

        internal Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels) : base(i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public float WeelMaxAirPressure
        {
            get
            {
                return k_WeelMaxAirPressure;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(string.Format(
@"License Type: {0}
Engine Capacity : {1}",
m_LicenseType,
m_EngineCapacity));

            return stringBuilder.ToString();
        }

    }
}
