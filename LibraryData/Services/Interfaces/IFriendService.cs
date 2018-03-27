using LibraryData.Models;

namespace LibraryData.Services.Interfaces
{
    public interface IFriendService : IGenericService<Friend>
    {
        Friend GetById(int id);
        Friend GetByName(string name);
        void Remove(int id);

    }
}
