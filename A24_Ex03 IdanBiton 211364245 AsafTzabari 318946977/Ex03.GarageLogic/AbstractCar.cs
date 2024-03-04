using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class AbstractCar : AbstractVehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoorsInCar m_NumberOfDoors;

        public AbstractCar()
        {
            int numberOfWheelsToAdd = 5;

            foreach (int i in Enumerable.Range(1, numberOfWheelsToAdd))
            {
                Wheel newWheel = new Wheel(30);
                this.Wheels.Add(newWheel);
            }
        }

        public eCarColor Color
        {
            get 
            {
                return m_Color;
            }

            set
            {
                if (Enum.IsDefined(typeof(eCarColor), value))
                {
                    m_Color = value;
                }

                else
                {
                    throw new ArgumentException("Invalid color value");
                }
            }
        }

        public eNumberOfDoorsInCar NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;    
            }

            set
            {
                if (Enum.IsDefined(typeof(eNumberOfDoorsInCar), value))
                {
                    m_NumberOfDoors = value;
                }

                else
                {
                    throw new ArgumentException("Invalid color value");
                }
            }
        }

        public override void SetWheelsInputAirPressure(int i_InputAirPressure)
        {
            foreach (Wheel wheel in this.Wheels)
            {
                wheel.AirPressure = i_InputAirPressure;
            }
        }
    }
}
