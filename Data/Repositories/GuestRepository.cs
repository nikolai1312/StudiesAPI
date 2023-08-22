using StudiesAPI.Data.Interfaces;
using StudiesAPI.Entities;

namespace StudiesAPI.Data.Repositories
{
    public class GuestRepository : Repository<Guest, Guid>, IGuestRepository
    {
        public GuestRepository(Context context) : base(context)
        {
        }
    }
}
