namespace FootballTeamGenerator.Exeption
{
    public static class ExeptionMessages
    {
        public static string InvalidStatExeption = "{0} should be between {1} and {2}.";

        public static string EmptyNameExeption = "A name should not be empty.";

        public static string MissingPlayerExeption = "Player {0} is not in {1} team.";

        public static string MissingTeamExeption = "Team {0} does not exist.";
    }
}
