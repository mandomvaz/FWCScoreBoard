namespace ScoreBoardNS
{
    public class ScoreBoard
    {
        private List<string> Games { get; set; }

        public ScoreBoard()
        {
            Games = new List<string>();
        }

        public void StartGame(string homeTeam, string awayTeam)
        {
            Games.Add($"{homeTeam} 0 - {awayTeam} 0");
        }
    }
}