using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {

        private static readonly List<string> m_TypeOfVehicles = new List<string>
        {
            "Petrol-Motorcycle",
            "Electric-Motorcycle",
            "Petrol-Car",
            "Electric-Car",
            "Petrol-Truck"
        };


       
        public static List<string> GetVehicleTypes()
        {
            return m_TypeOfVehicles;
        }

        
        public static AbstractVehicle CreateVehicle(int vehicleType)
        {
            AbstractVehicle vehicle;

            switch (vehicleType)
            {
                case 1:
                    vehicle = (AbstractVehicle) new PetrolMotorcycle();
                    vehicle.petrolVehicle = new PetrolVehicle(5.8f, eFuelType.Octan98);
                    vehicle.VehicleOwner = new VehicleOwner();
                    break;
                case 2:
                    vehicle = (AbstractVehicle) new ElectricMotorcycle();
                    vehicle.electricVehicle = new ElectricVehicle(2.8f);
                    vehicle.VehicleOwner = new VehicleOwner();
                    break;
                case 3:
                    vehicle = (AbstractVehicle) new PetrolCar();
                    vehicle.petrolVehicle = new PetrolVehicle(58f, eFuelType.Octan95);
                    vehicle.VehicleOwner = new VehicleOwner();
                    break;
                case 4:
                    vehicle = (AbstractVehicle) new ElectricCar();
                    vehicle.electricVehicle = new ElectricVehicle(4.8f);
                    vehicle.VehicleOwner = new VehicleOwner();
                    break;
                case 5:
                    vehicle = (AbstractVehicle) new PetrolTruck();
                    vehicle.petrolVehicle = new PetrolVehicle(110f, eFuelType.Soler);
                    vehicle.VehicleOwner = new VehicleOwner();
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            return vehicle;
        }


    }
}
