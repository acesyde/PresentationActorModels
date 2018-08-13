using Game.GrainInterfaces.Player;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;

namespace Game.GrainInterfaces.Game
{
    [Immutable]
    public class GameInfo
    {
        public Guid Key { get; set; }
        public List<IPlayerGrain> Players { get; set; }
    }
}
