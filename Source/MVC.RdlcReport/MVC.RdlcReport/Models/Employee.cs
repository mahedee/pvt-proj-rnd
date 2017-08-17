using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.RdlcReport.Models
{
    public class Employee
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int DesignationId { get; set; }
        
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}