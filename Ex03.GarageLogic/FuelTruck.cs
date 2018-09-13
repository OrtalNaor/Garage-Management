using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        private FuelEngine m_FuelEngine;
        public static readonly float k_MaxFuelInLiter = 105;
        public static readonly eFuelType k_FuelType = eFuelType.soler;

        internal FuelTruck(FuelEngine i_FuelEngine, string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft, bool i_IsTheTrunkCooled, float i_TrunkVolume, List<Wheel> i_Wheels) : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, i_IsTheTrunkCooled, i_TrunkVolume, i_Wheels)
        {
            m_FuelEngine = i_FuelEngine;
        }

        public FuelEngine FuelEngine
        {
            get
            {
                return m_FuelEngine;
            }
            set
            {
                m_FuelEngine = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(string.Format(
@"Fuel Type: {0},
Curret Amount Of Fuel Liter",
m_FuelEngine.FuelType,
m_FuelEngine.CurrenAmountOfFuelLiter));

            return stringBuilder.ToString();
        }
    }
}