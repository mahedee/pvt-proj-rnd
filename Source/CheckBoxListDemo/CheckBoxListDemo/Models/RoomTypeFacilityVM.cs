using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Models
{
    public class RoomTypeFacilityVM
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }

        public List<RoomType> RoomTypes { get; set; }
        public List<Facility> Facilities { get; set; }
    }
}