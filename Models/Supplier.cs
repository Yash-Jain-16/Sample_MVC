using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }

        public string Contact { get; set; }

        public string City { get; set; }
    }
}
