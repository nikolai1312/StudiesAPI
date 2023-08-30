namespace StudiesAPI.Domain.Entities
{
    public class Band : Entity<int>
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}
