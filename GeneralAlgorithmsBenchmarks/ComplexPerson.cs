namespace GeneralAlgorithmsBenchmarks
{
    public class Birthday { public int Year; public int Month; public int Day; }

	public class Address { public string City; public string Street; public string ZipCode; }

	public class ComplexPerson
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string Nickname { get; set; }

        public Birthday Birthday { get; set; }

        public Address Address { get; set; }
    }
}