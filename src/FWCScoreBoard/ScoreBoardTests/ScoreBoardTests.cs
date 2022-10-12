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
            Assert.Throws<ArgumentException>(()=> ScoreBoard.UpdateScore(1, 1, 1));
        }

        [Test]
        public void UpdateScoreThrowExceptionOnNegativeScores()
        {
            int gameId = ScoreBoard.StartGame("Spain", "Germany");
            Assert.Throws<ArgumentOutOfRangeException>(() => ScoreBoard.UpdateScore(gameId, -1, 1));
        }
    }
}