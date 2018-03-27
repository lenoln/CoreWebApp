using LibraryData.Data.IRepositories;
using LibraryData.Models;
using LibraryData.Services.Interfaces;

namespace LibraryData.Services
{
    public class FriendService : GenericService<Friend>, IFriendService
    {
        private new IFriendRepository Repository => Repository;
        private readonly LibraryContext DBLibraryContext;

        public FriendService(IFriendRepository repository,
            LibraryContext libraryContext) : base(repository)
        {
            DBLibraryContext = libraryContext;
        }

        public Friend GetById(int id)
        {
            return Repository.GetById(id);
        }

        public Friend GetByName(string name)
        {
            return Repository.GetByName(name);
        }

        public void Remove(int id)
        {
            Repository.Remove(id);
        }
    }
}
