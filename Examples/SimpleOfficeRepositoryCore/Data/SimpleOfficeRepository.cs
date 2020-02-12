using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleOfficeRepositoryCore.Data.Entities;
using System.Linq;
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
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Desk[]> GetAllDesksAsync(bool includeOwner = false, bool includeRoom = false)
        {
            IQueryable<Desk> query = _context.Desks;

            if (includeOwner)
            {
                query = query.Include(a => a.Owner);
            }

            if (includeRoom)
            {
                query = query.Include(a => a.Room);
            }

            return await query.OrderByDescending(a => a.DeskId).ToArrayAsync();
        }

        public async Task<Office[]> GetAllOfficesAsync()
        {
            return await _context.Offices.OrderByDescending(a => a.OfficeId).ToArrayAsync();
        }

        public async Task<Person[]> GetAllPersonsAsync()
        {
            return await _context.People.OrderByDescending(a => a.PersonId).ToArrayAsync();
        }

        public async Task<Room[]> GetAllRoomsAsync(bool includeDesks = false)
        {
            IQueryable<Room> query = _context.Rooms;
            if (includeDesks)
            {
                query = query.Include(a => a.Desks);
            }

            return await query.OrderByDescending(a => a.RoomId).ToArrayAsync();

        }

        public async Task<Desk> GetDeskAsync(int deskId, bool includeOwner, bool includeRoom = false)
        {
            IQueryable<Desk> query = _context.Desks.Where(a => a.DeskId == deskId);
            if (includeOwner)
            {
                query = query.Include(a => a.Owner);
            }
            if (includeRoom)
            {
                query = query.Include(a => a.Room);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Office> GetOfficeAsync(int officeId, bool includeEmployees = false)
        {
            IQueryable<Office> query = _context.Offices.Where(a => a.OfficeId == officeId);
            if (includeEmployees)
            {
                query = query.Include(a => a.Employees);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person> GetPersonAsync(int personId)
        {
            IQueryable<Person> query = _context.People.Where(a => a.PersonId == personId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Room> GetRoomAsync(int roomId)
        {
            IQueryable<Room> query = _context.Rooms.Where(a => a.RoomId == roomId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Office> GetOfficeByCompanyNameAsync(string companyName)
        {
            IQueryable<Office> query = _context.Offices.Where(a => a.CompanyName == companyName);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person> GetPersonByUniqeAsync(string firstName, string surename)
        {
            IQueryable<Person> query = _context.People.Where(a => a.FirstName == firstName
            && a.Surename == surename);

            return await query.FirstOrDefaultAsync();
        }
    }
}
