using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool m_IsTheTrunkCooled;
        private float m_TrunkVolume;
        public static readonly float k_WeelMaxAirPressure = 32f;
        
        internal Truck(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft, bool i_IsTheTrunkCooled, float i_TrunkVolume, List<Wheel> i_Wheels) : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels)
        {
            m_IsTheTrunkCooled = i_IsTheTrunkCooled;
            m_TrunkVolume = i_TrunkVolume;
        }

        public float WeelMaxAirPressure
        {
            get
            {
                return k_WeelMaxAirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(string.Format(
@"Is The Trunk Cooled: {0}
Trunk Volume: {1}",
m_IsTheTrunkCooled,
m_TrunkVolume));

            return stringBuilder.ToString();
        }
    }

}