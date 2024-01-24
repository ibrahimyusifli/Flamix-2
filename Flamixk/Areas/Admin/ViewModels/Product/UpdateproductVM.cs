using System.ComponentModel.DataAnnotations;

namespace Flamixk.Areas.Admin.ViewModels
{
    public class UpdateproductVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
