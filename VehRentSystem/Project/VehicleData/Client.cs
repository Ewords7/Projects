namespace Project.VehicleData
{
    class Client
    {
        public long? PersonalNumber { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public Client(long? personID = null, string name = null, string surename = null, string birthDate = null, string address = null,
            string city = null)
        {
            PersonalNumber = personID;
            Name = name;
            Surename = surename;
            DateOfBirth = birthDate;
            Address = address;
            City = city;  
        }
    }
}
