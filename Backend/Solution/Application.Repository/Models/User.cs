using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Repositories.Models
{
    public partial class User
    {
        public User()
        {
            Shoppings = new HashSet<Shopping>();
        }

        public int Id { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Shopping> Shoppings { get; set; }
    }
}
