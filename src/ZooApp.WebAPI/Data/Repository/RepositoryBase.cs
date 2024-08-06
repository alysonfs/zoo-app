using ZooApp.WebAPI.Data.Contract;

namespace ZooApp.WebAPI.Data.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly ZooContext _context;
        protected readonly IUUIDGererator _uuidGenerator;

        public RepositoryBase(ZooContext context, IUUIDGererator uuidGenerator)
        {
            _context = context;
            _uuidGenerator = uuidGenerator;
        }
    }
}