using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaction.Services
{
     public   interface IUnitOfWork
    {
        IShoppingService shoppingService { get; }
    }
}
