using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleImageUpload.Models
{
    public class ImageGallery
    {
        public int Id { get; set; }
        public string  ImageName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
