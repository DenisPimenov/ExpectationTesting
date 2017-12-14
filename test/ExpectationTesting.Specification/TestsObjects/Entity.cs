namespace ExpectationTesting.Specification.TestsObjects
{
    public class Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public Entity()
        {
            Address = new Address();
        }
    }

    public class Address
    {
        public string Name { get; set; }
    }
}