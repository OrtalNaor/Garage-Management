using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private ElectricEngine m_ElectricEngine;
        public static readonly float k_MaxBbatteryTimeInHours = 3.2f;

        internal ElectricMotorcycle(ElectricEngine i_ElectriclVehicle, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels) : base( i_LicenseType,  i_EngineCapacity,  i_ModelName,  i_LicenseNumber,  i_ThePercentageOfEnergyLeft, i_Wheels)
        {
            m_ElectricEngine = i_ElectriclVehicle;
        }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(base.ToString());
        stringBuilder.Append(string.Format(
@"Battery Time In Hours Left: {0},",
m_ElectricEngine.BatteryTimeInHoursLeft));

        return stringBuilder.ToString();
    }

    }
}
