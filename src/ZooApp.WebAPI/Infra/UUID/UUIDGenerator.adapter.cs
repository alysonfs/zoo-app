using ZooApp.WebAPI.Data.Contract;

namespace ZooApp.WebAPI.Infra.UUID
{
    public class UUIDGenerator : IUUIDGererator
    {
        public string Generate()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}