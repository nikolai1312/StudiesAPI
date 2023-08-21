namespace StudiesAPI.Entities
{
    public class Guest : Entity<Guid>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
