using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Exceptions
{
    public class WrongFuelTypeException : Exception
    {
        private string m_ErrorMessage;

        public WrongFuelTypeException()
        {
            this.m_ErrorMessage = "There was an attempt to fill the wrong fuel type.";
        }

        public override string Message => this.m_ErrorMessage;
    }
}
