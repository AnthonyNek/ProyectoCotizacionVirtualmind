using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public  class DtoUser
    {
        public DtoUser()
        {
            Shoppings = new HashSet<DtoShopping>();
        }

        public int Id { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DtoShopping> Shoppings { get; set; }
    }
}
