using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElwaldeEquipment.Model
{
    public class SenderModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
