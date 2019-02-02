using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        //Foreign Key
        public byte MembershipTypeId { get; set; }

        //[Check18YrsOld] 
        public DateTime? BirthDate { get; set; }

    }
}