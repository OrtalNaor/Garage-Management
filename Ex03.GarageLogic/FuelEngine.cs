using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        private float m_CurrenAmountOfFuelLiter;
        private float m_MaxAmountOfFuelLiter;

        public FuelEngine(eFuelType i_FuelType, float i_CurrenAmountOfFuelLiter, float i_MaxAmountOfFuelLiter)
        {
            m_FuelType = i_FuelType;
            m_CurrenAmountOfFuelLiter = i_CurrenAmountOfFuelLiter;
            m_MaxAmountOfFuelLiter = i_MaxAmountOfFuelLiter;
        }

        public void Refueling(float i_AmountOfLitersToAdd, eFuelType i_FuelType)
        {
            float newAmountOfFullLiters = i_AmountOfLitersToAdd + m_CurrenAmountOfFuelLiter;

            if (newAmountOfFullLiters <= m_MaxAmountOfFuelLiter)
            {
                m_CurrenAmountOfFuelLiter = newAmountOfFullLiters;
            }
            //need to check if fuel type is fit

        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public float CurrenAmountOfFuelLiter
        {
            get
            {
                return m_CurrenAmountOfFuelLiter;
            }
            set
            {
                m_CurrenAmountOfFuelLiter = value;
            }
        }

        public float MaxAmountOfFuelLiter
        {
            get
            {
                return m_MaxAmountOfFuelLiter;
            }
            set
            {
                m_MaxAmountOfFuelLiter = value;
            }
        }
    }
}
