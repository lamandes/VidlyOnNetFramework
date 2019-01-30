using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VidlyOnNetFramework.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set;}
        //Navigation Type
        public MembershipType MembershipType { get; set; }
        //Foreign Key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Column(TypeName="Date")]
        [Display(Name ="Date Of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}