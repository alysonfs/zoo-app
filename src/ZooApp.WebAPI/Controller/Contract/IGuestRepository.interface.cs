using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller.Contract
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetGuests();
        Task<Guest?> GetGuestById(int id);    
        Task<Guest?> GetGuestByUUID(string id);    
        Task<Guest> AddGuest(Guest guest);
    }
}