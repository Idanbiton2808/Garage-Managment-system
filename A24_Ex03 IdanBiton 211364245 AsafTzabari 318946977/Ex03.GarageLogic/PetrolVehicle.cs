using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class PetrolVehicle
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelQuantityInLiters;
        private float m_MaxFuelQuantityInLiters;

        public PetrolVehicle(float i_InputNumber, eFuelType i_FuelType)
        {
            m_MaxFuelQuantityInLiters = i_InputNumber;
            r_FuelType = i_FuelType;
        }

        public float CurrentFuelQuantityInLiters
        {
            get
            {
                return m_CurrentFuelQuantityInLiters;
            }

            set
            {
                m_CurrentFuelQuantityInLiters = value;
            }
        }

        public float MaxFuelQuantityInLiters
        {
            get
            {
                return m_MaxFuelQuantityInLiters;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
    }
}
