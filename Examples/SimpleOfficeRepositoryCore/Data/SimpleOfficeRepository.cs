using Microsoft.Extensions.Logging;
using SimpleOfficeRepositoryCore.Data.Entities;
using System.Threading.Tasks;

namespace SimpleOfficeRepositoryCore.Data
{
    public class SimpleOfficeRepository : ISimpleOfficeRepository
    {
        private OfficeContext _context;
        private ILogger<OfficeContext> _logger;

        public SimpleOfficeRepository(OfficeContext context, ILogger<OfficeContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Desk[]> GetAllDesksAsync(bool includeOwner = false, bool includeRoom = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Office[]> GetAllOfficesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Person[]> GetAllPersonsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Room[]> GetAllRoomsAsync(bool includeDesks = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Desk> GetDeskAsync(int deskId, bool includeOwner, bool includeRoom = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Office> GetOfficeAsync(int officeId, bool includeEmployees = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetPersonAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetRoomAsync(int roomId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
