using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private int m_AirPressure;
        private readonly int r_MaxAirPressure;

        public Wheel(int i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
           get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value; 
            }     
        }

        public int AirPressure
        {
            get
            {
                return m_AirPressure;
            }

            set
            {
                m_AirPressure = value;
            }
        }

        public int MaxAirPressure
        {
            get 
            {
                return r_MaxAirPressure;
            }    
        }

        public void WheelInflating(int i_PressureAmount)
        {
            if ((this.MaxAirPressure < i_PressureAmount + this.AirPressure) || (i_PressureAmount < 0))
            {
                throw new GarageLogic.ValueOutOfRangeException(0, this.MaxAirPressure);
            }

            this.AirPressure = i_PressureAmount + this.AirPressure;
        }
    }
}

