using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tblUserValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
    }

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string emailValue = value.ToString();
            int count = db.tbl_User.Count(x => x.UserEmail.Equals(emailValue));
            if (count != 0)
            {
                return new ValidationResult("Email already exist.");
            }
            return ValidationResult.Success;
        }
    }

    [MetadataType(typeof(tblUserValidation))]
    public partial class tbl_User
    {

        public string ConfirmPassword { get; set; }
    }
}
