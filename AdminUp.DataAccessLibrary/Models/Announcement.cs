using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public int BuilidingId { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
