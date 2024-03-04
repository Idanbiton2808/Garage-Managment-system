using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class AbstractMotorcycle : AbstractVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public AbstractMotorcycle()
        {
            int numberOfWheelsToAdd = 2;

            foreach (int i in Enumerable.Range(1, numberOfWheelsToAdd))
            {
                Wheel newWheel = new Wheel(29);
                this.Wheels.Add(newWheel);
            }
        }

        public eLicenseType LicenseType
        {
            get 
            { 
                return m_LicenseType;
            }

            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
                }

                else
                {
                    throw new ArgumentException("Invalid color value");
                }
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if (value > 0) 
                {
                    m_EngineCapacity = value;
                }

                else
                {
                    throw new ArgumentException("You Need To Enter A Positive Number!");
                }
            }
        }

        public override void SetWheelsInputAirPressure(int i_InputAirPressure)
        {
            foreach (Wheel wheel in this.Wheels)
            {
                wheel.WheelInflating(i_InputAirPressure);
            }
        }
    }
}
