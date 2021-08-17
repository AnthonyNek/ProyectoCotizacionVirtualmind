using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaction.Services
{
    public   interface IShoppingService
    {
        Task<int> Save(DtoShopping dtoShopping);
    }
}
