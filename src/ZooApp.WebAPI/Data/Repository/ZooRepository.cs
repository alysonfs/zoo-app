using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Data.Model;
using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Data.Repository
{
    public class ZooRepository : RepositoryBase, IZooRepository
    {
        public ZooRepository(ZooContext context, IUUIDGererator uuidGenerator) : base(context, uuidGenerator) { }
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
            if (string.IsNullOrEmpty(uuid))
            {
                throw new ArgumentNullException(nameof(uuid));
            }

            var query = from zoo in _context.Zoos
                        where zoo.UUID == uuid
                        select zoo;

            var zooList = await query.ToListAsync();
            return zooList.FirstOrDefault();
        }

        public async Task<IEnumerable<Zoo>> GetZoos()
        {
            var queryZoo = from zoo in _context.Zoos
                           join animal in _context.Animals on zoo.UUID equals animal.ZooUUID into zooAnimals
                           from zooAnimal in zooAnimals.DefaultIfEmpty()
                           join guest in _context.Guests on zoo.UUID equals guest.ZooUUID into zooGuests
                           from zooGuest in zooGuests.DefaultIfEmpty()
                           group new { zoo, zooAnimal, zooGuest } by new { zoo.UUID, zoo.Name, zoo.Address, zoo.ID } into zooGroup
                           select new Zoo
                           {
                               UUID = zooGroup.Key.UUID,
                               Name = zooGroup.Key.Name,
                               Address = zooGroup.Key.Address,
                               ID = zooGroup.Key.ID,
                               AnimalCount = zooGroup.Count(zg => zg.zooAnimal != null),
                               GuestCount = zooGroup.Count(zg => zg.zooGuest != null)
                           };

            var zooList = await queryZoo.ToListAsync();
            return zooList;
        }
    }
}