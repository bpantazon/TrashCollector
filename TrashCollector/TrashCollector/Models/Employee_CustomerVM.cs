using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee_CustomerVM
    {
        public Customer Customer { get; set; }
        public Employee CurrentEmployee { get; set; }
    }
}