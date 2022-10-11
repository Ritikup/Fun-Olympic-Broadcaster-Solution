using System.ComponentModel.DataAnnotations;

namespace Fun_Olympic_Broadcaster.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public string Heading { get; set; }

        public string NewsDescription { get; set; }

        public DateTime PublishedDate { get; set; }
        public string? NewsImg { get; set; }
    }
}
