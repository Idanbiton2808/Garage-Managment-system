using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        public void Run()
        {
            bool isAlreadyInGarage = false;
            int plateNumber;
            eVehicleStatus chosenStatus;
            eFuelType fueltype;

            GarageLogic.Garage garage = new GarageLogic.Garage();
            Console.WriteLine("Welcome To The Garage Managment System!");
            while (true)
            {
                try
                {
                    Console.WriteLine(@"Menu:
1. Enter a new vehicle to the garage  
2. Display list of vehicles in the garage with filtering by status
3. Change vehicle status
4. Inflate tires to maximum
5. Refuel a vehicle
6. Charge an electric vehicle
7. Display full vehicle details by license plate number
0. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            plateNumber = GetAndCheckUserInput();
                            isAlreadyInGarage = garage.CheckIfIsAlreadyInGarage(plateNumber);
                            if (!isAlreadyInGarage)
                            {
                                NewVehicleReceptionToGarage(plateNumber, garage);
                            }

                            else
                            {
                                Console.WriteLine("This Vehicle Is Already In The Garage ");
                                garage.ChangeVehicleStatus(eVehicleStatus.UnderRepair, plateNumber);
                            }

                            break;
                        case 2:
                            List<AbstractVehicle> VehiclesList = garage.Vehicles;
                            chosenStatus = GetStatusChoice();
                            List<AbstractVehicle> filteredVehicles = FilterByStatus(VehiclesList, chosenStatus);
                            Console.WriteLine($"Vehicles with status {chosenStatus}:");
                            foreach (var vehicle in filteredVehicles)
                            {
                                Console.WriteLine($"{vehicle.LicenseNumber}: {vehicle.VehicleStatus}");
                            }

                            break;
                        case 3:
                            plateNumber = GetAndCheckUserInput();
                            chosenStatus = GetStatusChoice();
                            garage.ChangeVehicleStatus(chosenStatus, plateNumber);
                            break;
                        case 4:
                            plateNumber = GetAndCheckUserInput();
                            bool IsAlreadyUnGarage = garage.CheckIfIsAlreadyInGarage(plateNumber);
                            if (isAlreadyInGarage)
                            {
                                (garage.GetVehicleDetailsByPlateNumber(plateNumber)).InflateWheelsAirPressureToMax();
                                foreach (Wheel wheel in (garage.GetVehicleDetailsByPlateNumber(plateNumber)).Wheels)
                                {

                                    Console.WriteLine(wheel.AirPressure);
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Not In Garage Can't Inflate!");
                            }

                            break;
                        case 5:
                            plateNumber = GetAndCheckUserInput();
                            AbstractVehicle vehicleToRefuel = garage.GetVehicleDetailsByPlateNumber(plateNumber);
                            Console.WriteLine("Enter The Fuel Type You Want To Refuel: ");
                            foreach (eFuelType fuelType in Enum.GetValues(typeof(eFuelType)))
                            {
                                Console.WriteLine($"{(int)fuelType}. {fuelType}");
                            }
                            string fuelTypeInput = Console.ReadLine();
                            Enum.TryParse(fuelTypeInput, true, out fueltype);
                            Console.WriteLine("Enter Amount you Would Like to Refuel:");
                            int amountToFuel = int.Parse(Console.ReadLine());
                            if (vehicleToRefuel.petrolVehicle != null && vehicleToRefuel.electricVehicle == null)
                            {
                                vehicleToRefuel.Refuling(fueltype, amountToFuel);
                            }

                            break;
                        case 6:
                            plateNumber = GetAndCheckUserInput();
                            AbstractVehicle vehicleToCharge = garage.GetVehicleDetailsByPlateNumber(plateNumber);
                            Console.WriteLine("Enter Amount you Would Like to Charge:");
                            int amountToCharge = int.Parse(Console.ReadLine());
                            if (vehicleToCharge.electricVehicle != null && vehicleToCharge.petrolVehicle == null)
                            {
                                vehicleToCharge.Charging(amountToCharge);
                            }

                            break;
                        case 7:
                            plateNumber = GetAndCheckUserInput();
                            DisplayVehicleDetailsByLicensePlate(plateNumber, garage);
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");

                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                catch (GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Value out of range. Please enter a number between {0} and {1}.", ex.MinValue, ex.MaxValue);
                }

                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An error occurred: {0}", ex.Message);
                }
            }
        }

        public void DisplayVehicleDetailsByLicensePlate(int i_LicensePlate, Garage i_Garage)
        {
            AbstractVehicle vehicle = i_Garage.GetVehicleDetailsByPlateNumber(i_LicensePlate);

            if (vehicle != null)
            {
                Console.WriteLine($"License Plate: {vehicle.LicenseNumber}");
                Console.WriteLine($"Model: {vehicle.ModelName}");
                Console.WriteLine($"Owner: {vehicle.VehicleOwner.OwnerName}");
                Console.WriteLine($"Owner Phone Number: {vehicle.VehicleOwner.PhoneNumber}");
                Console.WriteLine($"Status: {vehicle.VehicleStatus}");
                Console.WriteLine("Wheels:");
                foreach (Wheel wheel in vehicle.Wheels)
                {
                    Console.WriteLine($"- Manufacturer: {wheel.ManufacturerName}");
                    Console.WriteLine($"- Air Pressure: {wheel.AirPressure}");
                }

                if (vehicle.petrolVehicle != null && vehicle.electricVehicle == null)
                {
                    Console.WriteLine($"Current Fuel Quantity: {vehicle.EnergyStatePrecentge}");
                    Console.WriteLine($"Fuel Type: {vehicle.petrolVehicle.FuelType}");
                }

                if (vehicle.petrolVehicle == null && vehicle.electricVehicle != null)
                {
                    Console.WriteLine($"Current Battery: {vehicle.EnergyStatePrecentge}");
                }
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        public int GetAndCheckUserInput()
        {
            int plateNumber = 0;
            string stringInput;
            bool isValidInput;

            do
            {
                isValidInput = true;
                try
                {
                    Console.WriteLine("Please Enter Car Plate Number:");
                    stringInput = Console.ReadLine();
                    plateNumber = int.Parse(stringInput);
                }

                catch (FormatException)
                {
                    isValidInput = false;
                    Console.WriteLine("Error:Input is not a valid integer, Please Try Again...");
                }

                catch (ArgumentException ex)
                {
                    isValidInput = false;
                    Console.WriteLine("Error: {0}, Please Try Again...", ex.Message);
                }
            } while (!isValidInput);

            return plateNumber;
        }
        

        public static bool CheckIfOnlyString(string i_StringInput)
        {
            bool isValidLetters = true;
            int i = 0;

            while (i < i_StringInput.Length && isValidLetters)
            {
                char currentChar = (char)i_StringInput[i];
                isValidLetters = ((currentChar >= 'a' && currentChar <= 'z') || (currentChar >= 'A' && currentChar <= 'Z'));
                i++;
            }

            return isValidLetters;
        }

        public static eVehicleStatus GetStatusChoice()
         {
             Console.WriteLine("Choose a status:");
             foreach (eVehicleStatus status in Enum.GetValues(typeof(eVehicleStatus)))
             {
                 Console.WriteLine($"{(int)status}. {status}");
             }

             int choice;
             while (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(eVehicleStatus), choice))
             {
                 Console.WriteLine("Invalid choice. Please enter a valid status number.");
             }

             return (eVehicleStatus)choice;
         }

         static List<AbstractVehicle> FilterByStatus(List<AbstractVehicle> i_Vehicles, eVehicleStatus i_Status)
         {
             return i_Vehicles.Where(v => v.VehicleStatus == i_Status).ToList();
         }

        public static void NewVehicleReceptionToGarage(int i_ValidPlateNumberInput, Garage i_Garage)
            {
                bool isValidInput;
             
                do
                {
                    isValidInput = true;
                    try
                    {
                        int counterIndex = 1, vehicleListLength = 0;

                        List<string> VehicleTypes = GarageLogic.Factory.GetVehicleTypes();
                        vehicleListLength = VehicleTypes.Count;
                        foreach (string type in VehicleTypes)
                        {
                            Console.WriteLine("{0}. {1}", counterIndex, type);
                            counterIndex++;
                        }
                        Console.WriteLine("Enter A Number to choose from the Options Above:");
                        Console.Write("Enter your choice (1-{0}): ", vehicleListLength);
                        int choice = int.Parse(Console.ReadLine());
                        if (choice < 1 || choice > vehicleListLength)
                        {
                            throw new GarageLogic.ValueOutOfRangeException(1, vehicleListLength);
                        }

                        Console.WriteLine($"You selected option {choice}.");
                        GarageLogic.AbstractVehicle vehicle = GarageLogic.Factory.CreateVehicle(choice);
                        string modelNameInput;
                        int inputAirPressure, inputEnergyPrecentge;
                        Console.WriteLine("Enter the Model Of Your Vehicle :");
                        modelNameInput = Console.ReadLine();
                        if (!CheckIfOnlyString(modelNameInput))
                        {
                            throw new FormatException("Model name must contain only alphabetical characters.");
                        }

                        Console.WriteLine("Model name is valid:" + modelNameInput);
                        vehicle.LicenseNumber = i_ValidPlateNumberInput;
                        vehicle.ModelName = modelNameInput;
                        Console.WriteLine("Enetr Vehicle Owner Name:");
                        string nameInput = Console.ReadLine();
                        vehicle.VehicleOwner.OwnerName = nameInput;
                        Console.WriteLine("Enetr Vehicle Owner Phone:");
                        string phoneInput = Console.ReadLine();
                        vehicle.VehicleOwner.PhoneNumber = phoneInput;
                        Console.WriteLine("Enter The Manufacturer Name Of Vehicle Wheels: ");
                        string ManufacturerName = Console.ReadLine();
                        vehicle.SetManfactureNameForAllWheels(ManufacturerName);
                        Console.WriteLine("Enter the Air Pressure in Your Wheels: ");
                        inputAirPressure = int.Parse(Console.ReadLine());
                        vehicle.SetWheelsInputAirPressure(inputAirPressure);
                        Console.WriteLine("Enter The Precentege Left In Your Energy Source At Your Vehicle: ");
                        inputEnergyPrecentge = int.Parse(Console.ReadLine());
                        vehicle.EnergyStatePrecentge = inputEnergyPrecentge;
                        eNumberOfDoorsInCar numberCarDoors;
                        eCarColor carColor;
                        eLicenseType licenseType;
                        switch (vehicle)
                        {
                            case AbstractCar _:
                                Console.WriteLine("Choose the number of doors for your car:");
                                foreach (eNumberOfDoorsInCar doors in Enum.GetValues(typeof(eNumberOfDoorsInCar)))
                                {
                                    Console.WriteLine($"{(int)doors}. {doors}");
                                }
                                
                                string doorsInput = Console.ReadLine();
                                Enum.TryParse(doorsInput, true, out numberCarDoors);
                                ((AbstractCar)vehicle).NumberOfDoors = numberCarDoors;
                                Console.WriteLine("Enter The Color Of Your Car: ");
                                foreach (eCarColor color in Enum.GetValues(typeof(eCarColor)))
                                {
                                    Console.WriteLine($"{(int)color}. {color}");
                                }
                                
                                string colorInput = Console.ReadLine();
                                Enum.TryParse(colorInput, true, out carColor);
                                ((AbstractCar)vehicle).Color = carColor;
                                break;

                            case AbstractMotorcycle _:
                                Console.WriteLine("Enter The License Type: ");
                                foreach (eLicenseType licencetypes in Enum.GetValues(typeof(eLicenseType)))
                                {
                                    Console.WriteLine($"{(int)licencetypes}. {licencetypes}");
                                }
                                
                                string licenseTypeInput = Console.ReadLine();
                                Enum.TryParse(licenseTypeInput, true, out licenseType);
                                ((AbstractMotorcycle)vehicle).LicenseType = licenseType;
                                Console.WriteLine("Enter The Motorcycle Engin Capacity: ");
                                int EnginCapacityInput = int.Parse(Console.ReadLine());
                                ((AbstractMotorcycle)vehicle).EngineCapacity = EnginCapacityInput;
                                break;

                            case AbstractTruck _:
                                Console.WriteLine("Enter 1 if the truck contains hazardous materials, or Any Key otherwise:");
                                string containDangerousMaterialsInput = Console.ReadLine();
                                bool containsHazardousMaterials = (containDangerousMaterialsInput == "1");
                                ((AbstractTruck)vehicle).IsContainingHazardousMaterials = containsHazardousMaterials;
                                Console.WriteLine("Enter The Cargo Volume Of The Truck :");
                                float cargoVolumeInput = float.Parse(Console.ReadLine());
                                ((AbstractTruck)vehicle).CargoVolume = cargoVolumeInput;
                                break;
                        }
                    i_Garage.AddVehicle(vehicle);
                    }

                    catch (FormatException ex)
                    {
                        isValidInput = false;
                        Console.Clear();
                        Console.WriteLine("Error: {0}", ex.Message);
                    }

                    catch (GarageLogic.ValueOutOfRangeException ex)
                    {
                        isValidInput = false;
                        Console.Clear();
                        Console.WriteLine("Error: Value out of range. Please enter a number between {0} and {1}.", ex.MinValue, ex.MaxValue);
                    }

                    catch (ArgumentException ex)
                    {
                        isValidInput = false;
                        Console.Clear();
                        Console.WriteLine("Error: {0}", ex.Message);
                    }

                    catch (Exception ex)
                    {
                        isValidInput = false;
                        Console.Clear();
                        Console.WriteLine("An error occurred: {0}", ex.Message);
                    } 
                } while (!isValidInput);
            }
        }
}
