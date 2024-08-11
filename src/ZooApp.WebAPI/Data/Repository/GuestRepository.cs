using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Data.Model;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Repository
{
    public class GuestRepository : RepositoryBase , IGuestRepository
    {
        public GuestRepository(ZooContext context, IUUIDGererator uuidGenerator) : base(context, uuidGenerator){ }
        
        public async Task<Guest> AddGuest(string zooUUID, Guest guest)
        {
            if(string.IsNullOrEmpty(zooUUID))
            {
                throw new ArgumentNullException(nameof(zooUUID));
            }

            var newGuest = new GuestModel()
            {
                UUID = _uuidGenerator.Generate(),
                Name = guest.Name,
                Age = guest.Age,
                Email = guest.Email,
                ZooUUID = zooUUID
            };

            await _context.Guests.AddAsync(newGuest);
            await _context.SaveChangesAsync();
            return newGuest;
        }

        public async Task<Guest?> GetGuestById(int id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == id);
            return guest;
        }

        public async Task<Guest?> GetGuestByUUID(string uuid)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.UUID == uuid);
            return guest;
        }

        public async Task<IEnumerable<Guest>> GetGuests()
        {
            var guests = await _context.Guests.ToListAsync();
            return guests;
        }

        public async Task<IEnumerable<Guest>> GetGuestsByZooUUID(string zooUUID)
        {
            if(string.IsNullOrEmpty(zooUUID))
            {
                throw new ArgumentNullException(nameof(zooUUID));
            }

            var query = from guest in _context.Guests
                        join zoo in _context.Zoos on guest.ZooUUID equals zoo.UUID
                        where zoo.UUID == zooUUID
                        select guest;

            var guests = await query.ToListAsync();
            return guests;
        }
    }
}