using Application.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ShoppingRepository : RepositoryEF<Shopping>,IShoppingRepository
    {
        public ShoppingRepository(DbContext context):base(context)
        {
            repositoryEF = new RepositoryEF<Shopping>(context);
        }
        public IRepositoryEF<Shopping> repositoryEF { get; set; }

        public async Task<int> Save(Shopping shopping)
        {
            try
            {
                return await repositoryEF.Insert(shopping);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
