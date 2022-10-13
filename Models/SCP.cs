using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDMasterDetail.Models
{
    public class SCP
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Object Class")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string ObjectClass { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Classification { get; set; } = string.Empty;
        
      
        [Required]
        [StringLength(1500, MinimumLength = 100)]
        public string Description { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(100)]
        public string Containment { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;

    }
}
