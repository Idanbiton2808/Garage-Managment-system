using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class AbstractTruck : AbstractVehicle
    {

        private bool m_IsContainingHazardousMaterials;
        private float m_CargoVolume;
        
        public AbstractTruck()
        {
            int numberOfWheelsToAdd = 12;

            foreach (int i in Enumerable.Range(1, numberOfWheelsToAdd))
            {
                Wheel newWheel = new Wheel(28);
               this.Wheels.Add(newWheel);
            }
        }

        public bool IsContainingHazardousMaterials
        {
            get
            {
                return m_IsContainingHazardousMaterials;
            }

            set
            {
                m_IsContainingHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                if (value > 0)
                {
                    m_CargoVolume = value;
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
                wheel.AirPressure = i_InputAirPressure;
            }
        }

    }
}
