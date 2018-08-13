using System;

namespace Game.Api.Data.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
