using System.ComponentModel.DataAnnotations;
using System;

namespace testCore.Models
{
    public class Digital_credit_card
    {
        [Key]
        public int CARD_ID {get; set;}

        [Required(ErrorMessage = "The card number is mandatory")]
        [StringLength(16, ErrorMessage = "The carb number should have 16 characters")]
        public string? CARD_Number {get; set;}//Why complains about null if is required??

        [Required(ErrorMessage = "ID is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ID")]
        public int CARD_USER_ID {get; set;}
        public Users? Users {get; set;} //Why complains about null if is required??
    }
}