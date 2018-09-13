using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, VehicleInGarage> m_CustomerDetailsByLicenseNumber;

        public Garage()
        {
            m_CustomerDetailsByLicenseNumber = new Dictionary<string, VehicleInGarage>();
        }
 
        //EX1
        public bool PutANewCarIntoTheGarage(VehicleInGarage i_VehiclesInGarage)
        {
            string licenseNumber = i_VehiclesInGarage.CustomerVehicle.LicenseNumber;
            bool isExistInGarage = false;

            if (m_CustomerDetailsByLicenseNumber.ContainsKey(licenseNumber))
            {
                VehicleInGarage updateVehicle = m_CustomerDetailsByLicenseNumber[licenseNumber];
                updateVehicle.VehicleStatus = eVehicleStatus.vehicleInFix;
                m_CustomerDetailsByLicenseNumber[licenseNumber] = updateVehicle;
                isExistInGarage = true;
            }
            else
            {
                m_CustomerDetailsByLicenseNumber.Add(licenseNumber, i_VehiclesInGarage);
            }

            return isExistInGarage;
        }

        //EX2
        public ICollection<string> GetListOfLicenseNumbers(bool i_IsFiltered, eVehicleStatus i_FilteredStatus)
        {
            ICollection<string> collectionOfLicenseNumbers = new List<string>();

            if (i_IsFiltered)
            {
                foreach (string currentLicenseNumber in m_CustomerDetailsByLicenseNumber.Keys)
                {
                    VehicleInGarage currentCustomer = m_CustomerDetailsByLicenseNumber[currentLicenseNumber];
                    if (currentCustomer.VehicleStatus == i_FilteredStatus)
                    {
                        collectionOfLicenseNumbers.Add(currentLicenseNumber);
                    }
                }
            }
            else
            {
                collectionOfLicenseNumbers = m_CustomerDetailsByLicenseNumber.Keys;
            }

            return collectionOfLicenseNumbers;
        }

        //EX3
        public void ChangeTheStatusOfVehicleInTheGarage(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            VehicleInGarage updateVehicle = m_CustomerDetailsByLicenseNumber[i_LicenseNumber];
            updateVehicle.VehicleStatus = i_NewStatus;
            m_CustomerDetailsByLicenseNumber[i_LicenseNumber] = updateVehicle;
        }

        //EX4
        public void InflateVehicleWheelsToMaximum(string i_LicenseNumber)
        {
            //todo
        }

        //EX5
        public void RefuelVehicleDrivenByFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_LitersOfFuel)
        {
            Vehicle updateVehicle = m_CustomerDetailsByLicenseNumber[i_LicenseNumber].CustomerVehicle;
            //todo            
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_NumberOfMinutesToCharge)
        {
            //todo  
        }

        public VehicleInGarage GetFullDataOfVehicle(string i_LicenseNumber)
        {
            return m_CustomerDetailsByLicenseNumber[i_LicenseNumber];
        }
    }
}
