using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public  class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_maxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_maxValue;
        }

        public float MaxValue
        {
            get 
            { 
                return m_MaxValue;
            }

            set 
            {
                m_MaxValue = value;
            } 
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }

            set
            {
                m_MinValue = value;
            }
        }
    } 

}
