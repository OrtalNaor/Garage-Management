using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private string m_CustomerName;
        private string m_CustomerPhone;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_CustomerVehicle;

        public VehicleInGarage(string i_CustomerName, string i_CustomerPhone, Vehicle i_CustomerVehicle)
        {
            m_CustomerName = i_CustomerName;
            m_CustomerPhone = i_CustomerPhone;
            m_VehicleStatus = eVehicleStatus.vehicleInFix;
            m_CustomerVehicle = i_CustomerVehicle;
        }

        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }

        public string CustomerPhone
        {
            get
            {
                return m_CustomerPhone;
            }
            set
            {
                m_CustomerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        public Vehicle CustomerVehicle
        {
            get
            {
                return m_CustomerVehicle;
            }
            set
            {
                m_CustomerVehicle = value;
            }
        }
    }
}
