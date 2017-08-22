using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Models
{
    public class RoomType
    {
        public RoomType()
        {
            this.Facilities = new HashSet<Facility>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Room Type")]
        public string Name { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}