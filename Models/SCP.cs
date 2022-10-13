using System.ComponentModel.DataAnnotations;

namespace PDMasterDetail.Models
{
    public class SCP
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [StringLength(14, MinimumLength = 4)]
        [Required]
        public string ObjectClass { get; set; } = string.Empty;

        [StringLength(7, MinimumLength = 6)]
        public string Classification { get; set; } = string.Empty;

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = string.Empty;

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(5000)]
        public string Containment { get; set; } = string.Empty;

        public string ImageName { get; set; } = string.Empty;

    }
}
