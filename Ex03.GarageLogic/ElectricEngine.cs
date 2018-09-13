using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_BatteryTimeInHoursLeft;
        private float m_MaxBatteryTimeInHours;

        public ElectricEngine(float i_BatteryTimeInHours, float i_MaxBatteryTimeInHours)
        {
            m_BatteryTimeInHoursLeft = i_BatteryTimeInHours;
            m_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
    }

        public void ChargingABattery(float i_NumberOfHoursToAdd)
        {
            float newBatteryTime = m_BatteryTimeInHoursLeft + i_NumberOfHoursToAdd;

            if(newBatteryTime<= m_MaxBatteryTimeInHours)
            {
                m_BatteryTimeInHoursLeft = newBatteryTime;
            }
        }

        public float BatteryTimeInHoursLeft
        {
            get
            {
                return m_BatteryTimeInHoursLeft;
            }
            set
            {
                m_BatteryTimeInHoursLeft = value;
            }
        }

        public float MaxBatteryTimeInHours
        {
            get
            {
                return m_MaxBatteryTimeInHours;
            }
            set
            {
                m_MaxBatteryTimeInHours = value;
            }
        }
    }
}
