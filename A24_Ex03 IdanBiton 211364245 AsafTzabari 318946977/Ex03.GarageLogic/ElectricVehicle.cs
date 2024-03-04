using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle
    {
        float m_TimeLeftOnBattery;
        float m_MaxBatteryLifeInHouers; 

        public ElectricVehicle(float i_inputNumber)
        {
             m_MaxBatteryLifeInHouers = i_inputNumber;
        }

        public ElectricVehicle()
        {
           
        }

        public float TimeLeftOnBattery
        {
            get 
            {
                return m_TimeLeftOnBattery;
            }

            set
            {
                m_TimeLeftOnBattery = value;
            }
        }

             
        public float MaxBatteryLifeInHouers
        {
            get
            {
                return m_MaxBatteryLifeInHouers;
            }
        }
    }
}
