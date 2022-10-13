using System.Text;

namespace ScoreBoardNS
{
    public class ScoreBoard
    {
        private Dictionary<int, Game> GamesCollection { get; set; }
        private int CurrentId { get; set; }

        public ScoreBoard()
        {
            GamesCollection = new Dictionary<int, Game>();
            CurrentId = 0;
        }

        public int StartGame(string homeTeam, string awayTeam)
        {
            if(String.IsNullOrWhiteSpace(homeTeam) || String.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException();
            }

            CurrentId += 1;

            GamesCollection.Add(CurrentId, new Game(homeTeam, awayTeam));

            return CurrentId;
        }

        public void FinishGame(int gameId)
        {
            GamesCollection.Remove(gameId);
        }

        public void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore)
        {
            Game gameToUpdate;

            if(!GamesCollection.TryGetValue(gameId, out gameToUpdate)){
                throw new ArgumentException();
            }

            if(homeTeamScore < 0 || awayTeamScore < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            gameToUpdate.HomeTeamScore = homeTeamScore;
            gameToUpdate.AwayTeamScore = awayTeamScore;
        }

        public string GetSummary()
        {
            StringBuilder summaryBuilder = new StringBuilder();

            GamesCollection.ToList()
                .OrderByDescending(element => element.Value.HomeTeamScore + element.Value.AwayTeamScore)
                .ThenByDescending(element => element.Key)
                .ToList()
                .ForEach(element => summaryBuilder.AppendLine(element.Value.ToSummaryString()));

            return summaryBuilder.ToString();
        }
    }
}