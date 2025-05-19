using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Contact_Manager.Models
{
    public class Contact
    {
        //key
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Range(2010000000, 9899999999, ErrorMessage = "Please enter a valid 10 digit phone number.")]
        public long? Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; } = string.Empty;

        public DateTime Datetime { get; set; }
        public Contact()
        {
            if (Datetime == DateTime.MinValue)
            {
                Datetime = DateTime.Now;
            }
        }

        [Required(ErrorMessage = "Please enter a category.")]
        [Range(1,10000,ErrorMessage ="Must be greater than 0")]
        public int? CategoryID { get; set; } = null!;

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public string Slug => FirstName?.Replace(' ','-').ToLower() + '-' + LastName?.Replace(' ','-').ToLower();

        public string DateCreated()
        {
            string minutes = Datetime.Minute.ToString();
            string hours = Datetime.Hour.ToString();
            if (Datetime.Minute < 10) { minutes = $"0{Datetime.Minute}"; }
			if (Datetime.Hour > 12) { hours= $"{Datetime.Hour-12}"; }

			int minute = Datetime.Minute;
			string str = $"{Datetime.Month}/{Datetime.Day}/{Datetime.Year} at {hours}:{minutes}{Datetime.ToString("tt")}";
            return str;
        }
    }
}
