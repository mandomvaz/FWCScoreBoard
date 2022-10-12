namespace ScoreBoardNS
{
    public class ScoreBoard
    {
        private Dictionary<int, string> Games { get; set; }
        private int CurrentId { get; set; }

        public ScoreBoard()
        {
            Games = new Dictionary<int, string>();
            CurrentId = 0;
        }

        public int StartGame(string homeTeam, string awayTeam)
        {
            if(String.IsNullOrWhiteSpace(homeTeam) || String.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException();
            }

            CurrentId += 1;

            Games.Add(CurrentId, $"{homeTeam} 0 - {awayTeam} 0");

            return CurrentId;
        }
    }
}