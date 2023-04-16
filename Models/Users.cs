using System.ComponentModel.DataAnnotations;

namespace testCore.Models
{
    public class Users
    {
        [Key]
        public int USER_ID {get; set;}

        [RequiredAttribute(ErrorMessage = "Is necessary an email")]
        [MaxLength(120, ErrorMessage = "The email should have between 10 and 120 characters")]
        [MinLength(10, ErrorMessage = "The email should have between 10 and 120 characters")]
        public string USER_Email {get; set;} //Why complains about null if is required??
    }
}