namespace StudiesAPI.Domain.Entities
{
    public class Guest : Entity<int>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
