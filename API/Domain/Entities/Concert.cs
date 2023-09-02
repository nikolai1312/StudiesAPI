namespace StudiesAPI.Domain.Entities
{
    public class Concert : Entity<int>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }
    }
}
