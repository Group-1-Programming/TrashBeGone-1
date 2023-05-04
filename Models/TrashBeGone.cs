using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrashBeGone.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        // other admin-related properties
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ContactPerson { get; set; }
        // other company-related properties
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public string Company { get; set; }
        // other user-related properties
    }

    public class CompanyUser
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        // other properties, such as date added, etc.
    }

    

 


}
