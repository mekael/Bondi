using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Models
{
    public class Author : BaseModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
