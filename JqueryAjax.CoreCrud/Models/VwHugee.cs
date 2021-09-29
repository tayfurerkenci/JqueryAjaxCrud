using System;
using System.Collections.Generic;

#nullable disable

namespace JqueryAjax.CoreCrud.Models
{
    public partial class VwHugee
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
