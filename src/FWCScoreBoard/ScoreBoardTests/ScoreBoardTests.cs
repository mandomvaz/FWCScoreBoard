using ScoreBoardNS;

namespace ScoreBoardTests
{
    public class ScoreBoardTests
    {
        private ScoreBoard ScoreBoard { get; set; }

        [SetUp]
        public void Setup()
        {
            ScoreBoard = new ScoreBoard();
        }

        [Test]
        public void CanStartGame()
        {
            ScoreBoard.StartGame("Spain", "Germany");

            Assert.Pass();
        }

        [Test]
        [TestCase("", "Germany")]
        [TestCase("Spain", "")]
        [TestCase("", "")]
        public void StartGameThrowExceptionOnEmptyValues(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentException>(() => ScoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        public void StartGameReturnIntegerId()
        {
            var id = ScoreBoard.StartGame("Spain", "Germany");

            Assert.That(id, Is.TypeOf<int>());
        }

        [Test]
        public void CanFinishGame()
        {
            int gameId = ScoreBoard.StartGame("Spain", "Germany");

            ScoreBoard.FinishGame(gameId);

            Assert.Pass();
        }

        [Test]
        public void CanUpdateGameScore()
        {
            int gameId = ScoreBoard.StartGame("Spain", "Germany");

            ScoreBoard.UpdateScore(gameId, 3, 2);

            Assert.Pass();
        }

        [Test]
        public void UpdateScoreThrowExceptionOnInvalidId()
        {
            Assert.Throws<ArgumentException>(() => ScoreBoard.UpdateScore(1, 1, 1));
        }

        [Test]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1, -1)]
        public void UpdateScoreThrowExceptionOnNegativeScores(int homeTeamScore, int awayTeamScore)
        {
            int gameId = ScoreBoard.StartGame("Spain", "Germany");
            Assert.Throws<ArgumentOutOfRangeException>(() => ScoreBoard.UpdateScore(gameId, homeTeamScore, awayTeamScore));
        }

        [Test]
        public void CanGetSummary()
        {
            ScoreBoard.GetSummary();

            Assert.Pass();
        }

        [Test]
        public void GetSummaryReturnGameInformation()
        {
            SetExampleData();

            string summary = ScoreBoard.GetSummary();

            Assert.That(summary, Contains.Substring("Mexico 0 - Canada 5"));
            Assert.That(summary, Contains.Substring("Spain 10 - Brazil 2"));
            Assert.That(summary, Contains.Substring("Germany 2 - France 2"));
            Assert.That(summary, Contains.Substring("Uruguay 6 - Italy 6"));
            Assert.That(summary, Contains.Substring("Argentina 3 - Australia 1"));
        }

        [Test]
        public void GetSummaryReturnGameInformationOrderByTotalScoreAndRecently()
        {
            SetExampleData();

            string summary = ScoreBoard.GetSummary();

            string expectedSummary = "";

            expectedSummary += "Uruguay 6 - Italy 6\r\n";
            expectedSummary += "Spain 10 - Brazil 2\r\n";
            expectedSummary += "Mexico 0 - Canada 5\r\n";
            expectedSummary += "Argentina 3 - Australia 1\r\n";
            expectedSummary += "Germany 2 - France 2\r\n";

            Assert.That(summary, Is.EqualTo(expectedSummary));
        }

        private void SetExampleData()
        {
            int gameId = ScoreBoard.StartGame("Mexico", "Canada");
            ScoreBoard.UpdateScore(gameId, 0, 5);

            gameId = ScoreBoard.StartGame("Spain", "Brazil");
            ScoreBoard.UpdateScore(gameId, 10, 2);

            gameId = ScoreBoard.StartGame("Germany", "France");
            ScoreBoard.UpdateScore(gameId, 2, 2);

            gameId = ScoreBoard.StartGame("Uruguay", "Italy");
            ScoreBoard.UpdateScore(gameId, 6, 6);

            gameId = ScoreBoard.StartGame("Argentina", "Australia");
            ScoreBoard.UpdateScore(gameId, 3, 1);
        }
    }
}