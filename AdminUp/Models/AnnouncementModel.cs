using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class AnnouncementModel
    {
        public int Id { get; set; }
        public int BuilidingId { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
