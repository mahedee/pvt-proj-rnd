using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Models
{
    public class FacilityVM
    {
        public int Id { get; set; }
        public string FacilityName { get; set; }
        public bool IsChecked { get; set; }
    }
}