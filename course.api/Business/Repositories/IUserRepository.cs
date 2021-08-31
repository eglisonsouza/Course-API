using System.Threading.Tasks;
using course.api.Business.Entities;

namespace course.api.Business.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
    }
}