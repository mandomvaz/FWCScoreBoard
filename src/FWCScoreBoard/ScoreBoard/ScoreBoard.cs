namespace ScoreBoardNS
{
    public class ScoreBoard
    {
        private Dictionary<int, Game> Games { get; set; }
        private int CurrentId { get; set; }

        public ScoreBoard()
        {
            Games = new Dictionary<int, Game>();
            CurrentId = 0;
        }

        public int StartGame(string homeTeam, string awayTeam)
        {
            if(String.IsNullOrWhiteSpace(homeTeam) || String.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException();
            }

            CurrentId += 1;

            Games.Add(CurrentId, new Game(homeTeam, awayTeam));

            return CurrentId;
        }

        public void FinishGame(int gameId)
        {
            Games.Remove(gameId);
        }

        public void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore)
        {
            Game gameToUpdate;

            if(!Games.TryGetValue(gameId, out gameToUpdate)){
                throw new ArgumentException();
            }

            gameToUpdate.HomeTeamScore = homeTeamScore;
            gameToUpdate.AwayTeamScore = awayTeamScore;
        }
    }
}