using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.DTOs
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? FamilyId { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Role { get; set; }
        public bool Verified { get; set; }

    }
}