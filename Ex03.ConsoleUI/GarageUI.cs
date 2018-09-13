using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        GarageLogic.Garage m_Garage;
        GarageLogic.VehicleManufacturer m_VehicleManufacturer;

        public GarageUI()
        {
            m_Garage = new GarageLogic.Garage();
            m_VehicleManufacturer = new GarageLogic.VehicleManufacturer();
        }

        public void OpenTheGarage()
        {
            bool ifYouWantToContinue = true;

            while (ifYouWantToContinue)
            {
                Console.Clear();
                printGarageMenu();
                string choice = Console.ReadLine();
                Console.Clear();
                handleChoice(choice);
                ifYouWantToContinue = checkIfWantToContinue();
            }
            Console.WriteLine("Thank you , have a nice day. bye bye");
        }

        private bool checkIfWantToContinue()
        {
            Console.WriteLine("If you want to do more actions -> press 1, else another key");
            string choise = Console.ReadLine();

            return choise.Equals("1");
        }

        private void handleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    putNewVehicleInGarage();
                    break;
                case "2":
                    displayListOfVehicleInGarage();
                    break;
                case "3":
                    changeStatusOfAVehicle();
                    break;
                case "4":
                    inflateAirInTheWheelsOfAVehicle();
                    break;
                case "5":
                    refuelVehicleDrivenByFuel();
                    break;
                case "6":
                    chargeAnElectricVehicle();
                    break;
                case "7":
                    displayFullDataOfVehicle();
                    break;
                default:
                    exitGarage();
                    break;
            }
        }

        private void exitGarage()//////////////////////////////////////////
        {
            throw new NotImplementedException();
        }

        private void displayFullDataOfVehicle()
        {
            string licenseNumber = inputLicenseNumber();
            VehicleInGarage vehiclesInGarage = m_Garage.GetFullDataOfVehicle(licenseNumber);
            printForDataOfVehicle(vehiclesInGarage);
        }

        private void printForDataOfVehicle(VehicleInGarage i_VehiclesInGarage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format(
@"- View full data of a vehicle -
Customer Name : {0}
Status Of Vehicle In Garage : {1}",
i_VehiclesInGarage.CustomerName,
i_VehiclesInGarage.VehicleStatus));

            stringBuilder.Append(i_VehiclesInGarage.CustomerVehicle.ToString());
            Console.WriteLine(stringBuilder);
        }

        private void chargeAnElectricVehicle()
        {
            string licenseNumber = inputLicenseNumber();
            float numberOfMinutesToCharge = inputNumberOfMinutesToCharge();
            m_Garage.ChargeElectricVehicle(licenseNumber, numberOfMinutesToCharge);
        }

        private float inputNumberOfMinutesToCharge()/////////////////////////////////////////////////
        {
            throw new NotImplementedException();
        }

        private void refuelVehicleDrivenByFuel()
        {
            string licenseNumber = inputLicenseNumber();
            eFuelType fuelType = inputFuelType();
            float litersOfFule = inputLitersOfFuel();
            m_Garage.RefuelVehicleDrivenByFuel(licenseNumber, fuelType, litersOfFule);
        }

        private eFuelType findFuelType(string choice)
        {
            GarageLogic.eFuelType fuelType;

            if (choice.Equals("1"))
            {
                fuelType = GarageLogic.eFuelType.octan95;
            }
            else if (choice.Equals("2"))
            {
                fuelType = GarageLogic.eFuelType.octan96;
            }
            else if (choice.Equals("3"))
            {
                fuelType = GarageLogic.eFuelType.octan98;
            }
            else
            {
                fuelType = GarageLogic.eFuelType.soler;
            }

            return fuelType;
        }

        private eFuelType inputFuelType()
        {
            GarageLogic.eFuelType fuelType;
            Console.WriteLine(string.Format(
@"- please choose fuel type: -
octan95 -> Press 1
octan96 -> Press 2
octan98 -> Press 3
soler -> Press any other key"));
            string choice = Console.ReadLine();
            fuelType = findFuelType(choice);

            return fuelType;
        }

        private float inputLitersOfFuel()
        {
            bool isParseSucceeded = false;
            float literAsfloat = 0;
            string literAsString;

            while (!isParseSucceeded)
            {
                Console.WriteLine("Please enter liter of fule");
                literAsString = Console.ReadLine();
                isParseSucceeded = float.TryParse(literAsString, out literAsfloat);
                if (!isParseSucceeded)
                {
                    Console.WriteLine("input is invalid");
                }
            }

            return literAsfloat;
        }

        private void inflateAirInTheWheelsOfAVehicle()
        {
            string licenseNumber = inputLicenseNumber();
            m_Garage.InflateVehicleWheelsToMaximum(licenseNumber);
        }

        private void changeStatusOfAVehicle()
        {
            string licenseNumber = inputLicenseNumber();

            GarageLogic.eVehicleStatus newStatus = inputNewStatus();
            m_Garage.ChangeTheStatusOfVehicleInTheGarage(licenseNumber, newStatus);
        }

        private eVehicleStatus inputNewStatus()
        {
            GarageLogic.eVehicleStatus newStatus;
            Console.WriteLine(string.Format(
@"- Choose the new vehicle ststus you want -
vehicleInFix -> Press 1
vehicleFixed -> Press 2
for paid -> Press any other key"));

            string status = Console.ReadLine();
            newStatus = findVehicleNewStatus(status);

            return newStatus;
        }

        private eVehicleStatus findVehicleNewStatus(string i_status)
        {
            GarageLogic.eVehicleStatus newStatus;
            if (i_status.Equals("1"))
            {
                newStatus = GarageLogic.eVehicleStatus.vehicleInFix;
            }
            else if (i_status.Equals("2"))
            {
                newStatus = GarageLogic.eVehicleStatus.vehicleFixed;
            }
            else
            {
                newStatus = GarageLogic.eVehicleStatus.paid;
            }

            return newStatus;
        }

        private string inputLicenseNumber()
        {
            Console.WriteLine("Please insert the license Number");
            return Console.ReadLine();
        }

        private void displayListOfVehicleInGarage()
        {
            bool isFiltered = true;
            GarageLogic.eVehicleStatus filteredStatus = GarageLogic.eVehicleStatus.vehicleInFix;
            printDisplayOptions();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    filteredStatus = GarageLogic.eVehicleStatus.vehicleInFix;
                    break;
                case "2":
                    filteredStatus = GarageLogic.eVehicleStatus.vehicleFixed;
                    break;
                case "3":
                    filteredStatus = GarageLogic.eVehicleStatus.paid;
                    break;
                default:
                    isFiltered = false;
                    break;
            }

            ICollection<string> collectionOfLicenseNumbers = m_Garage.GetListOfLicenseNumbers(isFiltered, filteredStatus);
            printCollectionOfLicenseNumbers(collectionOfLicenseNumbers);
        }

        private void printCollectionOfLicenseNumbers(ICollection<string> collectionOfLicenseNumbers)
        {
            Console.WriteLine("The licence number are:");
            foreach (string LicenseNumbers in collectionOfLicenseNumbers)
            {
                Console.WriteLine(LicenseNumbers);
            }
        }

        private void printDisplayOptions()
        {
            Console.WriteLine("If you want to display only vehicles in fix - Press 1 ");
            Console.WriteLine("If you want to display only vehicles thar fixed - Press 2 ");
            Console.WriteLine("If you want to display only vehicles that paid - Press 3 ");
            Console.WriteLine("If you want to display all vehicles - Press any other key ");
        }

        private void putNewVehicleInGarage()
        {
            VehicleInGarage vehiclesInGarage = getDetailsOfVehicleInGarage();
            string modelName = inputModleName();
            string licenseNumber = inputLicenseNumber();
            float percentageOfEnergyLeft = inputPercentageOfEnergyLeft();
            eVehicleWheels WheelsByVehicleType = inputGeneralTypeOfVehicle();
            List<Wheel> wheels = inputListOfWheels(WheelsByVehicleType);

            switch (WheelsByVehicleType)
            {
                case eVehicleWheels.motorcycle:
                    putNewMotorcycleInGarage(licenseNumber, modelName, percentageOfEnergyLeft, vehiclesInGarage, wheels);
                    break;
                case eVehicleWheels.car:
                    putNewCarInGarage(licenseNumber, modelName, percentageOfEnergyLeft, vehiclesInGarage, wheels);
                    break;
                case eVehicleWheels.truck:
                    putNewTruckInGarage(licenseNumber, modelName, percentageOfEnergyLeft, vehiclesInGarage, wheels);
                    break;
                default:
                    Console.WriteLine("We do not handle this type of vehicle");
                    break;
            }
        }

        private List<Wheel> inputListOfWheels(eVehicleWheels i_WheelsByVehicleType)
        {
            List<Wheel> wheels = new List<Wheel>();
            Wheel currentWheel;
            float maxAirPressure = findMaxAirPressureByVehicleType(i_WheelsByVehicleType);

            Console.WriteLine("Please enter the weels details");

            for (int i = 0; i < (int)i_WheelsByVehicleType; i++)
            {
                currentWheel = createNewWheel(maxAirPressure);
                wheels.Add(currentWheel);
            }

            return wheels;
        }

        private float findMaxAirPressureByVehicleType(eVehicleWheels i_WheelsByVehicleType)
        {
            float maxAirPressure = 0;

            switch (i_WheelsByVehicleType)
            {
                case eVehicleWheels.motorcycle:
                    maxAirPressure = Motorcycle.k_WeelMaxAirPressure;
                    break;
                case eVehicleWheels.car:
                    maxAirPressure = Car.k_WeelMaxAirPressure;
                    break;
                case eVehicleWheels.truck:
                    maxAirPressure = Truck.k_WeelMaxAirPressure;
                    break;
            }

            return maxAirPressure;
        }

        private Wheel createNewWheel(float i_MaxAirPressure)
        {
            string manufacturerName = inputManufacturerName();
            float currentAirPressure = inputCurrentAirPressure(i_MaxAirPressure);

            Wheel currentWheel = new Wheel(manufacturerName, currentAirPressure, i_MaxAirPressure);

            return currentWheel;
        }

        private float inputCurrentAirPressure(float i_MaxAirPressure)
        {
            bool isParseSucceeded = false;
            float currentAirPressureFloat = 0;
            string currentAirPressurestring;

            while (!isParseSucceeded)
            {
                Console.WriteLine("enter current air pressure");
                currentAirPressurestring = Console.ReadLine();
                isParseSucceeded = float.TryParse(currentAirPressurestring, out currentAirPressureFloat);
                if (!isParseSucceeded || currentAirPressureFloat > i_MaxAirPressure || currentAirPressureFloat < 0)
                {
                    Console.WriteLine("input is invalid");
                }
            }

            return currentAirPressureFloat;
        }

        private string inputManufacturerName()
        {
            Console.WriteLine("Please input manufacturer name");
            return Console.ReadLine();
        }

        private void putNewTruckInGarage(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, VehicleInGarage i_VehiclesInGarage, List<Wheel> i_Wheels)
        {
            Console.WriteLine(string.Format(@"This garage only handles trucks with fuel"));

            bool isTheTrunkCooled = inputIsTheTrunkCooled();
            float trunkVolume = inputTrunkVolume();

            putNewFuelTruckInGarage(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, isTheTrunkCooled, trunkVolume, i_VehiclesInGarage, i_Wheels);
        }

        private void putNewFuelTruckInGarage(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft, bool i_IsTheTrunkCooled, float i_TrunkVolume, VehicleInGarage i_VehiclesInGarage, List<Wheel> i_Wheels)
        {
            eFuelType fuelType = FuelTruck.k_FuelType;
            float maxFuelInLiter = FuelTruck.k_MaxFuelInLiter;
            float currentFuelAmount = inputCurrentFuelAmount(maxFuelInLiter);

            FuelEngine fuelEngine = m_VehicleManufacturer.createNewFuelEngine(fuelType, currentFuelAmount, maxFuelInLiter);
            FuelTruck fuelTruck = m_VehicleManufacturer.createNewFuelTruck(fuelEngine, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, i_IsTheTrunkCooled, i_TrunkVolume,i_Wheels);
            i_VehiclesInGarage.CustomerVehicle = fuelTruck;
            m_Garage.PutANewCarIntoTheGarage(i_VehiclesInGarage);
        }

        private bool inputIsTheTrunkCooled()
        {
            bool isTheTrunkCooled = false;

            Console.WriteLine(string.Format(
@"- Choose if the trunk cooled -
Yes -> Press 1
No -> Press any other key"));

            string choise = Console.ReadLine();
            if (choise.Equals("1"))
            {
                isTheTrunkCooled = true;
            }

            return isTheTrunkCooled;
        }

        private float inputTrunkVolume()
        {
            bool isParseSucceeded = false;
            float trunkVolumeFloat = 0;
            string trunkVolumeString;

            while (!isParseSucceeded)
            {
                Console.WriteLine("enter trunk volume");
                trunkVolumeString = Console.ReadLine();
                isParseSucceeded = float.TryParse(trunkVolumeString, out trunkVolumeFloat);
                if (!isParseSucceeded || trunkVolumeFloat < 0)
                {
                    Console.WriteLine("input is invalid");
                }
            }

            return trunkVolumeFloat;
        }

        private void putNewCarInGarage(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, VehicleInGarage i_VehicleInGarage, List<Wheel> i_Wheels)
        {
            eCarColor carColor = inputCarColor();
            eNumberOfDoors numberOfDoors = inputNumberOfDoors();

            Console.WriteLine(string.Format(@"choose the type of vehicle you want:
for fuel engine car - press 1
for electric engine car - press any other key"));
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                putNewFuelCarInGarage(i_LicenseNumber, i_ModelName, i_PercentageOfEnergyLeft, carColor, numberOfDoors, i_VehicleInGarage, i_Wheels);
            }
            else
            {
                putNewElectricCarInGarage(i_LicenseNumber, i_ModelName, i_PercentageOfEnergyLeft, carColor, numberOfDoors, i_VehicleInGarage, i_Wheels);
            }
        }

        private void putNewElectricCarInGarage(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, VehicleInGarage i_VehicleInGarage, List<Wheel> i_Wheels)
        {
            float maxBbatteryTimeInHours = ElectricCar.k_MaxBbatteryTimeInHours;
            float batteryTimeInHoursLeft = inputBatteryTimeInHoursLeft(maxBbatteryTimeInHours);

            ElectricEngine electricEngine = m_VehicleManufacturer.createNewElectricEngine(batteryTimeInHoursLeft, maxBbatteryTimeInHours);
            ElectricCar electricCar = m_VehicleManufacturer.CreateNewElectricCar(electricEngine, i_NumberOfDoors, i_CarColor, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft,i_Wheels);
            i_VehicleInGarage.CustomerVehicle = electricCar;
            m_Garage.PutANewCarIntoTheGarage(i_VehicleInGarage);
        }

        private eNumberOfDoors inputNumberOfDoors()
        {
            Console.WriteLine(string.Format(
@"- Choose the number of doors you want -
2 -> Press 1
3 -> Press 2
4 -> Press 3
5 -> Press any other key"));

            string choice = Console.ReadLine();
            eNumberOfDoors numberOfDoors = findNumberOfDoors(choice);

            return numberOfDoors;
        }

        private eNumberOfDoors findNumberOfDoors(string choice)
        {
            eNumberOfDoors numberOfDoors;

            if (choice == "1")
            {
                numberOfDoors = eNumberOfDoors.two;
            }
            else if (choice == "2")
            {
                numberOfDoors = eNumberOfDoors.three;
            }
            else if (choice == "3")
            {
                numberOfDoors = eNumberOfDoors.four;
            }
            else
            {
                numberOfDoors = eNumberOfDoors.five;
            }

            return numberOfDoors;
        }

        private void putNewFuelCarInGarage(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, eCarColor carColor, eNumberOfDoors i_NumberOfDoors, VehicleInGarage i_VehicleInGarage, List<Wheel> i_Wheels)
        {
            eFuelType fuelType = FuelCar.k_FuelType;
            float maxFuelInLiter = FuelCar.k_MaxFuelInLiter;
            float currentFuelAmount = inputCurrentFuelAmount(maxFuelInLiter);

            FuelEngine fuelEngine = m_VehicleManufacturer.createNewFuelEngine(fuelType, currentFuelAmount, maxFuelInLiter);
            FuelCar fuelCar = m_VehicleManufacturer.CreateNewFuelCar(fuelEngine, i_NumberOfDoors, carColor, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft,i_Wheels);
            i_VehicleInGarage.CustomerVehicle = fuelCar;
            m_Garage.PutANewCarIntoTheGarage(i_VehicleInGarage);
        }

        private eCarColor inputCarColor()
        {
            Console.WriteLine(string.Format(
@"- Choose the car color you want -
grey -> Press 1
white -> Press 2
green -> Press 3
purple -> Press any other key"));

            string choice = Console.ReadLine();
            eCarColor carColor = findCarColor(choice);

            return carColor;
        }

        private eCarColor findCarColor(string choice)
        {
            eCarColor carColor;

            if (choice == "1")
            {
                carColor = eCarColor.grey;
            }
            else if (choice == "2")
            {
                carColor = eCarColor.white;
            }
            else if (choice == "3")
            {
                carColor = eCarColor.green;
            }
            else
            {
                carColor = eCarColor.purple;
            }

            return carColor;
        }

        private VehicleInGarage getDetailsOfVehicleInGarage()
        {
            Console.WriteLine("please enter customer name");
            string customerName = Console.ReadLine();
            Console.WriteLine("please enter customer phone");
            string customerPhone = Console.ReadLine();
            VehicleInGarage vehicleInGarage = new VehicleInGarage(customerName, customerPhone, null);
            return vehicleInGarage;
        }

        private void putNewMotorcycleInGarage(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, VehicleInGarage i_VehiclesInGarage, List<Wheel> i_Wheels)
        {
            eLicenseType licenseType = inputLicenseType();
            int engineCapacity = inputEngineCapacity();
            Console.WriteLine(string.Format(
@"- Choose the type of your motorcycle you want -
for fuel engine motorcycle -> Press 1
for electric engine motorcycle -> Press any other key"));

            string choise = Console.ReadLine();

            if (choise == "1")
            {
                putNewFuelEngineMotorcycle(i_LicenseNumber, i_ModelName, i_PercentageOfEnergyLeft, licenseType, engineCapacity, i_VehiclesInGarage, i_Wheels);
            }
            else
            {
                putNewElectricEngineMotorcycle(i_LicenseNumber, i_ModelName, i_PercentageOfEnergyLeft, licenseType, engineCapacity, i_VehiclesInGarage, i_Wheels);
            }
        }

        private void putNewElectricEngineMotorcycle(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, eLicenseType i_LicenseType, int i_EngineCapacity, VehicleInGarage i_VehiclesInGarage, List<Wheel> i_Wheels)
        {
            float maxBbatteryTimeInHours = ElectricMotorcycle.k_MaxBbatteryTimeInHours;
            float batteryTimeInHoursLeft = inputBatteryTimeInHoursLeft(maxBbatteryTimeInHours);

            ElectricEngine electricEngine = m_VehicleManufacturer.createNewElectricEngine(batteryTimeInHoursLeft, maxBbatteryTimeInHours);
            ElectricMotorcycle electricMotorcycle = m_VehicleManufacturer.createNewElectricMotorcycle(electricEngine, i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_EngineCapacity,i_Wheels);
            i_VehiclesInGarage.CustomerVehicle = electricMotorcycle;
            m_Garage.PutANewCarIntoTheGarage(i_VehiclesInGarage);
        }

        private float inputBatteryTimeInHoursLeft(float i_MaxBbatteryTimeInHours)
        {
            bool isParseSucceeded = false;
            float batteryTimeInHoursLeftFloat = 0;
            string batteryTimeInHoursLeftString;

            while (!isParseSucceeded)
            {
                Console.WriteLine("enter current fuel amount");
                batteryTimeInHoursLeftString = Console.ReadLine();
                isParseSucceeded = float.TryParse(batteryTimeInHoursLeftString, out batteryTimeInHoursLeftFloat);
                if (!isParseSucceeded || batteryTimeInHoursLeftFloat > i_MaxBbatteryTimeInHours || batteryTimeInHoursLeftFloat < 0)
                {
                    Console.WriteLine("input is invalid");
                }
            }

            return batteryTimeInHoursLeftFloat;
        }

        private void putNewFuelEngineMotorcycle(string i_LicenseNumber, string i_ModelName, float i_PercentageOfEnergyLeft, eLicenseType i_LicenseType, int i_EngineCapacity, VehicleInGarage i_VehiclesInGarage, List<Wheel> i_Wheels)
        {
            eFuelType fuelType = FuelMotorcycle.k_FuelType;
            float maxFuelInLiter = FuelMotorcycle.k_MaxFuelInLiter;
            float currentFuelAmount = inputCurrentFuelAmount(maxFuelInLiter);

            FuelEngine fuelEngine = m_VehicleManufacturer.createNewFuelEngine(fuelType, currentFuelAmount, maxFuelInLiter);
            FuelMotorcycle fuelMotorcycle = m_VehicleManufacturer.CreateNewFuelMotorcycle(fuelEngine, i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft,i_Wheels);
            i_VehiclesInGarage.CustomerVehicle = fuelMotorcycle;
            m_Garage.PutANewCarIntoTheGarage(i_VehiclesInGarage);
        }

        private float inputCurrentFuelAmount(float i_MaxFuelInLiter)
        {
            bool isParseSucceeded = false;
            float currentFuelAmount = 0;
            string currentFuelTypeAmountString;

            while (!isParseSucceeded)
            {
                Console.WriteLine("enter current fuel amount");
                currentFuelTypeAmountString = Console.ReadLine();
                isParseSucceeded = float.TryParse(currentFuelTypeAmountString, out currentFuelAmount);
                if (!isParseSucceeded || currentFuelAmount < 0 || currentFuelAmount > i_MaxFuelInLiter)
                {
                    Console.WriteLine("input is invalid");
                    isParseSucceeded = false;
                }
            }

            return currentFuelAmount;
        }

        private int inputEngineCapacity()
        {
            bool isParseSucceeded = false;
            int engineCapacityInt = 0;
            string engineCapacityString;

            while (!isParseSucceeded)
            {
                Console.WriteLine("enter engine capacity");
                engineCapacityString = Console.ReadLine();
                isParseSucceeded = int.TryParse(engineCapacityString, out engineCapacityInt);
                if (!isParseSucceeded)
                {
                    Console.WriteLine("input is invalid");
                }
            }

            return engineCapacityInt;
        }

        private eLicenseType inputLicenseType()
        {
            Console.WriteLine(string.Format(
@"- Choose the type of your license you want -
A1 -> Press 1
A2 -> Press 2
AB -> Press 3
for B -> Press any other key"));

            string choice = Console.ReadLine();
            eLicenseType vehicleWheels = findLicenseType(choice);

            return vehicleWheels;
        }

        private eLicenseType findLicenseType(string choice)
        {
            eLicenseType vehicleWheels;

            if (choice == "1")
            {
                vehicleWheels = eLicenseType.A1;
            }
            else if (choice == "2")
            {
                vehicleWheels = eLicenseType.A2;
            }
            else if (choice == "3")
            {
                vehicleWheels = eLicenseType.AB;
            }
            else
            {
                vehicleWheels = eLicenseType.B;
            }

            return vehicleWheels;
        }

        private eVehicleWheels inputGeneralTypeOfVehicle()
        {
            bool isValide = false;
            string typeOfVehicle = "1";
            eVehicleWheels vehicleWheels;
            while (!isValide)
            {
                Console.WriteLine(string.Format(
@"- Choose the type your vehicle you want -
your options are:
1- motorcycle
2- Car
3- Truck"));
                typeOfVehicle = Console.ReadLine();
                if (typeOfVehicle == "1" || typeOfVehicle == "2" || typeOfVehicle == "3")
                {
                    isValide = true;
                }
                else
                {
                    Console.WriteLine("Input is not valide");
                }
            }

            vehicleWheels = findTypeOfVehicle(typeOfVehicle);

            return vehicleWheels;
        }

        private eVehicleWheels findTypeOfVehicle(string i_TypeOfVehicle)
        {
            eVehicleWheels vehicleWheels;

            if (i_TypeOfVehicle == "1")
            {
                vehicleWheels = eVehicleWheels.motorcycle;
            }
            else if (i_TypeOfVehicle == "2")
            {
                vehicleWheels = eVehicleWheels.car;
            }
            else
            {
                vehicleWheels = eVehicleWheels.truck;
            }

            return vehicleWheels;
        }

        private float inputPercentageOfEnergyLeft()
        {
            bool isParseSucceeded = false;
            string percentageOfEnergyString;
            float percentageOfEnergyFloat = 0;

            while (!isParseSucceeded)
            {
                Console.WriteLine("Please insert the percentage of energy left in the vehicle (0-100)");
                percentageOfEnergyString = Console.ReadLine();
                isParseSucceeded = float.TryParse(percentageOfEnergyString, out percentageOfEnergyFloat);
                if (!isParseSucceeded || percentageOfEnergyFloat < 0 || percentageOfEnergyFloat > 100)
                {
                    Console.WriteLine("Input not valied");
                    isParseSucceeded = false;
                }
            }

            return percentageOfEnergyFloat;
        }

        private string inputModleName()
        {
            Console.WriteLine("Please insert the vehicle model");
            return Console.ReadLine();
        }

        private void printGarageMenu()
        {
            Console.Write(
@"- Hello and welcome to our garage! -
your options are:
1- If you want to put a new car into the garage
2- If you want to display the list of vehicle license numbers in the garage (filterd by status)
3- If you want to change the status of a vehicle in the garage
4- If you want to inflate the air in the wheels of a vehicle to the maximum
5- If you want to refuel a vehicle driven by fuel
6- If you want to charge an electric vehicle
7- If you want to display full data of a vehicle according to license number
If you want to exit -> press any other key
-> Enter your choice: ");
        }


    }
}

