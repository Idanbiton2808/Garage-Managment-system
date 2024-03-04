using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private string m_OwnerName;
        private string m_PhoneNumber;

        public VehicleOwner()
        {

        }

        public string OwnerName
        {
            get 
            { 
                return m_OwnerName; 
            }

            set
            {
                m_OwnerName = value;    
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }
    }
}
