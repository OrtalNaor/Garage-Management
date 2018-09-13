using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleManufacturer
    {
        public FuelCar CreateNewFuelCar(FuelEngine i_FuelVehicle, eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            FuelCar fuelCar = new FuelCar(i_FuelVehicle, i_NumberOfDoors, i_CarColor, i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels);

            return fuelCar;
        }

        public ElectricCar CreateNewElectricCar(ElectricEngine i_ElectriclEngine, eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            ElectricCar electricCar = new ElectricCar(i_ElectriclEngine, i_NumberOfDoors, i_CarColor, i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels);

            return electricCar;
        }

        public FuelMotorcycle CreateNewFuelMotorcycle(FuelEngine i_FuelVehicle, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            FuelMotorcycle fuelMotorcycle = new FuelMotorcycle(i_FuelVehicle, i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels);

            return fuelMotorcycle;
        }

        public ElectricMotorcycle createNewElectricMotorcycle(ElectricEngine i_ElectricEngine, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenseNumber, float i_ThePercentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            ElectricMotorcycle electricMotorcycle = new ElectricMotorcycle(i_ElectricEngine, i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_ThePercentageOfEnergyLeft, i_Wheels);
            return electricMotorcycle;
        }

        public FuelTruck createNewFuelTruck(FuelEngine i_FuelEngine, string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft, bool i_IsTheTrunkCooled, float i_TrunkVolume, List<Wheel> i_Wheels)
        {
            FuelTruck fuelTruck = new FuelTruck(i_FuelEngine, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, i_IsTheTrunkCooled, i_TrunkVolume,i_Wheels);
            return fuelTruck;
        }

        public ElectricEngine createNewElectricEngine(float i_BatteryTimeInHours, float i_MaxBatteryTimeInHours)
        {
            ElectricEngine electricEngine = new ElectricEngine(i_BatteryTimeInHours, i_MaxBatteryTimeInHours);
            return electricEngine;
        }

        public FuelEngine createNewFuelEngine(eFuelType i_FuelType, float i_CurrenAmountOfFuelLiter, float i_MaxAmountOfFuelLiter)
        {
            FuelEngine fuelEngine = new FuelEngine(i_FuelType, i_CurrenAmountOfFuelLiter, i_MaxAmountOfFuelLiter);
            return fuelEngine;
        }
    }
}