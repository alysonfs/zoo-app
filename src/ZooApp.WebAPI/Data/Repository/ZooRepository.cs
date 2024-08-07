using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Data.Model;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Repository
{
    public class ZooRepository : RepositoryBase, IZooRepository
    {
        public ZooRepository(ZooContext context, IUUIDGererator uuidGenerator) : base(context, uuidGenerator){}
        public async Task<Zoo> AddZoo(Zoo zoo)
        {
            var newZoo = new ZooModel()
            {
                UUID = _uuidGenerator.Generate(),
                Name = zoo.Name,
                Address = zoo.Address
            };

            await _context.Zoos.AddAsync(newZoo);
            await _context.SaveChangesAsync();
            return newZoo;
        }

        public async Task<Zoo?> GetZooByUUID(string uuid)
        {
            var zoo = await _context.Zoos.FirstOrDefaultAsync(z => z.UUID == uuid);
            return zoo;
        }

        public async Task<IEnumerable<Zoo>> GetZoos()
        {
            var zoos = await _context.Zoos.ToListAsync();
            return zoos;
        }
    }
}