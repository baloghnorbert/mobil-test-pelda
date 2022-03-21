using Solution.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.Requests
{
    public class PlayerRequest
    {
        [Required(ErrorMessage = "A nevet  kötelező megadni.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Url]
        [StringLength(2048)]
        public string ImageLink { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Club { get; set; }

        [Required]
        [StringLength(255)]
        public string Birthday { get; set; }

        [Required]
        [Range(0, 100)]
        public int Weight { get; set; }

        [Required]
        [Range(1.5, 2.5)]
        public double Height { get; set; }

        [Required]
        [StringLength(4096)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public PlayerRequest()
        {
        }

        public PlayerRequest(string name, string imageLink, string club, string birthday, int weight, double height, string description)
        {
            Name = name;
            ImageLink = imageLink;
            Club = club;
            Birthday = birthday;
            Weight = weight;
            Height = height;
            Description = description;
        }
    }
}
