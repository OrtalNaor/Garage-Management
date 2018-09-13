using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private ElectricEngine m_ElectriclEngine;
        public static readonly float k_MaxBbatteryTimeInHours = 4.8f;

        internal ElectricCar(ElectricEngine i_ElectriclEngine, eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels) : base( i_NumberOfDoors,  i_CarColor,  i_ModelName,  i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels)
        {
            m_ElectriclEngine = i_ElectriclEngine;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(string.Format(
@"Battery Time In Hours Left: {0},",
m_ElectriclEngine.BatteryTimeInHoursLeft));

            return stringBuilder.ToString();
        }
    }
}
