namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string NullOrEmtpyPlayerName = "Player's username cannot be null or an empty string.";

        public const string NullOrEmtpyCardName = "Card's name cannot be null or an empty string.";

        public const string HealthLessThanZero = "Player's health bonus cannot be less than zero.";

        public const string HealthPointsLessThanZero = "Card's HP cannot be less than zero.";

        public const string CardsDamagePointsLessThanZero = "Card's damage points cannot be less than zero.";

        public const string DamagePointsLessThanZero = "Damage points cannot be less than zero.";

        public const string DeadPlayer = "Player is dead!";

        public const string NullPlayer = "Player cannot be null";

        public const string NullCard = "Card cannot be null!";

        public const string ExistPlayer = "Player {0} already exists!";

        public const string ExistCard = "Card {0} already exists!";
    }
}
