using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Repositories.Models
{
    public partial class Shopping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double? Amount { get; set; }
        public string IdentificatorOfMoney { get; set; }

        public virtual User User { get; set; }
    }
}
