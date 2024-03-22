using System.ComponentModel.DataAnnotations;

namespace TrueCodeProj.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Domain { get; set; }

        public List<TagToUser> TagToUsers { get; set; }
    }

}
