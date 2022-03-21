using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.Entities
{
    [Table("Position")]
    public class Position
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Position()
        {
        }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
