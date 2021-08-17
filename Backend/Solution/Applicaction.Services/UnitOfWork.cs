using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaction.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork( DbContext context)
        {
            shoppingService = new ShoppingService(context);//Seguridad
        }

        public IShoppingService shoppingService { get; private set; }

    }
}
