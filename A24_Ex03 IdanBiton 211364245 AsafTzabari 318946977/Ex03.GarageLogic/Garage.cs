using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic

{
    public class Garage
    {
        private List<AbstractVehicle> m_Vehicles;
   
        public Garage()
        {
            m_Vehicles = new List<AbstractVehicle>();
        }

        public List<AbstractVehicle> Vehicles
        {
            get 
            {
                return m_Vehicles;
            }
        }


        public AbstractVehicle GetVehicleDetailsByPlateNumber(int i_InputPlateNumber)
        { 

            return m_Vehicles.FirstOrDefault(vehicle => vehicle.LicenseNumber == i_InputPlateNumber);
        }

        public void AddVehicle(AbstractVehicle vehicle)
        {
            m_Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(AbstractVehicle i_Vehicle)
        {
            m_Vehicles.Remove(i_Vehicle);
        }

        public bool CheckIfIsAlreadyInGarage(int i_PlateNumber)
        {
            return m_Vehicles.Any(vehicle => vehicle.LicenseNumber == i_PlateNumber);
        }

        public void ChangeVehicleStatus(eVehicleStatus i_VehicleStatus,int  i_PlateNumber)
        {
            this.GetVehicleDetailsByPlateNumber(i_PlateNumber).VehicleStatus = i_VehicleStatus;
        }
    }
}
