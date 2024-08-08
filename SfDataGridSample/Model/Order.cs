using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Model
{
    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string? ShipCity { get; set; }
    }

}
