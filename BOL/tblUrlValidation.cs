using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tblUrlValidation
    {
        [Required]
        public string UrlTitle { get; set; }
        [Required]
        [Url]
        [UniqueUrl]
        public string Url { get; set; }
        [Required]
        public string UrlDesc { get; set; }
    }

    internal class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string urlValue = value.ToString();
            int count = db.tbl_Url.Count(x => x.Url.Equals(urlValue));

            if (count != 0)
            {
                return new ValidationResult("The url already exist.");
            }
            return ValidationResult.Success;
        }
    }

    [MetadataType(typeof(tblUrlValidation))]
    public partial class tbl_Url { }
}
