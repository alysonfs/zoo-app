using ZooApp.WebAPI.Domain;

namespace ZooApp.WebAPI.Controller.Contract
{
    public interface IZooRepository
    {
        Task<IEnumerable<Zoo>> GetZoos();
        Task<Zoo?> GetZooByUUID(string uuid);
        Task<Zoo> AddZoo(Zoo zoo);
    }
}