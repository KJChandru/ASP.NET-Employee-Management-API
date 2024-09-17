using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class Employee
    {
        
        public int Id {  get; set; }
        
        [Required (ErrorMessage="FirstName is required")]        
        public string FirstName{  get; set; }
        
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }
    }
}
