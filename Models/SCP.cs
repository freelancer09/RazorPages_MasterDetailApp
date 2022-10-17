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
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string ObjectClass { get; set; } = string.Empty;
        
        [Required]
        [StringLength(60)]
        public string Classification { get; set; } = string.Empty;

        [Required]
        [StringLength(5000, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(5000)]
        public string Containment { get; set; } = string.Empty;
        
        public string ImageName { get; set; } = string.Empty;

    }
}