namespace ScoreBoardNS
{
    internal class Game
    {
        internal string HomeTeamName { get; set; }
        internal string AwayTeamName { get; set; }
        internal int HomeTeamScore { get; set; }
        internal int AwayTeamScore { get; set; }

        internal Game() { }
        internal Game(string homeTeamName, string awayTeamName)
        {
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            
            HomeTeamScore = 0;
            AwayTeamScore = 0;
        }

        internal string ToSummaryString()
        {
            return $"{HomeTeamName} {HomeTeamScore} - {AwayTeamName} {AwayTeamScore}";
        }
    }
}
