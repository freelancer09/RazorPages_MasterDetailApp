namespace PDMasterDetail.Models
{
    public class SCP
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ObjectClass { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Containment { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;

    }
}
