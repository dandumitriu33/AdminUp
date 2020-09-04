using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        //[MaxLength(150)] // if you want to change the type customize it as below
        [Column(TypeName = ("varchar(150)"))]
        public string Email { get; set; }
    }
}
