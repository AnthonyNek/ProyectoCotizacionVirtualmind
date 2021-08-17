using Application.Repositories.Models;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IShoppingRepository
    {
        Task<int> Save(Shopping shopping);
    }
}
