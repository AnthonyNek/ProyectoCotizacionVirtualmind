using Application.Dto;
using Application.Repositories;
using Application.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Applicaction.Services
{
    public class ShoppingService: IShoppingService
    {
        public ShoppingService(DbContext dbContext)
        {
            shoppingRepository = new ShoppingRepository(dbContext);
        }
        public IShoppingRepository shoppingRepository { get; private set; }

         public async Task<int > Save(DtoShopping dtoShopping)
        {
            return await shoppingRepository.Save(JsonSerializer.Deserialize<Shopping>(JsonSerializer.Serialize(dtoShopping)));
        }

    }
}
