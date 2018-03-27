using LibraryData.Data.IRepositories;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryData.Data.Repositories
{
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        public FriendRepository(LibraryContext context) : base(context)
        {

        }

        public Friend GetById(int id)
        {
            return Context.Friends
                .AsNoTracking()
                .Where(f => f.Id == id)
                .FirstOrDefault();
        }

        public Friend GetByName(string name)
        {
            return Context.Friends.Where(f => f.Name.ToUpperInvariant().Equals(name.ToUpperInvariant())).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Context.Friends.Remove(Context.Friends.FirstOrDefault(f => f.Id == id));
            Context.SaveChanges();
        }
    }
}
