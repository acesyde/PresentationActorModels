using Game.GrainInterfaces;
using Orleans;
using System;
using System.Threading.Tasks;

namespace Game.Grains
{
    public class PlayerGrain : Grain, IPlayerGrain
    {
        private IGameGrain currentGame;

        // Game the player is currently in. May be null.
        public Task<IGameGrain> GetCurrentGame()
        {
            return Task.FromResult(currentGame);
        }

        public Task JoinGame(IGameGrain game)
        {
            currentGame = game;
            Console.WriteLine(
                "Player {0} joined game {1}",
                this.GetPrimaryKey(),
                game.GetPrimaryKey());

            return Task.CompletedTask;
        }

        public Task LeaveGame(IGameGrain game)
        {
            currentGame = null;
            Console.WriteLine(
                "Player {0} left game {1}",
                this.GetPrimaryKey(),
                game.GetPrimaryKey());

            return Task.CompletedTask;
        }
    }
}
