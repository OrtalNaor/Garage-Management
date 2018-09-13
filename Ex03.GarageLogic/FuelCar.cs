using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private FuelEngine m_FuelEngine;
        public static readonly float k_MaxFuelInLiter = 48;
        public static readonly eFuelType k_FuelType = eFuelType.octan96;

        internal FuelCar(FuelEngine i_FuelVehicle, eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels) : base(i_NumberOfDoors, i_CarColor, i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels)
        {
            m_FuelEngine = i_FuelVehicle;
        }

        public FuelEngine FuelVehicle
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
