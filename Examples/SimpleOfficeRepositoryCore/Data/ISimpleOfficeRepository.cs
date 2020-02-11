using SimpleOfficeRepositoryCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOfficeRepositoryCore.Data
{
    public interface ISimpleOfficeRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Desk
        Task<Desk[]> GetAllDesksAsync(bool includeOwner = false, bool includeRoom = false);
        Task<Desk> GetDeskAsync(int deskId, bool includeOwner, bool includeRoom = false);

        // Office
        Task<Office[]> GetAllOfficesAsync();
        Task<Office> GetOfficeAsync(int officeId, bool includeEmployees = false);

        // Person
        Task<Person[]> GetAllPersonsAsync();
        Task<Person> GetPersonAsync(int personId);

        // Room
        Task<Room[]> GetAllRoomsAsync(bool includeDesks = false);
        Task<Room> GetRoomAsync(int roomId);
    }
}
