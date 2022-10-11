using System.ComponentModel.DataAnnotations;

namespace Fun_Olympic_Broadcaster.Models
{
    public class LiveVideo
    {

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string? rivals { get; set; }
        public string videolink { get; set; }
    }
}
