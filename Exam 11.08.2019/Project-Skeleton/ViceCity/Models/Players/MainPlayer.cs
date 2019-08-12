using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        private const string playersName = "Tommy Vercetti";
        private const int InitialLifePoints = 100;

        public MainPlayer() 
            : base(playersName, InitialLifePoints)
        {
        }
    }
}
