using System.ComponentModel.DataAnnotations;

namespace UmbracoProject.Models
{
    public class BranchModel
    {
        [Required]
        public int BranchId { get; set; }
        [Required]
        [MaxLength(250)]
        public string ? BranchName { get; set; }
    }
}
