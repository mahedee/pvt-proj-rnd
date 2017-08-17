﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMCore.Models
{
    public class Designation
    {
        public Designation()
        {
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Designation")]
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
