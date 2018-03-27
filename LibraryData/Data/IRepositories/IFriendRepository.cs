using LibraryData.Models;

namespace LibraryData.Data.IRepositories
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {
        Friend GetById(int id);
        Friend GetByName(string name);
        void Remove(int id);
    }
}
