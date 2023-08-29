namespace StudiesAPI.Domain.Entities
{
    public class Concert : Entity<int>
    {
        public string Name { get; set; }

        public string Year { get; set; }

        public string Address { get; set; }
    }
}
