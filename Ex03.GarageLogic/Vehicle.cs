using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_ThePercentageOfEnergyLeft;
        private List<Wheel> m_Wheels;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_ThePercentageOfEnergyLeft = i_ThePercentageOfEnergyLeft;
            m_Wheels = i_Wheels;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format(
@"
License numbers: {0}
Model Name : {1}
The Percentage Of Energy Left : {2}
wheels:
", 
m_LicenseNumber, 
m_ModelName,
m_ThePercentageOfEnergyLeft));

            for (int i = 0; i < m_Wheels.Count; i++)
            {
                stringBuilder.Append(string.Format("{0} - manufacturer name: {1}, current air pressure: {2}{3}",
                    i + 1, m_Wheels[i].ManufacturerName, m_Wheels[i].CurrentAirPressure,Environment.NewLine));
            }
            
            return stringBuilder.ToString();
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        public float ThePercentageOfEnergyLeft
        {
            get
            {
                return m_ThePercentageOfEnergyLeft;
            }
            set
            {
                m_ThePercentageOfEnergyLeft = value;
            }
        }

        public void AddWheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            Wheel newWheel = new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            m_Wheels.Add(newWheel);
        }
    }
}
