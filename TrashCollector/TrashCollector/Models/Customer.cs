using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Pickup Day")]
        [ForeignKey("PickupDay")]
        public int PickupId { get; set; }
        public virtual PickupDay PickupDay { get; set; }
        public IEnumerable<PickupDay> PickupDays { get; set; }

        [DisplayName("Extra Pickup")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ExtraPickup { get; set; }

        public bool ExtraPickupConfirmed { get; set; }

        public decimal Balance { get; set; }

        public bool PickupConfirmed { get; set; }

        [DisplayName("Suspend Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SuspendStart { get; set; }

        [DisplayName("Suspend End")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SuspendEnd { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }
       
        public int Zip { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        
    }
}