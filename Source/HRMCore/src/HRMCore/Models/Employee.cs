﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMCore.Models
{
    public class Employee
    {
        public Employee()
        {
            ActionDate = DateTime.Now;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee Code")]
        public string EmpCode { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
