using backendpv.Models;

namespace backendpv.Repository
{
    public interface IManagerRepository
    {
        Task<Manager> Create(Manager admin);
        Task<Manager> Get(int id);

        Task Update(Manager admin);

        Task Delete(int id);
    }
}
