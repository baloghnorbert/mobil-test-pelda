using Solution.Core.Interfaces.IEntities;
using Solution.Core.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace Solution.Core.Models.Entities
{
    public class Player : PlayerRequest, IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public Player()
        {
        }

        public Player(int id, string name, string imageLink, string club, string birthday, int weight, double height, string description, int positionId)
        {
            Id = id;
            Name = name;
            ImageLink = imageLink;
            Club = club;
            Birthday = birthday;
            Weight = weight;
            Height = height;
            Description = description;
            PositionId = positionId;
        }

        public Player( PlayerRequest player)
        {
            Name = player.Name;
            ImageLink = player.ImageLink;
            Club = player.Club;
            Birthday = player.Birthday;
            Weight = player.Weight;
            Height = player.Height;
            Description = player.Description;
            PositionId = player.PositionId;
        }
    }
}
