using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class AbstractVehicle
    {
        private int m_LicenseNumber;
        private string m_ModelName;
        private List<Wheel>  m_Wheels;
        private VehicleOwner m_VehicleOwner;
        private  eVehicleStatus m_VehicleStatus;
        private float m_EnergyStatePrecentge;
        private PetrolVehicle m_petrolVehicle = null;
        private ElectricVehicle m_electricVehicle = null;

        public PetrolVehicle petrolVehicle
        {
            get
            {
                return m_petrolVehicle;
            }

            set
            {
                m_petrolVehicle = value;
            }
        }

        public ElectricVehicle electricVehicle
        {
            get
            {
                return m_electricVehicle;
            }

            set
            {
                m_electricVehicle = value;
            }
        }


        public AbstractVehicle()
        {
            m_Wheels = new List<Wheel>();
        }

        public int LicenseNumber
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

        public List<Wheel> Wheels
        {
            get 
            {
                return m_Wheels;
            }

            set 
            {
                m_Wheels = value;
            }
        }

        public VehicleOwner VehicleOwner
        {
            get 
            {
                return m_VehicleOwner; 
            }

            set 
            {
                m_VehicleOwner = value;
            }
        }

        public float EnergyStatePrecentge
        {
            get
            {
                return m_EnergyStatePrecentge; 
            }

            set
            {
                if((value < 0) || (value > 100))
                {
                    throw new GarageLogic.ValueOutOfRangeException(0, 100);
                }

                m_EnergyStatePrecentge = value;
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

        public abstract void SetWheelsInputAirPressure(int i_InputAirPressure);

        public void Refuling(eFuelType i_FuelType, float i_AmountInLiters)
        {
            float amountInPrecetege = ((i_AmountInLiters / this.petrolVehicle.MaxFuelQuantityInLiters) * 100);

           if (100 >= ((amountInPrecetege) + this.EnergyStatePrecentge))
            {
                this.EnergyStatePrecentge = (amountInPrecetege + this.EnergyStatePrecentge);
            }

           else
            {
                throw new ArgumentException("Error : Putting more fuel than possible");
            }
        }

        public void Charging(float i_AmountInMinutes)
        {
            float amountInPrecetege = ((i_AmountInMinutes / (this.electricVehicle.MaxBatteryLifeInHouers*60)) * 100);

            if (100 >= (amountInPrecetege) + this.EnergyStatePrecentge)
            {
                this.EnergyStatePrecentge = (amountInPrecetege / this.EnergyStatePrecentge);
            }

            else
            {
                throw new ArgumentException("Error : Putting more charge life than possible");
            }
        }
        public void InflateWheelsAirPressureToMax()
        {
            foreach(Wheel wheel in this.Wheels)
            {
                wheel.AirPressure = wheel.MaxAirPressure;
            }
        }

        public void SetManfactureNameForAllWheels(string i_ManafactureNameStringInput)
        {
            foreach (Wheel wheel in this.Wheels)
            {
                wheel.ManufacturerName = i_ManafactureNameStringInput;
            }
        }

    }
}
