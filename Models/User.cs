using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleImageUpload.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string coverImage { get; set; }
        [NotMapped]
        public IFormFile coverFile{get;set;}
        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }

        public virtual ICollection<ImageGallery> ImageGalleries { get; set; } = new HashSet<ImageGallery>();

    }
}
