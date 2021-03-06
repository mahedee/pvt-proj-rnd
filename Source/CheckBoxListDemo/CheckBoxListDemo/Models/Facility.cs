﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Models
{
    public class Facility
    {
        public Facility()
        {
            this.RoomTypes = new HashSet<RoomType>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Facility Name")]
        public string FacilityName { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}