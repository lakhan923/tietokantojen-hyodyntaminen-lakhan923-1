﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Model
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [Column("MemberId")]
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
