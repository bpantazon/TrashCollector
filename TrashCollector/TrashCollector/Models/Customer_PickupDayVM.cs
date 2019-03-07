using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.Models
{
    public class Customer_PickupDayVM
    {
        public Customer Customer { get; set; }
        public PickupDay PickupDay { get; set; }
    }
}