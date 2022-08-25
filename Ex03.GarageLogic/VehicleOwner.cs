namespace Ex03.GarageLogic
{
    public struct VehicleOwner
    {
        private string m_Name;
        private string m_PhoneNumber;

        public string Name
        {
            get 
            {
                return this.m_Name;
            }
            set 
            {
                this.m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get 
            {
                return this.m_PhoneNumber;
            }
            set 
            {
                this.m_PhoneNumber = value;
            }
        }
    }
}
